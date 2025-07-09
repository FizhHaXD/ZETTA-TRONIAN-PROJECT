// ============================================================================
// 🎯 SKRIP INI MENGATUR SISTEM SKOR UNTUK GAME
//
// Fungsi utama:
// - Menyimpan nilai skor
// - Menampilkan skor ke layar dengan TextMeshPro
// - Bisa diakses global lewat Singleton
// ============================================================================

using TMPro;              // ✅ Import library TextMeshPro milik Unity (untuk teks UI)
using UnityEngine;        // ✅ Import library utama Unity (harus ada di semua skrip MonoBehaviour)

public class ScoreManager : MonoBehaviour  // 🔧 Turunan dari MonoBehaviour = bisa dipasang ke GameObject
{
    // 🟡 Singleton: biar skrip ini bisa dipanggil dari mana saja
    public static ScoreManager Instance;   

    // 🟡 Variabel untuk menyimpan skor saat ini
    public int currentScore = 0;

    // 🟡 Komponen TextMeshProUGUI untuk menampilkan skor di layar UI
    public TextMeshProUGUI scoreText;

    // 🔁 Fungsi bawaan Unity: dijalankan pertama kali saat GameObject ini aktif
    void Awake()
    {
        // 🟡 Cek apakah instance Singleton masih kosong, lalu isi
        if (Instance == null)
        {
            Instance = this;
        }
        // (Catatan: Tidak ada else, artinya kalau sudah ada instance sebelumnya, ini diabaikan)
    }

    // 🔁 Fungsi bawaan Unity: dijalankan sekali saat game dimulai
    void Start()
    {
        // 🟡 Perbarui tampilan skor awal di layar (biasanya 0)
        UpdateScoreText();
    }

    // 🟢 Fungsi publik untuk menambah skor
    public void AddScore(int amount)
    {
        currentScore += amount;  // Tambahkan nilai skor
        UpdateScoreText();       // Perbarui tampilan teks skor di UI
    }

    // 🔒 Fungsi privat untuk memperbarui tampilan teks skor
    void UpdateScoreText()
    {
        if (scoreText != null)   // 🛡️ Cek apakah komponen teks sudah diisi
        {
            // 🟢 Ganti isi teks menjadi: "Score: [angka skor]"
            scoreText.text = "Score: " + currentScore;
        }
    }

    // 🟢 Fungsi publik untuk mereset skor ke 0 (misalnya saat ulang game)
    public void ResetScore()
    {
        currentScore = 0;        // Atur skor menjadi 0
        UpdateScoreText();       // Tampilkan skor 0 ke layar
    }
}
