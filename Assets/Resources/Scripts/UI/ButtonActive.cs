using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActive : MonoBehaviour
{
    public GameObject shop;
    public GameObject scenes;
    private bool isActive = false;

    public void IsActiveButton()
    {
        if (!isActive)
        {
            isActive = true;
            shop.SetActive(true);
            scenes.SetActive(true);
        }
        else
        {
            isActive = false;
            shop.SetActive(false);
            scenes.SetActive(false);
        }
    }
}
