using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToGame : MonoBehaviour
{
    [SerializeField] private GameObject LevelManager;

    public void Click()
    {
        

        SceneManager.LoadScene("Game");
    }
}
