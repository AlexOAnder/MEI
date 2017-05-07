using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeiFarmWebApi.Migrations
{
    public partial class InitialMigrating2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Organizations_OrganizationId",
                table: "Users");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrganizationId",
                table: "Users",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Organizations_OrganizationId",
                table: "Users",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Organizations_OrganizationId",
                table: "Users");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrganizationId",
                table: "Users",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Organizations_OrganizationId",
                table: "Users",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
