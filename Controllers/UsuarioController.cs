using AutoMapper;
using CasaInteligente.Models;
using CasaInteligente.Services;
using CasaInteligente.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasaInteligente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMapper _mapper;

        //Implementando as Injeções de dependencia
        private readonly IUsuarioService _usuarioService;
        
        private readonly ICasaService _casaService;
        
        public UsuarioController(IUsuarioService usuarioService, ICasaService casaService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _casaService = casaService;
            _mapper = mapper;
        }
        /*
        public IActionResult Index()
        {
            var usuario = _usuarioService.ListarUsuarios();
            return View(usuario);
        }
        */
        
        [HttpGet]
        public ActionResult<IEnumerable<UsuarioViewModel>> Get()
        {
            var usuarios = _usuarioService.ListarUsuarios();
            var viewModelList = _mapper.Map<IEnumerable<UsuarioViewModel>>(usuarios);
            return Ok(viewModelList);
        }

        [HttpGet("{id}")]
        public ActionResult<UsuarioViewModel> Get(int id)
        {
            var usuario = _usuarioService.ObterUsuarioPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            else
            {
                var viewModel = _mapper.Map<UsuarioViewModel>(usuario);
                return Ok(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] UsuarioViewModel viewModel)
        {
            var usuario = _mapper.Map<UsuarioModel>(viewModel);
            _usuarioService.CriarUsuario(usuario);
            return CreatedAtAction(nameof(Get), new { id = usuario.UsuarioId }, usuario);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] UsuarioUpdateViewModel viewModel)
        {
            var usuarioExistente = _usuarioService.ObterUsuarioPorId(id);
            if (usuarioExistente == null)
            {
                return NotFound();
            }
            else
            {
                _mapper.Map(viewModel, usuarioExistente);
                _usuarioService.AtualizarUsuario(usuarioExistente);
                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _usuarioService.DeletarUsuario(id);
            return NoContent();
        }
    }
}
