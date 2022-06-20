using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class FirstSetup6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarHires_Branches_PickUpBranchId",
                table: "CarHires");

            migrationBuilder.DropForeignKey(
                name: "FK_CarHires_Branches_ReturnBranchId",
                table: "CarHires");

            migrationBuilder.DropIndex(
                name: "IX_CarHires_PickUpBranchId",
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

            migrationBuilder.AddColumn<int>(
                name: "CarHireReturnBranchId",
                table: "CarHires",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CarHires_CarHirePickUpBranchId",
                table: "CarHires",
                column: "CarHirePickUpBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_CarHires_CarHireReturnBranchId",
                table: "CarHires",
                column: "CarHireReturnBranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarHires_Branches_CarHirePickUpBranchId",
                table: "CarHires",
                column: "CarHirePickUpBranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CarHires_Branches_CarHireReturnBranchId",
                table: "CarHires",
                column: "CarHireReturnBranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarHires_Branches_CarHirePickUpBranchId",
                table: "CarHires");

            migrationBuilder.DropForeignKey(
                name: "FK_CarHires_Branches_CarHireReturnBranchId",
                table: "CarHires");

            migrationBuilder.DropIndex(
                name: "IX_CarHires_CarHirePickUpBranchId",
                table: "CarHires");

            migrationBuilder.DropIndex(
                name: "IX_CarHires_CarHireReturnBranchId",
                table: "CarHires");

            migrationBuilder.DropColumn(
                name: "CarHirePickUpBranchId",
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

            migrationBuilder.CreateIndex(
                name: "IX_CarHires_ReturnBranchId",
                table: "CarHires",
                column: "ReturnBranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarHires_Branches_PickUpBranchId",
                table: "CarHires",
                column: "PickUpBranchId",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarHires_Branches_ReturnBranchId",
                table: "CarHires",
                column: "ReturnBranchId",
                principalTable: "Branches",
                principalColumn: "Id");
        }
    }
}
