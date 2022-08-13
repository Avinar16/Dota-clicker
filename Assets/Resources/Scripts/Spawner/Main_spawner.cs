using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Main_spawner : MonoBehaviour
{
    // singleton �� ����������
    public static Main_spawner main_spawner { get; private set; }

    [SerializeField]
    private GameObject healthBar;

    [SerializeField]
    private Lane_spawner Lane_creeps;

    [SerializeField]
    private GameObject canvas;

    // ���������� � ���������� �������
    public List<GameObject> Wave;

    // ������ �����
    private string choice = "Lane_creeps";

    // ���������� �� ����� �������
    private Dictionary<string, Basic_spawner> creeps_dict;

    // ����, ������� �����������
    private GameObject enemy_creep;

    private void Awake()
    {
        main_spawner = this;
    }
    private void Start()
    {
        // �������� ������� �������� ������ GameObject
        //Lane_creeps = Resources.LoadAll<GameObject>("Prefabs/Lane_creeps");


        // ������� �� ����� ������ ������
        creeps_dict =  new Dictionary<string, Basic_spawner>
        {
            {"Lane_creeps",  Lane_creeps}
        };

        //������ �����
        CreateWave();
    
    }
    public void Spawn()
    {
        // ��������
        GameObject creep_to_spawn = Wave[0];
        enemy_creep = Instantiate(creep_to_spawn, new Vector3(5, 0, 0), Quaternion.identity) as GameObject;
        Creep enemy_creep_script = enemy_creep.GetComponent<Creep>();

        // ������� �� ���
        GameObject enemy_hp = Instantiate(healthBar, new Vector3(5, 10, 0), Quaternion.identity);
        // ������ �� ��� �� ������
        enemy_hp.transform.SetParent(canvas.transform, false);

        // ������ ����� ��� �� ���
        enemy_creep_script.SetHealthBar(enemy_hp);
       
    }



    // ����� ������ ( ����� �� UI) ���� �� ��������
    /*
    public void ChooseCreeps(string creeps)
    {
        choice = creeps;
        Wave = creeps_dict[choice].GetOrder();
        Destroy(enemy_creep);
        CreateWave();
    }
    */
    private void CreateWave()
    {
        Wave = creeps_dict[choice].GetOrder();
        Spawn();
    }
    // ��������� ���� � �����, ���� ����� �� �������� -> ��������� �����
    public void NextCreep()
    {

        Wave.RemoveAt(0);
        if (Wave.Count == 0)
        {
            Debug.Log($"� ��� �� ����������� {Wave.Count}");
            CreateWave();
        }
        else { Spawn(); Debug.Log($"������� ����� {Wave.Count}") ;  }
        
    }
            
        } 
