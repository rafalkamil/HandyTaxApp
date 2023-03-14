using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HandyTaxApp.Migrations
{
    public partial class extendOutcomeInvoiceModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "OutcomeInvoices",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_OutcomeInvoices_ApplicationUserId",
                table: "OutcomeInvoices",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OutcomeInvoices_AspNetUsers_ApplicationUserId",
                table: "OutcomeInvoices",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutcomeInvoices_AspNetUsers_ApplicationUserId",
                table: "OutcomeInvoices");

            migrationBuilder.DropIndex(
                name: "IX_OutcomeInvoices_ApplicationUserId",
                table: "OutcomeInvoices");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "OutcomeInvoices");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "OutcomeInvoices",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OutcomeInvoices_UserId",
                table: "OutcomeInvoices",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OutcomeInvoices_AspNetUsers_UserId",
                table: "OutcomeInvoices",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
