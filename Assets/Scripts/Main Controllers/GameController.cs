using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoSingleton<GameController>
{
    //ENUMS
    public enum EGameState
    {
        Start,
        Playing,
        Paused,
        GameOver,
        Quitting,
        Exiting
    }

    //DATA
    //SIMPLE DATA
    private EGameState state = 0;
    public bool IsPaused { get { return this.state == EGameState.Paused; } }
    public bool isGameOver { get { return this.state == EGameState.GameOver; } }
    public bool isPlaying { get { return !(IsPaused || isGameOver); } }



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("GameController is starting!");

        SetState(EGameState.Start);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //FUNCTIONALITIES
    public void SetState(EGameState targetState)
    {
        state = targetState;
        switch (state) 
        {
            case EGameState.Start:
                //RESERVED FOR INITIALIZATION

                SetState(EGameState.Playing);
                break;

            case EGameState.Playing:

                break;

            case EGameState.Paused:

                break;

            case EGameState.GameOver:

                break;

            case EGameState.Quitting:

                break;

            case EGameState.Exiting:

                break;
        }
    }


    //QUIT GAME (ABANDON SESSION)
    private static void QuitGame()
    {
        //TODO: GO BACK TO MAIN MENU
        //NOW IT QUITS THE GAME
        ExitGame();
    }


    //EXIT GAME
    private static void ExitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        if (UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
#endif
    }
}
