namespace CasaInteligente.Models;

public class DispositivoSegModel
{
    public int DispositivoId { get; set; }
    public String? Tipo { get; set; }
    public String? Status { get; set; }
    public String? LocalInstalacao { get; set; }
    public int CasaId { get; set; }
    public CasaModel? Casa { get; set; }
    
    public int? EventoId { get; set; }
    public EventoDeEmergenciaModel? Evento { get; set; }
    
}