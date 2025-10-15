using UnityEngine;

public class SpawnManager : MonoBehaviour {
    [SerializeField] float spawnDistanceMax;
    [SerializeField] float spawnEnemyChancePerSecond;
    [SerializeField] float spawnPowerUpChancePerSecond;
    [SerializeField] EnemyController enemyPrefab;
    [SerializeField] GameObject powerUpPrefab;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        var randomSpawn = Random.Range(0f, 1f);
        if (randomSpawn <= spawnEnemyChancePerSecond * Time.deltaTime) {
            var position = GetSpawnPosition();
            Instantiate(enemyPrefab, position, Quaternion.identity);
        }

        if (randomSpawn <= spawnPowerUpChancePerSecond * Time.deltaTime) {
            var position = GetSpawnPosition();
            Instantiate(powerUpPrefab, position, Quaternion.identity);
        }
    }

    Vector3 GetSpawnPosition() {
        return new Vector3(Random.Range(0f, spawnDistanceMax), 0, Random.Range(0f, spawnDistanceMax));
    }
}
