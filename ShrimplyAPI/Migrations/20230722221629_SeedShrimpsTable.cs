using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShrimplyAPI.Migrations
{
    public partial class SeedShrimpsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("58ba0c1c-d7ef-4b22-80a9-8adf8c442b05"), "Easy" },
                    { new Guid("58ba0c1c-d7ef-4b22-80a9-8adf8c442b06"), "Medium" },
                    { new Guid("58ba0c1c-d7ef-4b22-80a9-8adf8c442b07"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Families",
                columns: new[] { "Id", "Code", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("58ba0c1c-d7ef-4b22-80a9-8adf8c442b02"), "CAR", "image1", "Caridina" },
                    { new Guid("58ba0c1c-d7ef-4b22-80a9-8adf8c442b03"), "NEO", "image2", "Neocaridina" },
                    { new Guid("58ba0c1c-d7ef-4b22-80a9-8adf8c442b04"), "SUL", "image3", "Sulawesi" }
                });

            migrationBuilder.InsertData(
                table: "Shrimps",
                columns: new[] { "Id", "Description", "DifficultyId", "FamilyId", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("0ddf58d2-0dda-4ea6-9a49-86695ad9d569"), "White Pearl", new Guid("58ba0c1c-d7ef-4b22-80a9-8adf8c442b05"), new Guid("58ba0c1c-d7ef-4b22-80a9-8adf8c442b03"), "image8", "White Pearl" },
                    { new Guid("3463cedb-0c49-469c-8a5d-dfbc9105b464"), "Pure Red Line Shrimp", new Guid("58ba0c1c-d7ef-4b22-80a9-8adf8c442b06"), new Guid("58ba0c1c-d7ef-4b22-80a9-8adf8c442b02"), "image5", "Pure Red Line" },
                    { new Guid("48712e81-383b-41d6-8879-3b0b1ace78d8"), "Cardinal", new Guid("58ba0c1c-d7ef-4b22-80a9-8adf8c442b07"), new Guid("58ba0c1c-d7ef-4b22-80a9-8adf8c442b04"), "image9", "Cardinal" },
                    { new Guid("bceef984-27f2-4bec-b02d-25ef3d5acd18"), "Pure Black Line Shrimp", new Guid("58ba0c1c-d7ef-4b22-80a9-8adf8c442b06"), new Guid("58ba0c1c-d7ef-4b22-80a9-8adf8c442b02"), "image6", "Pure Black Line" },
                    { new Guid("c0505de0-424c-4388-af4b-b1fbd629433a"), "Pure White Line Shrimp", new Guid("58ba0c1c-d7ef-4b22-80a9-8adf8c442b06"), new Guid("58ba0c1c-d7ef-4b22-80a9-8adf8c442b02"), "image4", "Pure White Line" },
                    { new Guid("dd24d83a-c285-45e8-a26b-969ef8fe2970"), "Yellow Shrimp", new Guid("58ba0c1c-d7ef-4b22-80a9-8adf8c442b05"), new Guid("58ba0c1c-d7ef-4b22-80a9-8adf8c442b03"), "image7", "Yellow" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Shrimps",
                keyColumn: "Id",
                keyValue: new Guid("0ddf58d2-0dda-4ea6-9a49-86695ad9d569"));

            migrationBuilder.DeleteData(
                table: "Shrimps",
                keyColumn: "Id",
                keyValue: new Guid("3463cedb-0c49-469c-8a5d-dfbc9105b464"));

            migrationBuilder.DeleteData(
                table: "Shrimps",
                keyColumn: "Id",
                keyValue: new Guid("48712e81-383b-41d6-8879-3b0b1ace78d8"));

            migrationBuilder.DeleteData(
                table: "Shrimps",
                keyColumn: "Id",
                keyValue: new Guid("bceef984-27f2-4bec-b02d-25ef3d5acd18"));

            migrationBuilder.DeleteData(
                table: "Shrimps",
                keyColumn: "Id",
                keyValue: new Guid("c0505de0-424c-4388-af4b-b1fbd629433a"));

            migrationBuilder.DeleteData(
                table: "Shrimps",
                keyColumn: "Id",
                keyValue: new Guid("dd24d83a-c285-45e8-a26b-969ef8fe2970"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("58ba0c1c-d7ef-4b22-80a9-8adf8c442b05"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("58ba0c1c-d7ef-4b22-80a9-8adf8c442b06"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("58ba0c1c-d7ef-4b22-80a9-8adf8c442b07"));

            migrationBuilder.DeleteData(
                table: "Families",
                keyColumn: "Id",
                keyValue: new Guid("58ba0c1c-d7ef-4b22-80a9-8adf8c442b02"));

            migrationBuilder.DeleteData(
                table: "Families",
                keyColumn: "Id",
                keyValue: new Guid("58ba0c1c-d7ef-4b22-80a9-8adf8c442b03"));

            migrationBuilder.DeleteData(
                table: "Families",
                keyColumn: "Id",
                keyValue: new Guid("58ba0c1c-d7ef-4b22-80a9-8adf8c442b04"));

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
    }
}
