// Mengimpor library utama Unity
using UnityEngine; // Untuk fitur dasar seperti GameObject, MonoBehaviour, Debug.Log
using UnityEngine.SceneManagement; // Untuk berpindah antar scene (misalnya kembali ke menu utama)
using TMPro; // Untuk menangani teks UI dengan TextMeshPro (teks modern di Unity)

// GameManager: mengatur logika utama game seperti Game Over dan kembali ke menu
public class GameManager : MonoBehaviour
{
    // Singleton pattern — membuat GameManager bisa diakses dari skrip lain melalui GameManager.Instance
    public static GameManager Instance;

    [Header("Game Over UI")] // Label di Inspector untuk memudahkan pengelompokan
    public GameObject gameOverText; // Objek teks UI "Game Over", dihubungkan dari Inspector

    [HideInInspector] // Menyembunyikan variabel ini dari Inspector karena tidak perlu diubah manual
    public bool isGameOver = false; // Menandakan apakah game sudah berakhir

    // Fungsi bawaan Unity yang otomatis dijalankan saat GameObject aktif pertama kali
    void Awake()
    {
        // Menyimpan referensi GameManager ke variabel static Instance
        Instance = this;
    }

    // Fungsi publik yang bisa dipanggil dari skrip lain saat game berakhir (misalnya saat player mati)
    public void GameOver()
    {
        // Cegah pemanggilan ulang jika game sudah dalam status Game Over
        if (!isGameOver)
        {
            isGameOver = true; // Set status Game Over jadi true
            Debug.Log("GAME OVER"); // Tampilkan log di Console (untuk debugging)

            // Jika objek teks "Game Over" sudah disambungkan di Inspector, aktifkan/tampilkan
            if (gameOverText != null)
                gameOverText.SetActive(true);

            // Jalankan coroutine untuk kembali ke menu utama setelah delay 5 detik
            StartCoroutine(ReturnToMainMenu());
        }
    }

    // Coroutine: fungsi yang bisa menunggu beberapa detik tanpa menghentikan seluruh game
    private System.Collections.IEnumerator ReturnToMainMenu()
    {
        yield return new WaitForSeconds(5f); // Tunggu 5 detik
        SceneManager.LoadScene("main menu"); // Ganti scene ke "main menu" (nama scene bisa disesuaikan)
    }
}
