using CasaInteligente.Models;

namespace CasaInteligente.Services;

public interface IEventoDeEmergenciaService
{
    IEnumerable<EventoDeEmergenciaModel> ListarEventos();
    EventoDeEmergenciaModel ObterEventoPorId(int id);
    void CriarEvento(EventoDeEmergenciaModel evento);
    void AtualizarEvento(EventoDeEmergenciaModel evento);
    void DeletarEvento(int id);
}