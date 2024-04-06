using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class UI_RaindropsMainMenu : MonoSingleton<UI_RaindropsMainMenu>
{
    //EVENTS
    public static event EventHandler<MainMenuEventArgs> MainMenu;

    //DATA
    private RaindropsAction inputPlayer = null;
    public RaindropsAction InputPlayer { get { return inputPlayer; } }


    // Start is called before the first frame update
    void Start()
    {
        OnMainMenu(this, new());
    }

    private void OnEnable()
    {
        inputPlayer = new RaindropsAction();
        inputPlayer.Enable();

        //ESCAPE
        inputPlayer.BaseAction.EscapeAction.performed += OnEscapePressed;
    }

    //INPUT EVENTS
    private void OnEscapePressed(InputAction.CallbackContext value)
    {
        MainMenu?.Invoke(this, new());
    }

    //FUNCTIONALITIES
    public static void OpenMainMenu()
    {
        MainMenu?.Invoke(Instance, new(MainMenuEventArgs.EType.MAIN_MENU));
    }

    //EVENT ACTIVATION METHOD
    public static void OnMainMenu(object sender, MainMenuEventArgs eventArg)
    {
        MainMenu?.Invoke(sender, eventArg);
    }
}
