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
        return $"Описание {Level} уровня: {Description}, координаты игрока: {Player} и камеры: {Camera}. Этап: {Etap}";
    }
}

public class LevelStart : MonoBehaviour
{
    [SerializeField]
    public List<Part> parts = new List<Part>
    {
    new Part() { Description = "crank arm", Level = 1234 },
    new Part() { Description = "crank куаукаarm", Level = 12434 },
    new Part() { Description = "crank йуаarm", Level = 12334 },
    new Part() { Description = "crукаукаnk arm", Level = 12634 },
    };

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}