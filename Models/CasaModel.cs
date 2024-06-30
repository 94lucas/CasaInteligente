using Microsoft.AspNetCore.Mvc.Rendering;

namespace CasaInteligente.Models;

public class CasaModel
{
    public int CasaId { get; set; }
    public int Cep { get; set; }
    public String Endereco { get; set; }
    public int UsuarioId { get; set; }
    public UsuarioModel? Usuario { get; set; }
    
}