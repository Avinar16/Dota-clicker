using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desolator : ItemScript
{
    public int damage = 50;
    
    public void buyItem()
    {
        GoldCounter.currentGold -= price;
        counterItems++;
        price = (int)(price * 1.2);
    }
}
