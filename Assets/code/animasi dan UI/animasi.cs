// =======================================================
// Skrip ini digunakan untuk mengganti sprite karakter pemain
// berdasarkan arah posisi mouse terhadap pemain.
// 
// - Jika mouse ada di atas karakter → sprite menghadap atas
// - Jika mouse ada di bawah karakter → sprite menghadap bawah
// - Jika mouse sejajar (tidak naik/turun) → sprite idle
//
// Sangat cocok untuk game top-down atau RPG yang pakai mouse aiming.
// =======================================================

using UnityEngine; // Library utama Unity yang wajib untuk semua komponen game

public class PlayerSpriteSwitcher : MonoBehaviour
{
    // Sprite untuk kondisi diam, bergerak ke atas, dan bergerak ke bawah
    public Sprite idleSprite; // Sprite default saat karakter tidak mengarah ke atas atau bawah
    public Sprite upSprite;   // Sprite saat mouse berada di atas karakter
    public Sprite downSprite; // Sprite saat mouse berada di bawah karakter

    private SpriteRenderer sr; // Komponen yang menampilkan sprite karakter di layar
    private Vector2 lastMovement = Vector2.zero; // Disiapkan untuk keperluan lanjutan (tidak dipakai di sini)

    // Fungsi Unity yang berjalan sekali saat objek diaktifkan
    void Start()
    {
        sr = GetComponent<SpriteRenderer>(); // Ambil komponen SpriteRenderer dari objek ini
        sr.sprite = idleSprite; // Atur sprite awal ke sprite idle
    }

    // Fungsi Unity yang berjalan setiap frame (real-time update)
    void Update()
    {
        // Ambil posisi mouse di dunia (bukan di layar)
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Hitung arah dari posisi player ke mouse
        Vector2 direction = (mouseWorldPos - transform.position);
        direction.Normalize(); // Ubah ke arah normal (panjang 1) supaya lebih akurat

        // Ganti sprite berdasarkan arah vertikal mouse
        if (direction.y > 0.1f) // Jika mouse berada cukup di atas karakter
        {
            sr.sprite = upSprite; // Tampilkan sprite menghadap atas
        }
        else if (direction.y < -0.1f) // Jika mouse cukup di bawah karakter
        {
            sr.sprite = downSprite; // Tampilkan sprite menghadap bawah
        }
        else // Jika mouse sejajar (tidak terlalu atas/bawah)
        {
            sr.sprite = idleSprite; // Tampilkan sprite idle
        }
    }
}
