using CasaInteligente.Models;

namespace CasaInteligente.Services
{
    public interface IUsuarioService
    {

       
        IEnumerable<UsuarioModel> ListarUsuarios();
        UsuarioModel ObterUsuarioPorId(int id);
        void CriarUsuario(UsuarioModel usuario);
        void AtualizarUsuario(UsuarioModel usuario);
        void DeletarUsuario(int id);
    }
}
