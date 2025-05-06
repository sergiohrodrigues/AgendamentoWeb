using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi8_Scheduling.Migrations
{
    /// <inheritdoc />
    public partial class addAgendaBaseProfessional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgendaBaseModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessionalId = table.Column<int>(type: "int", nullable: false),
                    DayWeek = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendaBaseModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgendaBaseModel_Professional_ProfessionalId",
                        column: x => x.ProfessionalId,
                        principalTable: "Professional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgendaBaseModel_ProfessionalId",
                table: "AgendaBaseModel",
                column: "ProfessionalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgendaBaseModel");
        }
    }
}
