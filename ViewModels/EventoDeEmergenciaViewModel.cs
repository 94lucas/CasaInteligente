using CasaInteligente.Models;

namespace CasaInteligente.ViewModels;

public class EventoDeEmergenciaViewModel
{
    public int EventoId { get; set; }
    public String? Tipo { get; set; }
    public DateTime? DataEvento { get; set; }
    public String? Mensagem { get; set; }
    
    public int? DispositivoId { get; set; }
    //public DispositivoSegModel? Dispositivos { get; set; }
}