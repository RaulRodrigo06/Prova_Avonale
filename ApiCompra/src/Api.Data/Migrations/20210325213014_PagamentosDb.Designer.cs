﻿// <auto-generated />
using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20210325213014_PagamentosDb")]
    partial class PagamentosDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Api.Domain.Entities.PagamentoEntity", b =>
                {
                    b.Property<decimal>("valor")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("valor");

                    b.ToTable("Pagamento");
                });
#pragma warning restore 612, 618
        }
    }
}
