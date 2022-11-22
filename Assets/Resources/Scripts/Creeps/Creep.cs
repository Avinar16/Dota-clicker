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
    public int gold;
    


    private HealthBar health_bar;



    void Update()
    {
        Die();
    }

    public void TakeDamage(int damage) {
        health -= damage;
        health_bar.SetHp(health);
    }

    private void Die()
    {
        if(health <= 0)
        {
            GoldCounter.currentGold += gold;
            Destroy(gameObject);
            
            Debug.Log("����� ������ ���� ����");
            // singleton
            // ��������� ���� � �����
            Main_spawner.main_spawner.NextCreep();
        }
    }

    public void SetHealthBar(GameObject hpbar_game_object)
    {
        health_bar = hpbar_game_object.GetComponent<HealthBar>();
        health_bar.Init(health);
    }
}
