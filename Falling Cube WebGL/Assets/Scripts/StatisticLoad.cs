using System;
using UnityEngine;
using UnityEngine.UI;

public class StatisticLoad : MonoBehaviour
{
    // Кол-во пройденных уровней и смертей (1.1)
    private int Deaths = 0;
    private int LevelsCompleted = 0;
    // Текст
    [SerializeField] Text StatText;
    // Контроллер bridge
    public VkBridgeController bridge;

    // Проверяем на наличие переменных и если они есть, записываем их значение (1.1)
    private void CheckDeaths(string value)
    {
        if (value.Length != 0)
        {
            Deaths = Convert.ToInt32(value);
        }
        bridge.VKWebAppStorageGet("LevelsCompleted", CheckLevelsCompleted);
    }

    private void CheckLevelsCompleted(string value)
    {
        if (value.Length != 0)
        {
            LevelsCompleted = Convert.ToInt32(value);
        }
        Next();
    }

    // Загрузка переменных в текст (1.1)
    public void Load()
    {
        bridge.VKWebAppStorageGet("Deaths", CheckDeaths);
    }
    
    private void Next()
    {
        StatText.text = "Смертей: " + Deaths.ToString() + "\n" + "Пройдено уровней: " + LevelsCompleted.ToString();
    }
}
