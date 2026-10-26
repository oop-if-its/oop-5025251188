namespace Proyek;

public class Kontainer : IBisaDilacak
{
    private readonly List<Paket> _isi = new();

    public string Resi { get; }
    public StatusPaket Status { get; private set; }
    public IReadOnlyList<Paket> Isi => _isi.AsReadOnly();

    public Kontainer(string resi)
    {
        if (string.IsNullOrWhiteSpace(resi))
            throw new ArgumentException("Nomor kontainer tidak boleh kosong.");

        Resi = resi;
        Status = StatusPaket.DiTerima;
    }

    public void Masukkan(Paket paket)
    {
        _isi.Add(paket);
    }

    public void MajuStatus(StatusPaket statusBaru)
    {
        if (statusBaru != Status + 1)
            throw new StatusTidakValidException($"Kontainer tidak bisa langsung ke {statusBaru}.");

        Status = statusBaru;

        foreach (Paket paket in _isi)
            paket.MajuStatus(statusBaru);
    }

    public override string ToString()
    {
        return $"Kontainer {Resi} - {_isi.Count} paket, status {Status}";
    }
}