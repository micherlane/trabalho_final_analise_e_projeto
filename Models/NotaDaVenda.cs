using System.ComponentModel.DataAnnotations;

namespace micherlane.Models {
    public class NotaDaVenda {
        [Display(Name="Código")]
        public int Id {get; set;}

        public DateTime Data {get; set;}

        public bool Tipo {get; set;}

        public bool? Devolvido {get; set;}

        [Display(Name="Vendedor")]
        public int VendedorId {get; set;}
        public Vendedor Vendedor {get; set;} = null!;

        public ICollection<Pagamento> Pagamentos {get;} = new List<Pagamento>();
        
        public int TipoDePagamentoId {get; set;}
        
        [Display(Name="Forma de Pagamento")]
        public TipoDePagamento TipoDePagamento {get; set; } = null!;
        [Display(Name="Cliente")]
        public int ClienteId {get; set;}
        public Cliente Cliente {get; set;} = null!;

        public ICollection<Transportadora> Transportadoras {get;} = new List<Transportadora>();

        public ICollection<Item> Items {get;} = new List<Item>();
    }
}