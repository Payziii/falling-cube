using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenManager : MonoBehaviour
{
    // Метод, который включает полноэкранный режим (1.1)
    public void Full()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
