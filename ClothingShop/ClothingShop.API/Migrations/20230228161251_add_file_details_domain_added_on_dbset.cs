using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingShop.API.Migrations
{
    /// <inheritdoc />
    public partial class addfiledetailsdomainaddedondbset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "FileDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByTimeStamp",
                table: "FileDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "FileDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "FileDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByTimeStamp",
                table: "FileDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "FileDetails");

            migrationBuilder.DropColumn(
                name: "CreatedByTimeStamp",
                table: "FileDetails");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "FileDetails");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "FileDetails");

            migrationBuilder.DropColumn(
                name: "UpdatedByTimeStamp",
                table: "FileDetails");
        }
    }
}
