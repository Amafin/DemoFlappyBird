using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    private float spawnRate = 2f;

    private float minGap = 4.7f;
    private float maxGap = 6f;

    private float screenMargin = 1.5f;


    private float timer = 0f;

    private float screenTopY;
    private float screenBottomY;


    void Start()
    {
        screenTopY = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
        screenBottomY = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;

        SpawnPipe();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnPipe();
            timer = 0f;
        }
    }

    void SpawnPipe()
    {

        float gap = Random.Range(minGap, maxGap);

        float minHoleY = screenBottomY + screenMargin + (gap / 2f);
        float maxHoleY = screenTopY - screenMargin - (gap / 2f);
        float holeCenterY = Random.Range(minHoleY, maxHoleY);

        GameObject newPipes = Instantiate(pipePrefab, new Vector3(transform.position.x, holeCenterY, 0), Quaternion.identity);

        Transform top = newPipes.transform.Find("pipe-green_0_top");
        Transform bot = newPipes.transform.Find("pipe-green_0_bot");

        if (top != null)
        {
            top.localPosition = new Vector3(0, gap / 2f, 0);
        }

        if (bot != null)
        {
            bot.localPosition = new Vector3(0, -gap / 2f, 0);
        }
    }
}
