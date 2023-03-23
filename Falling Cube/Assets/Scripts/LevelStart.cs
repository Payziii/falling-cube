using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Part
{
    public string Name;
    public int Level;
    public string Description;
    public string Etap;
    public float Player;
    public float Camera;

    public override string ToString()
    {
        return $"�������� {Level} ������: {Description}, ���������� ������: {Player} � ������: {Camera}. ����: {Etap}";
    }
}

public class LevelStart : MonoBehaviour
{
    [SerializeField]
    public List<Part> parts = new List<Part>
    {
    new Part() { Description = "crank arm", Level = 1234 },
    new Part() { Description = "crank ������arm", Level = 12434 },
    new Part() { Description = "crank ���arm", Level = 12334 },
    new Part() { Description = "cr������nk arm", Level = 12634 },
    };

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}