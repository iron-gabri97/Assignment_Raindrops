using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "New Stage Data", menuName = "Scene Data/Stage")]
public class StageDataSO : ScriptableObject
{
    //ASSOCIATED SCENE
    [SerializeField] private string associatedSceneName;
    public string AssociatedSceneName { get { return associatedSceneName; } }

    //ENUM IDENTIFIER
    [SerializeField] private SceneNavigationController.eSceneName stageID;
    public SceneNavigationController.eSceneName StageID { get { return stageID; } }
}
