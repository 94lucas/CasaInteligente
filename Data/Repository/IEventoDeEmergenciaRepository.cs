using CasaInteligente.Models;

namespace CasaInteligente.Data.Repository;

public interface IEventoDeEmergenciaRepository
{
    IEnumerable<EventoDeEmergenciaModel> GetAll();
    EventoDeEmergenciaModel GetById(int id);
    void Add(EventoDeEmergenciaModel evento);
    void Update(EventoDeEmergenciaModel evento);
    void Delete(EventoDeEmergenciaModel evento);
}