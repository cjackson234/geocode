using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Geocode.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeoData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lat = table.Column<double>(type: "float", nullable: false),
                    Lng = table.Column<double>(type: "float", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zcta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentZcta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Population = table.Column<int>(type: "int", nullable: true),
                    Density = table.Column<double>(type: "float", nullable: true),
                    CountyFips = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountyWeights = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imprecise = table.Column<bool>(type: "bit", nullable: false),
                    Military = table.Column<bool>(type: "bit", nullable: false),
                    Timezone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeoData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountyFipsData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountyFips = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeoDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountyFipsData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountyFipsData_GeoData_GeoDataId",
                        column: x => x.GeoDataId,
                        principalTable: "GeoData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CountyNames",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeoDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountyNames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountyNames_GeoData_GeoDataId",
                        column: x => x.GeoDataId,
                        principalTable: "GeoData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountyFipsData_GeoDataId",
                table: "CountyFipsData",
                column: "GeoDataId");

            migrationBuilder.CreateIndex(
                name: "IX_CountyNames_GeoDataId",
                table: "CountyNames",
                column: "GeoDataId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountyFipsData");

            migrationBuilder.DropTable(
                name: "CountyNames");

            migrationBuilder.DropTable(
                name: "GeoData");
        }
    }
}
