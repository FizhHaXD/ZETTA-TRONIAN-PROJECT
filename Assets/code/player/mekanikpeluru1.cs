// ======================================================================
// Skrip ini digunakan untuk mengatur pergerakan peluru di game 2D.
//
// Fungsinya:
// - Peluru otomatis bergerak ke arah kanan (Vector2.right)
// - Jika peluru menyentuh objek dengan tag "Boundary", peluru akan dihancurkan
// 
// Cocok untuk game tembak-tembakan seperti space shooter atau platformer
// ======================================================================

using UnityEngine; // ← Library utama Unity

public class mekanikpeluru1 : MonoBehaviour
{
    // ====== [ VARIABEL PUBLIK UNTUK PENGATURAN ] ======
    public float kecepatan;   // Seberapa cepat peluru bergerak
    public float Pindah;      // Tidak digunakan dalam kode saat ini
    public float damage;      // Damage peluru (bisa digunakan di skrip lain)
    public float destroytime; // Tidak digunakan saat ini (bisa untuk auto-destroy)

    // === Unity built-in function: dipanggil sekali saat objek aktif pertama kali ===
    void Start()
    {
        // Saat ini kosong (bisa diisi fungsi destroy otomatis nanti)
    }

    // === Unity built-in function: dijalankan setiap frame (60x per detik) ===
    void Update()
    {
        // Gerakkan peluru ke arah kanan sesuai kecepatan
        transform.Translate(Vector2.right * kecepatan * Time.deltaTime);
        // - `transform.Translate()` = Unity built-in → memindahkan posisi objek
        // - `Vector2.right` = arah ke kanan (1, 0)
        // - `Time.deltaTime` = Unity built-in → supaya gerak tetap stabil di semua FPS
    }

    // === Unity built-in function: dipanggil saat peluru menyentuh collider lain (dengan trigger aktif) ===
    void OnTriggerEnter2D(Collider2D other)
    {
        // Jika peluru menyentuh objek dengan tag "Boundary"
        if (other.CompareTag("frame_peluru")) // Unity built-in → membandingkan tag objek
        {
            Destroy(gameObject); // Unity built-in → hancurkan peluru dari scene
        }
    }
}
