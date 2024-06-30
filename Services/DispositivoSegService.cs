using CasaInteligente.Data.Repository;
using CasaInteligente.Models;

namespace CasaInteligente.Services;

public class DispositivoSegService : IDispositivoSegService
{
    private readonly IDispositivoSegRepository _repository;

    public DispositivoSegService(IDispositivoSegRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<DispositivoSegModel> ListarDispositivos() => _repository.GetAll();
    

    public DispositivoSegModel ObterDispositivoPorId(int id) => _repository.GetById(id);

    public void CriarDispositivo(DispositivoSegModel dispositivo) => _repository.Add(dispositivo);

    public void AtualizarDispositivo(DispositivoSegModel dispositivo) => _repository.Update(dispositivo);

    public void DeletarDispositivo(int id)
    {
        var dispositivoSeg = _repository.GetById(id);
        if (dispositivoSeg != null)
        {
            _repository.Delete(dispositivoSeg);
        }
    }
}