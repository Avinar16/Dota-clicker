using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_spawner : Basic_spawner
{
    // singleton на минималках
    public static Boss_spawner boss_spawner { get; private set; }

    [SerializeField]
    private GameObject TimerObject;
    private Timer Timer;
    public List<GameObject> bosses; 
    public int Level = 0;

    private void Start()
    {
        boss_spawner = this;
        Timer = TimerObject.GetComponentInChildren<Timer>();
    }
    public override List<GameObject> GetOrder()
    {
        setBackground();
        List<GameObject> order = new List<GameObject>();
        order.Add(bosses[Level]);
        Timer.SetTimer(30f);
        TimerObject.SetActive(true);
        return order;
    }
    public override void setBackground()
    {
        background.sprite = sprite;
    }
}
