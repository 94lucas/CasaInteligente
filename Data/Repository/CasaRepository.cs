using CasaInteligente.Data.Contexts;
using CasaInteligente.Models;

namespace CasaInteligente.Data.Repository
{
    public class CasaRepository : ICasaRepository
    {

        private readonly DatabaseContext _context;
        public CasaRepository(DatabaseContext context)
        {
            _context = context;
        }
        public IEnumerable<CasaModel> ListarCasas() => _context.Casas.ToList();
        public CasaModel ObterCasaPorId(int id) => _context.Casas.Find(id);
        public void CriarCasa(CasaModel casa)
        {
            _context.Casas.Add(casa);
            _context.SaveChanges();
        }
        public void AtualizarCasa(CasaModel casa)
        {
            _context.Update(casa);
            _context.SaveChanges();
        }
        public void DeletarCasa(CasaModel casa)
        {
            _context.Casas.Remove(casa);
            _context.SaveChanges();
        }

    }
}