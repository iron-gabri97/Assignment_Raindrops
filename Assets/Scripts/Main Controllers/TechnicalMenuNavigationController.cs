using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TechnicalMenuNavigationController : MonoBehaviour
{
    //ENUMS
    public enum eTechnicalMenuCanvas
    {
        MainMenu,
        Options,
        Quit
    }

    //DATA
    [SerializeField] private Canvas MainMenuCanvas;
    [SerializeField] private Canvas OptionsCanvas;

    private List<Canvas> allCanvas = new();

    //LAST TARGET CANVAS
    private eTechnicalMenuCanvas lastTargetCanvas = 0;

    //METHODS
    // Start is called before the first frame update
    void Start()
    {
        InitializeGUI();
    }

    //FUNCTIONALITIES

    ///GUI INITIALIZATION
    private void InitializeGUI()
    {
        BuildAllCanvas();
        SetTargetCanvas(lastTargetCanvas);
    }

    private void BuildAllCanvas()
    {
        allCanvas = new List<Canvas> {
            MainMenuCanvas,
            OptionsCanvas
        };
    }

    private void DisableAllCanvas()
    {
        foreach (Canvas c in allCanvas) c.gameObject.SetActive(false);
    }


    //HANDLING SPECIFIC CANVAS
    public void SetTargetCanvas(eTechnicalMenuCanvas targetCanvas)
    {
        //EXIT GAME
        if (targetCanvas == eTechnicalMenuCanvas.Quit) ExitGame();
        else DisableAllCanvas();

        //SWITCH
        switch (targetCanvas)
        {
            case eTechnicalMenuCanvas.MainMenu:
                //MAIN MENU
                MainMenuCanvas.gameObject.SetActive(true);
                break;
            case eTechnicalMenuCanvas.Options:
                //OPTIONS
                OptionsCanvas.gameObject.SetActive(true);
                break;
            default:
                //DEFAULT -> MAIN MENU
                MainMenuCanvas.gameObject.SetActive(true);
                break;
        }

        lastTargetCanvas = targetCanvas;
    }

    //UTILITES

    ///CHECKS IF THIS IS THE ACTIVE CANVAS
    public bool isActiveCanvas(eTechnicalMenuCanvas canvasChecked) => canvasChecked == lastTargetCanvas;


    ///EXIT GAME
    private static void ExitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        if (UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
#endif
    }
}
