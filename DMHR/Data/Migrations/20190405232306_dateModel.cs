using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DMHR.Data.Migrations
{
    public partial class dateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Licencias_Empleados_EmpleadoId",
                table: "Licencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Permisos_Empleados_EmpleadoId",
                table: "Permisos");

            migrationBuilder.DropForeignKey(
                name: "FK_SalidadeEmpleados_Empleados_EmpleadoId",
                table: "SalidadeEmpleados");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacaciones_Empleados_EmpleadoId",
                table: "Vacaciones");

            migrationBuilder.DropIndex(
                name: "IX_Vacaciones_EmpleadoId",
                table: "Vacaciones");

            migrationBuilder.DropIndex(
                name: "IX_SalidadeEmpleados_EmpleadoId",
                table: "SalidadeEmpleados");

            migrationBuilder.DropIndex(
                name: "IX_Permisos_EmpleadoId",
                table: "Permisos");

            migrationBuilder.DropIndex(
                name: "IX_Licencias_EmpleadoId",
                table: "Licencias");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Vacaciones");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Permisos");

            migrationBuilder.DropColumn(
                name: "Month",
                table: "Nominas");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Nominas",
                newName: "Date");

            migrationBuilder.AddColumn<int>(
                name: "Año",
                table: "Vacaciones",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LicenciaId",
                table: "Empleados",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PermisoId",
                table: "Empleados",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalidadeEmpleadoSalidaEmpleadoId",
                table: "Empleados",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VacacionId",
                table: "Empleados",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_LicenciaId",
                table: "Empleados",
                column: "LicenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_PermisoId",
                table: "Empleados",
                column: "PermisoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_SalidadeEmpleadoSalidaEmpleadoId",
                table: "Empleados",
                column: "SalidadeEmpleadoSalidaEmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_VacacionId",
                table: "Empleados",
                column: "VacacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Licencias_LicenciaId",
                table: "Empleados",
                column: "LicenciaId",
                principalTable: "Licencias",
                principalColumn: "LicenciaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Permisos_PermisoId",
                table: "Empleados",
                column: "PermisoId",
                principalTable: "Permisos",
                principalColumn: "PermisoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_SalidadeEmpleados_SalidadeEmpleadoSalidaEmpleadoId",
                table: "Empleados",
                column: "SalidadeEmpleadoSalidaEmpleadoId",
                principalTable: "SalidadeEmpleados",
                principalColumn: "SalidaEmpleadoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Vacaciones_VacacionId",
                table: "Empleados",
                column: "VacacionId",
                principalTable: "Vacaciones",
                principalColumn: "VacacionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Licencias_LicenciaId",
                table: "Empleados");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Permisos_PermisoId",
                table: "Empleados");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_SalidadeEmpleados_SalidadeEmpleadoSalidaEmpleadoId",
                table: "Empleados");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Vacaciones_VacacionId",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_LicenciaId",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_PermisoId",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_SalidadeEmpleadoSalidaEmpleadoId",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_VacacionId",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "Año",
                table: "Vacaciones");

            migrationBuilder.DropColumn(
                name: "LicenciaId",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "PermisoId",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "SalidadeEmpleadoSalidaEmpleadoId",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "VacacionId",
                table: "Empleados");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Nominas",
                newName: "Year");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Vacaciones",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Permisos",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Month",
                table: "Nominas",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Vacaciones_EmpleadoId",
                table: "Vacaciones",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_SalidadeEmpleados_EmpleadoId",
                table: "SalidadeEmpleados",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Permisos_EmpleadoId",
                table: "Permisos",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Licencias_EmpleadoId",
                table: "Licencias",
                column: "EmpleadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Licencias_Empleados_EmpleadoId",
                table: "Licencias",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "EmpleadoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Permisos_Empleados_EmpleadoId",
                table: "Permisos",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "EmpleadoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalidadeEmpleados_Empleados_EmpleadoId",
                table: "SalidadeEmpleados",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "EmpleadoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacaciones_Empleados_EmpleadoId",
                table: "Vacaciones",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "EmpleadoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
