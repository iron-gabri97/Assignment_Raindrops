using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class RaindropOperation : MonoBehaviour
{
    //EVENTS
    public static event EventHandler<RaindropEventArgs> RaindropSolved;

    //DATA
    [SerializeField] float raindropSpeed = 1.0f;
    float speedDiffCoeff = 1.0f;

    //PREFAB
    [SerializeField] private TMP_Text textFirstNumber;
    [SerializeField] private TMP_Text textSecondNumber;
    [SerializeField] private TMP_Text textOperation;


    //CLASS
    private RaindropOperationData raindropOperationData;
    public RaindropOperationData RaindropOperationData {  get { return raindropOperationData; } }

    //METHODS

    // Start is called before the first frame update
    void Start()
    {
        //EVENTS
        UI_RaindropsGame.ResultInput += CheckResultInput;
        UI_RaindropsGame.MenuGame += ManageMenuGameEvent;

        //SETTING DATA
        RaindropOperationData.EOperation randomOP = RaindropOperationData.GetRandomOp();

        raindropOperationData = new RaindropOperationData(RaindropOperationData.GetRandomFirstValue(randomOP), RaindropOperationData.GetRandomFirstValue(randomOP), randomOP);

        //DIFFICULTY
        speedDiffCoeff = RaindropController.Instance.SpeedDifficultyValue;

        SetVisibleContent();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GameController.Instance.isPlaying)
        {
            ManageMovement();
        }
    }

    private void OnDestroy()
    {
        UI_RaindropsGame.ResultInput -= CheckResultInput;
        UI_RaindropsGame.MenuGame -= ManageMenuGameEvent;
    }

    public void CheckResultInput(object sender, ResultInputEventArgs rs)
    {
        //SOLUTION EVENT IF RESULT CORRECT
        if (rs.InputValue == this.raindropOperationData.Result)
        {
            RaindropEventArgs raindropLostEvent = new(this, RaindropEventArgs.EType.Win);
            OnRaindropSolved(raindropLostEvent);
        }
    }

    private void ManageMenuGameEvent(object sender, MenuGameEventArgs e)
    {
        if(e.EventType == MenuGameEventArgs.EType.MENU_PAUSE_OPEN)
            SetVisibleContent(false);
        else
            SetVisibleContent();

    }

    //FUNCTIONALITIES

    private void SetVisibleContent(bool visible = true)
    {
        if (visible)
        {
            textFirstNumber.text = raindropOperationData.FirstNumber.ToString();
            textOperation.text = RaindropOperationData.dictionaryOP[raindropOperationData.Operation];
            textSecondNumber.text = raindropOperationData.SecondNumber.ToString();  
        }
        else
        {
            textFirstNumber.text = ">:(";
            textOperation.text = "?";
            textSecondNumber.text = ">:(";
        }
    }

    private void ManageMovement()
    {
        Vector3 translation;
        translation = speedDiffCoeff * raindropSpeed * Time.fixedDeltaTime * Vector3.down;
        
        transform.position += translation;
    }

    //EVENT ACTIVATION METHOD
    private void OnRaindropSolved(RaindropEventArgs eventArg) => RaindropSolved?.Invoke(this, eventArg);
}
