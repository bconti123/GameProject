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
        Vector2 randomPosition = new Vector2(
            Random.Range(minX, maxX),
            Random.Range(minY, maxY)
        );

        GameObject enemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);

        EnemyFollow enemyFollow = enemy.GetComponent<EnemyFollow>();
        if (enemyFollow != null)
        {
            enemyFollow.target = player;
        }
    }
}