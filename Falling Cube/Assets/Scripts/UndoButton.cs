using UnityEngine;

public class UndoButton : MonoBehaviour
{
    [SerializeField] private GameObject ClosedMenu;
    [SerializeField] private GameObject OpenedMenu;
    [SerializeField] private GameObject ExitScript;
    void Update()
    {
        if (Input.GetKeyUp("escape"))
        {
            OpenedMenu.SetActive(true);
            ClosedMenu.SetActive(false);
            
            
        }
    }
}
