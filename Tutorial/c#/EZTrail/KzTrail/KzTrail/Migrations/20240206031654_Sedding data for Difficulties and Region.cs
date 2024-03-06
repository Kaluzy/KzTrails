using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KzTrail.Migrations
{
    /// <inheritdoc />
    public partial class SeddingdataforDifficultiesandRegion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0f81ec6f-c675-4838-a967-4964b48d9b19"), "Easy" },
                    { new Guid("175e8a13-362f-4def-8a10-a8341433721f"), "Medium" },
                    { new Guid("e3b6933e-319f-4a06-bc58-3e6c9f5baddf"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("1a39d5f9-a70c-45e9-b61b-8fe1b964286b"), "DE", "Delaware", "delaware-img-url.jpg" },
                    { new Guid("a23ea3b9-47c4-4e82-a8f7-9d2f42a0c46d"), "IL", "Illionois", "illionois-img-url.jpg" },
                    { new Guid("d52fa863-033f-410f-8516-1da939891ac9"), "KS", "Kansas", "kansas-img-url.jpg" },
                    { new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f6"), "CA", "California", "california-img-url.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("0f81ec6f-c675-4838-a967-4964b48d9b19"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("175e8a13-362f-4def-8a10-a8341433721f"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("e3b6933e-319f-4a06-bc58-3e6c9f5baddf"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1a39d5f9-a70c-45e9-b61b-8fe1b964286b"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a23ea3b9-47c4-4e82-a8f7-9d2f42a0c46d"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d52fa863-033f-410f-8516-1da939891ac9"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f6"));
        }
    }
}
