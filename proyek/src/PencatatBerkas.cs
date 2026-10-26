namespace Proyek;

public class PencatatBerkas : IPencatat, IDisposable
{
    private readonly StreamWriter _penulis;

    public PencatatBerkas(string namaBerkas)
    {
        _penulis = new StreamWriter(namaBerkas, true);
    }

    public void Catat(string pesan)
    {
        _penulis.WriteLine(pesan);
    }

    public void Dispose()
    {
        _penulis.Dispose();
    }
}