using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    // Окно с согласием на выход из игры
    [SerializeField] private GameObject ExitMenu;

    // Контроллер bridge (1.2)
    public VkBridgeController bridge;

    // Открытие окна при нажатии на ESC
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

    // Выход игры при подтверждении выхода (Изменено 1.2)
    public void Exit()
    {
        bridge.Send("VKWebAppJoinGroup", null, Text);
    }
}
