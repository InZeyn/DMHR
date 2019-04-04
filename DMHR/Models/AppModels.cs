using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DMHR.Models
{
    public class Empleado
    {
        [Key]
        public int EmpleadoId { get; set; }
        [Required]
        public int CodigoEmpleado { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Phone]
        public string Telefono { get; set; }
        public DateTime FechaIngreso { get; set; }
        [Required]
        public int Salario { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public Cargo Cargo{ get; set; }
        [Required]
        public Departamento Departamento { get; set; }
    }

    public class Departamento
    {
        [Key]
        public int DepartamentoId { get; set; }
        [Required]
        public int CodigoDepartamento { get; set; }
        [Required]
        public string Nombre { get; set; }

        public ICollection<Empleado> Empleados { get; set; }
    }

    public class Cargo
    {
        [Key]
        public int CargoId { get; set; }
        [Required]
        public string Nombre { get; set; }

        public ICollection<Empleado> Empleados { get; set; }
    }

    public class Nomina
    {
        [Key]
        public int NominaId { get; set; }
        [Required]
        public DateTime Year { get; set; }
        [Required]
        public DateTime Month { get; set; }
        public int MontoTotal { get; set; }
    }

    public class SalidadeEmpleado
    {
        [Key]
        public int SalidaEmpleadoId { get; set; }
        public Salida TipoDeSalida { get; set; }
        public string Motivo { get; set; }
        [Required]
        public DateTime FechaSalida { get; set; }
        [Required]
        public Empleado Empleado { get; set; }
    }

    public enum Salida
    {
        Renuncia,
        Despido,
        Desahucio
    }

    public class Vacaciones
    {
        [Key]
        public int VacacionesId { get; set; }
        [Required]
        public DateTime Desde { get; set; }
        [Required]
        public DateTime Hasta { get; set; }
        public DateTime Date { get; set; }
        public string Comentarios { get; set; }
        public bool IsPaid { get; set; }
        [Required]
        public Empleado Empleado { get; set; }
    }

    public class Permisos
    {
        [Key]
        public int PermisosId { get; set; }
        [Required]
        public DateTime Desde { get; set; }
        [Required]
        public DateTime Hasta { get; set; }
        public DateTime Date { get; set; }
        public string Comentarios { get; set; }
        public bool IsPaid { get; set; }

        [Required]
        public Empleado Empleado { get; set; }
    }

    public class Licencias
    {
        [Key]
        public int LicenciasId { get; set; }
        [Required]
        public DateTime Desde { get; set; }
        [Required]
        public DateTime Hasta { get; set; }
        public string Motivo { get; set; }
        public string Comentarios { get; set; }
        public bool IsPaid { get; set; }

        [Required]
        public Empleado Empleado { get; set; }
    }
}
