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
        Restarting,
        Quitting,
        Exiting
    }

    //DATA
    //SIMPLE DATA
    private EGameState state = 0;
    public bool IsPaused { get { return this.state == EGameState.Paused; } }
    public bool isGameOver { get { return this.state == EGameState.GameOver; } }
    public bool isPlaying { get { return !(IsPaused || isGameOver); } }

    //GAMEOBJECT
    [SerializeField] SceneNavigationController sceneNavigationController;



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
            case EGameState.Restarting:
                RestartGame();
                break;
            case EGameState.Quitting:

                break;

            case EGameState.Exiting:

                break;
        }
    }

    //RESTART GAME
    private static void RestartGame() => Instance.sceneNavigationController.LoadScene(SceneNavigationController.eSceneName.Raindrops);

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
