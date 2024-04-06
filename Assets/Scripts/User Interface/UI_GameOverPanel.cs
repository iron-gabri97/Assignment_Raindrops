using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GameOverPanel : MonoBehaviour
{
    //GAMEOBJECT
    [SerializeField] CanvasRenderer gameOverCanvas;


    // Start is called before the first frame update
    void Start()
    {
        gameOverCanvas.gameObject.SetActive(false);

        UI_RaindropsGame.MenuGame += ManageMenuGameEvent;
    }

    private void OnDestroy()
    {
        UI_RaindropsGame.MenuGame -= ManageMenuGameEvent;
    }

    //FUNCTIONALITIES
    public void ManageRestart()
    {
        GameController.Instance.SetState(GameController.EGameState.Restarting);
    }
    public void ManageMainMenu()
    {
        GameController.Instance.SetState(GameController.EGameState.Quitting);
    }
    public void ManageQuit()
    {
        GameController.Instance.SetState(GameController.EGameState.Exiting);
    }

    //EVENTS
    public void ManageMenuGameEvent(object sender, MenuGameEventArgs e)
    {
        switch(e.EventType)
        {
            case MenuGameEventArgs.EType.MENU_PAUSE_OPEN:
            case MenuGameEventArgs.EType.MENU_PAUSE_CLOSE:
                break;
            case MenuGameEventArgs.EType.GAME_OVER:
                gameOverCanvas.gameObject.SetActive(true);
                break;
        }
    }
}
