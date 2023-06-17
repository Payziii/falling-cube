using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject DeathPanel;

    // �������� ����� ����� (�������� ���� ��� ������) (1.0, �������� 1.2)
    public void GoToScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    // ������� ������ � ������� ����� ���������� (�������� ���� ���� ���������� ������) (1.2)
    public void ClosePanel(GameObject Panel)
    {
        Time.timeScale = 1f;
        Panel.SetActive(false);
    }

    // ������� ������ ����� ��� ������� ESC (1.2)
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

