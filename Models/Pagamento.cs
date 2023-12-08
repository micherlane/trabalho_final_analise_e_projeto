using System.ComponentModel.DataAnnotations;

namespace micherlane.Models 
{
    public class Pagamento {
        [Display(Name="Código")]
        public int Id {get; set;}
        [Display(Name="Data Limite")]
        public DateOnly DataLimite {get; set;}
        public double Valor {get; set;}
        public bool Pago {get; set;}
    }
}