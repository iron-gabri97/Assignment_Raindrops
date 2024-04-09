using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Difficulty Setting", menuName = "Difficulty Setting")]
public class DifficultySettingsSO : ScriptableObject
{
    //DATA
    [SerializeField] Helper_GameSettings.GameSettings.DIFFICULTYGAME difficultyValue = Helper_GameSettings.GameSettings.DIFFICULTYGAME.Easy;

    [SerializeField] float speedCoefficient = 1.0f;
    [SerializeField] float scoreCoefficient = 1.0f;

    public Helper_GameSettings.GameSettings.DIFFICULTYGAME DifficultyValue { get { return difficultyValue; } }
    public float SpeedCoefficient { get { return speedCoefficient; } }
    public float ScoreCoefficient { get { return scoreCoefficient; } }
}
