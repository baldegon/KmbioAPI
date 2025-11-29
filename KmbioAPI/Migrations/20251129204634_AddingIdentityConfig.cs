using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KmbioAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddingIdentityConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                    IF EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_Gastos_UserId' AND object_id = OBJECT_ID('Gastos'))
                    BEGIN
                        DROP INDEX IX_Gastos_UserId ON Gastos;
                    END
                ");

            //migrationBuilder.DropIndex(
            //    name: "IX_Gastos_UserId",
            //    table: "Gastos");

            migrationBuilder.DropForeignKey(
                name: "FK_Auditorias_Usuarios_UsuarioId",
                table: "Auditorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Capitales_Usuarios_UsuarioId",
                table: "Capitales");

            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Usuarios_UsuarioId",
                table: "Categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Gastos_Categorias_CategoriaId",
                table: "Gastos");

            migrationBuilder.DropForeignKey(
                name: "FK_Gastos_MetodosDePago_MetodoDePagoId",
                table: "Gastos");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Gastos_Usuarios_UserId",
            //    table: "Gastos");

            migrationBuilder.DropForeignKey(
                name: "FK_GastosRecurrentes_MetodosDePago_MetodoDePagoId",
                table: "GastosRecurrentes");

            migrationBuilder.DropForeignKey(
                name: "FK_GastosRecurrentes_Usuarios_UsuarioId",
                table: "GastosRecurrentes");

            migrationBuilder.DropForeignKey(
                name: "FK_MetodosDePago_Usuarios_UsuarioId",
                table: "MetodosDePago");

            migrationBuilder.DropForeignKey(
                name: "FK_Recomendaciones_Usuarios_UsuarioId",
                table: "Recomendaciones");

            //migrationBuilder.DropTable(
            //    name: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Recomendaciones_UsuarioId",
                table: "Recomendaciones");

            migrationBuilder.DropIndex(
                name: "IX_GastosRecurrentes_UsuarioId",
                table: "GastosRecurrentes");

            //migrationBuilder.DropIndex(
            //    name: "IX_Gastos_UserId",
            //    table: "Gastos");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_UsuarioId",
                table: "Categorias");

            migrationBuilder.DropIndex(
                name: "IX_Capitales_UsuarioId",
                table: "Capitales");

            migrationBuilder.DropIndex(
                name: "IX_Auditorias_UsuarioId",
                table: "Auditorias");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MetodosDePago",
                table: "MetodosDePago");

            migrationBuilder.DropIndex(
                name: "IX_MetodosDePago_UsuarioId",
                table: "MetodosDePago");

            migrationBuilder.RenameTable(
                name: "MetodosDePago",
                newName: "MetodosDePagos");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId1",
                table: "Recomendaciones",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId1",
                table: "GastosRecurrentes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Gastos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId1",
                table: "Categorias",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId1",
                table: "Capitales",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId1",
                table: "Auditorias",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CurrencyDefault",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId1",
                table: "MetodosDePagos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MetodosDePagos",
                table: "MetodosDePagos",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MetodosDePagos_UsuarioId1",
                table: "MetodosDePagos",
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
                name: "FK_Gastos_Categorias_CategoriaId",
                table: "Gastos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gastos_MetodosDePagos_MetodoDePagoId",
                table: "Gastos",
                column: "MetodoDePagoId",
                principalTable: "MetodosDePagos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GastosRecurrentes_AspNetUsers_UsuarioId1",
                table: "GastosRecurrentes",
                column: "UsuarioId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GastosRecurrentes_MetodosDePagos_MetodoDePagoId",
                table: "GastosRecurrentes",
                column: "MetodoDePagoId",
                principalTable: "MetodosDePagos",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "FK_Gastos_Categorias_CategoriaId",
                table: "Gastos");

            migrationBuilder.DropForeignKey(
                name: "FK_Gastos_MetodosDePagos_MetodoDePagoId",
                table: "Gastos");

            migrationBuilder.DropForeignKey(
                name: "FK_GastosRecurrentes_AspNetUsers_UsuarioId1",
                table: "GastosRecurrentes");

            migrationBuilder.DropForeignKey(
                name: "FK_GastosRecurrentes_MetodosDePagos_MetodoDePagoId",
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

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MetodosDePagos",
                table: "MetodosDePagos");

            migrationBuilder.DropIndex(
                name: "IX_MetodosDePagos_UsuarioId1",
                table: "MetodosDePagos");

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
                table: "GastosRecurrentes");

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

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CurrencyDefault",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                table: "MetodosDePagos");

            migrationBuilder.RenameTable(
                name: "MetodosDePagos",
                newName: "MetodosDePago");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MetodosDePago",
                table: "MetodosDePago",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrencyDefault = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recomendaciones_UsuarioId",
                table: "Recomendaciones",
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

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "([NormalizedUserName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "([NormalizedName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_MetodosDePago_UsuarioId",
                table: "MetodosDePago",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Username",
                table: "Usuarios",
                column: "Username",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Auditorias_Usuarios_UsuarioId",
                table: "Auditorias",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Capitales_Usuarios_UsuarioId",
                table: "Capitales",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Usuarios_UsuarioId",
                table: "Categorias",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gastos_Categorias_CategoriaId",
                table: "Gastos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Gastos_MetodosDePago_MetodoDePagoId",
                table: "Gastos",
                column: "MetodoDePagoId",
                principalTable: "MetodosDePago",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gastos_Usuarios_UserId",
                table: "Gastos",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GastosRecurrentes_MetodosDePago_MetodoDePagoId",
                table: "GastosRecurrentes",
                column: "MetodoDePagoId",
                principalTable: "MetodosDePago",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GastosRecurrentes_Usuarios_UsuarioId",
                table: "GastosRecurrentes",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MetodosDePago_Usuarios_UsuarioId",
                table: "MetodosDePago",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recomendaciones_Usuarios_UsuarioId",
                table: "Recomendaciones",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
