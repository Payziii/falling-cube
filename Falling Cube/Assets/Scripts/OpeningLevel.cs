using UnityEngine;
using UnityEngine.UI;

public class OpeningLevel : MonoBehaviour
{
    [SerializeField] private GameObject LevelManager;
    private int Max_Level;
    void Start()
    {
        Max_Level = PlayerPrefs.GetInt("Max_Level");
        for (int i = 1; i <= Max_Level; i++)
        {
            Button button = LevelManager.GetComponent<LevelStart>().parts.Find(p => p.Level == i).Button;
            button.interactable = true;
        }
    }
}
