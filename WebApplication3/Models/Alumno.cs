using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Alumno
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Genero { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public DateTime FechaDeIngreso { get; set; }
        public string RFC { get; set; }

    }

    public class AlumnoDBContext3 : DbContext
    {
        public DbSet<Alumno> Alumnos { get; set; }
    }
}