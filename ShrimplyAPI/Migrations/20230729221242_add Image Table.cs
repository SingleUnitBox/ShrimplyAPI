using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShrimplyAPI.Migrations
{
    public partial class addImageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSizeInBytes = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Shrimps",
                columns: new[] { "Id", "Description", "DifficultyId", "FamilyId", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("42c544f1-292f-4938-aae1-73052211c003"), "Pure Red Line Shrimp", new Guid("58ba0c1c-d7ef-4b22-80a9-8adf8c442b06"), new Guid("58ba0c1c-d7ef-4b22-80a9-8adf8c442b02"), "image5", "Pure Red Line" },
                    { new Guid("5d2ce064-3e0b-4c80-bac6-67ed5671a2c3"), "White Pearl", new Guid("58ba0c1c-d7ef-4b22-80a9-8adf8c442b05"), new Guid("58ba0c1c-d7ef-4b22-80a9-8adf8c442b03"), "image8", "White Pearl" },
                    { new Guid("9a376bed-dd58-40d1-9272-d2c6a664fbb0"), "Yellow Shrimp", new Guid("58ba0c1c-d7ef-4b22-80a9-8adf8c442b05"), new Guid("58ba0c1c-d7ef-4b22-80a9-8adf8c442b03"), "image7", "Yellow" },
                    { new Guid("b0f87f32-616a-44a4-b319-0f95ab12f410"), "Cardinal", new Guid("58ba0c1c-d7ef-4b22-80a9-8adf8c442b07"), new Guid("58ba0c1c-d7ef-4b22-80a9-8adf8c442b04"), "image9", "Cardinal" },
                    { new Guid("e7a43d70-ef76-4396-9942-c254cffb604d"), "Pure Black Line Shrimp", new Guid("58ba0c1c-d7ef-4b22-80a9-8adf8c442b06"), new Guid("58ba0c1c-d7ef-4b22-80a9-8adf8c442b02"), "image6", "Pure Black Line" },
                    { new Guid("fb80f05f-013a-4d26-96b1-b802828bf565"), "Pure White Line Shrimp", new Guid("58ba0c1c-d7ef-4b22-80a9-8adf8c442b06"), new Guid("58ba0c1c-d7ef-4b22-80a9-8adf8c442b02"), "image4", "Pure White Line" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DeleteData(
                table: "Shrimps",
                keyColumn: "Id",
                keyValue: new Guid("42c544f1-292f-4938-aae1-73052211c003"));

            migrationBuilder.DeleteData(
                table: "Shrimps",
                keyColumn: "Id",
                keyValue: new Guid("5d2ce064-3e0b-4c80-bac6-67ed5671a2c3"));

            migrationBuilder.DeleteData(
                table: "Shrimps",
                keyColumn: "Id",
                keyValue: new Guid("9a376bed-dd58-40d1-9272-d2c6a664fbb0"));

            migrationBuilder.DeleteData(
                table: "Shrimps",
                keyColumn: "Id",
                keyValue: new Guid("b0f87f32-616a-44a4-b319-0f95ab12f410"));

            migrationBuilder.DeleteData(
                table: "Shrimps",
                keyColumn: "Id",
                keyValue: new Guid("e7a43d70-ef76-4396-9942-c254cffb604d"));

            migrationBuilder.DeleteData(
                table: "Shrimps",
                keyColumn: "Id",
                keyValue: new Guid("fb80f05f-013a-4d26-96b1-b802828bf565"));

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
    }
}
