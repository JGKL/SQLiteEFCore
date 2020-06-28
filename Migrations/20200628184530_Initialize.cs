using Microsoft.EntityFrameworkCore.Migrations;

namespace EFSQLite.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ObjectTypeModels",
                columns: table => new
                {
                    TypeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    PreviewImage = table.Column<string>(nullable: true),
                    TagName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectTypeModels", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "ObjectModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    PreviewImage = table.Column<string>(nullable: true),
                    TagName = table.Column<string>(nullable: true),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObjectModels_ObjectTypeModels_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ObjectTypeModels",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ObjectModels_TypeId",
                table: "ObjectModels",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ObjectModels");

            migrationBuilder.DropTable(
                name: "ObjectTypeModels");
        }
    }
}
