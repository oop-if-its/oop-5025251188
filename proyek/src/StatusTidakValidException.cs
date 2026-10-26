namespace Proyek;

public class StatusTidakValidException : Exception
{
    public StatusTidakValidException(string pesan) : base(pesan) { }
}