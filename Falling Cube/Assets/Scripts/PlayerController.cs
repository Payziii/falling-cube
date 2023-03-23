using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.position += new Vector3(horizontalInput, 0, 0) * speed * Time.deltaTime;
    }
}