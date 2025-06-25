// ============================================================================
// Skrip ini mengatur sistem upgrade peluru (1 peluru → 3 peluru)
//
// Fitur:
// - Awalnya pemain hanya bisa menembak 1 peluru lurus
// - Setelah upgrade, peluru berubah jadi 3 arah
// - Singleton Instance agar bisa diakses dari luar
// ============================================================================

using UnityEngine;

public class PlayerBulletUpgrade : MonoBehaviour
{
    public static PlayerBulletUpgrade Instance; // Singleton akses global

    [Header("Referensi Prefab Peluru")]
    public GameObject peluruBiasa;      // Prefab peluru awal (satu arah)
    public GameObject peluruUpgrade;    // Prefab peluru upgrade (3 arah)

    [Header("Titik Tembak")]
    public Transform titikTembak;       // Titik keluarnya peluru

    [Header("Pengaturan Tembakan")]
    public float fireRate = 0.2f;       // Jeda antar tembakan
    public AudioClip suaraTembak;       // Suara saat menembak

    private AudioSource audioSrc;       // Komponen suara
    private float fireCooldown = 0f;
    private bool isUpgraded = false;    // Status upgrade peluru

    void Awake()
    {
        Instance = this;                // Set instance global
    }

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        fireCooldown -= Time.deltaTime;

        if (Input.GetMouseButton(0) && fireCooldown <= 0f)
        {
            Tembak();
            fireCooldown = fireRate;
        }
    }

    void Tembak()
    {
        if (!isUpgraded)
        {
            Instantiate(peluruBiasa, titikTembak.position, Quaternion.identity);
        }
        else
        {
            // Tembak 3 arah
            Instantiate(peluruUpgrade, titikTembak.position, Quaternion.identity);
        }

        if (suaraTembak != null && audioSrc != null)
        {
            audioSrc.PlayOneShot(suaraTembak);
        }
    }

    // Fungsi ini dipanggil saat upgrade aktif (misal setelah asteroid dihancurkan)
    public void UpgradeToTripleShot()
    {
        isUpgraded = true;
        Debug.Log("Peluru telah di-upgrade menjadi 3 arah!");
    }
}
