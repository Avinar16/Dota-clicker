using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_button : MonoBehaviour
{
    [SerializeField]
    private int maxLevel;
    private int levelItem = 0;

    [SerializeField]
    private List<int> Costs;
    private int CurrentLevel = 0;

    private int CurrentGold;

    private Button button;

    // ���������� ������ � �������
    [SerializeField]
    private List<int> GoldPerSec;
    // ���������� ����� �������� �����
    [SerializeField]
    private List<int> Attack;

    // ������� ���������
    [SerializeField]
    private GameObject LevelImageObject;
    private Image LevelImage;

    // ������ �������� ��������� ��������� �� ������
    [SerializeField]
    private List<Sprite> LevelSprites;

    // ���������� � ��������
    [SerializeField]
    private GameObject InfoTextObject;
    private Text InfoText;

    private void Start()
    {
        InfoText.text = $"����: {Costs[CurrentLevel]}" +
                $"\n+{GoldPerSec[CurrentLevel]} ������/���" +
                $"\n+{Attack[CurrentLevel]} �����";
    }

    private void Awake()
    {
        button = gameObject.GetComponent<Button>();
        LevelImage = LevelImageObject.GetComponent<Image>();
        InfoText = InfoTextObject.GetComponent<Text>();
    }

    void Update()
    {
        CurrentGold = GoldCounter.currentGold;
        if(CurrentGold >= Costs[CurrentLevel] && levelItem < maxLevel)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
    }

    public void Buy()
    {
        // �������, ���� ������ ������ � ������� ���� �������������
        if (button.IsInteractable())
        {
            // �������
            GoldCounter.currentGold -= Costs[CurrentLevel];
            // ����� �������
            Hero.Damage += Attack[CurrentLevel];
            GoldCounter.goldPerSecond += GoldPerSec[CurrentLevel];
            SetLevel();
        }
    }

    private void SetLevel()
    {
        // ����� ��������
        LevelImage.sprite = LevelSprites[CurrentLevel];
        LevelImage.color = new Color(255, 255, 255);
        // ����������� ����������
        if(CurrentLevel == Costs.Count - 1)
        {
            levelItem = 3;
            InfoText.text = $"���� �������" +
                $"\n+{GoldPerSec[CurrentLevel]} ������/���" +
                $"\n+{Attack[CurrentLevel]} �����";
        }
        else
        {
            // ����� �������� �� ������� ����
            CurrentLevel++;
            InfoText.text = $"����: {Costs[CurrentLevel]}" +
                $"\n+{GoldPerSec[CurrentLevel]} ������/���" +
                $"\n+{Attack[CurrentLevel]} �����";
        }
        // ����� ��������
        LevelImage.sprite = LevelSprites[CurrentLevel];
        LevelImage.color = new Color(255, 255, 255);
    }
}