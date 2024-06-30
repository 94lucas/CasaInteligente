using AutoMapper;
using CasaInteligente.Models;
using CasaInteligente.Services;
using CasaInteligente.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasaInteligente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DispositivoSegController : ControllerBase
    {
        private readonly IMapper _mapper;

        //Implementando as Injeções de dependencia
        private readonly IDispositivoSegService _dispositivoSegService;

        private readonly ICasaService _casaService;

        private readonly IEventoDeEmergenciaService _eventoDeEmergenciaService;

        public DispositivoSegController(IDispositivoSegService dispositivoSegService,  IMapper mapper)
        {
            _dispositivoSegService = dispositivoSegService;
            //_casaService = casaService;
            //_eventoDeEmergenciaService = eventoDeEmergenciaService;
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
        public ActionResult<IEnumerable<DispositivoSegViewModel>> Get()
        {
            var dispositivos = _dispositivoSegService.ListarDispositivos();
            var viewModelList = _mapper.Map<IEnumerable<DispositivoSegViewModel>>(dispositivos);
            return Ok(viewModelList);
        }

        [HttpGet("{id}")]
        public ActionResult<DispositivoSegViewModel> Get(int id)
        {
            var dispositivo = _dispositivoSegService.ObterDispositivoPorId(id);
            if (dispositivo == null)
            {
                return NotFound();
            }
            else
            {
                var viewModel = _mapper.Map<DispositivoSegViewModel>(dispositivo);
                return Ok(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] DispositivoSegViewModel viewModel)
        {
            var dispositivo = _mapper.Map<DispositivoSegModel>(viewModel);
            _dispositivoSegService.CriarDispositivo(dispositivo);
            return CreatedAtAction(nameof(Get), new { id = dispositivo.DispositivoId }, dispositivo);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] DispositivoSegUpdateViewModel viewModel)
        {
            var dispositivoExistente = _dispositivoSegService.ObterDispositivoPorId(id);
            if (dispositivoExistente == null)
            {
                return NotFound();
            }
            else
            {
                _mapper.Map(viewModel, dispositivoExistente);
                _dispositivoSegService.AtualizarDispositivo(dispositivoExistente);
                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _dispositivoSegService.DeletarDispositivo(id);
            return NoContent();
        }
    }
}
