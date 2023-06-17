using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DisableMusic : MonoBehaviour
{
    [SerializeField] private Toggle music;
    private int Music = 1;

    // Проверяем на наличие переменных и если они есть, записываем их значение (1.2)
    private void CheckPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("Music"))
        {
            Music = PlayerPrefs.GetInt("Music");
        }
    }

    private void Start()
    {
        CheckPlayerPrefs();
        music.isOn = Music == 1;
    }

    public void Click()
    {
        int on = Convert.ToInt32(music.isOn);
        PlayerPrefs.SetInt("Music", on);
        Debug.Log(on);
    }
}
