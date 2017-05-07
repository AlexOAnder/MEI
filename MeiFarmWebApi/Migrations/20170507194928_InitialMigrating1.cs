using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeiFarmWebApi.Migrations
{
    public partial class InitialMigrating1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicaments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AdditionInfo = table.Column<string>(nullable: true),
                    FarmType = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicaments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AdditionInfo = table.Column<string>(nullable: true),
                    AdditionalMedicamentId = table.Column<Guid>(nullable: false),
                    AutoUpdatableRecipe = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Expired = table.Column<DateTime>(nullable: false),
                    IsPaidReceipt = table.Column<bool>(nullable: false),
                    MedicamentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_Medicaments_AdditionalMedicamentId",
                        column: x => x.AdditionalMedicamentId,
                        principalTable: "Medicaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Recipes_Medicaments_MedicamentId",
                        column: x => x.MedicamentId,
                        principalTable: "Medicaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AdditionInfo = table.Column<string>(nullable: true),
                    BrithDate = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    OrganizationId = table.Column<Guid>(nullable: true),
                    SecondName = table.Column<string>(nullable: true),
                    Sex = table.Column<string>(nullable: true),
                    UserType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_AdditionalMedicamentId",
                table: "Recipes",
                column: "AdditionalMedicamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_MedicamentId",
                table: "Recipes",
                column: "MedicamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_OrganizationId",
                table: "Users",
                column: "OrganizationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Medicaments");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
