using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Main_spawner : MonoBehaviour
{
    // singleton на минималках
    public static Main_spawner main_spawner { get; private set; }

    [SerializeField]
    private Lane_spawner Lane_creeps;

    // Переменная с выбранными крипами
    public List<GameObject> creeps_choice;

    // Дефолт выбор
    private string choice = "Lane_creeps";

    // переменная со всеми крипами
    private Dictionary<string, Basic_spawner> creeps_dict;

    // Крип, который заспавнится
    private GameObject enemy_creep;

    private void Awake()
    {
        main_spawner = this;
    }
    private void Start()
    {
        // Получить префабы лайновых крипов GameObject
        //Lane_creeps = Resources.LoadAll<GameObject>("Prefabs/Lane_creeps");


        // Словарь со всеми типами крипов
        creeps_dict =  new Dictionary<string, Basic_spawner>
        {
            {"Lane_creeps",  Lane_creeps}
        };

        //Первая пачка
        CreateWave();
    
    }
    public void Spawn()
    {
            GameObject creep_to_spawn = creeps_choice[0];
            // Если шанс спавна >= выпавшему шансу, то спавним
            GameObject enemy_creep = Instantiate(creep_to_spawn, new Vector3(5, 0, 0), Quaternion.identity);

    }
    // выбор крипов ( придёт из UI)
    public void ChooseCreeps(string creeps)
    {
        choice = creeps;
        creeps_choice = creeps_dict[choice].GetOrder();
        Destroy(enemy_creep);
        Spawn();
    }
    private void CreateWave()
    {
        creeps_choice = creeps_dict[choice].GetOrder();
        Spawn();
    }
    // Следующий крип в пачке, если таких не осталось -> следующая пачка
    public void NextCreep()
    {
        
        creeps_choice.RemoveAt(0);
        if (creeps_choice.Count == 0)
        {
            Debug.Log($"У нас всё закончилось {creeps_choice.Count}");
            CreateWave();
        }
        else { Spawn(); Debug.Log($"Спавним некст {creeps_choice.Count}") ;  }
        
    }
            
        } 
