using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "New Technical Menu", menuName = "Menu Data/Technical")]
public class TechnicalMenuDataSO : ScriptableObject
{
    //ASSOCIATED SCENE
    [SerializeField] private string associatedSceneName;
    public string AssociatedSceneName { get { return associatedSceneName; } }


    //ENUM IDENTIFIER
    [SerializeField] private TechnicalMenuNavigationController.eTechnicalMenuCanvas technicalMenuID;
    public TechnicalMenuNavigationController.eTechnicalMenuCanvas TechnicalMenuID { get { return technicalMenuID; } }

}
