using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CasaInteligente.ViewModels
{
    public class UsuarioCreateViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [Display(Name = "Nome")]
        [StringLength(50, ErrorMessage = "O nome não pode exceder 50 caracteres.")]
        public string Nome { get; set; }
        
       
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Insira um endereço de e-mail válido.")]
        public string Email { get; set; }
        
        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O telefone é obrigatória.")]
        public int Telefone { get; set; }
        

    } 
}
