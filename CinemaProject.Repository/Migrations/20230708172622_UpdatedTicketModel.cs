using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaProject.Web.Data.Migrations
{
    public partial class UpdatedTicketModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Movies_ForMovieId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ForMovieId",
                table: "Tickets");

            migrationBuilder.AlterColumn<Guid>(
                name: "ForMovieId",
                table: "Tickets",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ForMovieId",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ForMovieId",
                table: "Tickets",
                column: "ForMovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Movies_ForMovieId",
                table: "Tickets",
                column: "ForMovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
