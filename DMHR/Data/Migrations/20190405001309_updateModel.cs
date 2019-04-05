using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DMHR.Data.Migrations
{
    public partial class updateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GetLicencias");

            migrationBuilder.DropTable(
                name: "GetPermisos");

            migrationBuilder.DropTable(
                name: "GetVacaciones");

            migrationBuilder.CreateTable(
                name: "Licencias",
                columns: table => new
                {
                    LicenciaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Desde = table.Column<DateTime>(type: "Date", nullable: false),
                    Hasta = table.Column<DateTime>(type: "Date", nullable: false),
                    Motivo = table.Column<string>(nullable: true),
                    Comentarios = table.Column<string>(nullable: true),
                    IsPaid = table.Column<bool>(nullable: false),
                    EmpleadoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licencias", x => x.LicenciaId);
                    table.ForeignKey(
                        name: "FK_Licencias_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permisos",
                columns: table => new
                {
                    PermisoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Desde = table.Column<DateTime>(type: "Date", nullable: false),
                    Hasta = table.Column<DateTime>(type: "Date", nullable: false),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    Comentarios = table.Column<string>(nullable: true),
                    IsPaid = table.Column<bool>(nullable: false),
                    EmpleadoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permisos", x => x.PermisoId);
                    table.ForeignKey(
                        name: "FK_Permisos_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vacaciones",
                columns: table => new
                {
                    VacacionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Desde = table.Column<DateTime>(type: "Date", nullable: false),
                    Hasta = table.Column<DateTime>(type: "Date", nullable: false),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    Comentarios = table.Column<string>(nullable: true),
                    IsPaid = table.Column<bool>(nullable: false),
                    EmpleadoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacaciones", x => x.VacacionId);
                    table.ForeignKey(
                        name: "FK_Vacaciones_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Licencias_EmpleadoId",
                table: "Licencias",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Permisos_EmpleadoId",
                table: "Permisos",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacaciones_EmpleadoId",
                table: "Vacaciones",
                column: "EmpleadoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Licencias");

            migrationBuilder.DropTable(
                name: "Permisos");

            migrationBuilder.DropTable(
                name: "Vacaciones");

            migrationBuilder.CreateTable(
                name: "GetLicencias",
                columns: table => new
                {
                    LicenciasId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comentarios = table.Column<string>(nullable: true),
                    Desde = table.Column<DateTime>(type: "Date", nullable: false),
                    EmpleadoId = table.Column<int>(nullable: false),
                    Hasta = table.Column<DateTime>(type: "Date", nullable: false),
                    IsPaid = table.Column<bool>(nullable: false),
                    Motivo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetLicencias", x => x.LicenciasId);
                    table.ForeignKey(
                        name: "FK_GetLicencias_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GetPermisos",
                columns: table => new
                {
                    PermisosId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comentarios = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    Desde = table.Column<DateTime>(type: "Date", nullable: false),
                    EmpleadoId = table.Column<int>(nullable: false),
                    Hasta = table.Column<DateTime>(type: "Date", nullable: false),
                    IsPaid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetPermisos", x => x.PermisosId);
                    table.ForeignKey(
                        name: "FK_GetPermisos_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GetVacaciones",
                columns: table => new
                {
                    VacacionesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comentarios = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    Desde = table.Column<DateTime>(type: "Date", nullable: false),
                    EmpleadoId = table.Column<int>(nullable: false),
                    Hasta = table.Column<DateTime>(type: "Date", nullable: false),
                    IsPaid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetVacaciones", x => x.VacacionesId);
                    table.ForeignKey(
                        name: "FK_GetVacaciones_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GetLicencias_EmpleadoId",
                table: "GetLicencias",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_GetPermisos_EmpleadoId",
                table: "GetPermisos",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_GetVacaciones_EmpleadoId",
                table: "GetVacaciones",
                column: "EmpleadoId");
        }
    }
}
