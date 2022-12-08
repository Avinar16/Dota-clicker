using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // singleton на минималках
    public static Timer timer { get; private set; }

    public float baseTime;
    public Text timerScore;

    public GameObject Scenes;
    public GameObject Shop;
    public GameObject ShopButton;

    [SerializeField]
    private AudioSource Source;
    [SerializeField]
    private AudioClip Sound;


    void Update()
    {
        baseTime -= Time.deltaTime;
        timerScore.text = "Время:" + (int) baseTime;
        if(baseTime <= 0)
        {
            Reset();
            Source.PlayOneShot(Sound);
        }
    }
    public void SetTimer(float time)
    {
        Shop.SetActive(false);
        Scenes.SetActive(false);
        ShopButton.GetComponentInChildren<Button>().interactable = false;
        baseTime = time;
    }
    public void Reset()
    {
        ShopButton.GetComponentInChildren<Button>().interactable = true;
        this.transform.parent.gameObject.SetActive(false);
        Main_spawner.main_spawner.ChooseCreeps("Lane_creeps");
    }
    private void Start()
    {
        timer = this;
    }
}
