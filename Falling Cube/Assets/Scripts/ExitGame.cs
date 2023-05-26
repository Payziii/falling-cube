using UnityEngine;

public class ExitGame : MonoBehaviour
{
    // Окно с согласием на выход из игры
    [SerializeField] private GameObject ExitMenu;

    // Открытие окна при нажатии на ESC
    void Update()
    {
        if (Input.GetKeyUp("escape"))
        {
            ExitMenu.SetActive(true);
        }
    }

    // Выход игры при подтверждении выхода
    public void Exit()
    {
        Application.Quit();
    }
}
