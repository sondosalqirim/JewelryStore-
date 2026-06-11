using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_project_as.Migrations
{
    public partial class FinalCleanSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderID", "ProductID", "Quantity", "TotalPrice", "UserID" },
                values: new object[,]
                {
                    { 1, 1, 3, 0m, 1 },
                    { 2, 1, 2, 0m, 2 },
                    { 3, 2, 5, 0m, 3 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "Description", "Price", "ProductName", "Quantity" },
                values: new object[,]
                {
                    { 1, null, 1200m, "Diamond Engagement Ring", 15 },
                    { 2, null, 450m, "Gold Chain Necklace", 10 },
                    { 3, null, 150m, "Silver Charm Bracelet", 20 },
                    { 4, null, 600m, "Classic Wedding Band", 50 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Email", "FullName", "Password" },
                values: new object[,]
                {
                    { 1, "lina@gmail.com", "Lina", "123" },
                    { 2, "sondos@gmail.com", "Sondos Alqirim", "456" },
                    { 3, "aya@gmail.com", "Aya Alkirim", "123" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 3);
        }
    }
}
