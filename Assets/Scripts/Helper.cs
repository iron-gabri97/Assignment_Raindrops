using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper
{
    public static void QuitGame()
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
