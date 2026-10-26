namespace Proyek;

public class Kilat : Paket
{
    public Kilat(string resi, double berat, int jarak) : base(resi, berat, jarak)
    {
    }

    public override decimal HitungOngkir()
    {
        return (decimal)Berat * 5000 + Jarak * 1000 + 10000;
    }
}