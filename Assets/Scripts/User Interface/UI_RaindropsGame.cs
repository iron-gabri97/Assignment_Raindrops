using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UI_RaindropsGame : MonoSingleton<UI_RaindropsGame>
{
    //EVENTS
    public static event EventHandler<MenuGameEventArgs> MenuGame;
    public static event EventHandler<ResultInputEventArgs> ResultInput;

    //DATA
    private RaindropsAction inputPlayer = null;
    public RaindropsAction InputPlayer { get { return inputPlayer; } }


    //PREFAB
    [SerializeField] private Image scorePanelImage;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text textScore;
    [SerializeField] private TMP_Text textLives;

    // Start is called before the first frame update
    void Start()
    {
        inputField.text = "0";
        inputField.Select();
        inputField.ActivateInputField();
    }

    private void OnEnable()
    {
        inputPlayer = new RaindropsAction();
        inputPlayer.Enable();

        //ENTER
        inputPlayer.BaseAction.EnterAction.performed += OnEnterPressed;
        //ESCAPE
        inputPlayer.BaseAction.EscapeAction.performed += OnEscapePressed;

        
    }

    private void OnDisable()
    {
        //ENTER
        inputPlayer.BaseAction.EnterAction.performed -= OnEnterPressed;
        //ESCAPE
        inputPlayer.BaseAction.EscapeAction.performed -= OnEscapePressed;

        inputPlayer.Disable();
    }

    //FUNCTIONALITIES
    private void TransmittingResult()
    {
        int.TryParse(inputField.text, out int testInt);

        ResultInputEventArgs myResultIE = new(testInt);
        OnRaindropLost(myResultIE);

        //RESET TEXT FIELD
        inputField.text = "0";

        //FOCUS INPUT FIELD
        inputField.Select();
        inputField.ActivateInputField();
    }

    //INPUT EVENTS
    private void OnEnterPressed(InputAction.CallbackContext value)
    {
        if(GameController.Instance.isPlaying) 
            TransmittingResult();
    }

    private void OnEscapePressed(InputAction.CallbackContext value)
    {
        if(GameController.Instance.isPlaying)
            GameController.Instance.SetState(GameController.EGameState.Paused);
        else if(GameController.Instance.isGameOver)
            GameController.Instance.SetState(GameController.EGameState.Playing);
    }

    //UI - BUTTON
    public void ManageInputButton ()
    {
        TransmittingResult();
    }

    //UTILITIES
    public void SetScore(float newScore) => textScore.text = newScore.ToString();
    public void SetLives(int newLives) => textLives.text = newLives.ToString();



    //EVENT ACTIVATION METHOD
    private void OnRaindropLost(ResultInputEventArgs rsEventArg) => ResultInput.Invoke(this, rsEventArg);

    public static void OnGamePause(object sender, MenuGameEventArgs rsEventArg) => MenuGame?.Invoke(sender, rsEventArg);

}
