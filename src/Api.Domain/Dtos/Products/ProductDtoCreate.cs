using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Products
{
    public class ProductDtoCreate
    {
        [Required(ErrorMessage = "Nome é campo obrigatório")]
        [StringLength(60, ErrorMessage = "Nome deve ter no máximo {1} caracteres")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Valor Unitário é Obrigatório")]
        //[Range(0, int.MaxValue, ErrorMessage = "Apenas números positivos")]
        public decimal valor_unitario { get; set; }

        [Required(ErrorMessage = "Quantidade no estoque é campo obrigatório")]
        //[Range(0, int.MaxValue, ErrorMessage = "Apenas números positivos")]
        public int qntd_estoque { get; set; }
    }
}
