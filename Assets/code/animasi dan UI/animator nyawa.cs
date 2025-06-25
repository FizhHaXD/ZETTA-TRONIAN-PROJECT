// ===============================================================
// Skrip ini digunakan untuk mengatur tampilan nyawa pemain 
// dalam bentuk ikon hati (♥) di layar.
// Saat pemain terkena damage:
//   - Salah satu hati akan berkedip 3 kali
//   - Lalu hati tersebut disembunyikan (hilang)
// Bisa digunakan di game platformer, action, atau RPG.
//
// Ditulis dengan struktur ringan dan bisa dipanggil dari skrip lain.
// ===============================================================

using UnityEngine; // ← Library utama Unity (untuk GameObject, MonoBehaviour, SpriteRenderer, dll)
using System.Collections; // ← Library C# bawaan .NET (untuk Coroutine / IEnumerator)

public class HeartSpriteManager : MonoBehaviour // ← MonoBehaviour adalah class dasar dari Unity untuk semua komponen skrip
{
    // ← Komponen SpriteRenderer yang menampilkan gambar hati
    // Diisi lewat Inspector dengan cara drag objek hati ke array ini
    public SpriteRenderer[] hearts;

    // Menyimpan berapa banyak nyawa yang tersisa saat ini
    private int currentHP;

    // ← Fungsi bawaan Unity, dipanggil sekali saat objek ini aktif
    void Start()
    {
        // Inisialisasi jumlah nyawa sesuai jumlah hati yang di-assign
        currentHP = hearts.Length;

        // Update tampilan hati agar semuanya terlihat di awal game
        UpdateHearts(); // ← Fungsi buatan sendiri (di bawah)
    }

    // ← Fungsi publik buatan sendiri, bisa dipanggil dari skrip lain
    // Digunakan untuk mengurangi nyawa saat terkena damage
    public void TakeDamage(int amount)
    {
        for (int i = 0; i < amount; i++) // ← Perulangan bawaan C# (built-in)
        {
            if (currentHP > 0) // ← Kondisional bawaan C#
            {
                currentHP--; // Kurangi 1 nyawa
                // Jalankan animasi hati berkedip lalu menghilang
                StartCoroutine(BlinkThenHide(hearts[currentHP])); 
                // ↑ StartCoroutine adalah fungsi bawaan Unity
            }
        }
    }

    // ← Coroutine buatan sendiri untuk memberikan efek animasi berkedip
    private IEnumerator BlinkThenHide(SpriteRenderer heart)
    {
        // Loop 3 kali: mati-nyala-mati-nyala
        for (int i = 0; i < 3; i++)
        {
            heart.enabled = false; // ← Unity built-in (menghilangkan sprite)
            yield return new WaitForSeconds(0.15f); 
            // ↑ Fungsi Unity bawaan untuk delay

            heart.enabled = true;  // Tampilkan kembali
            yield return new WaitForSeconds(0.15f);
        }

        heart.enabled = false; // Setelah selesai, hati dimatikan permanen
    }

    // ← Fungsi buatan sendiri untuk mengambil nilai HP saat ini
    public int GetCurrentHP()
    {
        return currentHP; // ← C# return value
    }

    // ← Fungsi buatan sendiri untuk menampilkan hati sesuai sisa nyawa
    private void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            // Jika index < jumlah nyawa, hati ditampilkan
            hearts[i].enabled = (i < currentHP); 
            // ← `enabled` adalah properti dari SpriteRenderer (Unity built-in)
        }
    }
}
