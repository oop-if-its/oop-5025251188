namespace Proyek;

public class PaketTidakDitemukanException : Exception
{
    public PaketTidakDitemukanException(string resi)
        : base($"Paket dengan resi {resi} tidak ditemukan.")
    {
    }
}