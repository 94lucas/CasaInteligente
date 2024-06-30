using CasaInteligente.Data.Repository;
using CasaInteligente.Models;

namespace CasaInteligente.Services;

public class EventoDeEmergenciaService : IEventoDeEmergenciaService
{

    private readonly IEventoDeEmergenciaRepository _repository;

    public EventoDeEmergenciaService(IEventoDeEmergenciaRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<EventoDeEmergenciaModel> ListarEventos() => _repository.GetAll();

    public EventoDeEmergenciaModel ObterEventoPorId(int id) => _repository.GetById(id);

    public void CriarEvento(EventoDeEmergenciaModel evento) => _repository.Add(evento);

    public void AtualizarEvento(EventoDeEmergenciaModel evento) => _repository.Update(evento);

    public void DeletarEvento(int id)
    {
        var evento = _repository.GetById(id);
        if (evento != null)
        {
            _repository.Delete(evento);
        }
    }
}