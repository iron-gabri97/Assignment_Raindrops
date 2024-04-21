using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UI_Difficulty : MonoBehaviour
{
    //GAMEOBJECT
    [SerializeField] Canvas optionsMenuPanel;

    [SerializeField] TMP_Dropdown difficultyDropDown;


    void Awake()
    {
        UI_RaindropsMainMenu.MainMenu += ManageEventMainMenu;
    }

    void OnDestroy()
    {
        UI_RaindropsMainMenu.MainMenu -= ManageEventMainMenu;
    }

    private void UpdateVisualisation()
    {
        difficultyDropDown.value = Helper_GameSettings.GameSettings.GetGameSpeed();
    }

    public void ManageDifficultyChange(int newValue) => Helper_GameSettings.GameSettings.SetGameSpeed((Helper_GameSettings.GameSettings.DIFFICULTYGAME) newValue);

    public void OpenMainMenu()
    {
        UI_RaindropsMainMenu.OpenMainMenu();
    }

    public void ManageEventMainMenu(object sender, MainMenuEventArgs e)
    {
        switch(e.EventType)
        {
            case MainMenuEventArgs.EType.MAIN_OPTIONS:
                optionsMenuPanel.gameObject.SetActive(true);
                UpdateVisualisation();
                break;
            default:
                optionsMenuPanel.gameObject.SetActive(false);
                break;
        }
    }
}
