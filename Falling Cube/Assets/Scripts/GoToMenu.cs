using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenu : MonoBehaviour
{
    [SerializeField] private GameObject LevelManager;

    public void Click()
    {
        SceneManager.LoadScene("Menu");
    }
}

