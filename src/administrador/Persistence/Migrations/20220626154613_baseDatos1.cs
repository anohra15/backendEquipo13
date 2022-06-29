using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace administrador.Persistence.Migrations
{
    public partial class baseDatos1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "asegurado",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    ci = table.Column<int>(type: "integer", nullable: false),
                    primer_n = table.Column<string>(type: "text", nullable: false),
                    segundo_n = table.Column<string>(type: "text", nullable: false),
                    primer_a = table.Column<string>(type: "text", nullable: false),
                    segundo_a = table.Column<string>(type: "text", nullable: false),
                    sexo = table.Column<char>(type: "character(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asegurado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    mail = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    tipo = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "poliza",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    aseguradoId = table.Column<Guid>(type: "uuid", nullable: false),
                    tipo = table.Column<string>(type: "text", nullable: false),
                    vencimiento = table.Column<DateTime>(type: "DATE", nullable: false),
                    PolizaEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_poliza", x => x.Id);
                    table.ForeignKey(
                        name: "FK_poliza_asegurado_aseguradoId",
                        column: x => x.aseguradoId,
                        principalTable: "asegurado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_poliza_poliza_PolizaEntityId",
                        column: x => x.PolizaEntityId,
                        principalTable: "poliza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    seguroId = table.Column<Guid>(type: "uuid", nullable: true),
                    marca = table.Column<Guid>(type: "uuid", nullable: false),
                    placa = table.Column<string>(type: "text", nullable: false),
                    tipo = table.Column<string>(type: "text", nullable: false),
                    color = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cars_poliza_seguroId",
                        column: x => x.seguroId,
                        principalTable: "poliza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "incident",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    adminId = table.Column<Guid>(type: "uuid", nullable: false),
                    polizaId = table.Column<Guid>(type: "uuid", nullable: false),
                    descripcion = table.Column<string>(type: "text", nullable: true),
                    ubicacion = table.Column<string>(type: "text", nullable: true),
                    fecha = table.Column<DateTime>(type: "DATE", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_incident", x => x.Id);
                    table.ForeignKey(
                        name: "FK_incident_poliza_polizaId",
                        column: x => x.polizaId,
                        principalTable: "poliza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_incident_user_adminId",
                        column: x => x.adminId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cars_seguroId",
                table: "cars",
                column: "seguroId");

            migrationBuilder.CreateIndex(
                name: "IX_incident_adminId",
                table: "incident",
                column: "adminId");

            migrationBuilder.CreateIndex(
                name: "IX_incident_polizaId",
                table: "incident",
                column: "polizaId");

            migrationBuilder.CreateIndex(
                name: "IX_poliza_aseguradoId",
                table: "poliza",
                column: "aseguradoId");

            migrationBuilder.CreateIndex(
                name: "IX_poliza_PolizaEntityId",
                table: "poliza",
                column: "PolizaEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cars");

            migrationBuilder.DropTable(
                name: "incident");

            migrationBuilder.DropTable(
                name: "poliza");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "asegurado");
        }
    }
}
