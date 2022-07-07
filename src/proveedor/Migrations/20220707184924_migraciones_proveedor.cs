using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RCVUcabBackend.Migrations
{
    public partial class migraciones_proveedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "Cotizacion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    costo_total = table.Column<double>(type: "double precision", nullable: false),
                    tiempo_de_entrega = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotizacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marca",
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
                    table.PrimaryKey("PK_Marca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdenDeCompra",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    costo_total = table.Column<double>(type: "double precision", nullable: false),
                    tiempo_de_entrega = table.Column<int>(type: "integer", nullable: false),
                    estado = table.Column<int>(type: "integer", nullable: false),
                    fecha_vencimiento = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenDeCompra", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pieza",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    costo = table.Column<double>(type: "double precision", maxLength: 100, nullable: false),
                    tipo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
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
                name: "Solicitud",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    estado = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitud", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Proveedor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    tipo = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Proveedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CotizacionEntityPiezaEntity",
                columns: table => new
                {
                    cotizacionesId = table.Column<Guid>(type: "uuid", nullable: false),
                    piezasId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CotizacionEntityPiezaEntity", x => new { x.cotizacionesId, x.piezasId });
                    table.ForeignKey(
                        name: "FK_CotizacionEntityPiezaEntity_Cotizacion_cotizacionesId",
                        column: x => x.cotizacionesId,
                        principalTable: "Cotizacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CotizacionEntityPiezaEntity_Pieza_piezasId",
                        column: x => x.piezasId,
                        principalTable: "Pieza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenDeCompraEntityPiezaEntity",
                columns: table => new
                {
                    ordenesId = table.Column<Guid>(type: "uuid", nullable: false),
                    piezasId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenDeCompraEntityPiezaEntity", x => new { x.ordenesId, x.piezasId });
                    table.ForeignKey(
                        name: "FK_OrdenDeCompraEntityPiezaEntity_OrdenDeCompra_ordenesId",
                        column: x => x.ordenesId,
                        principalTable: "OrdenDeCompra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenDeCompraEntityPiezaEntity_Pieza_piezasId",
                        column: x => x.piezasId,
                        principalTable: "Pieza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PiezaEntitySolicitudEntity",
                columns: table => new
                {
                    piezasId = table.Column<Guid>(type: "uuid", nullable: false),
                    solicitudesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PiezaEntitySolicitudEntity", x => new { x.piezasId, x.solicitudesId });
                    table.ForeignKey(
                        name: "FK_PiezaEntitySolicitudEntity_Pieza_piezasId",
                        column: x => x.piezasId,
                        principalTable: "Pieza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PiezaEntitySolicitudEntity_Solicitud_solicitudesId",
                        column: x => x.solicitudesId,
                        principalTable: "Solicitud",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    direccion = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    telefono = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    tipoId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proveedor_Tipo_Proveedor_tipoId",
                        column: x => x.tipoId,
                        principalTable: "Tipo_Proveedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MarcaEntityProveedorEntity",
                columns: table => new
                {
                    marcasId = table.Column<Guid>(type: "uuid", nullable: false),
                    proveedoresId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcaEntityProveedorEntity", x => new { x.marcasId, x.proveedoresId });
                    table.ForeignKey(
                        name: "FK_MarcaEntityProveedorEntity_Marca_marcasId",
                        column: x => x.marcasId,
                        principalTable: "Marca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarcaEntityProveedorEntity_Proveedor_proveedoresId",
                        column: x => x.proveedoresId,
                        principalTable: "Proveedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProveedorEntitySolicitudEntity",
                columns: table => new
                {
                    proveedoresId = table.Column<Guid>(type: "uuid", nullable: false),
                    solicitudesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProveedorEntitySolicitudEntity", x => new { x.proveedoresId, x.solicitudesId });
                    table.ForeignKey(
                        name: "FK_ProveedorEntitySolicitudEntity_Proveedor_proveedoresId",
                        column: x => x.proveedoresId,
                        principalTable: "Proveedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProveedorEntitySolicitudEntity_Solicitud_solicitudesId",
                        column: x => x.solicitudesId,
                        principalTable: "Solicitud",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CotizacionEntityPiezaEntity_piezasId",
                table: "CotizacionEntityPiezaEntity",
                column: "piezasId");

            migrationBuilder.CreateIndex(
                name: "IX_MarcaEntityProveedorEntity_proveedoresId",
                table: "MarcaEntityProveedorEntity",
                column: "proveedoresId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenDeCompraEntityPiezaEntity_piezasId",
                table: "OrdenDeCompraEntityPiezaEntity",
                column: "piezasId");

            migrationBuilder.CreateIndex(
                name: "IX_PiezaEntitySolicitudEntity_solicitudesId",
                table: "PiezaEntitySolicitudEntity",
                column: "solicitudesId");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_tipoId",
                table: "Proveedor",
                column: "tipoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProveedorEntitySolicitudEntity_solicitudesId",
                table: "ProveedorEntitySolicitudEntity",
                column: "solicitudesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CotizacionEntityPiezaEntity");

            migrationBuilder.DropTable(
                name: "MarcaEntityProveedorEntity");

            migrationBuilder.DropTable(
                name: "OrdenDeCompraEntityPiezaEntity");

            migrationBuilder.DropTable(
                name: "PiezaEntitySolicitudEntity");

            migrationBuilder.DropTable(
                name: "ProveedorEntitySolicitudEntity");

            migrationBuilder.DropTable(
                name: "Cotizacion");

            migrationBuilder.DropTable(
                name: "Marca");

            migrationBuilder.DropTable(
                name: "OrdenDeCompra");

            migrationBuilder.DropTable(
                name: "Pieza");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "Solicitud");

            migrationBuilder.DropTable(
                name: "Tipo_Proveedor");
        }
    }
}
