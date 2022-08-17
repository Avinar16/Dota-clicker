using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActive : MonoBehaviour
{
    public GameObject shop;
    private bool isActive = false;

    public void IsActiveButton()
    {
        if (!isActive)
        {
            isActive = true;
            shop.SetActive(true);
        }
        else
        {
            isActive = false;
            shop.SetActive(false);
        }
    }
}
