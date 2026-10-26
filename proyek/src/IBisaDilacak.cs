namespace Proyek;

public interface IBisaDilacak
{
    string Resi { get; }
    StatusPaket Status { get; }
    void MajuStatus(StatusPaket statusBaru);
}