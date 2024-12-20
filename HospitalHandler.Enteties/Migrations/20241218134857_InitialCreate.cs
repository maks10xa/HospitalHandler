using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalHandler.Enteties.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Names",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Use = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Family = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Names", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthdDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Names",
                columns: new[] { "Id", "Family", "FirstName", "PatientId", "Surname", "Use" },
                values: new object[] { new Guid("d8ff176f-bd0a-4b8e-b329-871952e32e1f"), "Иванов", "Иван", new Guid("640b993b-9e7a-4a9a-9e53-5ac0067c8124"), "Иванович", "official" });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Active", "BirthdDate", "Gender" },
                values: new object[] { new Guid("640b993b-9e7a-4a9a-9e53-5ac0067c8124"), true, new DateTime(2024, 1, 13, 18, 25, 43, 0, DateTimeKind.Unspecified), "male" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Names");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
