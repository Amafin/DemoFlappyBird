using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    private float spawnRate = 2f;
    private float heightOffset = 2.4f;

    private float timer = 0f;
    void Start()
    {
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
        //Calcul de la position aléatoire
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        float randomY = Random.Range(lowestPoint, highestPoint);

        Instantiate(pipePrefab, new Vector3(transform.position.x, randomY, 0), transform.rotation);
    }
}
