using AutoMapper;
using CasaInteligente.Models;
using CasaInteligente.Services;
using CasaInteligente.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CasaInteligente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasaController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IUsuarioService _usuarioService;

        private readonly ICasaService _casaService;
        
        public CasaController(IUsuarioService usuarioService, ICasaService casaService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _casaService = casaService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CasaViewModel>> Get()
        {
            var casas = _casaService.ListarCasas();
            var viewModelList = _mapper.Map<IEnumerable<CasaViewModel>>(casas);
            return Ok(viewModelList);
        }

        [HttpGet("{id}")]
        public ActionResult<CasaViewModel> Get(int id)
        {
            var casa = _casaService.ObterCasaPorId(id);
            if (casa == null)
            {
                return NotFound();
            }
            else
            {
                var viewModel = _mapper.Map<CasaViewModel>(casa);
                return Ok(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] CasaCreateViewModel viewModel)
        {
            var casa = _mapper.Map<CasaModel>(viewModel);
            _casaService.CriarCasa(casa);
            return CreatedAtAction(nameof(Get), new { id = casa.CasaId }, casa);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CasaUpdateViewModel viewModel)
        {
            var casaExistente = _casaService.ObterCasaPorId(id);
            if (casaExistente == null)
            {
                return NotFound();
            }
            else
            {
                _mapper.Map(viewModel, )
            }
        }
        
        
        
        

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new CasaCreateViewModel
            {
                Usuarios = new SelectList(_usuarioService.ListarUsuarios()
                                            , "UsuarioId", "Nome")
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(CasaCreateViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                var casa = _mapper.Map<CasaModel>(viewModel);
                _casaService.CriarCasa(casa);
                TempData["mensagemSucesso"] = $"Ocliente {casa.CasaId} foi cadastrado com sucesso";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                viewModel.Usuarios = new SelectList(_usuarioService.ListarUsuarios(), "UsuarioId", "Nome", viewModel.UsuarioId);
                return View(viewModel);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var usuario = _usuarioService.ObterUsuarioPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            else
            {
                return View(usuario);
            }
        }

        [HttpPost]
        public IActionResult Edit(UsuarioModel usuarioModel)
        {
            _usuarioService.AtualizarUsuario(usuarioModel);
            TempData["mensagemSucesso"] = $"Os dados do Usuario {usuarioModel.Nome} foram alterados com sucesso";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var usuario = _usuarioService.ObterUsuarioPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            else
            {
                return View(usuario);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _usuarioService.DeletarUsuario(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
