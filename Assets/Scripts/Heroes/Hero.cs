using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public int Damage = 1;
    private GameObject enemy;

    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Creep enemy = GameObject.FindGameObjectWithTag("Creep").GetComponent<Creep>();
            Debug.Log($"attack {enemy.name} Health= {enemy.health}");
            enemy.TakeDamage(Damage);
        }
    }

}
