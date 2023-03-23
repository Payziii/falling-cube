using UnityEngine;
using System.Collections.Generic;

public class LevelOpen : MonoBehaviour
{
    [SerializeField] GameObject CameraObject;
    [SerializeField] GameObject PlayerObject;
    private int Level;
    private void Start()
    {
        GameObject LevelManager = GameObject.Find("LevelManager");
        List<Part> myList = LevelManager.GetComponent<LevelStart>().parts;
        Level = PlayerPrefs.GetInt("Level");
        float Player = LevelManager.GetComponent<LevelStart>().parts.Find(p => p.Level == Level).Player;
        float Camera = LevelManager.GetComponent<LevelStart>().parts.Find(p => p.Level == Level).Camera;

        CameraObject.transform.position = new Vector3(CameraObject.transform.position.x, Camera, CameraObject.transform.position.z);
        PlayerObject.transform.position = new Vector3(PlayerObject.transform.position.x, Player, PlayerObject.transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            GameObject LevelManager = GameObject.Find("LevelManager");
            List<Part> myList = LevelManager.GetComponent<LevelStart>().parts;
            float Player = LevelManager.GetComponent<LevelStart>().parts.Find(p => p.Level == Level+1).Player;
            float Camera = LevelManager.GetComponent<LevelStart>().parts.Find(p => p.Level == Level+1).Camera;

            CameraObject.transform.position = new Vector3(CameraObject.transform.position.x, Camera, CameraObject.transform.position.z);
            PlayerObject.transform.position = new Vector3(PlayerObject.transform.position.x, Player, PlayerObject.transform.position.z);
            PlayerPrefs.SetInt("Max_Level", Level + 1);
            Level++;
        }
    }

}
