// File ini berisi TODO -- lihat SOAL.md untuk kontrak lengkap tiap level.
// Bagian bertanda TODO(Level N) adalah tugas kalian; kode lain sudah
// disediakan. Jangan mengubah nama/tipe yang sudah ada kecuali TODO
// memintanya secara eksplisit.

namespace Pertemuan04;

public class Buku
{
    // TODO(Level 1): field PUBLIK di bawah ini melanggar enkapsulasi (siapa pun
    //   bisa mengubahnya sembarangan). Jadikan field PRIVATE (awali nama dengan
    //   _) lalu ekspos lewat properti read-only: public get, tanpa setter
    //   publik. Nama properti tetap Isbn, Judul, StokTotal, StokTersedia.
    private readonly string _isbn;
    private readonly string _judul;
    private readonly int _stokTotal;
    private int _stokTersedia;

    public string Isbn => _isbn;
    public string Judul => _judul;
    public int StokTotal => _stokTotal;
    public int StokTersedia => _stokTersedia;

    // TODO(Level 8): properti di bawah ini menerima nilai apa saja. Beri nilai
    //   awal 7 dan tambahkan logika validasi di accessor set (perlu field
    //   pendukung): nilai harus 1..30, di luar itu lempar
    //   ArgumentOutOfRangeException dan JANGAN mengubah nilai lama.
    private int _batasHariPinjam = 7;

    public int BatasHariPinjam
    {
        get => _batasHariPinjam;
        set
        {
            if (value < 1 || value > 30)
                throw new ArgumentOutOfRangeException(nameof(value), "BatasHariPinjam harus antara 1 sampai 30 hari.");

            _batasHariPinjam = value;
        }
    }

    // TODO(Level 2): validasi di AWAL konstruktor -- judul null/kosong/spasi
    //   saja atau stokTotal negatif -> lempar ArgumentException
    //   (ArgumentOutOfRangeException juga boleh); jangan ada state yang berubah
    //   kalau ditolak.
    // TODO(Level 6): validasi & normalisasi ISBN -- buang tanda '-' dan spasi;
    //   hasilnya harus tepat 13 digit angka dengan digit cek ISBN-13 yang benar;
    //   kalau tidak, lempar ArgumentException. Isbn menyimpan versi TANPA '-'.
    public Buku(string isbn, string judul, int stokTotal)
    {
        // TODO(Level 1): isi Isbn, Judul, StokTotal dari parameter; StokTersedia
        //   awal = stokTotal.
        if (string.IsNullOrWhiteSpace(judul))
            throw new ArgumentException("Judul tidak boleh kosong.", nameof(judul));

        if (stokTotal < 0)
            throw new ArgumentOutOfRangeException(nameof(stokTotal), "Stok total tidak boleh negatif.");

        _isbn = NormalkanIsbn(isbn);
        _judul = judul;
        _stokTotal = stokTotal;
        _stokTersedia = stokTotal;
    }

    private static string NormalkanIsbn(string isbn)
    {
        if (isbn is null)
            throw new ArgumentNullException(nameof(isbn), "ISBN tidak boleh null.");

        var bersih = isbn.Replace("-", "").Replace(" ", "");

        if (bersih.Length != 13)
            throw new ArgumentException("ISBN harus terdiri dari 13 digit.", nameof(isbn));

        var total = 0;
        for (var i = 0; i < 13; i++)
        {
            if (bersih[i] < '0' || bersih[i] > '9')
                throw new ArgumentException("ISBN hanya boleh berisi angka.", nameof(isbn));

            var angka = bersih[i] - '0';
            total += i % 2 == 0 ? angka : angka * 3;
        }

        if (total % 10 != 0)
            throw new ArgumentException("Digit cek ISBN-13 tidak valid.", nameof(isbn));

        return bersih;
    }

    public void Pinjam()
    {
        // TODO(Level 3): kurangi StokTersedia satu. Kalau stok sudah 0, lempar
        //   InvalidOperationException dan biarkan stok tetap.
        if (_stokTersedia == 0)
            throw new InvalidOperationException("Stok buku sedang habis, tidak bisa dipinjam.");

        _stokTersedia--;
    }

    public void Kembalikan()
    {
        // TODO(Level 4): tambah StokTersedia satu. Kalau stok sudah sama dengan
        //   StokTotal (tidak ada yang sedang dipinjam), lempar
        //   InvalidOperationException dan biarkan stok tetap.
        if (_stokTersedia >= _stokTotal)
            throw new InvalidOperationException("Semua eksemplar sudah ada di perpustakaan.");

        _stokTersedia++;
    }

    // Level 5: properti TERHITUNG -- tanpa field pendukung, tanpa setter.
    public double PersentaseTersedia
    {
        get
        {
            // TODO(Level 5): kembalikan StokTersedia / StokTotal * 100 (double).
            //   Kalau StokTotal = 0 kembalikan 0 (bukan NaN).
            if (_stokTotal == 0)
                return 0;

            return (double)_stokTersedia / _stokTotal * 100;
        }
    }

    public string Status
    {
        get
        {
            // TODO(Level 5): kembalikan "Tersedia" kalau StokTersedia > 0,
            //   selain itu "Habis".
            return _stokTersedia > 0 ? "Tersedia" : "Habis";
        }
    }

}