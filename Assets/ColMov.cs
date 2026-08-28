using UnityEngine;

public class ColMov : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 4f;
    private float leftLimit = -15f;

    private void Update()
    {
        transform.position += (Vector3.left * speed) * Time.deltaTime;

        if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        }
    }

}
