using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.Diagnostics;

public class RaindropController : MonoSingleton<RaindropController>
{
    //DATA

    //SETTINGS
    [SerializeField] int maxConcurrentItems = 3;
    [SerializeField] int maxItemsPerSpawnIteration = 1;
    [SerializeField] float maxSpawnIterationCooldown = 1.0f;
    [SerializeField] int maxLives = 3;


    //STATS
    int concurrentItems;
    float spawnIterationCooldown;
    float score;
    int lives;

    //DATA METHODS
    public bool IsMaxConcurrentItems { get { return maxConcurrentItems <= concurrentItems; } }
    public bool IsGameOverCondition { get { return lives <= 0; } }

    //DIFFICULTY
    int difficultyGameValue;
    [SerializeField] List<DifficultySettingsSO> difficultySettings = new();

    //SCRIPTABLEOBJECTS
    Dictionary<int, float> speedCoefficientConfiguration = new();
    public float SpeedDifficultyValue { get { return speedCoefficientConfiguration[difficultyGameValue]; } }

    Dictionary<int, float> scoreCoefficientConfiguration = new();
    public float ScoreDifficultyValue { get { return scoreCoefficientConfiguration[difficultyGameValue]; } }

    //PREFABS
    [SerializeField] RaindropOperation raindropOpPrefab;


    // Start is called before the first frame update
    void Start()
    {
        RaindropOperationLowerLimit.RaindropLost += ManageRaindropEvent;
        RaindropOperation.RaindropSolved += ManageRaindropEvent;

        List<RaindropOperation> initialRaindrops = FindObjectsOfType<RaindropOperation>().ToList();
        concurrentItems = initialRaindrops.Count;

        lives = maxLives;
        UI_RaindropsGame.Instance.SetScore(score);
        UI_RaindropsGame.Instance.SetLives(lives);

        difficultyGameValue = Helper_GameSettings.GameSettings.GetGameSpeed();
        InitializeDifficultyConfiguration();


    }

    // Update is called once per frame
    void Update()
    {
        if (spawnIterationCooldown > 0)
        {
            spawnIterationCooldown -= Time.deltaTime;
            spawnIterationCooldown = Math.Clamp(spawnIterationCooldown, 0, maxSpawnIterationCooldown);
        }
        else
        {
            int spawnedItemsIteration = 0;
            while (spawnedItemsIteration < maxItemsPerSpawnIteration && !IsMaxConcurrentItems)
            {
                SpawnRaindrop();
                spawnedItemsIteration++;
            }
        }
    }

    private void OnDestroy()
    {
        RaindropOperationLowerLimit.RaindropLost -= ManageRaindropEvent;
        RaindropOperation.RaindropSolved -= ManageRaindropEvent;
    }

    //EVENTS
    public void ManageRaindropEvent(object sender, RaindropEventArgs ea)
    {
        //LOSS
        if (ea.EventType == RaindropEventArgs.EType.Loss) DestroyRaindrop(ea.LostRaindrop);

        //WIN
        if (ea.EventType == RaindropEventArgs.EType.Win) SolveRaindrop(ea.LostRaindrop);
    }

    //FUNCTIONALITIES
    private void SpawnRaindrop()
    {
        Vector3 newPosition = RaindropOperationUpperLimit.Instance.GetRandomPosition();
        Instantiate(raindropOpPrefab, newPosition, Quaternion.identity);
        concurrentItems++;
        spawnIterationCooldown = maxSpawnIterationCooldown;
    }

    private void DestroyRaindrop(RaindropOperation toDestroy)
    {
        Vector3 raindropPosition = toDestroy.transform.position;

        lives--;
        UI_RaindropsGame.Instance.SetLives(lives);

        if (IsGameOverCondition)
            GameController.Instance.SetState(GameController.EGameState.GameOver);

        //DESTROY
        Destroy(toDestroy.gameObject);
        concurrentItems--;
    }


    private void SolveRaindrop(RaindropOperation solvedRaindrop)
    {
        score += ScoreDifficultyValue * solvedRaindrop.RaindropOperationData.GetRaindropScore();
        UI_RaindropsGame.Instance.SetScore(score);

        //DESTROY
        Destroy(solvedRaindrop.gameObject);
        concurrentItems--;
    }

    private void InitializeDifficultyConfiguration()
    {
        if(difficultySettings.Count > 0)
        {
            foreach(DifficultySettingsSO diffsetSO in difficultySettings)
            {
                speedCoefficientConfiguration.Add((int) diffsetSO.DifficultyValue, diffsetSO.SpeedCoefficient);
                scoreCoefficientConfiguration.Add((int) diffsetSO.DifficultyValue, diffsetSO.ScoreCoefficient);
            }
        }
        else
        {
            foreach (int i in Enum.GetValues(typeof(Helper_GameSettings.GameSettings.DIFFICULTYGAME)))
            {
                speedCoefficientConfiguration.Add(i, 1);
                scoreCoefficientConfiguration.Add(i, 1);
            }
 //           Debug.LogError("NO DIFFICULTY SETTINGS");
        }
    }

}
