using System;
using Unity.VisualScripting;
using UnityEngine;

public class SoundTracksManager : MonoBehaviour
{
    [SerializeField] AudioSource[] Sounds;
    public VkBridgeController bridge;

    private int SelectedSound;
    private float SoundLength;

    private int Music = 1;

    // Проверяем на наличие переменных и если они есть, записываем их значение (1.2)
    private void CheckPlayerPrefs(string value)
    {
        if (value.Length != 0)
        {
            Music = Convert.ToInt32(value);
        }
        Next();
    }

    private void TrackChange()
    {
        SelectedSound = UnityEngine.Random.Range(0, 3);

        Sounds[SelectedSound].Play();
        SoundLength = Sounds[SelectedSound].clip.length;
        Invoke("TrackChange", SoundLength);
    }

    private void Start()
    {
        bridge.VKWebAppStorageGet("Music", CheckPlayerPrefs);
    }

    private void Next()
    {
        Debug.Log("Значение: " + Music);
        if (Music == 1)
        {
            TrackChange();
            Debug.Log("Работает");
        }
    }
}
