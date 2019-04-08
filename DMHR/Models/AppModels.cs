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
        [Display(Name = "#Emp")]
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

        public string NombreCompleto
        {
            get
            {
                return Nombre + " " + Apellido;
            }
        }

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
        [Display(Name = "#Dep")]
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
        public DateTime Date { get;  set; }

        [Display(Name = "Total")]
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

        [Required]
        public int EmpleadoId { get; set; }

        public IList<Empleado> Empleados { get; set; }
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
        public int Año { get; set; }
        public string Comentarios { get; set; }
        public bool IsPaid { get; set; }
        [Required]
        public int EmpleadoId { get; set; }
        public IList<Empleado> Empleados { get; set; }
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
      
        public string Comentarios { get; set; }
        public bool IsPaid { get; set; }
        [Required]
        public int EmpleadoId { get; set; }
        public IList<Empleado> Empleados { get; set; }
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
        [Required]
        public int EmpleadoId { get; set; }
        public IList<Empleado> Empleados { get; set; }
    }
}
