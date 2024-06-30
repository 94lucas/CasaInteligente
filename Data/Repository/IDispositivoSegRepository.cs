using CasaInteligente.Models;

namespace CasaInteligente.Data.Repository;

public interface IDispositivoSegRepository
{
    IEnumerable<DispositivoSegModel> GetAll();
    DispositivoSegModel GetById(int id);
    void Add(DispositivoSegModel dispositivo);
    void Update(DispositivoSegModel dispositivo);
    void Delete(DispositivoSegModel dispositivo);
}