using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArathsBaby.WebAPI.Migrations
{
    public partial class Usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Product",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Product",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    ConfirmPasword = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Colony = table.Column<string>(nullable: false),
                    Street = table.Column<string>(nullable: false),
                    OutsideNumber = table.Column<int>(nullable: false),
                    InternalNumber = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    ZipCode = table.Column<int>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Product",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "CreationDate",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
