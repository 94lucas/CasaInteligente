using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CasaInteligente.ViewModels
{
    public class CasaCreateViewModel
    {

        [Required(ErrorMessage = "O Cep é obrigatório.")]
        [Display(Name = "Cep")]
        [StringLength(8, ErrorMessage = "O cep não pode exceder 8 caracteres.")]
        public string Cep { get; set; }
        
        [Required(ErrorMessage = "O endereço é obrigatório.")]
        [Display(Name = "Endereço")]
        
        public string Endereco { get; set; }
        
        [Display(Name = "Usuarios")]
        public int UsuarioId { get; set; }
        
        /*
        public SelectList Usuarios { get; set; }
        public CasaCreateViewModel()
        {
            Usuarios = new SelectList(Enumerable.Empty<SelectListItem>());
        }
        */
    }
}
