using CasaInteligente.Models;

namespace CasaInteligente.Services
{
    public interface ICasaService
    {

        IEnumerable<CasaModel> ListarCasas();
        CasaModel ObterCasaPorId(int id);
        void CriarCasa(CasaModel casa);
        void AtualizarCasa(CasaModel casa);
        void DeletarCasa(int id);

    }
}
