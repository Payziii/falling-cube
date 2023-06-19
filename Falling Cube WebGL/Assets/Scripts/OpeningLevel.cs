using System;
using UnityEngine;
using UnityEngine.UI;

public class OpeningLevel : MonoBehaviour
{
    [SerializeField] private GameObject LevelManager;
    private int Max_Level;

    // Контроллер bridge
    public VkBridgeController bridge;

    private void GetMaxLevel(string value)
    {
        if (value.Length != 0)
        {
            Max_Level = Convert.ToInt32(value);
        }
        else
        {
            Max_Level = 1;
        }
        Next();
    }

    // Активируем нужные кнопки, чтобы они были открыты
    void Start()
    {
        bridge.VKWebAppStorageGet("Max_Level", GetMaxLevel);
    }

    private void Next()
    {
        int l = LevelManager.GetComponent<LevelStart>().parts.Count;
        Max_Level = PlayerPrefs.GetInt("Max_Level");
        for (int i = 1; i <= Max_Level; i++)
        {
            if (i > l) return;
            Button button = LevelManager.GetComponent<LevelStart>().parts.Find(p => p.Level == i).Button;
            button.interactable = true;
        }
    }
}
