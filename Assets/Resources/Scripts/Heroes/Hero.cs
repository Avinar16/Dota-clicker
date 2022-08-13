using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public int Damage;
    protected int exp;
    [SerializeField]
    protected int level = 1;


    void Update()
    {
        Attack();
    }

    void Attack()
    {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //find creep's script
                Creep enemy = GameObject.FindGameObjectWithTag("Creep").GetComponent<Creep>();

                enemy.TakeDamage(Damage);

                // Log
                //Debug.Log($"attack {enemy.name} Health= {enemy.health}");
           }
    }

}
