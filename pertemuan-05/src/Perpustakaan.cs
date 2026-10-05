// File ini berisi TODO -- lihat SOAL.md untuk kontrak lengkap tiap level.
// Bagian bertanda TODO(Level N) adalah tugas kalian; kode lain sudah
// disediakan. Jangan mengubah nama/tipe yang sudah ada kecuali TODO
// memintanya secara eksplisit.

namespace Pertemuan05;

// Komposisi: Perpustakaan MEMILIKI kumpulan Anggota. Karena Mahasiswa dan Dosen
// adalah Anggota, satu daftar bertipe Anggota bisa menampung keduanya.
public class Perpustakaan
{
    private readonly List<Anggota> _anggota = new();

    public int JumlahAnggota => _anggota.Count;

    public void Daftarkan(Anggota anggota)
    {
        // TODO(Level 8): anggota null -> ArgumentNullException; Id yang sudah
        //   terdaftar -> InvalidOperationException; selain itu tambahkan ke
        //   daftar.
        if (anggota is null)
            throw new ArgumentNullException(nameof(anggota), "Anggota tidak boleh null.");

        if (Cari(anggota.Id) is not null)
            throw new InvalidOperationException($"Anggota dengan Id {anggota.Id} sudah terdaftar.");

        _anggota.Add(anggota);
    }

    public Anggota? Cari(string id)
    {
        // TODO(Level 8): kembalikan anggota dengan Id yang sama persis, atau
        //   null.
        foreach (var anggota in _anggota)
        {
            if (anggota.Id == id)
                return anggota;
        }

        return null;
    }

    public int JumlahMahasiswa()
    {
        // TODO(Level 8): hitung anggota yang bertipe Mahasiswa (termasuk
        //   turunannya, mis. Asisten -- ingat: turunan "adalah sebuah"
        //   Mahasiswa). Petunjuk: `is` atau OfType<T>().
        var jumlah = 0;
        foreach (var anggota in _anggota)
        {
            if (anggota is Mahasiswa)
                jumlah++;
        }

        return jumlah;
    }

    public int JumlahDosen()
    {
        // TODO(Level 8): hitung anggota yang bertipe Dosen.
        var jumlah = 0;
        foreach (var anggota in _anggota)
        {
            if (anggota is Dosen)
                jumlah++;
        }

        return jumlah;
    }
}