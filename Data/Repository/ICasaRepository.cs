using CasaInteligente.Models;

namespace CasaInteligente.Data.Repository
{
    public interface ICasaRepository
    {

        IEnumerable<CasaModel> ListarCasas();
        CasaModel ObterCasaPorId(int id);
        void CriarCasa(CasaModel casa);
        void AtualizarCasa(CasaModel casa);
        void DeletarCasa(CasaModel casa);

    }
}