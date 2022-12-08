using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Main_spawner : MonoBehaviour
{
    // singleton на минималках
    public static Main_spawner main_spawner { get; private set; }

    [SerializeField]
    private GameObject healthBar;
    private GameObject enemy_hp;

    [SerializeField]
    private Lane_spawner Lane_creeps;

    [SerializeField]
    private Forest_spawner Forest_creeps;

    [SerializeField]
    private Boss_spawner Boss_creeps;


    [SerializeField]
    private GameObject canvas;

    // Переменная с выбранными крипами
    public List<GameObject> Wave;

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
            {"Lane_creeps",  Lane_creeps},
            {"Forest_creeps",  Forest_creeps},
            {"Boss_spawner", Boss_creeps}
        };

        //Первая пачка
        CreateWave();
    
    }
    public void Spawn()
    {
        // Выбираем
        GameObject creep_to_spawn = Wave[0];
        enemy_creep = Instantiate(creep_to_spawn, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        enemy_creep.transform.SetParent(gameObject.transform, false);
        Creep enemy_creep_script = enemy_creep.GetComponent<Creep>();

        // Создаем хп бар
        enemy_hp = Instantiate(healthBar, new Vector3(5, 10, 0), Quaternion.identity);
        // Ставим хп бар на канвас
        enemy_hp.transform.SetParent(canvas.transform, false);

        // Задаем крипу его хп бар
        enemy_creep_script.SetHealthBar(enemy_hp);
       
    }



    // выбор крипов ( придёт из UI)
    
    public void ChooseCreeps(string creeps)
    {
        choice = creeps;
        Destroy(enemy_creep);
        Destroy(enemy_hp);
        //Debug.Log("Выбор");
        CreateWave();
    }
    
    private void CreateWave()
    {
        Wave = creeps_dict[choice].GetOrder();
        Spawn();
    }
    // Следующий крип в пачке, если таких не осталось -> следующая пачка
    public void NextCreep()
    {

        Wave.RemoveAt(0);
        if (Wave.Count == 0)
        {
            Debug.Log($"У нас всё закончилось {Wave.Count}");
            CreateWave();
        }
        else { Spawn(); Debug.Log($"Спавним некст {Wave.Count}") ;  }
        
    }
            
        }   
