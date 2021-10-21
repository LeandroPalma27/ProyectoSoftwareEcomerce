using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Evaluacion4.Migrations
{
    public partial class ModeloCompraFactura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "AspNetRoles",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(nullable: false),
            //        Name = table.Column<string>(maxLength: 256, nullable: true),
            //        NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
            //        ConcurrencyStamp = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoles", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUsers",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(nullable: false),
            //        UserName = table.Column<string>(maxLength: 100, nullable: true, defaultValue: "0"),
            //        NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
            //        Email = table.Column<string>(maxLength: 256, nullable: true),
            //        NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
            //        EmailConfirmed = table.Column<bool>(nullable: false),
            //        PasswordHash = table.Column<string>(nullable: true),
            //        SecurityStamp = table.Column<string>(nullable: true),
            //        ConcurrencyStamp = table.Column<string>(nullable: true),
            //        PhoneNumber = table.Column<string>(nullable: true),
            //        PhoneNumberConfirmed = table.Column<bool>(nullable: false),
            //        TwoFactorEnabled = table.Column<bool>(nullable: false),
            //        LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
            //        LockoutEnabled = table.Column<bool>(nullable: false),
            //        AccessFailedCount = table.Column<int>(nullable: false),
            //        Nombre = table.Column<string>(maxLength: 50, nullable: true),
            //        APaterno = table.Column<string>(maxLength: 50, nullable: true),
            //        AMaterno = table.Column<string>(maxLength: 50, nullable: true),
            //        DNI = table.Column<string>(maxLength: 8, nullable: true),
            //        Direccion = table.Column<string>(maxLength: 60, nullable: true),
            //        Imagen = table.Column<string>(maxLength: 100, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUsers", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Categoria",
            //    columns: table => new
            //    {
            //        IdCategoria = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        NombreCategoria = table.Column<string>(maxLength: 100, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Categoria", x => x.IdCategoria);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetRoleClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        RoleId = table.Column<string>(nullable: false),
            //        ClaimType = table.Column<string>(nullable: true),
            //        ClaimValue = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<string>(nullable: false),
            //        ClaimType = table.Column<string>(nullable: true),
            //        ClaimValue = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserClaims_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserLogins",
            //    columns: table => new
            //    {
            //        LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
            //        ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
            //        ProviderDisplayName = table.Column<string>(nullable: true),
            //        UserId = table.Column<string>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserLogins_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserRoles",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(nullable: false),
            //        RoleId = table.Column<string>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserTokens",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(nullable: false),
            //        LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
            //        Name = table.Column<string>(maxLength: 128, nullable: false),
            //        Value = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserTokens_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            migrationBuilder.CreateTable(
                name: "CompraFactura",
                columns: table => new
                {
                    IdFactura = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaFactura = table.Column<DateTime>(nullable: false),
                    PrecioTotal = table.Column<double>(nullable: false),
                    JsonCompras = table.Column<string>(nullable: true),
                    Id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompraFactura", x => x.IdFactura);
                    table.ForeignKey(
                        name: "FK_CompraFactura_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            //migrationBuilder.CreateTable(
            //    name: "Producto",
            //    columns: table => new
            //    {
            //        IdProducto = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Nombre = table.Column<string>(maxLength: 150, nullable: false),
            //        Descripcion = table.Column<string>(maxLength: 150, nullable: false),
            //        Codigo = table.Column<string>(maxLength: 15, nullable: false),
            //        Stock = table.Column<float>(nullable: false),
            //        Precio = table.Column<float>(nullable: false),
            //        FechaRegistro = table.Column<DateTime>(nullable: false),
            //        Imagen = table.Column<string>(nullable: true),
            //        IdCategoria = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Producto", x => x.IdProducto);
            //        table.ForeignKey(
            //            name: "FK_Producto_Categoria_IdCategoria",
            //            column: x => x.IdCategoria,
            //            principalTable: "Categoria",
            //            principalColumn: "IdCategoria",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Compras",
            //    columns: table => new
            //    {
            //        IdCompras = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        IdProducto = table.Column<int>(nullable: false),
            //        Id = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Compras", x => x.IdCompras);
            //        table.ForeignKey(
            //            name: "FK_Compras_AspNetUsers_Id",
            //            column: x => x.Id,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Compras_Producto_IdProducto",
            //            column: x => x.IdProducto,
            //            principalTable: "Producto",
            //            principalColumn: "IdProducto",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "HistorialCompras",
            //    columns: table => new
            //    {
            //        IdHistorial = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FechaHistorial = table.Column<DateTime>(nullable: false),
            //        PrecioProducto = table.Column<float>(nullable: false),
            //        IdProducto = table.Column<int>(nullable: false),
            //        Id = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_HistorialCompras", x => x.IdHistorial);
            //        table.ForeignKey(
            //            name: "FK_HistorialCompras_AspNetUsers_Id",
            //            column: x => x.Id,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_HistorialCompras_Producto_IdProducto",
            //            column: x => x.IdProducto,
            //            principalTable: "Producto",
            //            principalColumn: "IdProducto",
            //            onDelete: ReferentialAction.Cascade);
            //    });

        //    migrationBuilder.CreateIndex(
        //        name: "IX_AspNetRoleClaims_RoleId",
        //        table: "AspNetRoleClaims",
        //        column: "RoleId");

        //    migrationBuilder.CreateIndex(
        //        name: "RoleNameIndex",
        //        table: "AspNetRoles",
        //        column: "NormalizedName",
        //        unique: true,
        //        filter: "[NormalizedName] IS NOT NULL");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_AspNetUserClaims_UserId",
        //        table: "AspNetUserClaims",
        //        column: "UserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_AspNetUserLogins_UserId",
        //        table: "AspNetUserLogins",
        //        column: "UserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_AspNetUserRoles_RoleId",
        //        table: "AspNetUserRoles",
        //        column: "RoleId");

        //    migrationBuilder.CreateIndex(
        //        name: "EmailIndex",
        //        table: "AspNetUsers",
        //        column: "NormalizedEmail");

        //    migrationBuilder.CreateIndex(
        //        name: "UserNameIndex",
        //        table: "AspNetUsers",
        //        column: "NormalizedUserName",
        //        unique: true,
        //        filter: "[NormalizedUserName] IS NOT NULL");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_CompraFactura_Id",
        //        table: "CompraFactura",
        //        column: "Id");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Compras_Id",
        //        table: "Compras",
        //        column: "Id");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Compras_IdProducto",
        //        table: "Compras",
        //        column: "IdProducto");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_HistorialCompras_Id",
        //        table: "HistorialCompras",
        //        column: "Id");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_HistorialCompras_IdProducto",
        //        table: "HistorialCompras",
        //        column: "IdProducto");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Producto_IdCategoria",
        //        table: "Producto",
        //        column: "IdCategoria");
        //}

        //protected override void Down(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.DropTable(
        //        name: "AspNetRoleClaims");

        //    migrationBuilder.DropTable(
        //        name: "AspNetUserClaims");

        //    migrationBuilder.DropTable(
        //        name: "AspNetUserLogins");

        //    migrationBuilder.DropTable(
        //        name: "AspNetUserRoles");

        //    migrationBuilder.DropTable(
        //        name: "AspNetUserTokens");

        //    migrationBuilder.DropTable(
        //        name: "CompraFactura");

        //    migrationBuilder.DropTable(
        //        name: "Compras");

        //    migrationBuilder.DropTable(
        //        name: "HistorialCompras");

        //    migrationBuilder.DropTable(
        //        name: "AspNetRoles");

        //    migrationBuilder.DropTable(
        //        name: "AspNetUsers");

        //    migrationBuilder.DropTable(
        //        name: "Producto");

        //    migrationBuilder.DropTable(
        //        name: "Categoria");
        }
    }
}
