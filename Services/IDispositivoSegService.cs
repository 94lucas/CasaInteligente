using CasaInteligente.Models;

namespace CasaInteligente.Services;

public interface IDispositivoSegService
{
    IEnumerable<DispositivoSegModel> ListarDispositivos();
    DispositivoSegModel ObterDispositivoPorId(int id);
    void CriarDispositivo(DispositivoSegModel dispositivo);
    void AtualizarDispositivo(DispositivoSegModel dispositivo);
    void DeletarDispositivo(int id);
}