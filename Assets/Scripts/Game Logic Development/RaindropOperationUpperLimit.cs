using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaindropOperationUpperLimit : MonoSingleton<RaindropOperationUpperLimit>
{
    //DATA
    [SerializeField] Vector3 startEnd = new Vector3(-8, 6, 0);
    [SerializeField] Vector3 extremeEnd = new Vector3(8, 6, 0);

    //UTILITIES
    public Vector3 GetRandomPosition()
    {
        float myRandom = UnityEngine.Random.Range(0.0f, 1.0f);
        return Vector3.Lerp(startEnd, extremeEnd, myRandom);
    }


    //GIZMOS DRAWING
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(startEnd, extremeEnd);
    }
}
