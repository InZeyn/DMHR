﻿// <auto-generated />
using System;
using DMHR.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DMHR.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190405001309_updateModel")]
    partial class updateModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DMHR.Models.Cargo", b =>
                {
                    b.Property<int>("CargoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CargoNombre")
                        .IsRequired();

                    b.Property<int?>("EmpleadoId");

                    b.HasKey("CargoId");

                    b.HasIndex("EmpleadoId");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("DMHR.Models.Departamento", b =>
                {
                    b.Property<int>("DepartamentoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodigoDepartamento");

                    b.Property<string>("DepartamentoNombre")
                        .IsRequired();

                    b.Property<int?>("EmpleadoId");

                    b.HasKey("DepartamentoId");

                    b.HasIndex("EmpleadoId");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("DMHR.Models.Empleado", b =>
                {
                    b.Property<int>("EmpleadoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired();

                    b.Property<string>("CargoNombre")
                        .IsRequired();

                    b.Property<int>("CodigoEmpleado");

                    b.Property<string>("DepartamentoNombre")
                        .IsRequired();

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("Date");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Nombre")
                        .IsRequired();

                    b.Property<int>("Salario");

                    b.Property<string>("Telefono");

                    b.HasKey("EmpleadoId");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("DMHR.Models.Licencia", b =>
                {
                    b.Property<int>("LicenciaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comentarios");

                    b.Property<DateTime>("Desde")
                        .HasColumnType("Date");

                    b.Property<int>("EmpleadoId");

                    b.Property<DateTime>("Hasta")
                        .HasColumnType("Date");

                    b.Property<bool>("IsPaid");

                    b.Property<string>("Motivo");

                    b.HasKey("LicenciaId");

                    b.HasIndex("EmpleadoId");

                    b.ToTable("Licencias");
                });

            modelBuilder.Entity("DMHR.Models.Nomina", b =>
                {
                    b.Property<int>("NominaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Month")
                        .HasColumnType("Date");

                    b.Property<int>("MontoTotal");

                    b.Property<DateTime>("Year")
                        .HasColumnType("Date");

                    b.HasKey("NominaId");

                    b.ToTable("Nominas");
                });

            modelBuilder.Entity("DMHR.Models.Permiso", b =>
                {
                    b.Property<int>("PermisoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comentarios");

                    b.Property<DateTime>("Date")
                        .HasColumnType("Date");

                    b.Property<DateTime>("Desde")
                        .HasColumnType("Date");

                    b.Property<int>("EmpleadoId");

                    b.Property<DateTime>("Hasta")
                        .HasColumnType("Date");

                    b.Property<bool>("IsPaid");

                    b.HasKey("PermisoId");

                    b.HasIndex("EmpleadoId");

                    b.ToTable("Permisos");
                });

            modelBuilder.Entity("DMHR.Models.SalidadeEmpleado", b =>
                {
                    b.Property<int>("SalidaEmpleadoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmpleadoId");

                    b.Property<DateTime>("FechaSalida")
                        .HasColumnType("Date");

                    b.Property<string>("Motivo");

                    b.Property<int>("TipoDeSalida");

                    b.HasKey("SalidaEmpleadoId");

                    b.HasIndex("EmpleadoId");

                    b.ToTable("SalidadeEmpleados");
                });

            modelBuilder.Entity("DMHR.Models.Vacacion", b =>
                {
                    b.Property<int>("VacacionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comentarios");

                    b.Property<DateTime>("Date")
                        .HasColumnType("Date");

                    b.Property<DateTime>("Desde")
                        .HasColumnType("Date");

                    b.Property<int>("EmpleadoId");

                    b.Property<DateTime>("Hasta")
                        .HasColumnType("Date");

                    b.Property<bool>("IsPaid");

                    b.HasKey("VacacionId");

                    b.HasIndex("EmpleadoId");

                    b.ToTable("Vacaciones");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DMHR.Models.Cargo", b =>
                {
                    b.HasOne("DMHR.Models.Empleado")
                        .WithMany("Cargos")
                        .HasForeignKey("EmpleadoId");
                });

            modelBuilder.Entity("DMHR.Models.Departamento", b =>
                {
                    b.HasOne("DMHR.Models.Empleado")
                        .WithMany("Departamentos")
                        .HasForeignKey("EmpleadoId");
                });

            modelBuilder.Entity("DMHR.Models.Licencia", b =>
                {
                    b.HasOne("DMHR.Models.Empleado", "Empleado")
                        .WithMany()
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DMHR.Models.Permiso", b =>
                {
                    b.HasOne("DMHR.Models.Empleado", "Empleado")
                        .WithMany()
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DMHR.Models.SalidadeEmpleado", b =>
                {
                    b.HasOne("DMHR.Models.Empleado", "Empleado")
                        .WithMany()
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DMHR.Models.Vacacion", b =>
                {
                    b.HasOne("DMHR.Models.Empleado", "Empleado")
                        .WithMany()
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
