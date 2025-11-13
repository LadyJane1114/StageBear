using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StageBear.Migrations
{
    /// <inheritdoc />
    public partial class AddPurchaseModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    PurchaseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketsPurchased = table.Column<int>(type: "int", nullable: false),
                    ClientFName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientLName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientStAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientRegion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientPostCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardNum = table.Column<int>(type: "int", nullable: false),
                    CardExpMon = table.Column<int>(type: "int", nullable: false),
                    CardExpYear = table.Column<int>(type: "int", nullable: false),
                    CardSecCode = table.Column<int>(type: "int", nullable: false),
                    ShowID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.PurchaseID);
                    table.ForeignKey(
                        name: "FK_Purchase_Show_ShowID",
                        column: x => x.ShowID,
                        principalTable: "Show",
                        principalColumn: "ShowID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_ShowID",
                table: "Purchase",
                column: "ShowID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchase");
        }
    }
}
