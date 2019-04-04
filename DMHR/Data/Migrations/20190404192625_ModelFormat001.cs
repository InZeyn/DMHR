using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DMHR.Data.Migrations
{
    public partial class ModelFormat001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Cargos_CargoId",
                table: "Empleados");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Departamentos_DepartamentoId",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_CargoId",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_DepartamentoId",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "CargoId",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "DepartamentoId",
                table: "Empleados");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Departamentos",
                newName: "DepartamentoNombre");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Cargos",
                newName: "CargoNombre");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaSalida",
                table: "SalidadeEmpleados",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Year",
                table: "Nominas",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Month",
                table: "Nominas",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Hasta",
                table: "GetVacaciones",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Desde",
                table: "GetVacaciones",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "GetVacaciones",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Hasta",
                table: "GetPermisos",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Desde",
                table: "GetPermisos",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "GetPermisos",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Hasta",
                table: "GetLicencias",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Desde",
                table: "GetLicencias",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaIngreso",
                table: "Empleados",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "CargoNombre",
                table: "Empleados",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DepartamentoNombre",
                table: "Empleados",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EmpleadoId",
                table: "Departamentos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmpleadoId",
                table: "Cargos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_EmpleadoId",
                table: "Departamentos",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cargos_EmpleadoId",
                table: "Cargos",
                column: "EmpleadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cargos_Empleados_EmpleadoId",
                table: "Cargos",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "EmpleadoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departamentos_Empleados_EmpleadoId",
                table: "Departamentos",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "EmpleadoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cargos_Empleados_EmpleadoId",
                table: "Cargos");

            migrationBuilder.DropForeignKey(
                name: "FK_Departamentos_Empleados_EmpleadoId",
                table: "Departamentos");

            migrationBuilder.DropIndex(
                name: "IX_Departamentos_EmpleadoId",
                table: "Departamentos");

            migrationBuilder.DropIndex(
                name: "IX_Cargos_EmpleadoId",
                table: "Cargos");

            migrationBuilder.DropColumn(
                name: "CargoNombre",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "DepartamentoNombre",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "EmpleadoId",
                table: "Departamentos");

            migrationBuilder.DropColumn(
                name: "EmpleadoId",
                table: "Cargos");

            migrationBuilder.RenameColumn(
                name: "DepartamentoNombre",
                table: "Departamentos",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "CargoNombre",
                table: "Cargos",
                newName: "Nombre");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaSalida",
                table: "SalidadeEmpleados",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Year",
                table: "Nominas",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Month",
                table: "Nominas",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Hasta",
                table: "GetVacaciones",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Desde",
                table: "GetVacaciones",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "GetVacaciones",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Hasta",
                table: "GetPermisos",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Desde",
                table: "GetPermisos",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "GetPermisos",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Hasta",
                table: "GetLicencias",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Desde",
                table: "GetLicencias",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaIngreso",
                table: "Empleados",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AddColumn<int>(
                name: "CargoId",
                table: "Empleados",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoId",
                table: "Empleados",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_CargoId",
                table: "Empleados",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_DepartamentoId",
                table: "Empleados",
                column: "DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Cargos_CargoId",
                table: "Empleados",
                column: "CargoId",
                principalTable: "Cargos",
                principalColumn: "CargoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Departamentos_DepartamentoId",
                table: "Empleados",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "DepartamentoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
