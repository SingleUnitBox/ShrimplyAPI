using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShrimplyAPI.Migrations
{
    public partial class seedFamiliesandDifficulties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("15e50b91-c664-49cd-a28d-67d579c05b2d"), "Easy" },
                    { new Guid("1fa72dc6-283a-4010-ba17-0c78f1e3a6d6"), "Hard" },
                    { new Guid("96e665e2-a9a8-4b41-91ed-e58d88b27563"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Families",
                columns: new[] { "Id", "Code", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("c49eb27d-278e-4540-a5af-de134699267f"), "CAR", "image1", "Caridina" },
                    { new Guid("d9c63042-8115-4124-93ec-d5149e7d48a0"), "SUL", "image3", "Sulawesi" },
                    { new Guid("f22c0219-c568-438e-8921-d3dc5761a6e3"), "NEO", "image2", "Neocaridina" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("15e50b91-c664-49cd-a28d-67d579c05b2d"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("1fa72dc6-283a-4010-ba17-0c78f1e3a6d6"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("96e665e2-a9a8-4b41-91ed-e58d88b27563"));

            migrationBuilder.DeleteData(
                table: "Families",
                keyColumn: "Id",
                keyValue: new Guid("c49eb27d-278e-4540-a5af-de134699267f"));

            migrationBuilder.DeleteData(
                table: "Families",
                keyColumn: "Id",
                keyValue: new Guid("d9c63042-8115-4124-93ec-d5149e7d48a0"));

            migrationBuilder.DeleteData(
                table: "Families",
                keyColumn: "Id",
                keyValue: new Guid("f22c0219-c568-438e-8921-d3dc5761a6e3"));
        }
    }
}
