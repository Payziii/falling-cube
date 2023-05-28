using UnityEngine;
using UnityEngine.UI;

public class StatisticLoad : MonoBehaviour
{
    // ���-�� ���������� ������� � ������� (1.1)
    private int Deaths = 0;
    private int LevelsCompleted = 0;
    // �����
    [SerializeField] Text StatText;

    // ��������� �� ������� ���������� � ���� ��� ����, ���������� �� �������� (1.1)
    private void CheckPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("Deaths"))
        {
            Deaths = PlayerPrefs.GetInt("Deaths");
        }
        if (PlayerPrefs.HasKey("LevelsCompleted"))
        {
            LevelsCompleted = PlayerPrefs.GetInt("LevelsCompleted");
        }
    }

    // �������� ���������� � ����� (1.1)
    public void Load()
    {
        CheckPlayerPrefs();
        StatText.text = "�������: " + Deaths.ToString() + "\n" + "�������� �������: " + LevelsCompleted.ToString();
    }
}
