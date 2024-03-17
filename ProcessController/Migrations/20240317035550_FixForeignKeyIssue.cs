using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcessController.Migrations
{
    /// <inheritdoc />
    public partial class FixForeignKeyIssue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Processs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProcessName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Story = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Availability",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValAvailibity = table.Column<int>(type: "int", nullable: false),
                    ProcessId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availability", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Availability_Processs_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Oee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    ProcessId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oee_Processs_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Perfomance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PerfomanceVal = table.Column<float>(type: "real", nullable: false),
                    ProcessId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfomance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Perfomance_Processs_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProcessControl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoodPart = table.Column<int>(type: "int", nullable: false),
                    BadPart = table.Column<int>(type: "int", nullable: false),
                    EstimativePart = table.Column<int>(type: "int", nullable: false),
                    TimeWork = table.Column<int>(type: "int", nullable: false),
                    TimeStop = table.Column<int>(type: "int", nullable: false),
                    TimeAvaibe = table.Column<int>(type: "int", nullable: false),
                    ProcessId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessControl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessControl_Processs_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValQuality = table.Column<int>(type: "int", nullable: false),
                    ProcessId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quality", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quality_Processs_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Availability_ProcessId",
                table: "Availability",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Oee_ProcessId",
                table: "Oee",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Perfomance_ProcessId",
                table: "Perfomance",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessControl_ProcessId",
                table: "ProcessControl",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Quality_ProcessId",
                table: "Quality",
                column: "ProcessId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Availability");

            migrationBuilder.DropTable(
                name: "Oee");

            migrationBuilder.DropTable(
                name: "Perfomance");

            migrationBuilder.DropTable(
                name: "ProcessControl");

            migrationBuilder.DropTable(
                name: "Quality");

            migrationBuilder.DropTable(
                name: "Processs");
        }
    }
}
