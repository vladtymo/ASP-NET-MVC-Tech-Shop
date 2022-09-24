using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Tech_Shop.Migrations
{
    public partial class SeedLaptops : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Laptops",
                columns: new[] { "Id", "Display", "Model", "Price", "Processor" },
                values: new object[,]
                {
                    { 1, "13.3″ Full HD", "Dell Latitude 5320", 699m, "11th Gen Intel® Core i5" },
                    { 2, "11.6″ HD LED Display", "Samsung Chromebook 4 310XBA-KA1", 199m, "Intel® Dual-Core" },
                    { 3, "13.3″ Full HD IPS Touch Screen", "Lenovo IdeaPad Flex 5", 419m, "Intel® Core i3" },
                    { 4, "14” 4K Anti-glare", "Dell Latitude E7420", 899m, "11th Gen Intel Core i7" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
