using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaindropEventArgs : EventArgs
{
    //ENUMS
    public enum EType
    {
        Loss,
        Win
    }

    //DATA
    private RaindropOperation lostRaindrop;
    public RaindropOperation LostRaindrop { get { return lostRaindrop; } }

    private EType eventType = EType.Loss;
    public EType EventType { get { return eventType; } }


    public RaindropEventArgs (RaindropOperation raindrop, EType eventType = EType.Loss)
    {
        this.lostRaindrop = raindrop;
        this.eventType = eventType;
    }

}
