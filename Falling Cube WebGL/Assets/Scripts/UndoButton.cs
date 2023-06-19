using UnityEngine;

public class UndoButton : MonoBehaviour
{
    // Важные объекты для возвращения в нужное меню по нажатии ESC
    [SerializeField] private GameObject ClosedMenu;
    [SerializeField] private GameObject OpenedMenu;
    [SerializeField] private bool UsingLoading;
    [SerializeField] private GameObject LoadingPanel;

    // Само перемещение
    void Update()
    {
        if (Input.GetKeyUp("escape"))
        {
            OpenedMenu.SetActive(true);
            ClosedMenu.SetActive(false);
        }
    }
}
