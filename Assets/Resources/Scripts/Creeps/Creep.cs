using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Creep : MonoBehaviour
{
    public int health;
    [SerializeField]
    protected int exp;
    [SerializeField]
    protected int gold;

    private void Awake()
    {
        Debug.Log(this.name);
    }


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
            // singleton
            // —ледующий крип в пачке
            Main_spawner.main_spawner.NextCreep();
        }
    }
}
