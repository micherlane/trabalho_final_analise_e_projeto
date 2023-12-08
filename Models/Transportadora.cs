using System.ComponentModel.DataAnnotations;

namespace micherlane.Models {
    public class Transportadora {
        [Display(Name="Código")]
        public int Id {get; set;}
        public string? Nome {get; set;}

        public ICollection<NotaDaVenda> NotaDaVendas {get;} = new List<NotaDaVenda>();
    }
}