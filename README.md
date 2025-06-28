Berikut isi lengkap file `README.md` yang sudah saya buat, langsung bisa kamu salin dan tempel ke repositori GitHub kamu:

---

````markdown
# 🚀 Zetta Tronian

_Zetta Tronian_ adalah sebuah game **horizontal space shooter** bergaya klasik seperti game **Platypus**, dikembangkan sebagai **projek akhir mata kuliah Multimedia di ITPLN**. Pemain mengendalikan pesawat luar angkasa untuk menghancurkan asteroid dan musuh yang datang dari sisi kanan layar. Game ini memiliki sistem wave, skor, peluru upgrade otomatis, dan UI futuristik.

---

## 🎮 Fitur Utama

- 🔫 **Tembakan Peluru Biasa dan Upgrade**  
  Pemain menembakkan peluru ke arah kanan. Setelah mengalahkan asteroid tertentu, peluru otomatis berubah menjadi **peluru 3 arah** (spread shot) tanpa perlu mengambil power-up.

- 🌌 **Musuh & Asteroid Bergelombang (Wave System)**  
  Musuh dan asteroid muncul dalam gelombang yang bertambah sulit setiap 60 detik. Kecepatan dan frekuensi spawn akan meningkat.

- 💥 **Efek Suara dan Ledakan**  
  Efek suara disematkan pada tembakan, tabrakan, dan ledakan untuk menambah imersi arcade.

- 🎮 **Kontrol Sederhana dan Responsif**  
  Kontrol game menggunakan **WASD atau tombol panah** untuk gerakan dan **Spasi atau Klik Kiri** untuk menembak.

- 🧠 **Sistem Skor dan Game Over**  
  Skor bertambah saat pemain menghancurkan musuh atau asteroid. Game akan berakhir saat pemain terkena musuh atau asteroid.

- 🎛️ **UI Interaktif & Lengkap**  
  Game memiliki menu utama, game over, dan tombol navigasi seperti Start, Exit, dan Restart.

- 🎨 **Dark UI Futuristik**  
  Antarmuka game menggunakan desain gelap bertema luar angkasa dengan nuansa modern.

- ⚙️ **Struktur Modular & Mudah Dikembangkan**  
  Setiap fitur dibuat dalam skrip terpisah, sehingga mudah dikembangkan lebih lanjut.

---

## 🛠️ Teknologi

- **Engine**: Unity 2D (versi 2022.3.x atau lebih tinggi)
- **Bahasa Pemrograman**: C#
- **Assets**: Sprite, font, dan suara dari Unity Asset Store dan sumber bebas

---

## ▶️ Cara Menjalankan

### 🔧 Opsi 1: Jalankan Lewat Unity Editor
1. Clone repository ini:
   ```bash
   git clone https://github.com/username/zettatronian.git
````

2. Buka Unity Hub dan buka folder project.
3. Buka scene `Assets/Scenes/MainMenu.unity`.
4. Klik tombol **Play** di Unity.

### 💻 Opsi 2: Jalankan Lewat Build

1. Masuk ke folder `Build/`.
2. Jalankan file `.exe` (untuk Windows).

---

## 📁 Struktur Proyek

```
📁 Assets
├── Audio              # Efek suara
├── Fonts              # Font UI
├── Prefabs            # Objek prefab: player, musuh, peluru
├── Scenes             # MainMenu, Gameplay, GameOver
├── Scripts            # Player, Enemy, Bullet, Manager, dll.
├── Sprites            # Gambar pesawat, asteroid, musuh
└── UI                 # Tampilan antarmuka pengguna
📁 ProjectSettings
📁 Packages
.gitignore
README.md
```

---

## 📜 Lisensi

Proyek ini dibuat untuk tujuan pembelajaran dan akademik. Bebas digunakan dan dimodifikasi dengan menyertakan kredit kepada pengembang.

---

## 🙋‍♂️ Pengembang

**Hafizh Wijdan**
Mahasiswa ITPLN
Proyek Akhir Mata Kuliah Multimedia

---

> 🚀 Selamat bermain Zetta Tronian 

```


