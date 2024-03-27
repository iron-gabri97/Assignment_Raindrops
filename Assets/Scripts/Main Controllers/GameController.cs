using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoSingleton<GameController>
{
    //ENUMS
    public enum EGameState
    {
        Start,
        Playing,
        Paused,
        GameOver,
        Quitting,
        Exiting
    }

    //DATA
    ///SIMPLE DATA
    private EGameState state = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
