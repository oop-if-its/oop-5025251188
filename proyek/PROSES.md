# PROSES

Berkas ini menjadi bahan utama ujian lisan. Tulis dengan kata-kata sendiri.

## 1. Domain dan masalahnya

Ekspedisi Paket, aplikasi untuk mencatat paket yang dikirim. masalahnya adalah tarif tiap jenis paket beda, dan status paket gampang salah kalau tidak dijaga, misalnya
dilaporkan "sampai" padahal belum dikirim.

## 2. Rancangan kelas

Kelas apa saja, siapa mewarisi siapa, siapa memiliki siapa, dan mengapa dirancang begitu.

- `Paket` , abstract, menyimpan resi, berat, jarak, status
- `Reguler`, `Kilat`, `Kargo` , turunan Paket, bedanya cuma cara hitung ongkir
- `Kontainer` , bukan turunan Paket, tapi sama sama pakai `IBisaDilacak`
- `RiwayatPelacakan` , dimiliki tiap paket, mencatat perjalanannya
- `Ekspedisi` , menyimpan daftar paket, mencari resi, mengubah status
- `IPencatat` , ada dua versi, tulis ke layar dan tulis ke berkas

## 3. Satu keputusan desain dan alasannya

Contoh: memilih interface atau abstract class untuk suatu hal, mengapa.

Kontainer saya buat pakai interface, bukan diturunkan dari paket, Kontainer bukan paket, jadi dia tidak punya berat dan ongkir, yang sama cuma satu, yaitu bisa dilacak. Jadi cukup kemampuannya dibagi lewat interface.

## 4. Bug atau kendala (minimal dua)

Untuk tiap kendala: apa yang terjadi, bagaimana menemukan penyebabnya, bagaimana memperbaikinya.

- Salah tulis `StatusPaket.Dikirim`, harusnya `DiKirim`
- `git push` ditolak dengan pesan Internal Server Error, dicoba push ulang dan berhasil.
