using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public int price;
    public int counterItems = 0;
    private bool isActiveButton = false;
    public GameObject item;

    void Update()
    {
        isActive();
        Debug.Log("HUY");
    }
    public void isActive()
    {
        if (GoldCounter.currentGold >= price)
        {
            isActiveButton = true;
            item.SetActive(true);
        }
        else
        {
            isActiveButton = false;
            item.SetActive(false);
        }
    }
}
