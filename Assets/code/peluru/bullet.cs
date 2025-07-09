// ============================================================================
// 🎯 SKRIP INI UNTUK: Sistem Upgrade Peluru dari 1 arah menjadi 3 arah
//
// ➕ FITUR UTAMA:
// - Pemain awalnya hanya bisa menembak 1 peluru lurus
// - Setelah "upgrade" (misalnya setelah hancurkan asteroid), berubah jadi 3 arah
// - Menggunakan Singleton agar bisa dipanggil dari skrip lain
// ============================================================================

using UnityEngine; // ← Built-in Unity Engine (dibutuhkan untuk semua komponen di scene)

public class PlayerBulletUpgrade : MonoBehaviour
{
    // 🔁 Singleton: membuat instance global agar mudah dipanggil dari skrip lain
    public static PlayerBulletUpgrade Instance;

    [Header("Referensi Prefab Peluru")]
    public GameObject peluruBiasa;      // Prefab peluru awal (hanya lurus ke depan)
    public GameObject peluruUpgrade;    // Prefab peluru upgrade (3 arah)

    [Header("Titik Tembak")]
    public Transform titikTembak;       // Titik di mana peluru muncul saat ditembakkan

    [Header("Pengaturan Tembakan")]
    public float fireRate = 0.2f;       // Waktu jeda antara setiap tembakan (semakin kecil = semakin cepat)
    public AudioClip suaraTembak;       // Efek suara saat peluru ditembakkan

    private AudioSource audioSrc;       // Komponen audio dari GameObject ini
    private float fireCooldown = 0f;    // Cooldown tembak agar tidak spam terus
    private bool isUpgraded = false;    // Apakah peluru sudah di-upgrade atau belum?

    // 🔁 Dipanggil sekali saat objek pertama kali hidup
    void Awake()
    {
        Instance = this; // Set Singleton agar bisa dipanggil dari skrip lain: PlayerBulletUpgrade.Instance
    }

    // 🔁 Dipanggil sekali saat mulai scene
    void Start()
    {
        audioSrc = GetComponent<AudioSource>(); // Ambil komponen suara dari game object pemain
    }

    // 🔁 Dipanggil setiap frame
    void Update()
    {
        fireCooldown -= Time.deltaTime; // Kurangi timer cooldown berdasarkan waktu nyata

        // 🖱️ Kalau klik kiri mouse dan cooldown sudah habis → tembak
        if (Input.GetMouseButton(0) && fireCooldown <= 0f)
        {
            Tembak();                     // Jalankan fungsi tembak
            fireCooldown = fireRate;     // Reset timer tembakan
        }
    }

    // 🚀 Fungsi untuk menembakkan peluru
    void Tembak()
    {
        if (!isUpgraded)
        {
            // 🔫 Peluru normal (hanya 1 arah lurus)
            Instantiate(peluruBiasa, titikTembak.position, Quaternion.identity);
        }
        else
        {
            // 💥 Peluru sudah upgrade → spawn prefab peluru 3 arah
            Instantiate(peluruUpgrade, titikTembak.position, Quaternion.identity);
        }

        // 🔊 Mainkan suara tembakan jika tersedia
        if (suaraTembak != null && audioSrc != null)
        {
            audioSrc.PlayOneShot(suaraTembak);
        }
    }

    // 🆙 Fungsi untuk mengaktifkan mode peluru 3 arah (dipanggil dari luar)
    public void UpgradeToTripleShot()
    {
        isUpgraded = true; // Aktifkan status upgrade
        Debug.Log("Peluru telah di-upgrade menjadi 3 arah!"); // Log info ke Console
    }
}
