// ====================================================================
// Skrip ini digunakan untuk efek ledakan (Explosion).
// Saat animasi ledakan selesai diputar, objek ledakan akan otomatis dihancurkan.
// Ini membuat ledakan hanya muncul sebentar, lalu hilang sendiri.
//
// Cara kerjanya:
//   - Fungsi `DestroySelf()` dipanggil oleh Animation Event di akhir animasi
// ====================================================================

using UnityEngine; // ← Library utama Unity

public class ExplosionEffect : MonoBehaviour
{
    // ← Fungsi buatan sendiri yang akan menghancurkan objek ini
    // Fungsi ini DIPANGGIL lewat Animation Event di akhir animasi ledakan
    public void DestroySelf()
    {
        Destroy(gameObject); // ← Built-in Unity → Menghapus GameObject ini dari scene
    }
}
