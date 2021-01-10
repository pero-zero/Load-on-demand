using Microsoft.EntityFrameworkCore.Migrations;

namespace Load_on_demand.Data.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ŠifrarnikDržava",
                columns: table => new
                {
                    DržavaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DržavaNaziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ŠifrarnikDržava", x => x.DržavaID);
                });

            migrationBuilder.CreateTable(
                name: "Naselja",
                columns: table => new
                {
                    NaseljeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoštanskiBroj = table.Column<int>(nullable: false),
                    NazivNaselja = table.Column<string>(nullable: true),
                    DržavaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Naselja", x => x.NaseljeID);
                    table.ForeignKey(
                        name: "FK_Naselja_ŠifrarnikDržava_DržavaID",
                        column: x => x.DržavaID,
                        principalTable: "ŠifrarnikDržava",
                        principalColumn: "DržavaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Naselja_DržavaID",
                table: "Naselja",
                column: "DržavaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Naselja");

            migrationBuilder.DropTable(
                name: "ŠifrarnikDržava");
        }
    }
}
