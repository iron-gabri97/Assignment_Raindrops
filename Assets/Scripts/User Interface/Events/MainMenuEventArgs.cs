using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MainMenuEventArgs : EventArgs
{
    //ENUMS
    public enum EType
    {
        MAIN_MENU,
        MAIN_OPTIONS
    }

    //DATA
    private EType eventType;
    public EType EventType { get { return eventType; } }

    public MainMenuEventArgs (EType eventType = EType.MAIN_MENU)
    {
        this.eventType = eventType;
    }
}
