using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldCounter : MonoBehaviour
{
    public static int currentGold = 9999;
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

    public int getGold()
    {
        return currentGold;
    }

    // ���������� ������ � ������ ��������
    public int receivingGold(int gold)
    {
        return currentGold + gold;
    }

    // ��������� ������ �� ������ ��������
    public int wasteGold(int gold)
    {
        return currentGold - gold;
    }
    private IEnumerator GoldPerSecond()
    {
        while (true) {
            yield return new WaitForSeconds(1);
            currentGold += goldPerSecond;
        }
        
    }

}
