
using System.ComponentModel.DataAnnotations;

namespace micherlane.Models

{
    public class Marca
    {
        [Display(Name="Código")]
        public int Id {get; set;}

        [Display(Name="Descrição")]
        public string? Descricao {get; set;}
        
        [Display(Name="Produtos")]
        public ICollection<Produto> Produtos {get;} = new List<Produto>();

    }
}