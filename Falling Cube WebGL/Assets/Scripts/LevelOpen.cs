using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Unity.VisualScripting;
using System;

public class LevelOpen : MonoBehaviour
{
    // ���������� bridge
    public VkBridgeController bridge;
    // ������� ��� ����������� (����� � ������)
    [SerializeField] GameObject CameraObject;
    [SerializeField] GameObject PlayerObject;
    [SerializeField] GameObject PauseManager;
    [SerializeField] GameObject Vk;
    // ������ ������ (������ ������, ����� � ������� ������� � �.�.)
    [SerializeField] GameObject DeathPanel;
    [SerializeField] GameObject PausePanel;
    [SerializeField] Text LevelText;
    [SerializeField] int Levels;
    private int Level;
    private int Max_Level;
    // ���-�� ���������� ������� � ������� (1.1)
    private int Deaths = 0;
    private int LevelsCompleted = 0;

    private Rigidbody rb;

    // ��������� �� ������� ���������� � ���� ��� ����, ���������� �� ��������
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
    /* ������ ����������� �����, ����� �������� list � ��������, ����� �����
    ������ ������� ������� � PlayerPrefs, � ����� ������ (Max_Level) � �������
    �� ����� ������� ������� (�� �������� ��������� ������ ������).
    ����� ����������� �������� ���������� ������ � ������ � ������ ����� */
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
        LevelText.text = "�������: " + Level.ToString();
        DeathPanel.SetActive(false);
        float Player = LevelManager.GetComponent<LevelStart>().parts.Find(p => p.Level == Level).Player;
        float Camera = LevelManager.GetComponent<LevelStart>().parts.Find(p => p.Level == Level).Camera;

        CameraObject.transform.position = new Vector3(CameraObject.transform.position.x, Camera, CameraObject.transform.position.z);
        PlayerObject.transform.position = new Vector3(6, Player, PlayerObject.transform.position.z);
    }

    /* ������ ������ �������, ���� ����� �������� ������������ ��������� */
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

    /* ���� ����� ����� �� ������, �� ������ �������� (���� �� ����� ������,
    �� ���������� �����). �����, ���� ��� �� ��������� �������, �� �� ���������
    ������ � ������ �� ����� ������� � ������� ������� �������. */
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
            LevelText.text = "�������: " + Level.ToString();
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

    /* ���� ����� �������� ������� ���������, �� �� ����������� ����������
    �������, ������ ���� �� ����� � ������� ������ ������ */
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
