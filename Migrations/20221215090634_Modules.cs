using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeManagement.Migrations
{
    /// <inheritdoc />
    public partial class Modules : Migration
    {
        /// <inheritdoc />
        /// 
                // CREATE DATABASE TABLES WITH MIGRATION
        // // (Shaukat, 2016)   available at https://www.c-sharpcorner.com/article/code-first-migrations-Asp-Net-mvc/

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleName = table.Column<string>(name: "Module_Name", type: "nvarchar(max)", nullable: false),
                    ModuleCode = table.Column<string>(name: "Module_Code", type: "nvarchar(max)", nullable: false),
                    ModuleCredits = table.Column<int>(name: "Module_Credits", type: "int", nullable: false),
                    WeeklyClassHours = table.Column<int>(name: "Weekly_Class_Hours", type: "int", nullable: false),
                    SemesterWeeks = table.Column<int>(name: "Semester_Weeks", type: "int", nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    SemesterStartDate = table.Column<DateTime>(name: "Semester_Start_Date", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Modules");
        }
    }
}
