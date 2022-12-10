using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    private float baseTime = 5f;

    private void Update()
    {
        baseTime -= Time.deltaTime;
        if (baseTime <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
