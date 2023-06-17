using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Скорость и Rigidbody
    public float speed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Само перемещение игрока (да, такое простое)
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontalInput, 0.0f, 0.0f);

        rb.AddForce(movement * speed);
    }
}