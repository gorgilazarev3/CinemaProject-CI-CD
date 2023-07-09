using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaProject.Web.Data.Migrations
{
    public partial class UpdatedShoppingCartModelToIncludeTotalPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "ShoppingCarts",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "ShoppingCarts");
        }
    }
}
