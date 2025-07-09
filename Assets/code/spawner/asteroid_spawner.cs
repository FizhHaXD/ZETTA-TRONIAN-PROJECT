// ===================================================================
// Skrip ini bertugas untuk membuat asteroid muncul secara otomatis.
// Asteroid akan:
//   - Muncul dari sisi kanan layar
//   - Muncul di posisi Y acak
//   - Bergerak ke kiri dengan kecepatan acak
//   - Muncul setiap beberapa detik (interval random)
//
// Cocok untuk game space shooter atau endless game.
// ===================================================================

using UnityEngine; // ← Library utama Unity untuk akses GameObject, MonoBehaviour, Time, Rigidbody2D, dll

public class AsteroidSpawner : MonoBehaviour
{
    // Prefab asteroid yang akan dikloning saat spawn
    public GameObject asteroidPrefab;

    // Posisi vertikal tempat spawn (acak di sumbu Y)
    public float spawnRangeY = 4f;

    // Rentang kecepatan asteroid
    public float minSpeed = 1f;
    public float maxSpeed = 8f;

    // Rentang waktu antar spawn asteroid
    public float minSpawnInterval = 4f;
    public float maxSpawnInterval = 7f;

    // Waktu kapan asteroid berikutnya akan muncul
    private float nextSpawnTime = 0f;

    // Fungsi bawaan Unity → dijalankan sekali saat game mulai
    void Start()
    {
        // Mulai spawn pertama kali setelah 60 detik (bisa dianggap "fase tenang")
        nextSpawnTime = Time.time + 15f;
        // ↑ Time.time adalah built-in Unity → waktu sejak game dimulai (dalam detik)
    }

    // Fungsi bawaan Unity → dijalankan setiap frame (~60x per detik)
    void Update()
    {
        // 🔒 Jika Game Over, jangan spawn asteroid
        // GameManager.Instance → akses global (singleton), isGameOver adalah flag status game
        if (GameManager.Instance != null && GameManager.Instance.isGameOver)
            return; // Keluar dari fungsi Update (tidak spawn lagi)

        // ⏰ Jika waktu sekarang sudah melewati waktu spawn berikutnya...
        if (Time.time >= nextSpawnTime)
        {
            SpawnAsteroid(); // ← Panggil fungsi buatan sendiri untuk spawn asteroid

            // Jadwalkan waktu spawn selanjutnya secara acak (antara min dan max interval)
            nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
            // ↑ Random.Range() adalah fungsi built-in Unity untuk ambil angka acak
        }
    }

    // Fungsi buatan sendiri untuk membuat asteroid baru
    void SpawnAsteroid()
    {
        // Tentukan posisi spawn: X = 10 (kanan layar), Y = acak
        Vector3 spawnPos = new Vector3(10f, Random.Range(-spawnRangeY, spawnRangeY), 0f);

        // Buat (kloning) asteroid dari prefab di posisi tersebut
        GameObject asteroid = Instantiate(asteroidPrefab, spawnPos, Quaternion.identity);
        // ↑ Instantiate() adalah fungsi bawaan Unity untuk membuat objek baru dari prefab

        // Ambil komponen Rigidbody2D dari asteroid
        Rigidbody2D rb = asteroid.GetComponent<Rigidbody2D>();
        // ↑ GetComponent<T>() adalah fungsi built-in Unity untuk mengambil komponen dari GameObject

        if (rb != null)
        {
            // Ambil nilai kecepatan secara acak
            float randomSpeed = Random.Range(minSpeed, maxSpeed);

            // Beri kecepatan ke kiri pada asteroid
            rb.linearVelocity = new Vector2(-randomSpeed, 0f);
            // ↑ linearVelocity adalah properti dari Rigidbody2D (Unity built-in)
        }
    }
}
