using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Main_spawner : MonoBehaviour
{
    // singleton �� ����������
    public static Main_spawner main_spawner { get; private set; }

    [SerializeField]
    private Lane_spawner Lane_creeps;

    // ���������� � ���������� �������
    public List<GameObject> creeps_choice;

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
            GameObject creep_to_spawn = creeps_choice[0];
            // ���� ���� ������ >= ��������� �����, �� �������
            GameObject enemy_creep = Instantiate(creep_to_spawn, new Vector3(5, 0, 0), Quaternion.identity);

    }
    // ����� ������ ( ����� �� UI)
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
    // ��������� ���� � �����, ���� ����� �� �������� -> ��������� �����
    public void NextCreep()
    {
        
        creeps_choice.RemoveAt(0);
        if (creeps_choice.Count == 0)
        {
            Debug.Log($"� ��� �� ����������� {creeps_choice.Count}");
            CreateWave();
        }
        else { Spawn(); Debug.Log($"������� ����� {creeps_choice.Count}") ;  }
        
    }
            
        } 
