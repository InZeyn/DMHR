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
        [Display(Name = "Cod-Emp")]
        public int CodigoEmpleado { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Phone]
        public string Telefono { get; set; }
        [Column(TypeName="Date")]
        public DateTime FechaIngreso { get; set; }
        [Required]
        public int Salario { get; set; }
        [Display(Name = "Estado")]
        public bool IsActive { get; set; }

        [Required]
        [Display(Name = "Cargo")]
        public string CargoNombre { get; set; }
        [Required]
        [Display(Name = "Departamento")]
        public string DepartamentoNombre { get; set; }

        public IList<Cargo> Cargos { get; set; }
        public IList<Departamento> Departamentos { get; set; }
    }

    public class Departamento
    {
        [Key]
        public int DepartamentoId { get; set; }
        [Required]
        [Display(Name = "Codigo-Dep")]
        public int CodigoDepartamento { get; set; }
        [Required]
        [Display(Name = "Departamento")]
        public string DepartamentoNombre { get; set; }

    }

    public class Cargo
    {
        [Key]
        public int CargoId { get; set; }
        [Required]
        [Display(Name = "Cargo")]
        public string CargoNombre { get; set; }

    }

    public class Nomina
    {
        [Key]
        public int NominaId { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime Year { get; set; }
        [Required]
        [Column(TypeName = "Date")]
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
        [Column(TypeName = "Date")]
        public DateTime FechaSalida { get; set; }

        public int EmpleadoId { get; set; }
        [Required]
        public Empleado Empleado { get; set; }
    }

    public enum Salida
    {
        Renuncia,
        Despido,
        Desahucio
    }

    public class Vacacion
    {
        [Key]
        public int VacacionId { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime Desde { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime Hasta { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }
        public string Comentarios { get; set; }
        public bool IsPaid { get; set; }

        public int EmpleadoId { get; set; }
        [Required]
        public Empleado Empleado { get; set; }
    }

    public class Permiso
    {
        [Key]
        public int PermisoId { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime Desde { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime Hasta { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }
        public string Comentarios { get; set; }
        public bool IsPaid { get; set; }

        public int EmpleadoId { get; set; }
        [Required]
        public Empleado Empleado { get; set; }
    }

    public class Licencia
    {
        [Key]
        public int LicenciaId { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime Desde { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime Hasta { get; set; }
        public string Motivo { get; set; }
        public string Comentarios { get; set; }
        public bool IsPaid { get; set; }

        public int EmpleadoId { get; set; }
        [Required]
        public Empleado Empleado { get; set; }
    }
}
