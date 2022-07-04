using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace perito.Persistence.Migrations
{
    public partial class bdPerito : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "Analisis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analisis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DireccionEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    calle = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    municipio = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    parroquia = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DireccionEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pieza",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pieza", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario_perito",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    nombres = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    apellidos = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    email = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    contrasena = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    direccionId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario_perito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_perito_DireccionEntity_direccionId",
                        column: x => x.direccionId,
                        principalTable: "DireccionEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_perito_direccionId",
                table: "Usuario_perito",
                column: "direccionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Analisis");

            migrationBuilder.DropTable(
                name: "Pieza");

            migrationBuilder.DropTable(
                name: "Usuario_perito");

            migrationBuilder.DropTable(
                name: "DireccionEntity");
        }
    }
}
