using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MainMenu : MonoBehaviour
{
    //GAMEOBJECT 
    [SerializeField] Canvas mainMenuPanel;


    private void Awake()
    {
        
    }

    private void OnDestroy()
    {
        
    }

    //FUNCTIONALITIES
    public void ManagePlay()
    {
        SceneNavigationController.Instance.LoadScene(SceneNavigationController.eSceneName.Raindrops);
    }
}
