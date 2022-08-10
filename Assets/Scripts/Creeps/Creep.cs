using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creep : MonoBehaviour
{
    public int health;
    [SerializeField]
    protected int exp;
    protected int level_to_spawn;

    void Update()
    {
        Die();
    }
    public void TakeDamage(int damage) {
        health -= damage;
    }
    private void Die()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("„ирик пиздык ху€к куку");
        }
    }
}
