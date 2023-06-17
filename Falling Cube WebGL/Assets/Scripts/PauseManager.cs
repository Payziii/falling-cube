using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject DeathPanel;

    // Открытие любой сцены (например меню при смерти) (1.0, Изменено 1.2)
    public void GoToScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    // Закрыть панель и сделать время нормальным (например если надо продолжить играть) (1.2)
    public void ClosePanel(GameObject Panel)
    {
        Time.timeScale = 1f;
        Panel.SetActive(false);
    }

    // Открыть панель паузы при нажатии ESC (1.2)
    void Update()
    {
        if (Input.GetKeyUp("escape"))
        {
            if(!DeathPanel.activeInHierarchy)
            {
                PausePanel.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
}

