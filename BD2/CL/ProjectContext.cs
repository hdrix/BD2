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
<<<<<<< HEAD
        public DbSet<Encomienda> Encomienda { get; set; }
        public DbSet<EncomiendaBus> EncomiendaBus { get; set; }
        public DbSet<Destino> Destino { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<ClienteEncomienda> ClienteEncomienda { get; set; }

        public DbSet<Passwords> Passwords { get; set; }

        public DbSet<BusEmpleado> BusEmpleado { get; set; }

        //public DbSet<BusDestino> BusDestino { get; set; }


=======
>>>>>>> 460e55d6493c502f2e1620c511684e27bd784bea
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoEmpleado>().ToTable("TipoEmpleado");
            modelBuilder.Entity<Empleado>().ToTable("Empleado");
            modelBuilder.Entity<TipoEstado>().ToTable("TipoEstado");
            modelBuilder.Entity<Estado>().ToTable("Estado");
            modelBuilder.Entity<Horario>().ToTable("Horario");
<<<<<<< HEAD
            modelBuilder.Entity<Bus>().ToTable("Bus");
            modelBuilder.Entity<Encomienda>().ToTable("Encomienda");
            modelBuilder.Entity<EncomiendaBus>().ToTable("EncomiendaBus");
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Destino>().ToTable("Destino");

            modelBuilder.Entity<ClienteEncomienda>().ToTable("ClienteEncomienda");
            modelBuilder.Entity<Passwords>().ToTable("Passwords");
            modelBuilder.Entity<BusEmpleado>().ToTable("BusEmpleado");
            modelBuilder.Entity<BusDestinos>().ToTable("BusDestinos");
            //modelBuilder.Entity<BusDestino>().ToTable("BusDestino");

        }


        public DbSet<BD2.Model.BusDestinos> BusDestinos { get; set; }


=======
            modelBuilder.Entity<Bus>().ToTable("Horario");

        }

        


        
>>>>>>> 460e55d6493c502f2e1620c511684e27bd784bea
    }
}
