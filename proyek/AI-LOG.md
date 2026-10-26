# AI-LOG

Catat setiap penggunaan AI yang menghasilkan kode. Satu entri per penggunaan. Tulis "tidak memakai AI" jika memang tidak.
Log yang jujur tidak mengurangi nilai; log yang tidak sesuai dengan kode, atau isi log yang tidak bisa dijelaskan, yang mengurangi nilai.

## Entri saya

## Rancangan kelas

- Prompt: "jabarkan & jelaskan rancang kelas-kelasnya untuk ekspedisi paket"
- Dipakai: susunan kelas Paket, tiga turunannya, Kontainer, RiwayatPelacakan, Ekspedisi
- Diubah: tidak ada, minta penjelasan tiap kelas dulu sebelum rancangan kode

## Kelas Paket dan turunannya

- Prompt: "sebutkan kelas Paket abstract dan turunannya, jelaskan tiap bagiannya"
- Dipakai: `Paket.cs`, `Reguler.cs`, `Kilat.cs`, `Kargo.cs`
- Diubah: Tarif tiap jenis sempat saya ubah dan tentukan sendiri, dan saya beri dua aturan tambahan, resi harus diawali EKS, dan berat maksimal 500 kg

## Kontainer dan interface

- Prompt: "bagaimana cara agar Kontainer ikut bisa dilacak tanpa jadi turunan Paket"
- Dipakai: `IBisaDilacak.cs`, `Kontainer.cs`
- Diubah: versi awal pakai penulisan `(int)` yang susah dibaca, kemudian diganti jadi `statusBaru != Status + 1`

## Pencatat log dan Ekspedisi

- Prompt: "jabarkan & rancang interface pencatat dengan dua versi, satu nulis ke layar satu ke berkas"
- Dipakai: `IPencatat.cs`, `PencatatLayar.cs`, `PencatatBerkas.cs`, `Ekspedisi.cs`
- Diubah: nama kelas awalnya PencatatKonsol, saya ganti jadi PencatatLayar sebelum di push karena lebih merepresentasikan situasi 

## Demo di Program.cs

- Prompt: "buat struktur demo berurutan yang menunjukkan semua aturan, juga termasuk yang sengaja gagal"
- Dipakai: `Program.cs`
- Diubah: saya tambahkan jeda tekan Enter tiap langkah supaya bisa dijelaskan satu per satu waktu demo

## Dokumen

- Prompt: "jelaskan & bantu susun README bagian diagram kelas"
- Dipakai: `README.md`,
- Diubah: diperjelas strukturnya
