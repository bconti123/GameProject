using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;
    public float spawnInterval = 2f;

    public float minX = -8f;
    public float maxX = 8f;
    public float minY = -4f;
    public float maxY = 4f;

    public float speedIncrease = 0.2f;

    public float minDistanceFromPlayer = 2.5f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
        InvokeRepeating(nameof(IncreaseAllEnemiesSpeed), 5f, 5f);
    }

    void SpawnEnemy()
    {
        Vector2 spawnPosition = GetValidSpawnPosition();

        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        EnemyFollow enemyFollow = enemy.GetComponent<EnemyFollow>();
        if (enemyFollow != null)
        {
            enemyFollow.target = player;
        }
    }

    Vector2 GetValidSpawnPosition()
    {
        Vector2 spawnPosition;
        int maxAttempts = 10;

        for (int i = 0; i < maxAttempts; i++)
        {
            spawnPosition = GetRandomEdgePosition();

            if (Vector2.Distance(spawnPosition, player.position) >= minDistanceFromPlayer)
            {
                return spawnPosition;
            }
        }

        // fallback (if somehow all attempts fail)
        return GetRandomEdgePosition();
    }

    void IncreaseAllEnemiesSpeed()
    {
        EnemyFollow[] enemies = FindObjectsOfType<EnemyFollow>();

        foreach (EnemyFollow enemy in enemies)
        {
            enemy.IncreaseSpeed(speedIncrease);
        }
    }

    Vector2 GetRandomEdgePosition()
    {
        int edge = Random.Range(0, 4);

        switch (edge)
        {
            case 0: return new Vector2(Random.Range(minX, maxX), maxY);
            case 1: return new Vector2(Random.Range(minX, maxX), minY);
            case 2: return new Vector2(minX, Random.Range(minY, maxY));
            case 3: return new Vector2(maxX, Random.Range(minY, maxY));
            default: return Vector2.zero;
        }
    }
}