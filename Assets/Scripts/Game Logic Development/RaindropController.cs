using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaindropController : MonoSingleton<RaindropController>
{
    //DATA

    //PREFABS
    [SerializeField] RaindropOperation raindropOpPrefab;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //EVENTS
    public void ManageRaindropEvent(object sender, RaindropEventArgs ea)
    {
        //LOSS
        if (ea.EventType == RaindropEventArgs.EType.Loss) DestroyRaindrop(ea.LostRaindrop);

        //WIN
        if (ea.EventType == RaindropEventArgs.EType.Win) SolveRaindrop(ea.LostRaindrop);
    }    


    private void DestroyRaindrop(RaindropOperation toDestroy)
    {

    }


    private void SolveRaindrop(RaindropOperation solvedRaindrop)
    {

    }

}
