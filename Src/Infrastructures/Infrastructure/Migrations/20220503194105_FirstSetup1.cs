using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class FirstSetup1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarHires_Branches_PickUpBranchId",
                table: "CarHires");

            migrationBuilder.DropForeignKey(
                name: "FK_CarHires_Branches_ReturnBranchId",
                table: "CarHires");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarHires_Branches_PickUpBranchId",
                table: "CarHires");

            migrationBuilder.DropForeignKey(
                name: "FK_CarHires_Branches_ReturnBranchId",
                table: "CarHires");

            migrationBuilder.AddForeignKey(
                name: "FK_CarHires_Branches_PickUpBranchId",
                table: "CarHires",
                column: "PickUpBranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarHires_Branches_ReturnBranchId",
                table: "CarHires",
                column: "ReturnBranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
