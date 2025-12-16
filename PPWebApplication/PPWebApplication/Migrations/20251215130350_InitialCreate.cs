using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PPWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Publications",
                columns: table => new
                {
                    PubId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PubName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    PubYear = table.Column<int>(type: "int", nullable: false),
                    PubMonth = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publications", x => x.PubId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Publications");
        }
    }
}
