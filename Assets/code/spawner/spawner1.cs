// =====================================================================
// 🎯 Skrip ini digunakan untuk men-spawn musuh secara bertahap per "wave"
//
// 🔥 FITUR:
// - Jumlah musuh makin banyak setiap wave
// - Kecepatan musuh makin cepat seiring wave
// - Interval spawn makin pendek (semakin sulit)
// =====================================================================

using UnityEngine; // ✅ Built-in Unity: untuk akses semua komponen game, objek, physics, transform, dll

public class EnemyWaveSpawner : MonoBehaviour
{
    // ============================ [PENGATURAN MUSUH] ============================
    [Header("Enemy Settings")]
    public GameObject enemyPrefab;        // 🔧 Prefab musuh yang akan di-spawn
    public float baseSpawnInterval = 2f;  // 🕒 Jarak waktu spawn antar musuh awal (detik)
    public float waveInterval = 60f;      // ⏳ Waktu untuk naik ke wave selanjutnya (detik)

    // ============================ [PENINGKATAN KESELAMATAN] ============================
    [Header("Kesulitan Bertahap")]
    public int baseEnemyPerSpawn = 1;       // 📦 Jumlah musuh per spawn di wave awal
    public float enemySpeedIncrement = 0.5f; // 🚀 Tambahan kecepatan musuh setiap wave
    public float minSpawnInterval = 0.3f;    // ⛔ Batas minimum waktu spawn (jangan terlalu cepat)

    // ============================ [VARIABEL INTERNAL] ============================
    private float spawnTimer = 0f;            // ⏲️ Timer untuk spawn musuh
    private float waveTimer = 0f;             // ⏲️ Timer untuk pergantian wave
    private float currentSpawnInterval;       // 🔁 Interval saat ini antar spawn
    private int currentWave = 1;              // 🔢 Wave saat ini
    private int enemyPerSpawn;                // 👾 Jumlah musuh per spawn saat ini

    // 🔁 Fungsi bawaan Unity — dijalankan sekali saat game dimulai
    void Start()
    {
        currentSpawnInterval = baseSpawnInterval;  // Set interval spawn awal
        enemyPerSpawn = baseEnemyPerSpawn;         // Set jumlah musuh per spawn awal
    }

    // 🔁 Fungsi bawaan Unity — dijalankan setiap frame
    void Update()
    {
        // ⛔ Jika game over, hentikan semua proses spawn
        if (GameManager.Instance != null && GameManager.Instance.isGameOver)
            return;

        // ⏱️ Timer untuk spawn musuh
        spawnTimer += Time.deltaTime; // Tambah waktu sesuai real time
        if (spawnTimer >= currentSpawnInterval) // Kalau waktunya spawn
        {
            SpawnEnemy();           // Panggil fungsi spawn
            spawnTimer = 0f;        // Reset timer spawn
        }

        // ⏱️ Timer untuk pergantian wave
        waveTimer += Time.deltaTime;
        if (waveTimer >= waveInterval) // Kalau sudah waktunya naik wave
        {
            AdvanceWave();          // Naik level wave
            waveTimer = 0f;         // Reset timer wave
        }
    }

    // 📦 Fungsi untuk spawn musuh
    void SpawnEnemy()
    {
        for (int i = 0; i < enemyPerSpawn; i++) // Loop sesuai jumlah musuh per spawn
        {
            // 🎯 Posisi spawn musuh secara horizontal tetap, tapi vertikal acak
            Vector3 spawnPos = new Vector3(8.5f, Random.Range(-4f, 4f), 0f);

            // 🧠 Buat objek musuh dari prefab
            GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

            // 💨 Atur kecepatan musuh berdasarkan wave sekarang
            Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>(); // Ambil Rigidbody musuh
            if (rb != null)
            {
                float speed = 2f + (currentWave * enemySpeedIncrement); // Kecepatan dasar + tambahan per wave
                rb.linearVelocity = new Vector2(-speed, 0f); // Musuh bergerak ke kiri
            }
        }
    }

    // ⬆️ Fungsi untuk naik ke wave selanjutnya
    void AdvanceWave()
    {
        currentWave++;            // Tambah nomor wave
        enemyPerSpawn++;          // Tambah jumlah musuh per spawn

        // Kurangi waktu spawn supaya lebih cepat, tapi tidak boleh kurang dari minSpawnInterval
        currentSpawnInterval = Mathf.Max(minSpawnInterval, currentSpawnInterval - 0.2f);

        // 🔊 Cetak informasi wave ke Console Unity
        Debug.Log($"🔥 Wave {currentWave} DIMULAI → Spawn x{enemyPerSpawn}, Interval: {currentSpawnInterval:F2}s");
    }
}
