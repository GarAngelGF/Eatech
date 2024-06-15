using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eatech.Migrations
{
    public partial class bdfinalv10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comidas",
                columns: table => new
                {
                    IDComida = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Visibilidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Porciones = table.Column<int>(type: "int", nullable: false),
                    PorcionesDisponibles = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comidas", x => x.IDComida);
                });

            migrationBuilder.CreateTable(
                name: "Ingredientes",
                columns: table => new
                {
                    IdIngrediente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredientes", x => x.IdIngrediente);
                });

            migrationBuilder.CreateTable(
                name: "LicenciaUsu",
                columns: table => new
                {
                    Clave = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenciaUsu", x => x.Clave);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    pedido = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaCPedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NotaPedido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.pedido);
                });

            migrationBuilder.CreateTable(
                name: "Intermedia_Comida_Ingre",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDComida = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdIngrediente = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Intermedia_Comida_Ingre_Comidas_IDComida",
                        column: x => x.IDComida,
                        principalTable: "Comidas",
                        principalColumn: "IDComida",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Intermedia_Comida_Ingre_Ingredientes_IdIngrediente",
                        column: x => x.IdIngrediente,
                        principalTable: "Ingredientes",
                        principalColumn: "IdIngrediente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Intermedia_Comida_Pedi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDComida = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    pedido = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Intermedia_Comida_Pedi_Comidas_IDComida",
                        column: x => x.IDComida,
                        principalTable: "Comidas",
                        principalColumn: "IDComida",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Intermedia_Comida_Pedi_Pedidos_pedido",
                        column: x => x.pedido,
                        principalTable: "Pedidos",
                        principalColumn: "pedido",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alumnos",
                columns: table => new
                {
                    IdAlumno = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoMatricula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    aPaterno = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    aMaterno = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Alergias = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Enfermedades = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    PreferenciasComida = table.Column<string>(type: "nvarchar(528)", maxLength: 528, nullable: false),
                    GradoEscolar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notas = table.Column<string>(type: "nvarchar(528)", maxLength: 528, nullable: false),
                    BdI_Usu_AlumId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos", x => x.IdAlumno);
                });

            migrationBuilder.CreateTable(
                name: "Intermedia_Alum_Pedi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    pedido = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdAlumno = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Intermedia_Alum_Pedi_Alumnos_IdAlumno",
                        column: x => x.IdAlumno,
                        principalTable: "Alumnos",
                        principalColumn: "IdAlumno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Intermedia_Alum_Pedi_Pedidos_pedido",
                        column: x => x.pedido,
                        principalTable: "Pedidos",
                        principalColumn: "pedido",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Intermedia_Usuario_Alumno",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdAlumno = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intermedia_Usuario_Alumno", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Intermedia_Usuario_Alumno_Alumnos_IdAlumno",
                        column: x => x.IdAlumno,
                        principalTable: "Alumnos",
                        principalColumn: "IdAlumno",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    aPaterno = table.Column<string>(type: "nvarchar(28)", maxLength: 28, nullable: false),
                    aMaterno = table.Column<string>(type: "nvarchar(28)", maxLength: 28, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TokenDRestauracion = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CaducidadToken = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BdI_Usu_AlumId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Intermedia_Usuario_Alumno_BdI_Usu_AlumId",
                        column: x => x.BdI_Usu_AlumId,
                        principalTable: "Intermedia_Usuario_Alumno",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LicenciaAdmin",
                columns: table => new
                {
                    IdLicencia = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaveLicencia = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenciaAdmin", x => x.IdLicencia);
                    table.ForeignKey(
                        name: "FK_LicenciaAdmin_LicenciaUsu_ClaveLicencia",
                        column: x => x.ClaveLicencia,
                        principalTable: "LicenciaUsu",
                        principalColumn: "Clave",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LicenciaAdmin_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_BdI_Usu_AlumId",
                table: "Alumnos",
                column: "BdI_Usu_AlumId");

            migrationBuilder.CreateIndex(
                name: "IX_Intermedia_Alum_Pedi_IdAlumno",
                table: "Intermedia_Alum_Pedi",
                column: "IdAlumno");

            migrationBuilder.CreateIndex(
                name: "IX_Intermedia_Alum_Pedi_pedido",
                table: "Intermedia_Alum_Pedi",
                column: "pedido");

            migrationBuilder.CreateIndex(
                name: "IX_Intermedia_Comida_Ingre_IDComida",
                table: "Intermedia_Comida_Ingre",
                column: "IDComida");

            migrationBuilder.CreateIndex(
                name: "IX_Intermedia_Comida_Ingre_IdIngrediente",
                table: "Intermedia_Comida_Ingre",
                column: "IdIngrediente");

            migrationBuilder.CreateIndex(
                name: "IX_Intermedia_Comida_Pedi_IDComida",
                table: "Intermedia_Comida_Pedi",
                column: "IDComida");

            migrationBuilder.CreateIndex(
                name: "IX_Intermedia_Comida_Pedi_pedido",
                table: "Intermedia_Comida_Pedi",
                column: "pedido");

            migrationBuilder.CreateIndex(
                name: "IX_Intermedia_Usuario_Alumno_IdAlumno",
                table: "Intermedia_Usuario_Alumno",
                column: "IdAlumno");

            migrationBuilder.CreateIndex(
                name: "IX_Intermedia_Usuario_Alumno_IdUsuario",
                table: "Intermedia_Usuario_Alumno",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_LicenciaAdmin_ClaveLicencia",
                table: "LicenciaAdmin",
                column: "ClaveLicencia");

            migrationBuilder.CreateIndex(
                name: "IX_LicenciaAdmin_IdUsuario",
                table: "LicenciaAdmin",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_BdI_Usu_AlumId",
                table: "Usuarios",
                column: "BdI_Usu_AlumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alumnos_Intermedia_Usuario_Alumno_BdI_Usu_AlumId",
                table: "Alumnos",
                column: "BdI_Usu_AlumId",
                principalTable: "Intermedia_Usuario_Alumno",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Intermedia_Usuario_Alumno_Usuarios_IdUsuario",
                table: "Intermedia_Usuario_Alumno",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alumnos_Intermedia_Usuario_Alumno_BdI_Usu_AlumId",
                table: "Alumnos");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Intermedia_Usuario_Alumno_BdI_Usu_AlumId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Intermedia_Alum_Pedi");

            migrationBuilder.DropTable(
                name: "Intermedia_Comida_Ingre");

            migrationBuilder.DropTable(
                name: "Intermedia_Comida_Pedi");

            migrationBuilder.DropTable(
                name: "LicenciaAdmin");

            migrationBuilder.DropTable(
                name: "Ingredientes");

            migrationBuilder.DropTable(
                name: "Comidas");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "LicenciaUsu");

            migrationBuilder.DropTable(
                name: "Intermedia_Usuario_Alumno");

            migrationBuilder.DropTable(
                name: "Alumnos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
