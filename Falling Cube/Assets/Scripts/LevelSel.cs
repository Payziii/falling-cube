using UnityEngine;
using UnityEngine.UI;

public class LevelSel : MonoBehaviour
{
    //����������� ��� ������� ������
    [SerializeField] private int Level;

    //����� ��� ���� �������
    [SerializeField] private GameObject LevelManager;
    [SerializeField] private GameObject LevelPanel;
    [SerializeField] private Text LevelName;
    [SerializeField] private Text Etap;
    [SerializeField] private Text Description;

    // ����� ���������� �� ������
    public void Click()
    {
        string Desc = LevelManager.GetComponent<LevelStart>().parts.Find(p => p.Level == Level).Description;
        string EtapLevel = LevelManager.GetComponent<LevelStart>().parts.Find(p => p.Level == Level).Etap;
        LevelName.text = Level.ToString() + " �������";
        Etap.text = "����: " + EtapLevel;
        Description.text = "��������: " + Desc;
        LevelPanel.SetActive(true);
        PlayerPrefs.SetInt("Level", Level);
    }
}
