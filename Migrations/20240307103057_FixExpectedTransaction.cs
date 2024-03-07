using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SecondBrain.Migrations
{
    /// <inheritdoc />
    public partial class FixExpectedTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayOfMonth",
                table: "ExpectedTransaction");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DayOfMonth",
                table: "ExpectedTransaction",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
