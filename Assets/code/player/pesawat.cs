// ==============================================================================
// Skrip ini dipasang pada pesawat pemain.
//
// Fungsi utama:
// - Menggerakkan pesawat mengikuti posisi mouse
// - Menerima damage saat terkena asteroid atau musuh
// - Menampilkan HP dengan ikon hati (HeartSpriteManager)
// - Ketika HP habis, pesawat dihancurkan dan game over
//
// Cocok untuk game top-down shooter atau space shooter
// ==============================================================================

using UnityEngine; // ← Library utama Unity

public class pesawat : MonoBehaviour
{
    // ====== [ PENGATURAN PESAWAT & NYAWA ] ======
    public float kecepatan = 50f;          // Seberapa cepat pesawat mengikuti mouse
    public int maxHP = 3;                  // Jumlah maksimal nyawa
    private int currentHP;                 // Nyawa saat ini (private → internal)

    // public float invincibilityDuration = 1f; // Durasi kebal setelah terkena hit (belum digunakan aktif)
    // private bool isInvincible = false;       // Apakah pesawat sedang kebal?

    public HeartSpriteManager heartUI;       // Referensi ke UI nyawa (pakai sprite hati)

    Rigidbody2D rb; // Komponen fisika Unity untuk menggerakkan pesawat dengan smooth

    // === Unity built-in function: dijalankan sekali saat objek dibuat ===
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // Ambil komponen Rigidbody2D dari objek
        currentHP = maxHP;                // Set nyawa awal = maksimal
    }

    // === Unity built-in function: dipanggil setiap frame fisika (lebih stabil dari Update) ===
    void FixedUpdate()
    {
        // Ambil posisi mouse di dunia game
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Buat vektor target hanya X dan Y (Z dibuang karena 2D)
        Vector2 targetPos = new Vector2(mousePos.x, mousePos.y);

        // Gerakkan pesawat secara smooth ke arah posisi mouse
        rb.MovePosition(Vector2.Lerp(rb.position, targetPos, kecepatan * Time.fixedDeltaTime));
        // - Lerp() = fungsi Unity → transisi halus antara dua titik
        // - MovePosition() = Unity built-in Rigidbody2D → menggerakkan objek secara fisik
    }

    // === Fungsi buatan sendiri: mengurangi nyawa dan mengecek kematian ===
    public void TakeDamage(int amount)
    {
        // if (isInvincible) return; // Jika kebal, abaikan damage

        currentHP -= amount;
        Debug.Log("Pesawat kena! Sisa HP: " + currentHP);

        if (currentHP <= 0)
        {
            Die(); // Mati kalau HP habis
        }

        // [CATATAN] Kamu bisa tambahkan efek visual, suara, atau invincibility di sini
    }

    // === Fungsi buatan sendiri: saat pesawat mati ===
    void Die()
    {
        Debug.Log("Pesawat Hancur!");

        GameManager.Instance.GameOver(); // Akses GameManager untuk memicu Game Over
        Destroy(gameObject);             // Hancurkan pesawat dari scene
    }

    // === Unity built-in function: saat bersentuhan dengan Collider yang di-tag tertentu ===
   void OnTriggerEnter2D(Collider2D other)
    {
    if (other.CompareTag("asteroid") || other.CompareTag("enemy") || other.CompareTag("enemy_bullet"))
        {
            heartUI.TakeDamage(1);

            if (heartUI.GetCurrentHP() <= 0)
            {
                Die();
            }

        Destroy(other.gameObject);
        }
    }

}
