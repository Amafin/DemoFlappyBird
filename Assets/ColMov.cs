using UnityEngine;

public class ColMov : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 3f;
    private float leftLimit = -15f;

    public Transform topPipe;
    public Transform botPipe;

    private float minGap = 5.5f;
    private float maxGap = 8f;


    void Start()
    {
        float gap = Random.Range(minGap, maxGap);

        if (topPipe != null && botPipe != null)
        {
            topPipe.localPosition = new Vector3(0, gap / 2f, 0);
            botPipe.localPosition = new Vector3(0, -gap / 2f, 0);
        }
    }

    private void Update()
    {
        transform.position += (Vector3.left * speed) * Time.deltaTime;

        if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        }
    }

}
