using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi8_Scheduling.Migrations
{
    /// <inheritdoc />
    public partial class addAgendaBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgendaBaseModel_Professional_ProfessionalId",
                table: "AgendaBaseModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AgendaBaseModel",
                table: "AgendaBaseModel");

            migrationBuilder.RenameTable(
                name: "AgendaBaseModel",
                newName: "AgendaBase");

            migrationBuilder.RenameIndex(
                name: "IX_AgendaBaseModel_ProfessionalId",
                table: "AgendaBase",
                newName: "IX_AgendaBase_ProfessionalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AgendaBase",
                table: "AgendaBase",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AgendaBase_Professional_ProfessionalId",
                table: "AgendaBase",
                column: "ProfessionalId",
                principalTable: "Professional",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgendaBase_Professional_ProfessionalId",
                table: "AgendaBase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AgendaBase",
                table: "AgendaBase");

            migrationBuilder.RenameTable(
                name: "AgendaBase",
                newName: "AgendaBaseModel");

            migrationBuilder.RenameIndex(
                name: "IX_AgendaBase_ProfessionalId",
                table: "AgendaBaseModel",
                newName: "IX_AgendaBaseModel_ProfessionalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AgendaBaseModel",
                table: "AgendaBaseModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AgendaBaseModel_Professional_ProfessionalId",
                table: "AgendaBaseModel",
                column: "ProfessionalId",
                principalTable: "Professional",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
