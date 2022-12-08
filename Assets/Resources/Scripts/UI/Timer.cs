using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float baseTime = 30;
    public Text timerScore;

    void Update()
    {
        baseTime -= Time.deltaTime;
        timerScore.text = "Время:" + (int) baseTime;
    }
}
