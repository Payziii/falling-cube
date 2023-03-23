using UnityEngine;

public class ExitGame : MonoBehaviour
{
    [SerializeField] private GameObject ExitMenu;
    void Update()
    {
        if (Input.GetKeyUp("escape"))
        {
            ExitMenu.SetActive(true);
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
