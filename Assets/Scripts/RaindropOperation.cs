using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class RaindropOperation : MonoBehaviour
{
    //DATA
    [SerializeField] float raindropSpeed = 1.0f;
    private RaindropOperationData raindropOperationData;

    //PREFAB
    [SerializeField] private TMP_Text textFirstNumber;
    [SerializeField] private TMP_Text textSecondNumber;
    [SerializeField] private TMP_Text textOperation;

    //METHODS

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckResultInput(object sender, ResultInputEventArgs rs)
    {
        //SOLUTION EVENT IF RESULT CORRECT
        if (rs.InputValue == this.raindropOperationData.Result)
        {
            RaindropEventArgs raindropLostEvent = new(this, RaindropEventArgs.EType.Win);
            
        }
    }

    //FUNCTIONALITIES
    private void SetContent()
    {
        textFirstNumber.text = raindropOperationData.FirstNumber.ToString();
        textSecondNumber.text = raindropOperationData.SecondNumber.ToString();
        textOperation.text = RaindropOperationData.dictionaryOP[raindropOperationData.Operation];
    }

}
