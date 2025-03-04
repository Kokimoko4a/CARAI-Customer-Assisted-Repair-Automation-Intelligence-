using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CARAI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewEntityCalledMechanicTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MechanicTaskId",
                table: "RequestToMechanics",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MechanicTasks",
                columns: table => new
                {
                    RequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MechanicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MechanicTasks", x => new { x.RequestId, x.MechanicId });
                    table.ForeignKey(
                        name: "FK_MechanicTasks_Mechanics_MechanicId",
                        column: x => x.MechanicId,
                        principalTable: "Mechanics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MechanicTasks_RequestToMechanics_RequestId",
                        column: x => x.RequestId,
                        principalTable: "RequestToMechanics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MechanicTasks_MechanicId",
                table: "MechanicTasks",
                column: "MechanicId");

            migrationBuilder.CreateIndex(
                name: "IX_MechanicTasks_RequestId",
                table: "MechanicTasks",
                column: "RequestId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MechanicTasks");

            migrationBuilder.DropColumn(
                name: "MechanicTaskId",
                table: "RequestToMechanics");
        }
    }
}
