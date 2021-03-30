using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Products
{
    public class ProductDtoUpdate
    {
        [Required(ErrorMessage = "ID é campo obrigatório")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome é campo obrigatório")]
        [StringLength(60, ErrorMessage = "Nome deve ter no máximo {1} caracteres")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Valor Unitário é Obrigatório")]
        [StringLength(100, ErrorMessage = "Valor Unitário deve ter no máximo {1} caracteres")]
        public decimal valor_unitario { get; set; }

        [Required(ErrorMessage = "Quantidade no estoque é campo obrigatório")]
        [StringLength(100, ErrorMessage = "Quantidade no estoque deve ter no máximo {1} caracteres")]
        public int qtde_estoque { get; set; }
    }
}
