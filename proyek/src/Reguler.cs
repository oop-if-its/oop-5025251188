namespace Proyek;

public class Reguler : Paket
{
    public Reguler(string resi, double berat, int jarak) : base(resi, berat, jarak)
    {
    }

    public override decimal HitungOngkir()
    {
        return (decimal)Berat * 3000 + Jarak * 500;
    }
}