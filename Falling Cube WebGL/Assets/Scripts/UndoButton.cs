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
            OpenedMenu.SetActive(true);
            ClosedMenu.SetActive(false);
        }
    }
}
