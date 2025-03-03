using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CARAI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChnagedTheEntityConfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestToMechanics_Mechanics_SenderId",
                table: "RequestToMechanics");

            migrationBuilder.CreateIndex(
                name: "IX_RequestToMechanics_ReceiverId",
                table: "RequestToMechanics",
                column: "ReceiverId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestToMechanics_Mechanics_ReceiverId",
                table: "RequestToMechanics",
                column: "ReceiverId",
                principalTable: "Mechanics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestToMechanics_Mechanics_ReceiverId",
                table: "RequestToMechanics");

            migrationBuilder.DropIndex(
                name: "IX_RequestToMechanics_ReceiverId",
                table: "RequestToMechanics");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestToMechanics_Mechanics_SenderId",
                table: "RequestToMechanics",
                column: "SenderId",
                principalTable: "Mechanics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
