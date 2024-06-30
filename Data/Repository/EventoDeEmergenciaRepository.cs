using CasaInteligente.Data.Contexts;
using CasaInteligente.Models;
using Microsoft.EntityFrameworkCore;

namespace CasaInteligente.Data.Repository;

public class EventoDeEmergenciaRepository : IEventoDeEmergenciaRepository
{
    private readonly DatabaseContext _context;

    public EventoDeEmergenciaRepository(DatabaseContext context)
    {
        _context = context;
    }

    public IEnumerable<EventoDeEmergenciaModel> GetAll() => _context.Eventos
        .Include(e=> e.Dispositivos)
        .ToList();

    public EventoDeEmergenciaModel GetById(int id) => _context.Eventos.Find(id);

    public void Add(EventoDeEmergenciaModel evento)
    {
        _context.Eventos.Add(evento);
        _context.SaveChanges();
    }

    public void Update(EventoDeEmergenciaModel evento)
    {
        _context.Update(evento);
        _context.SaveChanges();
    }

    public void Delete(EventoDeEmergenciaModel evento)
    {
        _context.Eventos.Remove(evento);
        _context.SaveChanges();
    }
}