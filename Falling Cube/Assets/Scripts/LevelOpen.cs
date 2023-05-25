using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LevelOpen : MonoBehaviour
{
    [SerializeField] GameObject CameraObject;
    [SerializeField] GameObject PlayerObject;
    [SerializeField] GameObject DeathPanel;
    [SerializeField] Text LevelText;
    [SerializeField] int Levels;
    private int Level;
    private int Max_Level;
    private void Start()
    {
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
        }
    }

}
