namespace Proyek;

public class Kargo : Paket
{
    public bool PakaiAsuransi { get; }

    public Kargo(string resi, double berat, int jarak) : this(resi, berat, jarak, false)
    {
    }

    public Kargo(string resi, double berat, int jarak, bool pakaiAsuransi) : base(resi, berat, jarak)
    {
        PakaiAsuransi = pakaiAsuransi;
    }

    public override decimal HitungOngkir()
    {
        decimal ongkir = (decimal)Berat * 1500 + Jarak * 2000;

        if (PakaiAsuransi)
            ongkir = ongkir + 25000;

        return ongkir;
    }
}