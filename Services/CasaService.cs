using CasaInteligente.Data.Repository;
using CasaInteligente.Models;

namespace CasaInteligente.Services
{
    public class CasaService : ICasaService
    {

        private readonly ICasaRepository _repository;

        public CasaService(ICasaRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CasaModel> ListarCasas() => _repository.ListarCasas();
        public CasaModel ObterCasaPorId(int id) => _repository.ObterCasaPorId(id);
        public void CriarCasa(CasaModel casa) => _repository.CriarCasa(casa);
        public void AtualizarCasa(CasaModel casa) => _repository.AtualizarCasa(casa);
        public void DeletarCasa(int id)
        {
            var casa = _repository.ObterCasaPorId(id);
            if (casa != null)
            {
                _repository.DeletarCasa(casa);
            }
        }

    }
}
