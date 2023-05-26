using UnityEngine;
using UnityEngine.UI;

public class LevelSel : MonoBehaviour
{
    //Указываются для каждого уровня
    [SerializeField] private int Level;

    //Общие для всех уровней
    [SerializeField] private GameObject LevelManager;
    [SerializeField] private GameObject LevelPanel;
    [SerializeField] private Text LevelName;
    [SerializeField] private Text Etap;
    [SerializeField] private Text Description;

    // Вывод информации об уровне
    public void Click()
    {
        string Desc = LevelManager.GetComponent<LevelStart>().parts.Find(p => p.Level == Level).Description;
        string EtapLevel = LevelManager.GetComponent<LevelStart>().parts.Find(p => p.Level == Level).Etap;
        LevelName.text = Level.ToString() + " уровень";
        Etap.text = "Этап: " + EtapLevel;
        Description.text = "Описание: " + Desc;
        LevelPanel.SetActive(true);
        PlayerPrefs.SetInt("Level", Level);
    }
}
