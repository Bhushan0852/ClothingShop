using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingShop.API.Migrations
{
    /// <inheritdoc />
    public partial class addMobilenumberpropertyunderuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MobileNumber",
                table: "Users",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MobileNumber",
                table: "Users");
        }
    }
}
