using System.ComponentModel.DataAnnotations;

namespace micherlane.Models {
    public class Vendedor {
        [Display(Name="Código")]
        public int Id {get; set;}
        public string? Nome {get; set;}

        public ICollection<NotaDaVenda> NotaDeVendas {get;} = new List<NotaDaVenda>();
    }
}