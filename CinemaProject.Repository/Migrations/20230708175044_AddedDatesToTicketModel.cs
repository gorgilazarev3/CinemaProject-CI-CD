using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaProject.Web.Data.Migrations
{
    public partial class AddedDatesToTicketModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ValidForDate",
                table: "Tickets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValidForDate",
                table: "Tickets");
        }
    }
}
