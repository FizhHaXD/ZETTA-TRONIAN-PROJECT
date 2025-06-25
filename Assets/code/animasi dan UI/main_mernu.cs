// ============================================================================
// Skrip ini digunakan untuk membuat tombol menu utama,
// seperti tombol "New Game" dan "Exit" di game.
//
// Cara kerja:
// - Ketika objek tombol di-klik (pakai collider + event `OnMouseDown()`),
//   skrip akan mendeteksi jenis tombol (NewGame atau Exit)
// - Jika NewGame → masuk ke scene game utama
// - Jika Exit → keluar dari aplikasi
//
// Cocok untuk game menu berbasis UI atau objek 3D dengan collider
// ============================================================================

using UnityEngine;              // ← Library utama Unity (untuk MonoBehaviour, Input, Application)
using UnityEngine.SceneManagement; // ← Unity Engine (untuk berpindah scene)

public class MenuButton : MonoBehaviour
{
    // Buat pilihan tipe tombol: apakah tombol ini untuk mulai game atau keluar
    public enum ButtonType { NewGame, Exit } // ← Enum (fitur C#) untuk membedakan jenis tombol
    public ButtonType buttonType; // Diset di Inspector: apakah ini tombol NewGame atau Exit

    // === Unity built-in function: dipanggil saat objek diklik (mouse down) ===
    void OnMouseDown()
    {
        // Jika tombol ini bertipe NewGame → pindah ke scene utama
        if (buttonType == ButtonType.NewGame)
        {
            SceneManager.LoadScene("MainGame"); 
            // `SceneManager.LoadScene()` = Unity built-in → untuk berpindah ke scene lain
        }
        // Jika tombol ini bertipe Exit → keluar dari aplikasi
        else if (buttonType == ButtonType.Exit)
        {
            Application.Quit(); // Unity built-in → keluar dari game
            Debug.Log("Keluar dari game."); // Muncul di Console (tidak terlihat saat build kecuali di desktop)
        }
    }
}
