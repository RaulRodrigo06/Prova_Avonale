using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public decimal? ValorUltVenda { get; set; }

        public DateTime? DataUltCompra { get; set; }

    }
}
