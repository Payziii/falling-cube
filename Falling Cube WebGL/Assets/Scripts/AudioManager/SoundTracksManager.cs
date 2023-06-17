using Unity.VisualScripting;
using UnityEngine;

public class SoundTracksManager : MonoBehaviour
{
    [SerializeField] AudioSource[] Sounds;

    private int SelectedSound;
    private float SoundLength;

    private int Music = 1;

    // ��������� �� ������� ���������� � ���� ��� ����, ���������� �� �������� (1.2)
    private void CheckPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("Music"))
        {
            Music = PlayerPrefs.GetInt("Music");
        }
    }

    private void TrackChange()
    {
        SelectedSound = Random.Range(0, 3);

        Sounds[SelectedSound].Play();
        SoundLength = Sounds[SelectedSound].clip.length;
        Invoke("TrackChange", SoundLength);
    }

    private void Start()
    {
        CheckPlayerPrefs();
        Debug.Log("��������: " + Music);
        if (Music == 1)
        {
            TrackChange();
            Debug.Log("��������");
        }
    }
}
