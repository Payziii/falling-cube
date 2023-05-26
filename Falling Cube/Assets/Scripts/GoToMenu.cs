using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenu : MonoBehaviour
{
    [SerializeField] private GameObject LevelManager;

    // Открытие меню, например при смерти
    public void Click()
    {
        SceneManager.LoadScene("Menu");
    }
}

