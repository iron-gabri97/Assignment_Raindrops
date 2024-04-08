using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helper_GameSettings
{
    //DATA
    public readonly static string defaultGameStatsName = "GameStats";
    public readonly static string gameSpeed = "GameSpeed";
    public static class GameSettings
    {
        //ENUMS
        public enum DIFFICULTYGAME
        {
            Easy = 0,
            Normal = 1,
            Hard = 2
        }

        //FUNCTIONALITIES
        public static void SetGameSpeed(DIFFICULTYGAME value)
        {
            PlayerPrefs.SetInt(gameSpeed, (int) value);
        }

        public static int GetGameSpeed() => PlayerPrefs.HasKey(gameSpeed) ? PlayerPrefs.GetInt(gameSpeed) : (int) DIFFICULTYGAME.Easy;
    }
}
