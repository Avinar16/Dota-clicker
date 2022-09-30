using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Forest_spawner : Basic_spawner
{
    [SerializeField]
    private GameObject krisa;

    public override List<GameObject> GetOrder()
    {
        List<GameObject> order = new List<GameObject>();
        order.Add(krisa);
        order.Add(krisa);
        order.Add(krisa);

        setBackground();

        return order;
    }

    
    public override void setBackground()
    {
        background.sprite = sprite;
    }
}
