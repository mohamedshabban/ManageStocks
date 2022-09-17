using Microsoft.EntityFrameworkCore.Migrations;

namespace EGID.Test.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brokers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brokers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    BrokerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Clients_Brokers_BrokerId",
                        column: x => x.BrokerId,
                        principalTable: "Brokers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockID = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Commission = table.Column<double>(nullable: false),
                    BrokerId = table.Column<int>(nullable: true),
                    PersonID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Orders_Brokers_BrokerId",
                        column: x => x.BrokerId,
                        principalTable: "Brokers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Clients_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Clients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Stocks_StockID",
                        column: x => x.StockID,
                        principalTable: "Stocks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brokers",
                columns: new[] { "ID", "Name" },
                values: new object[] { 1, "Broker1" });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "ID", "Name", "Price" },
                values: new object[,]
                {
                    { 26, "MeetMe", 99.0 },
                    { 25, "InterNAP", 64.0 },
                    { 24, "Genesis", 94.0 },
                    { 23, "FlashZero", 80.0 },
                    { 22, "Epazz", 86.0 },
                    { 21, "Envestnet", 62.0 },
                    { 20, "ENDEXX", 53.0 },
                    { 19, "Eastern", 69.0 },
                    { 18, "EarthLink", 70.0 },
                    { 17, "CrowdGather", 66.0 },
                    { 16, "Crexendo", 84.0 },
                    { 15, "Cogent", 76.0 },
                    { 27, "Netease", 98.0 },
                    { 14, "Cnova", 56.0 },
                    { 12, "ADR", 51.0 },
                    { 11, "ChinaCache", 77.0 },
                    { 10, "China Finance", 69.0 },
                    { 9, "Carbonite", 73.0 },
                    { 8, "Brainybrawn", 89.0 },
                    { 7, "Boingo", 93.0 },
                    { 6, "Blucora", 75.0 },
                    { 5, "Blinkx", 78.0 },
                    { 4, "Baidu", 57.0 },
                    { 3, "Akamai", 56.0 },
                    { 2, "Agritek", 96.0 },
                    { 1, "Vianet", 61.0 },
                    { 13, "ChitrChatr", 92.0 },
                    { 28, "Qihoo", 76.0 }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ID", "BrokerId", "Name" },
                values: new object[] { 1, 1, "Client1" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ID", "BrokerId", "Name" },
                values: new object[] { 2, 1, "Client2" });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_BrokerId",
                table: "Clients",
                column: "BrokerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BrokerId",
                table: "Orders",
                column: "BrokerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PersonID",
                table: "Orders",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StockID",
                table: "Orders",
                column: "StockID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Brokers");
        }
    }
}
