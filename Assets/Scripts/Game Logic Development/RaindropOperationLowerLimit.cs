using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaindropOperationLowerLimit : MonoBehaviour
{
    //EVENTS
    public static event EventHandler<RaindropEventArgs> RaindropLost;

    //FUNCTIONALITIES
    private void OnTriggerEnter2D(Collider2D collision)
    {
        RaindropOperation raindrop = collision.gameObject?.GetComponent<RaindropOperation>();
        if (raindrop != null)
        {
            Debug.Log("Collision");

            RaindropEventArgs raindropLostEvent = new RaindropEventArgs(raindrop);
            OnRaindropLost(raindropLostEvent);
        }
    }

    //GIZMOS DRAWING FOR DEBUG REASONS
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }

    //EVENT ACTIVATION METHOD
    private void OnRaindropLost(RaindropEventArgs eventArg) => RaindropLost?.Invoke(this, eventArg);
}
