// ========================================================================
// Skrip ini mengatur sistem nyawa musuh (Enemy) di game.
//
// Fitur yang dilakukan:
// - Musuh bisa terkena damage jika terkena peluru (tag: "BULLET")
// - Saat kena: musuh berkedip putih & bunyi suara hit
// - Saat mati: muncul efek ledakan + suara ledakan + objek dihancurkan
//
// Sangat cocok untuk game shooter 2D seperti side-scroller atau space shooter
// ========================================================================

using System.Collections; // ← Library C# (untuk penggunaan Coroutine)
using UnityEngine; // ← Library utama Unity

public class EnemyHealth : MonoBehaviour
{

    
    // ====== [ PENGATURAN NYAWA ] ======
    [Header("Health Settings")]
    public int maxHealth = 1;       // Maksimal nyawa musuh
    private int currentHealth;      // Nyawa sekarang (private → hanya dipakai di skrip ini)

    // ====== [ EFEK VISUAL & AUDIO ] ======
    [Header("Effects")]
    public GameObject explosionPrefab; // Prefab efek ledakan visual 💥
    public AudioClip suaraHit;         // 🔊 Suara saat kena peluru
    public AudioClip suaraLedakan;     // 🔊 Suara saat musuh mati

    private SpriteRenderer sr;         // Komponen untuk merubah warna musuh saat kena hit
    private Color originalColor;       // Warna asli musuh
    private Coroutine flashCoroutine;  // Untuk menyimpan coroutine yang berjalan

    private AudioSource audioSrc;      // Komponen pemutar audio Unity

    // === Dipanggil saat objek dibuat / diaktifkan (Unity built-in function) ===
    void Awake()
    {
        sr = GetComponentInChildren<SpriteRenderer>(); // Ambil SpriteRenderer dari anak objek
        originalColor = sr.color;                      // Simpan warna aslinya

        audioSrc = GetComponent<AudioSource>();        // Ambil komponen AudioSource di objek
    }

    // === Unity built-in function: dipanggil ulang setiap kali objek aktif (OnEnable) ===
    void OnEnable()
    {
        currentHealth = maxHealth;        // Reset nyawa ke penuh
        sr.color = originalColor;         // Reset warna ke normal
    }

    // === Unity built-in function: dipanggil saat ada objek lain menyentuh collider musuh ===
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Jika yang menyentuh musuh adalah peluru
        if (collision.CompareTag("BULLET")) // ← Fungsi built-in Unity: cek tag
        {
            TakeDamage(1);                      // Kurangi nyawa
            Destroy(collision.gameObject);      // Hancurkan peluru setelah menyentuh (Unity built-in)
        }
    }

    // === Fungsi buatan sendiri: mengurangi nyawa dan menentukan musuh mati atau tidak ===
    void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die(); // Jika nyawa habis → mati
        }
        else
        {
            OnHit(); // Jika belum mati → beri efek hit
        }
    }

    // === Fungsi buatan sendiri: efek saat musuh terkena peluru tapi belum mati ===
    public void OnHit()
    {
        // 🔊 Mainkan suara terkena peluru
        if (suaraHit != null && audioSrc != null)
        {
            audioSrc.PlayOneShot(suaraHit, 0.5f); // Unity built-in: mainkan sekali
        }

        // ✨ Flash putih singkat
        if (flashCoroutine != null)
            StopCoroutine(flashCoroutine); // Hentikan flash lama jika ada

        flashCoroutine = StartCoroutine(FlashWhite()); // Jalankan flash baru (Unity built-in)
    }

    // === Coroutine buatan sendiri: membuat musuh berkedip putih sebentar ===
    private IEnumerator FlashWhite()
    {
        sr.color = Color.white;                  // Ubah warna ke putih
        yield return new WaitForSeconds(0.1f);   // Tunggu 0.1 detik (Unity built-in)
        sr.color = originalColor;                // Kembalikan ke warna awal
    }

    // === Fungsi buatan sendiri: eksekusi saat musuh mati ===
    void Die()
    {
        // 🔊 Mainkan suara ledakan
        if (suaraLedakan != null && audioSrc != null)
        {
            audioSrc.PlayOneShot(suaraLedakan, 0.7f); // Suara lebih keras
        }

        // 💥 Tampilkan efek visual ledakan
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            // Unity built-in: buat efek baru di posisi musuh
        }

        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.AddScore(100); // Tambah 100 poin misalnya
        }
    
        Destroy(gameObject); // Unity built-in: hapus musuh dari scene
    }
}
