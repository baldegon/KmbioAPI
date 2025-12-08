using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KmbioAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddTablePresupuesto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recomendaciones_Capitales_PresupuestoId",
                table: "Recomendaciones");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b90d9c95-9692-40c9-a14a-c0fda10137c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d64a2d17-5fcd-43c1-b57d-fdba18143c12");

            migrationBuilder.AddColumn<int>(
                name: "CapitaleId",
                table: "Recomendaciones",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Presupuestos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MontoLimite = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Frecuencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presupuestos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Presupuestos_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "070bdb9e-d484-4f26-9223-9f451dd715ff", "070bdb9e-d484-4f26-9223-9f451dd715ff", "Client", "CLIENT" },
                    { "1c55b9ba-471d-49af-ba32-e9fe6fc105dd", "1c55b9ba-471d-49af-ba32-e9fe6fc105dd", "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recomendaciones_CapitaleId",
                table: "Recomendaciones",
                column: "CapitaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Presupuestos_UsuarioId",
                table: "Presupuestos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recomendaciones_Capitales_CapitaleId",
                table: "Recomendaciones",
                column: "CapitaleId",
                principalTable: "Capitales",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recomendaciones_Presupuestos_PresupuestoId",
                table: "Recomendaciones",
                column: "PresupuestoId",
                principalTable: "Presupuestos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recomendaciones_Capitales_CapitaleId",
                table: "Recomendaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Recomendaciones_Presupuestos_PresupuestoId",
                table: "Recomendaciones");

            migrationBuilder.DropTable(
                name: "Presupuestos");

            migrationBuilder.DropIndex(
                name: "IX_Recomendaciones_CapitaleId",
                table: "Recomendaciones");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "070bdb9e-d484-4f26-9223-9f451dd715ff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c55b9ba-471d-49af-ba32-e9fe6fc105dd");

            migrationBuilder.DropColumn(
                name: "CapitaleId",
                table: "Recomendaciones");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b90d9c95-9692-40c9-a14a-c0fda10137c1", "b90d9c95-9692-40c9-a14a-c0fda10137c1", "Client", "CLIENT" },
                    { "d64a2d17-5fcd-43c1-b57d-fdba18143c12", "d64a2d17-5fcd-43c1-b57d-fdba18143c12", "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Recomendaciones_Capitales_PresupuestoId",
                table: "Recomendaciones",
                column: "PresupuestoId",
                principalTable: "Capitales",
                principalColumn: "Id");
        }
    }
}
