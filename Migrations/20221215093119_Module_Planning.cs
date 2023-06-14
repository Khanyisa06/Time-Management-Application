using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeManagement.Migrations
{
    /// <inheritdoc />
    /// 
    //        // CREATE DATABASE TABLES WITH MIGRATION
    // (Shaukat, 2016)   available at https://www.c-sharpcorner.com/article/code-first-migrations-Asp-Net-mvc/

    public partial class ModulePlanning : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Module_Planning",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleDay = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module_Planning", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Module_Planning");
        }
    }
}
