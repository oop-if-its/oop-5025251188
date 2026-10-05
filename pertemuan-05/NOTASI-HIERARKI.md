# Diagram Hierarki Kelas (UML) — Perpustakaan

Gambarkan diagram UML yang menunjukkan **hubungan antar kelas** di pertemuan ini, di bagian **bawah** penanda di akhir berkas ini. Format bebas — boleh kotak ASCII/Mermaid (`classDiagram`) atau daftar bertingkat. Yang wajib ada:

- Kelas `Anggota`, `Mahasiswa`, `Dosen`, `Asisten`, `Alamat`, dan `LogAktivitas`.
- Hubungan **pewarisan** (*is-a*): panah segitiga kosong dari kelas turunan ke kelas induk (`<|--` di Mermaid, atau `▲`, atau tulis "extends"/"turunan dari").
- Hubungan **komposisi** (*has-a*): berlian terisi dekat pihak pemilik (`*--` di Mermaid, atau `◆`, atau tulis "komposisi"/"memiliki") — siapa memiliki siapa?
- Anggota `protected` ditandai dengan simbol `#` (mis. `# BatasPinjam`), `public` dengan `+`, `private` dengan `-`.

Contoh format Mermaid (untuk kelas lain, bukan jawaban):

```mermaid
classDiagram
    Kendaraan <|-- Mobil
    Mobil *-- Mesin
    class Kendaraan {
        + Merek : string
        # kecepatan : int
    }
```

Jangan hapus baris penanda di bawah ini — jawaban kalian harus ditulis **setelah** baris itu, bukan sebelumnya.

<!-- TULIS JAWABAN KALIAN DI BAWAH BARIS INI -->

```mermaid
classDiagram
    Anggota <|-- Mahasiswa
    Anggota <|-- Dosen
    Mahasiswa <|-- Asisten
    Anggota *-- Alamat
    Anggota *-- LogAktivitas

    class Anggota {
        + Id : string
        + Nama : string
        + Alamat : Alamat
        + BatasPinjam : int
        # set_BatasPinjam() protected
        - _log : LogAktivitas
        + Info() string
        + Pinjam(judul) void
    }
    class Mahasiswa {
        + Nrp : string
        + Prodi : string
        + InfoLengkap() string
    }
    class Dosen {
        + Nip : string
        + InfoLengkap() string
    }
    class Asisten {
        + MataKuliah : string
        + InfoAsisten() string
    }
    class Alamat {
        + Jalan : string
        + Kota : string
        + ToString() string
    }
    class LogAktivitas {
        - _entri : List~string~
        + Semua : IReadOnlyList~string~
        + Catat(pesan) void
    }
```

Penjelasan hubungannya:

- Pewarisan (is-a), panah segitiga kosong `<|--`:
  - Mahasiswa adalah turunan dari Anggota
  - Dosen adalah turunan dari Anggota
  - Asisten adalah turunan dari Mahasiswa, jadi hierarkinya tiga tingkat
- Komposisi (has-a), berlian terisi `*--`:
  - Anggota memiliki satu Alamat
  - Anggota memiliki satu LogAktivitas sendiri (bukan dipakai bersama)

Simbol visibilitas: `+` public, `#` protected, `-` private.
Setter BatasPinjam ditandai `#` karena protected: hanya Anggota dan turunannya
yang boleh mengubahnya.