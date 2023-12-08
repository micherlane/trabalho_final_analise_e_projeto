using System.ComponentModel.DataAnnotations;

namespace micherlane.Models {
    public class TipoDePagamento {
        [Display(Name = "Código")]
        public int Id {get; set;}

        [Display(Name="Nome do Cobrado")]
        public string? NomeDoCobrado {get; set;}

        [Display(Name="Informações Adicionais")]
        public string? InformacoesAdicionais {get; set;}
    }
}