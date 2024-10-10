using AutoMapper;
using CasaInteligente.Models;
using CasaInteligente.Services;
using CasaInteligente.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CasaInteligente.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
                _mapper.Map(viewModel, casaExistente);
                _casaService.AtualizarCasa(casaExistente);
                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _casaService.DeletarCasa(id);
            return NotFound();
        }

    }
}
