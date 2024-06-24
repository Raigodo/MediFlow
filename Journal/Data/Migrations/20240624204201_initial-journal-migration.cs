using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Journal.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialjournalmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatorId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TargetPersonId = table.Column<Guid>(type: "TEXT", nullable: false),
                    NoteBody = table.Column<string>(type: "TEXT", nullable: false),
                    NoteTag = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Persons_TargetPersonId",
                        column: x => x.TargetPersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdinatoryRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    MedicineName = table.Column<string>(type: "TEXT", nullable: false),
                    TargetPersonId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdinatoryRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdinatoryRecords_Persons_TargetPersonId",
                        column: x => x.TargetPersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_TargetPersonId",
                table: "Notes",
                column: "TargetPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdinatoryRecords_TargetPersonId",
                table: "OrdinatoryRecords",
                column: "TargetPersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "OrdinatoryRecords");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
