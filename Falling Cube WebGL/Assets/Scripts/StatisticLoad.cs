using System;
using UnityEngine;
using UnityEngine.UI;

public class StatisticLoad : MonoBehaviour
{
    // ���-�� ���������� ������� � ������� (1.1)
    private int Deaths = 0;
    private int LevelsCompleted = 0;
    // �����
    [SerializeField] Text StatText;
    // ���������� bridge
    public VkBridgeController bridge;

    // ��������� �� ������� ���������� � ���� ��� ����, ���������� �� �������� (1.1)
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

    // �������� ���������� � ����� (1.1)
    public void Load()
    {
        bridge.VKWebAppStorageGet("Deaths", CheckDeaths);
    }
    
    private void Next()
    {
        StatText.text = "�������: " + Deaths.ToString() + "\n" + "�������� �������: " + LevelsCompleted.ToString();
    }
}
