using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane_spawner : Basic_spawner
{
    [SerializeField]
    private GameObject Melee_creep;
    [SerializeField]
    private GameObject Range_creep;
    [SerializeField]
    private GameObject Catapult_creep;


    public override List<GameObject> GetOrder()
    {
        List<GameObject> order = new List<GameObject>();
        for(int i = 0; i <= 4; i++)
        {
            order.Add(Melee_creep);
        }
        order.Add(Range_creep);
        int chance = Random.Range(0, 10);
        if(chance >= 4)
        {
            order.Add(Catapult_creep);
        }
        return order;
    }
}
