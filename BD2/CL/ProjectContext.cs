using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BD2.Model;
using Microsoft.EntityFrameworkCore;
namespace BD2.CL
{
    public class ProjectContext :DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options ): base(options)
        {
        }

        public DbSet<TipoEmpleado> TipoEmpleados { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<TipoEstado> TipoEstado { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Horario> Horario { get; set; }
        public DbSet<Bus> Bus { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoEmpleado>().ToTable("TipoEmpleado");
            modelBuilder.Entity<Empleado>().ToTable("Empleado");
            modelBuilder.Entity<TipoEstado>().ToTable("TipoEstado");
            modelBuilder.Entity<Estado>().ToTable("Estado");
            modelBuilder.Entity<Horario>().ToTable("Horario");
            modelBuilder.Entity<Bus>().ToTable("Horario");

        }

        


        
    }
}
