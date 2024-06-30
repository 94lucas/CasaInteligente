using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CasaInteligente.ViewModels
{
    public class DispositivoSegCreateViewModel
    {

        [Required(ErrorMessage = "O tipo é obrigatório.")]
        [Display(Name = "Tipo")]
        [StringLength(50, ErrorMessage = "O tipo não pode exceder 50 caracteres.")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "O status é obrigatório.")]
        [Display(Name = "Status")]
        [StringLength(20, ErrorMessage = "O status não pode exceder 20 caracteres.")]
        public string Status { get; set; }

        [Required(ErrorMessage = "O local é obrigatório.")]
        [Display(Name = "LocalInstalacao")]
        [StringLength(60, ErrorMessage = "O status não pode exceder 60 caracteres.")]
        public string LocalInstalacao { get; set; }

        [Display(Name = "Casas")]
        public int CasaId { get; set; }

        //public SelectList Casas { get; set; }
       
        [Display(Name = "Eventos")]
        public int EventoId { get; set; }
        
        //public SelectList Eventos { get; set; }
        /*
        public DispositivoSegCreateViewModel()
        {
            Eventos = new SelectList(Enumerable.Empty<SelectListItem>());
            Casas = new SelectList(Enumerable.Empty<SelectListItem>());
        }
        */
    }
}
