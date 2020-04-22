using Microsoft.EntityFrameworkCore.Migrations;

namespace login.Migrations
{
    public partial class initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "credential",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_credential", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "credential",
                columns: new[] { "id", "password", "userName" },
                values: new object[,]
                {
                    { 1, "Chicag0", "kevincab" },
                    { 2, "Chicag0", "kevin" },
                    { 3, "Chicag0", "kevycabbb" },
                    { 4, "Chicag0", "whatizit" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "credential");
        }
    }
}
