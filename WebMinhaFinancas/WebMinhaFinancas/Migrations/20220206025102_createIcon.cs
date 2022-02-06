using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebMinhaFinancas.Migrations
{
    public partial class createIcon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IconFontId",
                table: "TypePay",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Icon",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    iconName = table.Column<string>(nullable: true),
                    icon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Icon", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TypePay_IconFontId",
                table: "TypePay",
                column: "IconFontId");

            migrationBuilder.AddForeignKey(
                name: "FK_TypePay_Icon_IconFontId",
                table: "TypePay",
                column: "IconFontId",
                principalTable: "Icon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TypePay_Icon_IconFontId",
                table: "TypePay");

            migrationBuilder.DropTable(
                name: "Icon");

            migrationBuilder.DropIndex(
                name: "IX_TypePay_IconFontId",
                table: "TypePay");

            migrationBuilder.DropColumn(
                name: "IconFontId",
                table: "TypePay");
        }
    }
}
