using System.ComponentModel.DataAnnotations;

namespace micherlane.Models
{
    public class Item {
        [Display(Name = "Código")]
        public int Id{get; set;}

        public int Percentual { get; set;}

        public int Quantidade {get; set;}

        public int ProdutoId {get; set;}
        public Produto Produto {get; set;} = null!;
    }
}