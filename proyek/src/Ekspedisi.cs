namespace Proyek;

public class Ekspedisi
{
    private readonly List<Paket> _paket = new();
    private readonly IPencatat _pencatat;

    public Ekspedisi(IPencatat pencatat)
    {
        _pencatat = pencatat;
    }

    public IReadOnlyList<Paket> SemuaPaket => _paket.AsReadOnly();

    public void Tambah(Paket paket)
    {
        _paket.Add(paket);
        _pencatat.Catat(paket.Resi + " didaftarkan");
    }

    public Paket Cari(string resi)
    {
        foreach (Paket paket in _paket)
        {
            if (paket.Resi == resi)
                return paket;
        }

        throw new PaketTidakDitemukanException(resi);
    }

    public void UbahStatus(string resi, StatusPaket statusBaru)
    {
        try
        {
            Paket paket = Cari(resi);
            paket.MajuStatus(statusBaru);
            _pencatat.Catat(resi + " sekarang " + statusBaru);
        }
        catch (StatusTidakValidException)
        {
            _pencatat.Catat(resi + " gagal diubah");
            throw;
        }
        finally
        {
            _pencatat.Catat("selesai memproses " + resi);
        }
    }

    public decimal TotalOngkir()
    {
        decimal total = 0;

        foreach (Paket paket in _paket)
            total = total + paket.HitungOngkir();

        return total;
    }
}