using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldCounter : MonoBehaviour
{
    public static int currentGold = 0;
    public static int goldPerSecond = 0;
    Text goldText;

    void Start()
    {
        goldText = GetComponent<Text>();
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

}
