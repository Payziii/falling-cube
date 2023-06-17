using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Unity.VisualScripting;

public class LevelOpen : MonoBehaviour
{
    // Объекты для перемещения (Игрок и камера)
    [SerializeField] GameObject CameraObject;
    [SerializeField] GameObject PlayerObject;
    [SerializeField] GameObject PauseManager;
    [SerializeField] GameObject Vk;
    // Всякое нужное (Панель смерти, текст с текущим уровнем и т.д.)
    [SerializeField] GameObject DeathPanel;
    [SerializeField] GameObject PausePanel;
    [SerializeField] Text LevelText;
    [SerializeField] int Levels;
    private int Level;
    private int Max_Level;
    // Кол-во пройденных уровней и смертей (1.1)
    private int Deaths = 0;
    private int LevelsCompleted = 0;

    private Rigidbody rb;

    // Проверяем на наличие переменных и если они есть, записываем их значение
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
    /* Делаем стандартное время, затем получаем list с уровнями, после этого
    вносим текущий уровень в PlayerPrefs, а также рекорд (Max_Level) и выводим
    на экран текущий уровень (НЕ ЗАБЫВАЕМ ВЫКЛЮЧИТЬ ПАНЕЛЬ СМЕРТИ).
    После проделанных действий перемещаем камеру и игрока в нужное место */
    private void Start()
    {
        CheckPlayerPrefs();
        rb = GetComponent<Rigidbody>();
        Time.timeScale = 1f;
        GameObject LevelManager = GameObject.Find("LevelManager");
        List<Part> myList = LevelManager.GetComponent<LevelStart>().parts;
        Level = PlayerPrefs.GetInt("Level");
        LevelText.text = "Уровень: " + Level.ToString();
        Max_Level = PlayerPrefs.GetInt("Max_Level");
        DeathPanel.SetActive(false);
        float Player = LevelManager.GetComponent<LevelStart>().parts.Find(p => p.Level == Level).Player;
        float Camera = LevelManager.GetComponent<LevelStart>().parts.Find(p => p.Level == Level).Camera;

        CameraObject.transform.position = new Vector3(CameraObject.transform.position.x, Camera, CameraObject.transform.position.z);
        PlayerObject.transform.position = new Vector3(6, Player, PlayerObject.transform.position.z);
    }

    /* Делаем разные события, если игрок коснулся определенной платформы */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            FinishLevel();
        }
        else if (collision.gameObject.CompareTag("Red"))
        {
            PlayerDeath();
        }
        else if (collision.gameObject.CompareTag("Jump"))
        {
            rb.AddForce(Vector3.up * 0.19f, ForceMode.Impulse);
        }
    }

    /* Если игрок дошел до финиша, то делаем проверку (Если он побил рекорд,
    то записываем новый). Также, если это не последний уровень, то мы переносим
    камеру и игрока на новый уровень и выводим текущий уровень. */
    private void FinishLevel()
    {
        LevelsCompleted++;
        PlayerPrefs.SetInt("LevelsCompleted", LevelsCompleted);
        if (Levels >= Max_Level)
        {
            PlayerPrefs.SetInt("Max_Level", Level + 1);
        }
        Level++;
        Max_Level++;
        if (Levels >= Level)
        {
            LevelText.text = "Уровень: " + Level.ToString();
            GameObject LevelManager = GameObject.Find("LevelManager");
            List<Part> myList = LevelManager.GetComponent<LevelStart>().parts;
            float Player = LevelManager.GetComponent<LevelStart>().parts.Find(p => p.Level == Level).Player;
            float Camera = LevelManager.GetComponent<LevelStart>().parts.Find(p => p.Level == Level).Camera;

            CameraObject.transform.position = new Vector3(CameraObject.transform.position.x, Camera, CameraObject.transform.position.z);
            PlayerObject.transform.position = new Vector3(6, Player, PlayerObject.transform.position.z);
        }
        else
        {
            PauseManager.GetComponent<PauseManager>().GoToScene("Menu");
        }
    }

    /* Если игрок коснулся красной платформы, то мы увеличиваем количество
    смертей, ставим игру на паузу и выводим панель смерти */
    private void PlayerDeath()
    {
        Deaths++;
        PlayerPrefs.SetInt("Deaths", Deaths);
        DeathPanel.SetActive(true);
        Time.timeScale = 0f;

        int ads = Random.Range(0, 100);
        if(ads < 10)
        {
            Vk.GetComponent<Vkgame>().ShowAds();
        }
    }

    public void RestartLevel()
    {
        if (Levels >= Level)
        {
            PlayerPrefs.SetInt("Level", Level);
            DeathPanel.SetActive(false);
            PausePanel.SetActive(false);
            Start();
        }
    }

}
