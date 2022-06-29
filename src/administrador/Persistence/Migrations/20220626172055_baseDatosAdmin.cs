using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace administrador.Persistence.Migrations
{
    public partial class baseDatosAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_poliza_asegurado_aseguradoId",
                table: "poliza");

            migrationBuilder.AlterColumn<Guid>(
                name: "aseguradoId",
                table: "poliza",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "segundo_n",
                table: "asegurado",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "segundo_a",
                table: "asegurado",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "primer_n",
                table: "asegurado",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "primer_a",
                table: "asegurado",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_poliza_asegurado_aseguradoId",
                table: "poliza",
                column: "aseguradoId",
                principalTable: "asegurado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_poliza_asegurado_aseguradoId",
                table: "poliza");

            migrationBuilder.AlterColumn<Guid>(
                name: "aseguradoId",
                table: "poliza",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "segundo_n",
                table: "asegurado",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "segundo_a",
                table: "asegurado",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "primer_n",
                table: "asegurado",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "primer_a",
                table: "asegurado",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_poliza_asegurado_aseguradoId",
                table: "poliza",
                column: "aseguradoId",
                principalTable: "asegurado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
