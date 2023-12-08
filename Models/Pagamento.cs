using System.ComponentModel.DataAnnotations;

namespace micherlane.Models 
{
    public class Pagamento {
        [Display(Name="Código")]
        public int Id {get; set;}
        [Display(Name="Data Limite")]
        public DateTime DataLimite {get; set;}
        public double Valor {get; set;}
        public bool Pago {get; set;}

        public int NotaDaVendaId {get; set;}
        public NotaDaVenda NotaDaVenda {get; set;} = null!;
    }
}