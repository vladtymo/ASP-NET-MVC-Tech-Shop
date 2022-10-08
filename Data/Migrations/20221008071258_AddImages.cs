using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Laptops",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImagePath",
                value: "https://img.moyo.ua/img/gallery/4867/43/1104939_middle.jpg?1617223785");

            migrationBuilder.UpdateData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImagePath",
                value: "https://i5.walmartimages.com/asr/8d794c17-41b0-42b2-9e11-4c60bfd81af0_1.54a5a04f52a9a6f929e635df6d8c31e6.jpeg");

            migrationBuilder.UpdateData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImagePath",
                value: "https://www.notebookcheck-ru.com/uploads/tx_nbc2/LenovoIdeaPadFlex5-14IIL05__1__06.JPG");

            migrationBuilder.UpdateData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImagePath",
                value: "https://hotline.ua/img/tx/132/13238035.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Laptops");
        }
    }
}
