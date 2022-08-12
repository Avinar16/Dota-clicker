using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider health_bar;

    [SerializeField]
    private Creep creep;

    public void Init()
    {
        creep = GameObject.FindGameObjectWithTag("Creep").GetComponent<Creep>();
        health_bar = gameObject.GetComponent<Slider>();
        gameObject.transform.localPosition = new Vector3(550, 350, 0);
    }

    private void Update()
    {
        health_bar.value = creep.health;

        if (creep.health <= 0) { Destroy(gameObject); }
    }

    private void Start()
    {
        Init();
        health_bar.maxValue = creep.health;
        health_bar.value = creep.health;
    }
}
