using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MenuGameEventArgs : EventArgs
{
    //ENUMS
    public enum EType
    {
        MENU_PAUSE_OPEN,
        MENU_PAUSE_CLOSE,
        GAME_OVER
    }

    //DATA
    private EType eventType;
    public EType EventType { get { return eventType; } }

    public MenuGameEventArgs (EType eventType = EType.MENU_PAUSE_OPEN)
    {
        this.eventType = eventType;
    }
}
