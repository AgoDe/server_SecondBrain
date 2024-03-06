using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SecondBrain.Migrations
{
    /// <inheritdoc />
    public partial class FixTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayOfMonth",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "RecurringTransaction");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "RecurringTransaction",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "RecurringTransaction");

            migrationBuilder.AddColumn<int>(
                name: "DayOfMonth",
                table: "Transaction",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "RecurringTransaction",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
