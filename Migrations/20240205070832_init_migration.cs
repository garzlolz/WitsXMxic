using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WitsXMxic.Migrations
{
    /// <inheritdoc />
    public partial class init_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hank_teams",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "姓名"),
                    age = table.Column<int>(type: "int", nullable: false, comment: "年齡"),
                    birth = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "生日")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hank_teams", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hank_teams");
        }
    }
}
