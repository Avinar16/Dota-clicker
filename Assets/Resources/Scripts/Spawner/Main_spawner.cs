using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Main_spawner : MonoBehaviour
{
    // singleton на минималках
    public static Main_spawner main_spawner { get; private set; }

    [SerializeField]
    private GameObject[] Lane_creeps;

    // Переменная с выбранными крипами
    private GameObject[] creeps_choice;

    // Дефолт выбор
    private string default_choice = "Lane_creeps_easy";

    // переменная со всеми крипами
    Dictionary<string, GameObject[]> creeps_dict;

    private void Awake()
    {
        main_spawner = this;
    }
    private void Start()
    {
        // Получить префабы лайновых крипов GameObject
        //Lane_creeps = Resources.LoadAll<GameObject>("Prefabs/Lane_creeps");


        // Словарь со всеми типами крипов
        creeps_dict = new Dictionary<string, GameObject[]>
        {
            {"Lane_creeps_easy", Lane_creeps}
        };

        // определить стандартных крипов
        creeps_choice = creeps_dict[default_choice];

        Spawn();
    
    }
    public void Spawn()
    {
        for (;;)
        {
            // Рандомное число (шанс из 10)
            int chance = Random.Range(0, 10);
            // Рандомный крип
            GameObject creep_GameObject = creeps_choice[Random.Range(0, creeps_choice.Length)];
            // получить скрипт из GameObject
            Creep creep = creep_GameObject.GetComponent<Creep>();
            // Если шанс спавна >= выпавшему шансу, то спавним
            if (creep.chance >= chance) {
                GameObject enemy_creep = Instantiate(creep_GameObject, new Vector3(5, 0, 0), Quaternion.identity);
                break;
            }
        }
    }
    // выбор крипов ( придёт из UI)
    public void ChooseCreeps(string creeps)
    {
        creeps_choice = creeps_dict[creeps];
    }
}
