// ==========================================================================
// Skrip ini digunakan untuk membuat efek scrolling latar belakang (background).
//
// Cara kerjanya:
// - Skrip ini menggeser tampilan tekstur (UV offset) dari material objek
// - Efek yang dihasilkan: background seperti bergerak / mengalir ke kanan
//
// Sangat cocok untuk game 2D seperti space shooter, runner, atau platformer
// ==========================================================================

using UnityEngine; // ← Library utama Unity (untuk Renderer, Vector2, Time, dll)

public class BackgroundUVScroller : MonoBehaviour
{
    public float scrollSpeed = 0.1f; // Kecepatan geser background (semakin besar, semakin cepat)

    private Renderer rend;     // Komponen Renderer objek (untuk akses material)
    private Vector2 offset;    // Offset UV saat ini (diubah setiap frame)

    // === Unity built-in function: dijalankan sekali saat objek aktif pertama kali ===
    void Start()
    {
        rend = GetComponent<Renderer>(); // Ambil komponen Renderer dari objek ini
    }

    // === Unity built-in function: dijalankan setiap frame (~60x per detik) ===
    void Update()
    {
        // Tambahkan nilai offset X berdasarkan waktu dan kecepatan scroll
        offset.x += scrollSpeed * Time.deltaTime;
        // - `Time.deltaTime` = waktu antar frame → agar kecepatan tetap stabil di semua FPS

        // Terapkan offset ke material utama → menghasilkan efek background berjalan
        rend.material.mainTextureOffset = offset;
        // - `mainTextureOffset` = Unity built-in → menggeser tampilan tekstur
    }
}
