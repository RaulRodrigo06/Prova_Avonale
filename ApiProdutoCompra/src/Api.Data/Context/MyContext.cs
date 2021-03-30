using System;
using Api.Data.Mapping;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<ProductEntity> Product { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductEntity>(new ProductMap().Configure);

            modelBuilder.Entity<ProductEntity>().HasData(
               new ProductEntity
               {
                   Id = Guid.NewGuid(),
                   nome = "Bolo Do Adm",
                   valor_unitario = 10,
                   qntd_estoque = 1,
                   DataUltCompra = null,
                   ValorUltVenda = null
               }
           );
        }

    }
}
