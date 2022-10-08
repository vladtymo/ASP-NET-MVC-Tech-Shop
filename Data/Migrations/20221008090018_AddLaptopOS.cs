using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddLaptopOS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OperationSystemId",
                table: "Laptops",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OperationSystems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationSystems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "OperationSystems",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Windows" },
                    { 2, "macOS" },
                    { 3, "Linux" },
                    { 4, "MS DOS" }
                });

            migrationBuilder.UpdateData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: 1,
                column: "OperationSystemId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: 2,
                column: "OperationSystemId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: 3,
                column: "OperationSystemId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: 4,
                column: "OperationSystemId",
                value: 4);

            migrationBuilder.CreateIndex(
                name: "IX_Laptops_OperationSystemId",
                table: "Laptops",
                column: "OperationSystemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Laptops_OperationSystems_OperationSystemId",
                table: "Laptops",
                column: "OperationSystemId",
                principalTable: "OperationSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laptops_OperationSystems_OperationSystemId",
                table: "Laptops");

            migrationBuilder.DropTable(
                name: "OperationSystems");

            migrationBuilder.DropIndex(
                name: "IX_Laptops_OperationSystemId",
                table: "Laptops");

            migrationBuilder.DropColumn(
                name: "OperationSystemId",
                table: "Laptops");
        }
    }
}
