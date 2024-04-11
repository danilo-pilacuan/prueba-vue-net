using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VentaEntradas.Infraestructure.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionEvento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LugarEvento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrecioEvento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaEvento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eventos");
        }
    }
}
