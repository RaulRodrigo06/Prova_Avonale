using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ProductTableUpdateqntdtoqtde : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "qntd_estoque",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "qtde_estoque",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "DataUltCompra", "ValorUltVenda", "nome", "qtde_estoque", "valor_unitario" },
                values: new object[] { new Guid("8ed7cd56-e02c-4357-8a8f-2bb40f9a0916"), null, null, "Bolo Do Adm", 1, 10m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("8ed7cd56-e02c-4357-8a8f-2bb40f9a0916"));

            migrationBuilder.DropColumn(
                name: "qtde_estoque",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "qntd_estoque",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
