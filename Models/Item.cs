using System.ComponentModel.DataAnnotations;

namespace micherlane.Models
{
    public class Item {
        [Display(Name = "Código")]
        public int Id{get; set;}

        public int Percentual { get; set;}

        public int Quantidade {get; set;}

        [Display(Name = "Código do produto")]
        public int ProdutoId {get; set;}
        public Produto Produto {get; set;} = null!;

        public ICollection<NotaDaVenda> NotaDaVendas {get;} = new List<NotaDaVenda>();
    }
}