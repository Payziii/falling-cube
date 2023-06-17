using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Unity.VisualScripting;

public class LevelOpen : MonoBehaviour
{
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
    /* ������ ����������� �����, ����� �������� list � ��������, ����� �����
    ������ ������� ������� � PlayerPrefs, � ����� ������ (Max_Level) � �������
    �� ����� ������� ������� (�� �������� ��������� ������ ������).
    ����� ����������� �������� ���������� ������ � ������ � ������ ����� */
    private void Start()
    {
        CheckPlayerPrefs();
        rb = GetComponent<Rigidbody>();
        Time.timeScale = 1f;
        GameObject LevelManager = GameObject.Find("LevelManager");
        List<Part> myList = LevelManager.GetComponent<LevelStart>().parts;
        Level = PlayerPrefs.GetInt("Level");
        LevelText.text = "�������: " + Level.ToString();
        Max_Level = PlayerPrefs.GetInt("Max_Level");
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
        PlayerPrefs.SetInt("LevelsCompleted", LevelsCompleted);
        if (Levels >= Max_Level)
        {
            PlayerPrefs.SetInt("Max_Level", Level + 1);
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
