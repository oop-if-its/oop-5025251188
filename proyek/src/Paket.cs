namespace Proyek;

public abstract class Paket : IBisaDilacak
{
    private readonly RiwayatPelacakan _riwayat = new();

    public string Resi { get; }
    public double Berat { get; }
    public int Jarak { get; }
    public StatusPaket Status { get; private set; }

    public IReadOnlyList<string> Riwayat => _riwayat.Catatan;

    protected Paket(string resi, double berat, int jarak)
    {
        if (string.IsNullOrWhiteSpace(resi))
            throw new ArgumentException("Resi tidak boleh kosong.");

        if (!resi.StartsWith("EKS"))
            throw new ArgumentException("Resi harus diawali EKS.");

        if (berat <= 0)
            throw new ArgumentException("Berat harus lebih dari 0.");

        if (berat > 500)
            throw new ArgumentException("Berat maksimal 500 kg.");

        if (jarak <= 0)
            throw new ArgumentException("Jarak harus lebih dari 0.");

        Resi = resi;
        Berat = berat;
        Jarak = jarak;
        Status = StatusPaket.DiTerima;
        _riwayat.Tambah(StatusPaket.DiTerima, "paket masuk gudang");
    }

    public abstract decimal HitungOngkir();

    public void MajuStatus(StatusPaket statusBaru)
    {
        if ((int)statusBaru != (int)Status + 1)
            throw new StatusTidakValidException($"Status {Status} tidak bisa langsung ke {statusBaru}.");

        Status = statusBaru;
        _riwayat.Tambah(statusBaru, "status diperbarui");
    }

    public override string ToString()
    {
        return $"{Resi} - {Berat} kg, {Jarak} km, status {Status}";
    }
}