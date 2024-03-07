using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SecondBrain.Migrations
{
    /// <inheritdoc />
    public partial class FixMoneyTransfer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoneyTransfer_Goal_GoalId",
                table: "MoneyTransfer");

            migrationBuilder.AlterColumn<int>(
                name: "GoalId",
                table: "MoneyTransfer",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_MoneyTransfer_Goal_GoalId",
                table: "MoneyTransfer",
                column: "GoalId",
                principalTable: "Goal",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoneyTransfer_Goal_GoalId",
                table: "MoneyTransfer");

            migrationBuilder.AlterColumn<int>(
                name: "GoalId",
                table: "MoneyTransfer",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MoneyTransfer_Goal_GoalId",
                table: "MoneyTransfer",
                column: "GoalId",
                principalTable: "Goal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
