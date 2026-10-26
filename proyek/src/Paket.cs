namespace Proyek;

public abstract class Paket
{
    public string Resi { get; }
    public double Berat { get; }
    public int Jarak { get; }
    public StatusPaket Status { get; private set; }

    protected Paket(string resi, double berat, int jarak)
    {
        if (string.IsNullOrWhiteSpace(resi))
            throw new ArgumentException("Resi tidak boleh kosong.");

        if (berat <= 0)
            throw new ArgumentException("Berat harus lebih dari 0.");

        if (jarak <= 0)
            throw new ArgumentException("Jarak harus lebih dari 0.");

        Resi = resi;
        Berat = berat;
        Jarak = jarak;
        Status = StatusPaket.DiTerima;
    }

    public abstract decimal HitungOngkir();

    public override string ToString()
    {
        return $"{Resi} - {Berat} kg, {Jarak} km, status {Status}";
    }
}