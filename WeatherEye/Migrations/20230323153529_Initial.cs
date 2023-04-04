using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherEye.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnvironmentalSensors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dampness = table.Column<double>(type: "float", nullable: false),
                    Temperature = table.Column<double>(type: "float", nullable: false),
                    Pressure = table.Column<double>(type: "float", nullable: false),
                    IAQuality = table.Column<double>(type: "float", nullable: false),
                    DateOfReading = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnvironmentalSensors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LightSensors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IlluminanceLux = table.Column<double>(type: "float", nullable: false),
                    DateOfReading = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LightSensors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RainSensors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rain = table.Column<double>(type: "float", nullable: false),
                    IntensityOfRain = table.Column<double>(type: "float", nullable: false),
                    DateOfReading = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RainSensors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DustSensors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntensityPm2_5 = table.Column<double>(type: "float", nullable: false),
                    IntensityPm10 = table.Column<double>(type: "float", nullable: false),
                    DateOfReading = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UVSensors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IlluminanceUV = table.Column<double>(type: "float", nullable: false),
                    DateOfReading = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UVSensors", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnvironmentalSensors");

            migrationBuilder.DropTable(
                name: "LightSensors");

            migrationBuilder.DropTable(
                name: "RainSensors");

            migrationBuilder.DropTable(
                name: "Sensors");

            migrationBuilder.DropTable(
                name: "UVSensors");
        }
    }
}
