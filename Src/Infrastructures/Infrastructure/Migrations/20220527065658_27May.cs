using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class _27May : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarHires_Branches_CarHirePickUpBranchId",
                table: "CarHires");

            migrationBuilder.DropIndex(
                name: "IX_CarHires_CarHirePickUpBranchId",
                table: "CarHires");

            migrationBuilder.DropColumn(
                name: "CarHirePickUpBranchId",
                table: "CarHires");

            migrationBuilder.AlterColumn<int>(
                name: "PickUpBranchId",
                table: "CarHires",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarHires_PickUpBranchId",
                table: "CarHires",
                column: "PickUpBranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarHires_Branches_PickUpBranchId",
                table: "CarHires",
                column: "PickUpBranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarHires_Branches_PickUpBranchId",
                table: "CarHires");

            migrationBuilder.DropIndex(
                name: "IX_CarHires_PickUpBranchId",
                table: "CarHires");

            migrationBuilder.AlterColumn<int>(
                name: "PickUpBranchId",
                table: "CarHires",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CarHirePickUpBranchId",
                table: "CarHires",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CarHires_CarHirePickUpBranchId",
                table: "CarHires",
                column: "CarHirePickUpBranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarHires_Branches_CarHirePickUpBranchId",
                table: "CarHires",
                column: "CarHirePickUpBranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
