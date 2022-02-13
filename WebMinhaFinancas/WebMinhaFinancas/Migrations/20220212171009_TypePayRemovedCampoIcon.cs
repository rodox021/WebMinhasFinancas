using Microsoft.EntityFrameworkCore.Migrations;

namespace WebMinhaFinancas.Migrations
{
    public partial class TypePayRemovedCampoIcon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "TypePay");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "TypePay",
                nullable: true);
        }
    }
}
