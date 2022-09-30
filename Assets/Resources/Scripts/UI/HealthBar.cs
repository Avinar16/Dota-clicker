using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider health_bar;


    public void Init(int max_hp)
    {
        // Получаем слайдер
        health_bar = gameObject.GetComponent<Slider>();
        // Задаем место, где будет полоска хп
        gameObject.transform.localPosition = new Vector3(550, 350, 0);
        // Задаем максимальное и стартовое значения
        health_bar.maxValue = max_hp;
        health_bar.value = max_hp;
    }

    public void SetHp(int hp)
    {
        health_bar.value = hp;
        // Если нет хп, удаляем полоску хп
        if (health_bar.value <= 0) { Destroy(gameObject); }
        
    }
    

}
