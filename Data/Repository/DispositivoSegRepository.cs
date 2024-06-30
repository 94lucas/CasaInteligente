using CasaInteligente.Data.Contexts;
using CasaInteligente.Models;
using Microsoft.EntityFrameworkCore;

namespace CasaInteligente.Data.Repository;

public class DispositivoSegRepository : IDispositivoSegRepository
{

    private readonly DatabaseContext _context;

    public DispositivoSegRepository(DatabaseContext context)
    {
        _context = context;
    }


    public IEnumerable<DispositivoSegModel> GetAll() => _context.Dispositivos
        .Include(c => c.Casa)
        .ToList();

    public DispositivoSegModel GetById(int id) => _context.Dispositivos.Find(id);

    public void Add(DispositivoSegModel dispositivo)
    {
        _context.Dispositivos.Add(dispositivo);
        _context.SaveChanges();
    }

    public void Update(DispositivoSegModel dispositivo)
    {
        _context.Update(dispositivo);
        _context.SaveChanges();
    }

    public void Delete(DispositivoSegModel dispositivo)
    {
        _context.Dispositivos.Remove(dispositivo);
        _context.SaveChanges();
    }
}