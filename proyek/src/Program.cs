// Titik masuk aplikasi. Ganti isi berkas ini dengan demo (menu atau skenario berurutan)
// yang memperlihatkan semua aturan khas domain kalian, termasuk skenario gagal yang
// ditangani exception. Kelas-kelas domain ditulis di berkas terpisah.

using Proyek;

using var pencatat = new PencatatBerkas("log.txt");
Ekspedisi ekspedisi = new Ekspedisi(pencatat);

Reguler satu = new Reguler("EKS001", 2, 10);
Kilat dua = new Kilat("EKS002", 1.5, 20);
Kargo tiga = new Kargo("EKS003", 50, 100, true);

Console.WriteLine("=== 1. Daftar paket ===");
ekspedisi.Tambah(satu);
ekspedisi.Tambah(dua);
ekspedisi.Tambah(tiga);

foreach (Paket paket in ekspedisi.SemuaPaket)
    Console.WriteLine(paket + " | ongkir Rp" + paket.HitungOngkir().ToString("N0"));

Console.WriteLine("(tekan Enter untuk lanjut)");
Console.ReadLine();

Console.WriteLine("=== 2. Total ongkir semua paket ===");
Console.WriteLine("Rp" + ekspedisi.TotalOngkir().ToString("N0"));

Console.WriteLine("(tekan Enter untuk lanjut)");
Console.ReadLine();

Console.WriteLine("=== 3. Kirim EKS001 dan EKS002 lewat kontainer ===");
Kontainer kontainer = new Kontainer("KTR01");
kontainer.Masukkan(satu);
kontainer.Masukkan(dua);
kontainer.MajuStatus(StatusPaket.DiKirim);

Console.WriteLine(kontainer);
foreach (Paket paket in kontainer.Isi)
    Console.WriteLine("  " + paket);

Console.WriteLine("(tekan Enter untuk lanjut)");
Console.ReadLine();

Console.WriteLine("=== 4. Coba lompat status, sengaja gagal ===");
try
{
    ekspedisi.UbahStatus("EKS003", StatusPaket.Sampai);
}
catch (StatusTidakValidException ex)
{
    Console.WriteLine("Ditolak: " + ex.Message);
}

Console.WriteLine("(tekan Enter untuk lanjut)");
Console.ReadLine();

Console.WriteLine("=== 5. Cari resi yang tidak ada, sengaja gagal ===");
try
{
    ekspedisi.Cari("EKS999");
}
catch (PaketTidakDitemukanException ex)
{
    Console.WriteLine("Ditolak: " + ex.Message);
}

Console.WriteLine("(tekan Enter untuk lanjut)");
Console.ReadLine();

Console.WriteLine("=== 6. Riwayat EKS001 ===");
foreach (string baris in satu.Riwayat)
    Console.WriteLine("  " + baris);

Console.WriteLine();
Console.WriteLine("Selesai tanpa crash. Catatan lengkap ada di log.txt");
