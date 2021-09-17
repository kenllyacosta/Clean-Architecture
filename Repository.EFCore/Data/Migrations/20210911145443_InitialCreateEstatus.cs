using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.EFCore.Data.Migrations
{
    public partial class InitialCreateEstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estatus",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificado = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estatus", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estatus");
        }
    }
}
