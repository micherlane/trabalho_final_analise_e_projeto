using System.ComponentModel.DataAnnotations;

namespace micherlane.Models
{
    public class Cliente {
        [Display(Name="Código")]
        public int Id {get; set;}

        public string? Nome {get; set;}
    }
}