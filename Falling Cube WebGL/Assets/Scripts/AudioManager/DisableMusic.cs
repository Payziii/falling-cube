using System;
using UnityEngine;
using UnityEngine.UI;

public class DisableMusic : MonoBehaviour
{
    [SerializeField] private Toggle music;
    [SerializeField] private GameObject LoadingPanel;
    public VkBridgeController bridge;
    private int Music = 1;

    // ��������� �� ������� ���������� � ���� ��� ����, ���������� �� �������� (1.2)
    private void CheckPlayerPrefs(string value)
    {
        if (value.Length != 0)
        {
            Music = Convert.ToInt32(value);
        }
        Next();
    }

    private void Start()
    {
        bridge.VKWebAppStorageGet("Music", CheckPlayerPrefs);
    }

    private void Next()
    {
        music.isOn = Music == 1;
        LoadingPanel.SetActive(false);
    }

    public void Click()
    {
        int on = Convert.ToInt32(music.isOn);
        bridge.VKWebAppStorageSet("Music", on.ToString());
        Debug.Log(on);
    }
}
