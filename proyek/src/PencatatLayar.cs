namespace Proyek;

public class PencatatLayar : IPencatat
{
    public void Catat(string pesan)
    {
        Console.WriteLine("[log] " + pesan);
    }
}