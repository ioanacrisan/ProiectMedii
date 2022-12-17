using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectMedii.Migrations
{
    public partial class Hairstylist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hairstylist",
                table: "Service");

            migrationBuilder.AddColumn<int>(
                name: "HairstylistID",
                table: "Service",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Hairstylist",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HairstylistName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hairstylist", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Service_HairstylistID",
                table: "Service",
                column: "HairstylistID");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Hairstylist_HairstylistID",
                table: "Service",
                column: "HairstylistID",
                principalTable: "Hairstylist",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_Hairstylist_HairstylistID",
                table: "Service");

            migrationBuilder.DropTable(
                name: "Hairstylist");

            migrationBuilder.DropIndex(
                name: "IX_Service_HairstylistID",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "HairstylistID",
                table: "Service");

            migrationBuilder.AddColumn<string>(
                name: "Hairstylist",
                table: "Service",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
