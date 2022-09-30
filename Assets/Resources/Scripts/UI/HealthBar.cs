using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider health_bar;


    public void Init(int max_hp)
    {
        // �������� �������
        health_bar = gameObject.GetComponent<Slider>();
        // ������ �����, ��� ����� ������� ��
        gameObject.transform.localPosition = new Vector3(550, 350, 0);
        // ������ ������������ � ��������� ��������
        health_bar.maxValue = max_hp;
        health_bar.value = max_hp;
    }

    public void SetHp(int hp)
    {
        health_bar.value = hp;
        // ���� ��� ��, ������� ������� ��
        if (health_bar.value <= 0) { Destroy(gameObject); }
        
    }
    

}
