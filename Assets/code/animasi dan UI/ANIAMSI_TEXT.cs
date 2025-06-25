// ===============================================
// Skrip ini membuat teks di UI terlihat "berdenyut" seperti hologram.
// Efeknya berupa:
    // - Teks membesar dan mengecil pelan-pelan (zoom in-out)
    // - Teks jadi lebih terang lalu gelap sedikit (transparansi berubah)
// Hasilnya: Teks jadi terlihat hidup dan futuristik, cocok untuk efek hologram!
// ===============================================

using TMPro; // Untuk pakai komponen teks modern (TextMeshPro)
using UnityEngine; // Untuk semua fitur dasar dari Unity

public class HologramPulse : MonoBehaviour
{
    // Objek teks yang akan diberi efek. Diisi lewat Inspector (drag & drop).
    public TextMeshProUGUI tmpText;

    // Seberapa cepat denyutnya. Nilai lebih besar = lebih cepat.
    public float pulseSpeed = 2f;

    // Ukuran terkecil dan terbesar saat teks membesar-mengecil.
    public float minScale = 0.98f; // Hampir sama dengan ukuran aslinya
    public float maxScale = 1.02f; // Sedikit lebih besar dari ukuran aslinya

    // Transparansi terkecil dan terbesar dari teks.
    public float minAlpha = 0.6f; // Agak transparan
    public float maxAlpha = 1f;   // Sepenuhnya terlihat

    // Menyimpan ukuran awal objek ini
    Vector3 originalScale;

    // Penyimpan waktu untuk menghitung animasi sin wave
    float time;

    // Fungsi ini dijalankan sekali saat game mulai (atau saat objek ini diaktifkan)
    void Start()
    {
        // Ambil skala awal dari objek (biasanya 1,1,1)
        originalScale = transform.localScale;
    }

    // Fungsi ini terus berjalan setiap frame (sekitar 60 kali per detik)
    void Update()
    {
        // Tambahkan waktu berdasarkan detik yang berlalu dan kecepatan denyut
        time += Time.deltaTime * pulseSpeed;

        // Hitung nilai scale (besar-kecil) berdasarkan gelombang sinus agar halus
        float scaleFactor = Mathf.Lerp(minScale, maxScale, (Mathf.Sin(time) + 1) / 2);

        // Hitung nilai alpha (transparansi) dengan cara yang sama
        float alphaFactor = Mathf.Lerp(minAlpha, maxAlpha, (Mathf.Sin(time) + 1) / 2);

        // Terapkan efek besar-kecil ke objek ini
        transform.localScale = originalScale * scaleFactor;

        // Kalau objek teks tidak kosong, ubah alpha-nya
        if (tmpText != null)
        {
            // Ambil warna asli dari teks
            Color c = tmpText.color;

            // Ganti alpha-nya saja
            c.a = alphaFactor;

            // Simpan kembali warna baru ke teks
            tmpText.color = c;
        }
    }
}
