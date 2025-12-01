using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KmbioAPI.Migrations
{
    /// <inheritdoc />
    public partial class ConsolidarFKUsuariosString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auditorias_AspNetUsers_UsuarioId1",
                table: "Auditorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Capitales_AspNetUsers_UsuarioId1",
                table: "Capitales");

            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_AspNetUsers_UsuarioId1",
                table: "Categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Gastos_AspNetUsers_UserId1",
                table: "Gastos");

            migrationBuilder.DropForeignKey(
                name: "FK_GastosRecurrentes_AspNetUsers_UsuarioId1",
                table: "GastosRecurrentes");

            migrationBuilder.DropForeignKey(
                name: "FK_MetodosDePagos_AspNetUsers_UsuarioId1",
                table: "MetodosDePagos");

            migrationBuilder.DropForeignKey(
                name: "FK_Recomendaciones_AspNetUsers_UsuarioId1",
                table: "Recomendaciones");

            migrationBuilder.DropIndex(
                name: "IX_Recomendaciones_UsuarioId1",
                table: "Recomendaciones");

            migrationBuilder.DropIndex(
                name: "IX_MetodosDePagos_UsuarioId1",
                table: "MetodosDePagos");

            migrationBuilder.DropIndex(
                name: "IX_GastosRecurrentes_UsuarioId1",
                table: "GastosRecurrentes");

            migrationBuilder.DropIndex(
                name: "IX_Gastos_UserId1",
                table: "Gastos");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_UsuarioId1",
                table: "Categorias");

            migrationBuilder.DropIndex(
                name: "IX_Capitales_UsuarioId1",
                table: "Capitales");

            migrationBuilder.DropIndex(
                name: "IX_Auditorias_UsuarioId1",
                table: "Auditorias");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1ef1e54-2ac7-4438-a052-8072b5a202a0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4013b4d-de23-4022-aad6-55a32fdde745");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                table: "Recomendaciones");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                table: "MetodosDePagos");

            migrationBuilder.DropColumn(
                name: "MetodoPagoId",
                table: "GastosRecurrentes");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                table: "GastosRecurrentes");

            migrationBuilder.DropColumn(
                name: "MetodoPagoId",
                table: "Gastos");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Gastos");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                table: "Capitales");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                table: "Auditorias");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Recomendaciones",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Recomendaciones",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "MetodosDePagos",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "MetodosDePagos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "GastosRecurrentes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "GastosRecurrentes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Gastos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Categorias",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Categorias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Capitales",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Capitales",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Auditorias",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Auditorias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b90d9c95-9692-40c9-a14a-c0fda10137c1", "b90d9c95-9692-40c9-a14a-c0fda10137c1", "Client", "CLIENT" },
                    { "d64a2d17-5fcd-43c1-b57d-fdba18143c12", "d64a2d17-5fcd-43c1-b57d-fdba18143c12", "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recomendaciones_UsuarioId",
                table: "Recomendaciones",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_MetodosDePagos_UsuarioId",
                table: "MetodosDePagos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_GastosRecurrentes_UsuarioId",
                table: "GastosRecurrentes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Gastos_UserId",
                table: "Gastos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_UsuarioId",
                table: "Categorias",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Capitales_UsuarioId",
                table: "Capitales",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Auditorias_UsuarioId",
                table: "Auditorias",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Auditorias_AspNetUsers_UsuarioId",
                table: "Auditorias",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Capitales_AspNetUsers_UsuarioId",
                table: "Capitales",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_AspNetUsers_UsuarioId",
                table: "Categorias",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gastos_AspNetUsers_UserId",
                table: "Gastos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GastosRecurrentes_AspNetUsers_UsuarioId",
                table: "GastosRecurrentes",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MetodosDePagos_AspNetUsers_UsuarioId",
                table: "MetodosDePagos",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recomendaciones_AspNetUsers_UsuarioId",
                table: "Recomendaciones",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auditorias_AspNetUsers_UsuarioId",
                table: "Auditorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Capitales_AspNetUsers_UsuarioId",
                table: "Capitales");

            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_AspNetUsers_UsuarioId",
                table: "Categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Gastos_AspNetUsers_UserId",
                table: "Gastos");

            migrationBuilder.DropForeignKey(
                name: "FK_GastosRecurrentes_AspNetUsers_UsuarioId",
                table: "GastosRecurrentes");

            migrationBuilder.DropForeignKey(
                name: "FK_MetodosDePagos_AspNetUsers_UsuarioId",
                table: "MetodosDePagos");

            migrationBuilder.DropForeignKey(
                name: "FK_Recomendaciones_AspNetUsers_UsuarioId",
                table: "Recomendaciones");

            migrationBuilder.DropIndex(
                name: "IX_Recomendaciones_UsuarioId",
                table: "Recomendaciones");

            migrationBuilder.DropIndex(
                name: "IX_MetodosDePagos_UsuarioId",
                table: "MetodosDePagos");

            migrationBuilder.DropIndex(
                name: "IX_GastosRecurrentes_UsuarioId",
                table: "GastosRecurrentes");

            migrationBuilder.DropIndex(
                name: "IX_Gastos_UserId",
                table: "Gastos");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_UsuarioId",
                table: "Categorias");

            migrationBuilder.DropIndex(
                name: "IX_Capitales_UsuarioId",
                table: "Capitales");

            migrationBuilder.DropIndex(
                name: "IX_Auditorias_UsuarioId",
                table: "Auditorias");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b90d9c95-9692-40c9-a14a-c0fda10137c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d64a2d17-5fcd-43c1-b57d-fdba18143c12");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Recomendaciones",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Recomendaciones",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId1",
                table: "Recomendaciones",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "MetodosDePagos",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "MetodosDePagos",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId1",
                table: "MetodosDePagos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "GastosRecurrentes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "GastosRecurrentes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "MetodoPagoId",
                table: "GastosRecurrentes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId1",
                table: "GastosRecurrentes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Gastos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "MetodoPagoId",
                table: "Gastos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Gastos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Categorias",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Categorias",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId1",
                table: "Categorias",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Capitales",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Capitales",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId1",
                table: "Capitales",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Auditorias",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Auditorias",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId1",
                table: "Auditorias",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d1ef1e54-2ac7-4438-a052-8072b5a202a0", "d1ef1e54-2ac7-4438-a052-8072b5a202a0", "Client", "CLIENT" },
                    { "f4013b4d-de23-4022-aad6-55a32fdde745", "f4013b4d-de23-4022-aad6-55a32fdde745", "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recomendaciones_UsuarioId1",
                table: "Recomendaciones",
                column: "UsuarioId1");

            migrationBuilder.CreateIndex(
                name: "IX_MetodosDePagos_UsuarioId1",
                table: "MetodosDePagos",
                column: "UsuarioId1");

            migrationBuilder.CreateIndex(
                name: "IX_GastosRecurrentes_UsuarioId1",
                table: "GastosRecurrentes",
                column: "UsuarioId1");

            migrationBuilder.CreateIndex(
                name: "IX_Gastos_UserId1",
                table: "Gastos",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_UsuarioId1",
                table: "Categorias",
                column: "UsuarioId1");

            migrationBuilder.CreateIndex(
                name: "IX_Capitales_UsuarioId1",
                table: "Capitales",
                column: "UsuarioId1");

            migrationBuilder.CreateIndex(
                name: "IX_Auditorias_UsuarioId1",
                table: "Auditorias",
                column: "UsuarioId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Auditorias_AspNetUsers_UsuarioId1",
                table: "Auditorias",
                column: "UsuarioId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Capitales_AspNetUsers_UsuarioId1",
                table: "Capitales",
                column: "UsuarioId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_AspNetUsers_UsuarioId1",
                table: "Categorias",
                column: "UsuarioId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gastos_AspNetUsers_UserId1",
                table: "Gastos",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GastosRecurrentes_AspNetUsers_UsuarioId1",
                table: "GastosRecurrentes",
                column: "UsuarioId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MetodosDePagos_AspNetUsers_UsuarioId1",
                table: "MetodosDePagos",
                column: "UsuarioId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recomendaciones_AspNetUsers_UsuarioId1",
                table: "Recomendaciones",
                column: "UsuarioId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
