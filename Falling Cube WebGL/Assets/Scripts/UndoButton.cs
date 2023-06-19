using UnityEngine;

public class UndoButton : MonoBehaviour
{
    // ������ ������� ��� ����������� � ������ ���� �� ������� ESC
    [SerializeField] private GameObject ClosedMenu;
    [SerializeField] private GameObject OpenedMenu;
    [SerializeField] private bool UsingLoading;
    [SerializeField] private GameObject LoadingPanel;

    // ���� �����������
    void Update()
    {
        if (Input.GetKeyUp("escape"))
        {
            if (LoadingPanel.activeInHierarchy == true && UsingLoading == true) return;
            OpenedMenu.SetActive(true);
            ClosedMenu.SetActive(false);
        }
    }
}
