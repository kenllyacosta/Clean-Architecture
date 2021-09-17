using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.EFCore.Data.Migrations
{
    public partial class InitialCreateEstatusCatefory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "EstatuId",
                table: "Products",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "EstatusId",
                table: "Products",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "EstatuId",
                table: "Category",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "EstatusId",
                table: "Category",
                type: "tinyint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_EstatuId",
                table: "Products",
                column: "EstatuId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_EstatuId",
                table: "Category",
                column: "EstatuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Estatus_EstatuId",
                table: "Category",
                column: "EstatuId",
                principalTable: "Estatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Estatus_EstatuId",
                table: "Products",
                column: "EstatuId",
                principalTable: "Estatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Estatus_EstatuId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Estatus_EstatuId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_EstatuId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Category_EstatuId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "EstatuId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "EstatusId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "EstatuId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "EstatusId",
                table: "Category");
        }
    }
}
