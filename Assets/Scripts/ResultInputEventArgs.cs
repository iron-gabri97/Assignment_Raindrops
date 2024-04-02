using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultInputEventArgs : EventArgs
{
    //DATA
    private int inputValue = 0;
    public int InputValue { get { return inputValue; } }

    public ResultInputEventArgs (int inputValue)
    {
        this.inputValue = inputValue;
    }
}
