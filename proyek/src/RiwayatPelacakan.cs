namespace Proyek;

public class RiwayatPelacakan
{
    private readonly List<string> _catatan = new();

    public IReadOnlyList<string> Catatan => _catatan.AsReadOnly();

    public void Tambah(StatusPaket status, string keterangan)
    {
        if (string.IsNullOrWhiteSpace(keterangan))
            throw new ArgumentException("Keterangan tidak boleh kosong.", nameof(keterangan));

        _catatan.Add($"{status} - {keterangan}");
    }
}