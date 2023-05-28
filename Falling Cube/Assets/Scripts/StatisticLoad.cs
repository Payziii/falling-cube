using UnityEngine;
using UnityEngine.UI;

public class StatisticLoad : MonoBehaviour
{
    // Кол-во пройденных уровней и смертей (1.1)
    private int Deaths = 0;
    private int LevelsCompleted = 0;
    // Текст
    [SerializeField] Text StatText;

    // Проверяем на наличие переменных и если они есть, записываем их значение (1.1)
    private void CheckPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("Deaths"))
        {
            Deaths = PlayerPrefs.GetInt("Deaths");
        }
        if (PlayerPrefs.HasKey("LevelsCompleted"))
        {
            LevelsCompleted = PlayerPrefs.GetInt("LevelsCompleted");
        }
    }

    // Загрузка переменных в текст (1.1)
    public void Load()
    {
        CheckPlayerPrefs();
        StatText.text = "Смертей: " + Deaths.ToString() + "\n" + "Пройдено уровней: " + LevelsCompleted.ToString();
    }
}
