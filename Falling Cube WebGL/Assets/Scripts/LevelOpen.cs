using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Unity.VisualScripting;
using System;

public class LevelOpen : MonoBehaviour
{
    // Контроллер bridge
    public VkBridgeController bridge;
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
        bridge.VKWebAppStorageGet("Level", GetLevel);
    }

    private void GetLevel(string value)
    {
        Level = Convert.ToInt32(value);
        bridge.VKWebAppStorageGet("Max_Level", GetMaxLevel);
    }

    private void GetMaxLevel(string value)
    {
        if (value.Length != 0)
        {
            Max_Level = Convert.ToInt32(value);
        }
        else
        {
            Max_Level = 0;
        }
        Next();
    }
    /* Делаем стандартное время, затем получаем list с уровнями, после этого
    вносим текущий уровень в PlayerPrefs, а также рекорд (Max_Level) и выводим
    на экран текущий уровень (НЕ ЗАБЫВАЕМ ВЫКЛЮЧИТЬ ПАНЕЛЬ СМЕРТИ).
    После проделанных действий перемещаем камеру и игрока в нужное место */
    private void Start()
    {
        bridge.VKWebAppStorageGet("Deaths", CheckDeaths);
    }

    private void Next()
    {
        rb = GetComponent<Rigidbody>();
        Time.timeScale = 1f;
        GameObject LevelManager = GameObject.Find("LevelManager");
        List<Part> myList = LevelManager.GetComponent<LevelStart>().parts;
        LevelText.text = "Уровень: " + Level.ToString();
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
        bridge.VKWebAppStorageSet("LevelsCompleted", LevelsCompleted.ToString());
        if (Levels >= Max_Level)
        {
            bridge.VKWebAppStorageSet("Max_Level", (Level+1).ToString());
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
        bridge.VKWebAppStorageSet("Deaths", Deaths.ToString());
        DeathPanel.SetActive(true);
        Time.timeScale = 0f;

        int ads = UnityEngine.Random.Range(0, 100);
        if(ads < 10)
        {
            Vk.GetComponent<Vkgame>().ShowAds();
        }
    }

    public void RestartLevel()
    {
        if (Levels >= Level)
        {
            bridge.VKWebAppStorageSet("Level", Level.ToString());
            DeathPanel.SetActive(false);
            PausePanel.SetActive(false);
            Start();
        }
    }

}
