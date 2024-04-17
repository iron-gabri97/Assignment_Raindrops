using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MainMenu : MonoBehaviour
{
    //GAMEOBJECT 
    [SerializeField] Canvas mainMenuPanel;


    private void Awake()
    {
        UI_RaindropsMainMenu.MainMenu += ManageMainMenuEvent;
    }

    private void OnDestroy()
    {
        UI_RaindropsMainMenu.MainMenu -= ManageMainMenuEvent;        
    }

    //FUNCTIONALITIES
    public void ManagePlay()
    {
        SceneNavigationController.Instance.LoadScene(SceneNavigationController.eSceneName.Raindrops);
    }
    public void ManageOptions()
    {
        UI_RaindropsMainMenu.OpenOptions();
    }
    public void ManageQuit()
    {
        Helper.QuitGame();
    }

    //EVENT
    public void ManageMainMenuEvent(object sender, MainMenuEventArgs e)
    {
        switch(e.EventType)
        {
            case MainMenuEventArgs.EType.MAIN_MENU:
                mainMenuPanel.gameObject.SetActive(true);
                break;
            default:
                mainMenuPanel.gameObject.SetActive(false);
                break;
        }
    }
}
