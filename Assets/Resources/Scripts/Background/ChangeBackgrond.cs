using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackgrond : MonoBehaviour
{
    public GameObject firstNoActive;
    public GameObject secondActive;
    public GameObject thirdNoActive;
    public bool isLine = false;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void backgroundChanger()
    {
        firstNoActive.SetActive(false);
        secondActive.SetActive(true);
        thirdNoActive.SetActive(false);   
    }
}
