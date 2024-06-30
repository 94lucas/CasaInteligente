namespace CasaInteligente.Models;

public class EventoDeEmergenciaModel
{
    public int EventoId { get; set; }
    public String? Tipo { get; set; }
    public DateTime? DataEvento { get; set; }
    public String? Mensagem { get; set; }
    
    public int? DispositivoId { get; set; }
    public DispositivoSegModel? Dispositivos { get; set; }
    
}