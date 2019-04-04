using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DMHR.Models;

namespace DMHR.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<Departamento> Departamentos { get; set; }
        public virtual DbSet<Cargo> Cargos { get; set; }
        public virtual DbSet<Nomina> Nominas { get; set; }
        public virtual DbSet<SalidadeEmpleado> SalidadeEmpleados { get; set; }
        public virtual DbSet<Vacaciones> GetVacaciones { get; set; }
        public virtual DbSet<Permisos> GetPermisos { get; set; }
        public virtual DbSet<Licencias> GetLicencias { get; set; }

    }
}
