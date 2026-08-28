using UnityEngine;
using UnityEngine.InputSystem;

public class BirdMov : MonoBehaviour
{
    private Rigidbody2D rb;
    private float jumpForce = 5f;

    private void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            rb.linearVelocity = Vector2.up * jumpForce;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision avec : " + collision.gameObject.name);
    }
    
}
