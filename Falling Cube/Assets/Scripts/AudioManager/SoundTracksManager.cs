using Unity.VisualScripting;
using UnityEngine;

public class SoundTracksManager : MonoBehaviour
{
    [SerializeField] AudioSource Sound1;
    [SerializeField] AudioSource Sound2;

    private int SelectedSound;
    private float SoundLength;

    private void TrackChange()
    {
        SelectedSound = Random.Range(0, 2);
        
        if (SelectedSound == 0 )
        {
            Sound1.Play();
            SoundLength = Sound1.clip.length;
            Invoke("TrackChange", SoundLength);
        }
        else if (SelectedSound == 1)
        {
            Sound2.Play();
            SoundLength = Sound2.clip.length;
            Invoke("TrackChange", SoundLength);
        }
    }

    private void Start()
    {
        TrackChange();
    }
}
