using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class ProductEntity : BaseEntity
    {
        [Required]
        public string nome { get; set; }
        [Required]
        public decimal valor_unitario { get; set; }
        [Required]
        public int qntd_estoque { get; set; }
    }
}
