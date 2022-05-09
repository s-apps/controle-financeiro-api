using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleFinanceiroApi.Migrations
{
    public partial class AlterTransactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "description",
                table: "Transactions",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Transactions",
                newName: "description");
        }
    }
}
