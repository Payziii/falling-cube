using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LevelOpen : MonoBehaviour
{
    // Объекты для перемещения (Игрок и камера)
    [SerializeField] GameObject CameraObject;
    [SerializeField] GameObject PlayerObject;
    // Всякое нужное (Панель смерти, текст с текущим уровнем и т.д.)
    [SerializeField] GameObject DeathPanel;
    [SerializeField] Text LevelText;
    [SerializeField] int Levels;
    private int Level;
    private int Max_Level;

    private Rigidbody rb;

    /* Делаем стандартное время, затем получаем list с уровнями, после этого
    вносим текущий уровень в PlayerPrefs, а также рекорд (Max_Level) и выводим
    на экран текущий уровень (НЕ ЗАБЫВАЕМ ВЫКЛЮЧИТЬ ПАНЕЛЬ СМЕРТИ).
    После проделанных действий перемещаем камеру и игрока в нужное место */
    private void Start()
    {
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

    /* Если игрок дошел до финиша, то делаем проверку (Если он побил рекорд,
     то записываем новый). Также, если это не последний уровень, то мы переносим
    камеру и игрока на новый уровень и выводим текущий уровень.
    Если же игрок коснулся красной платформы, то мы просто ставим игру на
    паузу и выводим панель смерти */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
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
            
            
        }else if (collision.gameObject.CompareTag("Red"))
        {
            DeathPanel.SetActive(true);
            Time.timeScale = 0f;
        }else if (collision.gameObject.CompareTag("Jump"))
        {
            rb.AddForce(Vector3.up * 0.19f, ForceMode.Impulse);
        }
    }

}
