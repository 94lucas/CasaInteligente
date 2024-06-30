using CasaInteligente.Models;

namespace CasaInteligente.Data.Repository
{
    public interface IUsuarioRepository
    {
        
        IEnumerable<UsuarioModel> GetAll();
        UsuarioModel GetById(int id);
        void Add(UsuarioModel usuario);
        void Update(UsuarioModel usuario);
        void Delete(UsuarioModel usuario);
    }

}