using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class _26May : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarHires_Branches_CarHireReturnBranchId",
                table: "CarHires");

            migrationBuilder.DropIndex(
                name: "IX_CarHires_CarHireReturnBranchId",
                table: "CarHires");

            migrationBuilder.DropColumn(
                name: "CarHireReturnBranchId",
                table: "CarHires");

            migrationBuilder.AlterColumn<int>(
                name: "ReturnBranchId",
                table: "CarHires",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarHires_ReturnBranchId",
                table: "CarHires",
                column: "ReturnBranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarHires_Branches_ReturnBranchId",
                table: "CarHires",
                column: "ReturnBranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarHires_Branches_ReturnBranchId",
                table: "CarHires");

            migrationBuilder.DropIndex(
                name: "IX_CarHires_ReturnBranchId",
                table: "CarHires");

            migrationBuilder.AlterColumn<int>(
                name: "ReturnBranchId",
                table: "CarHires",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CarHireReturnBranchId",
                table: "CarHires",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CarHires_CarHireReturnBranchId",
                table: "CarHires",
                column: "CarHireReturnBranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarHires_Branches_CarHireReturnBranchId",
                table: "CarHires",
                column: "CarHireReturnBranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
