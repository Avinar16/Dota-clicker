using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldCounter : MonoBehaviour
{
    public static int currentGold = 100000;
    public static int goldPerSecond = 1;
    Text goldText;

    void Start()
    {
        goldText = GetComponent<Text>();
        StartCoroutine(GoldPerSecond());
    }

    void Update()
    {
        goldText.text = "" + currentGold;
    }

    private IEnumerator GoldPerSecond()
    {
        while (true) {
            yield return new WaitForSeconds(1);
            currentGold += goldPerSecond;
        }
        
    }
}
