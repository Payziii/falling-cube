using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    // ���� � ��������� �� ����� �� ����
    [SerializeField] private GameObject ExitMenu;

    // ���������� bridge (1.2)
    public VkBridgeController bridge;

    // �������� ���� ��� ������� �� ESC
    void Update()
    {
        if (Input.GetKeyUp("escape"))
        {
            ExitMenu.SetActive(true);
        }
    }

    private void Text(string json)
    {
        Debug.Log(json);
    }

    // ����� ���� ��� ������������� ������ (�������� 1.2)
    public void Exit()
    {
        bridge.Send("VKWebAppJoinGroup", null, Text);
    }
}
