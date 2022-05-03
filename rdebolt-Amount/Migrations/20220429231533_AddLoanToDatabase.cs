using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rdebolt_Amount.Migrations
{
    public partial class AddLoanToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Demographics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Credit = table.Column<int>(type: "int", nullable: false),
                    Defaults = table.Column<int>(type: "int", nullable: false),
                    DebtTotal = table.Column<float>(type: "real", nullable: false),
                    Risk = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demographics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DemographicId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Businesses_Demographics_DemographicId",
                        column: x => x.DemographicId,
                        principalTable: "Demographics",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amount = table.Column<double>(type: "float", nullable: false),
                    apr = table.Column<double>(type: "float", nullable: false),
                    duration = table.Column<int>(type: "int", nullable: false),
                    Business_Id = table.Column<int>(type: "int", nullable: false),
                    BusinessId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loans_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_DemographicId",
                table: "Businesses",
                column: "DemographicId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_BusinessId",
                table: "Loans",
                column: "BusinessId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Businesses");

            migrationBuilder.DropTable(
                name: "Demographics");
        }
    }
}
