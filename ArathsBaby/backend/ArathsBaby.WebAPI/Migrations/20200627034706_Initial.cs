using Microsoft.EntityFrameworkCore.Migrations;

namespace ArathsBaby.WebAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(nullable: false),
                    Photo = table.Column<string>(nullable: true),
                    CategoryName = table.Column<string>(nullable: false),
                    Price = table.Column<float>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    UnitInStock = table.Column<int>(nullable: false),
                    Color = table.Column<string>(nullable: false),
                    CreationDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
