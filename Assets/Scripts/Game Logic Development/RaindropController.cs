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

    //PREFABS
    [SerializeField] RaindropOperation raindropOpPrefab;


    //STATS
    int concurrentItems;
    float spawnIterationCooldown;
    float score;
    int lives;

    //DATA METHODS
    public bool IsMaxConcurrentItems { get { return maxConcurrentItems <= concurrentItems; } }
    public bool IsGameOverCondition { get { return lives <= 0; } }


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
        UI_RaindropsGame.Instance.SetScore(score);

        //DESTROY
        Destroy(solvedRaindrop.gameObject);
        concurrentItems--;
    }

}
