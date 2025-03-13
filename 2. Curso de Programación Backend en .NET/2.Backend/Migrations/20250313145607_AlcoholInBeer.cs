using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AlcoholInBeer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AlcoholPercentage",
                table: "Beers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlcoholPercentage",
                table: "Beers");
        }
    }
}
