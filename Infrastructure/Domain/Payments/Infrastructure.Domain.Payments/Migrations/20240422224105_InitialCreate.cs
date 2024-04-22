using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Domain.Payments.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bank",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    bankname = table.Column<string>(type: "text", nullable: false),
                    bankcode = table.Column<string>(type: "text", nullable: false),
                    interestrate = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bank", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "paymentslip",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    payername = table.Column<string>(type: "text", nullable: false),
                    payerdocument = table.Column<string>(type: "text", nullable: false),
                    beneficiaryname = table.Column<string>(type: "text", nullable: false),
                    beneficiarydocument = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<decimal>(type: "numeric", nullable: false),
                    duedate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    observation = table.Column<string>(type: "text", nullable: false),
                    bankid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paymentslip", x => x.id);
                    table.ForeignKey(
                        name: "FK_paymentslip_bank_bankid",
                        column: x => x.bankid,
                        principalTable: "bank",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_paymentslip_bankid",
                table: "paymentslip",
                column: "bankid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "paymentslip");

            migrationBuilder.DropTable(
                name: "bank");
        }
    }
}
