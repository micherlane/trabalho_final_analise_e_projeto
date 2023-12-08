using System.ComponentModel.DataAnnotations;

namespace micherlane.Models
{
    public class Produto
    {   
        [Display(Name = "Código")]
        public int Id{get; set;}

        [Display(Name = "Descrição")]
        public string? Descricao {get; set;}

        [Display(Name = "Quantidade")]
        public int Quantidade {get; set;}

        [Display(Name="Preço")]
        public double Preco {get; set;}

        [Display(Name="Código da Marca")]
        public int MarcaId {get; set;}
        public Marca Marca {get; set;} = null!;
        [Display(Name = "Itens")]
        public ICollection<Item> Items {get;} = new List<Item>();

    }
}