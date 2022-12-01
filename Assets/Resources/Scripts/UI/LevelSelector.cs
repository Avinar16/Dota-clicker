using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [SerializeField]
    private Button button;


    public void OpenScene()
    {
        SceneManager.LoadScene("LineCreepsScene");
        
    }
}
