using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HandyTaxApp.Migrations
{
    public partial class UpdateInvoiceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InvoiceTitle",
                table: "Invoices",
                newName: "InvoiceContractor");

            migrationBuilder.AlterColumn<string>(
                name: "InvoiceDescription",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvoiceContractorAddress",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvoiceContractorPostalCode",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InvoiceDate",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "InvoiceSumVat",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceContractorAddress",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "InvoiceContractorPostalCode",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "InvoiceDate",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "InvoiceSumVat",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "InvoiceContractor",
                table: "Invoices",
                newName: "InvoiceTitle");

            migrationBuilder.AlterColumn<string>(
                name: "InvoiceDescription",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
