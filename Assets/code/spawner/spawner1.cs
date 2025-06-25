// =====================================================================
// Skrip ini digunakan untuk men-spawn musuh secara bertahap (per wave).
//
// Fitur tambahan:
// - Makin banyak musuh muncul per wave
// - Kecepatan musuh naik seiring wave
// - Interval spawn makin cepat (lebih agresif)
// =====================================================================

using UnityEngine;

public class EnemyWaveSpawner : MonoBehaviour
{
    [Header("Enemy Settings")]
    public GameObject enemyPrefab;
    public float baseSpawnInterval = 2f;
    public float waveInterval = 60f;

    [Header("Kesulitan Bertahap")]
    public int baseEnemyPerSpawn = 1;       // Musuh awal per spawn
    public float enemySpeedIncrement = 0.5f; // Penambahan kecepatan musuh tiap wave
    public float minSpawnInterval = 0.3f;    // Batas minimum spawn interval

    private float spawnTimer = 0f;
    private float waveTimer = 0f;
    private float currentSpawnInterval;
    private int currentWave = 1;
    private int enemyPerSpawn;              // Jumlah musuh per spawn saat ini

    void Start()
    {
        currentSpawnInterval = baseSpawnInterval;
        enemyPerSpawn = baseEnemyPerSpawn;
    }

    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.isGameOver)
            return;

        spawnTimer += Time.deltaTime;
        if (spawnTimer >= currentSpawnInterval)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }

        waveTimer += Time.deltaTime;
        if (waveTimer >= waveInterval)
        {
            AdvanceWave();
            waveTimer = 0f;
        }
    }

    void SpawnEnemy()
    {
        for (int i = 0; i < enemyPerSpawn; i++)
        {
            Vector3 spawnPos = new Vector3(8.5f, Random.Range(-4f, 4f), 0f);
            GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

            // Tambah kecepatan musuh sesuai wave
            Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                float speed = 2f + (currentWave * enemySpeedIncrement); // Semakin tinggi wave, semakin cepat
                rb.linearVelocity = new Vector2(-speed, 0f);
            }
        }
    }

    void AdvanceWave()
    {
        currentWave++;
        enemyPerSpawn++; // Tambah jumlah musuh per spawn
        currentSpawnInterval = Mathf.Max(minSpawnInterval, currentSpawnInterval - 0.2f);

        Debug.Log($"🔥 Wave {currentWave} DIMULAI → Spawn x{enemyPerSpawn}, Interval: {currentSpawnInterval:F2}s");
    }
}
