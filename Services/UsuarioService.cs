using CasaInteligente.Data.Repository;
using CasaInteligente.Models;

namespace CasaInteligente.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<UsuarioModel> ListarUsuarios() => _repository.GetAll();
        public UsuarioModel ObterUsuarioPorId(int id) => _repository.GetById(id);
        public void CriarUsuario(UsuarioModel usuario) => _repository.Add(usuario);
        public void AtualizarUsuario(UsuarioModel usuario) => _repository.Update(usuario);
        public void DeletarUsuario (int id)
        {
            var usuario = _repository.GetById(id);
            if (usuario != null)
            {
                _repository.Delete(usuario);
            }
        }
    }
}
