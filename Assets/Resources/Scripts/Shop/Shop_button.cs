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

    // Увеличение золота в секунду
    [SerializeField]
    private List<int> GoldPerSec;
    // Увеличение урона главного героя
    [SerializeField]
    private List<int> Attack;

    // Уровень предметов
    [SerializeField]
    private GameObject LevelImageObject;
    private Image LevelImage;

    // Список спрайтов предметов зависящий от уровня
    [SerializeField]
    private List<Sprite> LevelSprites;

    // Информация о предмете
    [SerializeField]
    private GameObject InfoTextObject;
    private Text InfoText;

    private void Start()
    {
        InfoText.text = $"Цена: {Costs[CurrentLevel]}" +
                $"\n+{GoldPerSec[CurrentLevel]} Золота/сек" +
                $"\n+{Attack[CurrentLevel]} Атаки";
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
        // Покупка, если нажата кнопка и уровень ниже максимального
        if (button.IsInteractable())
        {
            // Покупка
            GoldCounter.currentGold -= Costs[CurrentLevel];
            // Зачёт бонусов
            Hero.Damage += Attack[CurrentLevel];
            GoldCounter.goldPerSecond += GoldPerSec[CurrentLevel];
            SetLevel();
        }
    }

    private void SetLevel()
    {
        // Смена картинки
        LevelImage.sprite = LevelSprites[CurrentLevel];
        LevelImage.color = new Color(255, 255, 255);
        // Отображение информации
        if(CurrentLevel == Costs.Count - 1)
        {
            levelItem = 3;
            InfoText.text = $"Макс уровень" +
                $"\n+{GoldPerSec[CurrentLevel]} Золота/сек" +
                $"\n+{Attack[CurrentLevel]} Атаки";
        }
        else
        {
            // Смена предмета на уровень выше
            CurrentLevel++;
            InfoText.text = $"Цена: {Costs[CurrentLevel]}" +
                $"\n+{GoldPerSec[CurrentLevel]} Золота/сек" +
                $"\n+{Attack[CurrentLevel]} Атаки";
        }
        // Смена картинки
        LevelImage.sprite = LevelSprites[CurrentLevel];
        LevelImage.color = new Color(255, 255, 255);
    }
}