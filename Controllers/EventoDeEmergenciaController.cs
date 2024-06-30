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
    public class EventoDeEmergenciaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEventoDeEmergenciaService _eventoDeEmergenciaService;

        public EventoDeEmergenciaController(IMapper mapper, IEventoDeEmergenciaService eventoDeEmergenciaService)
        {
            _mapper = mapper;
            _eventoDeEmergenciaService = eventoDeEmergenciaService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EventoDeEmergenciaViewModel>> Get()
        {
            var evento = _eventoDeEmergenciaService.ListarEventos();
            var viewModelList = _mapper.Map<IEnumerable<EventoDeEmergenciaViewModel>>(evento);
            return Ok(viewModelList);
        }

        [HttpGet("{id}")]
        public ActionResult<EventoDeEmergenciaViewModel> Get(int id)
        {
            var evento = _eventoDeEmergenciaService.ObterEventoPorId(id);
            if (evento == null)
            {
                return NotFound();
            }
            else
            {
                var viewModel = _mapper.Map<EventoDeEmergenciaViewModel>(evento);
                return Ok(viewModel);
            }
        }
        
        [HttpPost]
        public ActionResult Post([FromBody] EventoDeEmergenciaViewModel viewModel)
        {
            var evento = _mapper.Map<EventoDeEmergenciaModel>(viewModel);
            _eventoDeEmergenciaService.CriarEvento(evento);
            return CreatedAtAction(nameof(Get), new { id = evento.EventoId }, evento);
        }
        
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] EventoDeEmergenciaUpdateViewModel viewModel)
        {
            var eventoExistente = _eventoDeEmergenciaService.ObterEventoPorId(id);
            if (eventoExistente == null)
            {
                return NotFound();
            }
            else
            {
                _mapper.Map(viewModel, eventoExistente);
                _eventoDeEmergenciaService.AtualizarEvento(eventoExistente);
                return NoContent();
            }
        }
        
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _eventoDeEmergenciaService.DeletarEvento(id);
            return NoContent();
        }
        
    }
}
