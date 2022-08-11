using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Main_spawner : MonoBehaviour
{
    // singleton �� ����������
    public static Main_spawner main_spawner { get; private set; }

    [SerializeField]
    private GameObject[] Lane_creeps;

    // ���������� � ���������� �������
    private GameObject[] creeps_choice;

    // ������ �����
    private string default_choice = "Lane_creeps_easy";

    // ���������� �� ����� �������
    Dictionary<string, GameObject[]> creeps_dict;

    private void Awake()
    {
        main_spawner = this;
    }
    private void Start()
    {
        // �������� ������� �������� ������ GameObject
        //Lane_creeps = Resources.LoadAll<GameObject>("Prefabs/Lane_creeps");


        // ������� �� ����� ������ ������
        creeps_dict = new Dictionary<string, GameObject[]>
        {
            {"Lane_creeps_easy", Lane_creeps}
        };

        // ���������� ����������� ������
        creeps_choice = creeps_dict[default_choice];

        Spawn();
    
    }
    public void Spawn()
    {
        for (;;)
        {
            // ��������� ����� (���� �� 10)
            int chance = Random.Range(0, 10);
            // ��������� ����
            GameObject creep_GameObject = creeps_choice[Random.Range(0, creeps_choice.Length)];
            // �������� ������ �� GameObject
            Creep creep = creep_GameObject.GetComponent<Creep>();
            // ���� ���� ������ >= ��������� �����, �� �������
            if (creep.chance >= chance) {
                GameObject enemy_creep = Instantiate(creep_GameObject, new Vector3(5, 0, 0), Quaternion.identity);
                break;
            }
        }
    }
    // ����� ������ ( ����� �� UI)
    public void ChooseCreeps(string creeps)
    {
        creeps_choice = creeps_dict[creeps];
    }
}
