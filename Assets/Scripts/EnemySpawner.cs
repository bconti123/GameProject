using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;
    // public int enemyCount = 3;
    public float spawnInterval = 2f;

    public float minX = -8f;
    public float maxX = 8f;
    public float minY = -4f;
    public float maxY = 4f;

    void Start()
    {
        // for (int i = 0; i < enemyCount; i++)
        // {
        //     Vector2 randomPosition = new Vector2(
        //         Random.Range(minX, maxX),
        //         Random.Range(minY, maxY)
        //     );

        //     GameObject enemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);

        //     EnemyFollow enemyFollow = enemy.GetComponent<EnemyFollow>();
        //     if (enemyFollow != null)
        //     {
        //         enemyFollow.target = player;
        //     }
        // }
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }
    void SpawnEnemy()
    {
        // Vector2 randomPosition = new Vector2(
        //     Random.Range(minX, maxX),
        //     Random.Range(minY, maxY)
        // );

        // GameObject enemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);

        Vector2 spawnPosition = GetRandomEdgePosition();

        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        EnemyFollow enemyFollow = enemy.GetComponent<EnemyFollow>();
        if (enemyFollow != null)
        {
            enemyFollow.target = player;
        }
    }

    Vector2 GetRandomEdgePosition()
    {
        int edge = Random.Range(0, 4);

        switch (edge)
        {
            case 0: // Top
                return new Vector2(Random.Range(minX, maxX), maxY);
            case 1: // Bottom
                return new Vector2(Random.Range(minX, maxX), minY);
            case 2: // Left
                return new Vector2(minX, Random.Range(minY, maxY));
            case 3: // Right
                return new Vector2(maxX, Random.Range(minY, maxY));
            default:
                return Vector2.zero;
        }
    }
}