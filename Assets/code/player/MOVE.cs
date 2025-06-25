// ============================================================================
// Skrip ini digunakan untuk mengatur pergerakan objek seperti musuh, asteroid,
// atau item yang bergerak dari kanan ke kiri.
//
// Fitur skrip:
// - Objek bergerak otomatis ke kiri sesuai kecepatan
// - Saat game over, objek akan berhenti
// - Jika menyentuh objek dengan tag "Boundary", objek dihancurkan
//
// Cocok untuk game side-scroller, space shooter, atau runner.
// ============================================================================

using UnityEngine; // ← Library utama Unity

public class MOVE : MonoBehaviour
{
    // ====== [ VARIABEL PUBLIK UNTUK DISET DI INSPECTOR ] ======
    public float kecepatan;     // Seberapa cepat objek bergerak
    public float Pindah;        // Tidak dipakai di kode ini (opsional/future use)
    public float damage;        // Tidak dipakai di sini (bisa untuk sistem serang)
    public float destroytime;   // Tidak dipakai di sini (bisa untuk timer auto-destroy)

    // === Unity built-in function: dipanggil sekali saat objek diaktifkan ===
    void Start()
    {
        // Kosong saat ini, bisa dipakai untuk setup awal
    }

    // === Unity built-in function: dijalankan setiap frame (~60x per detik) ===
    void Update()
    {
        // 🔒 Cegah gerakan jika game sudah Game Over
        if (GameManager.Instance.isGameOver) // ← GameManager.Instance = akses global (singleton)
            return; // Keluar dari Update, tidak lanjut gerak

        // ⏩ Gerakkan objek ke kiri (negatif arah kanan)
        transform.Translate(Vector2.right * -kecepatan * Time.deltaTime);
        // - `transform.Translate()` = Unity built-in → untuk memindahkan posisi objek
        // - `Vector2.right` = arah ke kanan, dikali -1 artinya ke kiri
        // - `Time.deltaTime` = Unity built-in → menjaga kecepatan agar konsisten di semua FPS
    }

    // === Unity built-in function: dipanggil saat objek menyentuh collider lain (dengan isTrigger) ===
    void OnTriggerEnter2D(Collider2D other)
    {
        // Jika menyentuh objek dengan tag "Boundary"
        if (other.CompareTag("Boundary")) // Unity built-in → untuk membandingkan tag objek
        {
            Destroy(gameObject); // Unity built-in → hapus objek dari scene
        }
    }
}
