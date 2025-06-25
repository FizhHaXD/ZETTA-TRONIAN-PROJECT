// ============================================================================
// Skrip ini berfungsi untuk menghancurkan (Destroy) objek secara otomatis
// ketika objek tersebut menyentuh area yang ditandai dengan tag "Boundary".
//
// Biasanya digunakan untuk:
// - Peluru, musuh, atau asteroid yang keluar dari layar
// - Mencegah objek tidak penting terus menumpuk di scene
//
// Skrip ini cukup sederhana dan umum digunakan dalam game 2D Unity
// ============================================================================

using UnityEngine; // ← Library utama Unity (untuk MonoBehaviour, Collider2D, Destroy, dll)

public class DESTROY : MonoBehaviour
{
    // === Unity built-in function: dijalankan sekali saat objek aktif ===
    void Start()
    {
        // Tidak ada inisialisasi khusus di sini untuk sekarang
    }

    // === Unity built-in function: dipanggil setiap frame (~60x per detik) ===
    void Update()
    {
        // Kosong → bisa dihapus jika tidak digunakan
    }

    // === Unity built-in function: dipanggil saat menyentuh Collider bertipe Trigger ===
    void OnTriggerEnter2D(Collider2D other)
    {
        // Jika objek yang disentuh memiliki tag "Boundary"
        if (other.CompareTag("Boundary")) // Unity built-in: membandingkan tag
        {
            Destroy(gameObject); // Unity built-in: menghancurkan objek ini
        }
    }
}
