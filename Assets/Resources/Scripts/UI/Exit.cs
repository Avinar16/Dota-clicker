using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public GameObject exitInMenu;

    void Update()
    {
        SetActiveQuitPanel();
    }

    private void SetActiveQuitPanel()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exitInMenu.SetActive(true);
        }
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
