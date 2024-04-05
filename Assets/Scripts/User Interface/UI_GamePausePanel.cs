using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class UI_GamePausePanel : MonoBehaviour
{

    //GAMEOBJECT
    [SerializeField] CanvasRenderer buttonPanel;

    // Start is called before the first frame update
    void Start()
    {
        buttonPanel.gameObject.SetActive(false);

        UI_RaindropsGame.MenuGame += ManageMenuGameEvent;
    }

    private void OnDestroy()
    {
        UI_RaindropsGame.MenuGame -= ManageMenuGameEvent;
    }

    //FUNCTIONALITIES
    public void ManageContinue()
    {
        GameController.Instance.SetState(GameController.EGameState.Playing);
    }
    public void ManageMainMenu()
    {
        GameController.Instance.SetState(GameController.EGameState.Quitting);
    }
    public void ManageRestart()
    {
        GameController.Instance.SetState(GameController.EGameState.Restarting);
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
                buttonPanel.gameObject.SetActive(true);
                break;
            case MenuGameEventArgs.EType.MENU_PAUSE_CLOSE:
            case MenuGameEventArgs.EType.GAME_OVER:
                buttonPanel.gameObject.SetActive(false);
                break;
        }
    }
}
