using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenManager : MonoBehaviour
{
    // �����, ������� �������� ������������� ����� (1.1)
    public void Full()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
