using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToGame : MonoBehaviour
{
    [SerializeField] private GameObject LevelManager;

    // ������ ������� ����� (0.9)
    public void Click()
    {
        SceneManager.LoadScene("Game");
    }
}
