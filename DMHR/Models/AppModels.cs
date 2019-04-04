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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpleadoId { get; set; }
        
        public int CodigoEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int Salario { get; set; }
        public bool IsActive { get; set; }

        public Cargo Cargo{ get; set; }
        public Departamento Departamento { get; set; }
    }

    public class Departamento
    {
        public int DepartamentoId { get; set; }
        public int CodigoDepartamento { get; set; }

        public ICollection<Empleado> Empleados { get; set; }
    }

    public class Cargo
    {
        public int CargoId { get; set; }
        public string Nombre { get; set; }

        public ICollection<Empleado> Empleados { get; set; }
    }

    public class Nomina
    {
        public int NominaId { get; set; }
        public DateTime Year { get; set; }
        public DateTime Month { get; set; }
        public int MontoTotal { get; set; }
    }

    public class SalidadeEmpleado
    {
        public Salida TipoDeSalida { get; set; }
        public string Motivo { get; set; }
        public DateTime FechaSalida { get; set; }

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
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public DateTime Date { get; set; }
        public string Comentarios { get; set; }

        public Empleado Empleado { get; set; }
    }

    public class Permisos
    {
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public DateTime Date { get; set; }
        public string Comentarios { get; set; }

        public Empleado Empleado { get; set; }
    }

    public class Licencias
    {
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public string Motivo { get; set; }
        public string Comentarios { get; set; }

        public Empleado Empleado { get; set; }
    }
}
