using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BD2.Model;

namespace BD2.CL
{
    public class DBInitializer
    {
        public static void Initialize(ProjectContext context)
        {
            context.Database.EnsureCreated();
            //context.BusDestino

            if (context.TipoEmpleados.Any())
            {
                return;
            }

            var tipoEmpleados = new TipoEmpleado[]
            {
                new TipoEmpleado{Nombre="A",Descrip="Descrip A"},
                new TipoEmpleado{Nombre="B",Descrip="Descrip B"},
                new TipoEmpleado{Nombre="C",Descrip="Descrip C"},
                new TipoEmpleado{Nombre="D",Descrip="Descrip D"}
            };
            
            foreach(TipoEmpleado t in tipoEmpleados)
            {
                context.TipoEmpleados.Add(t);
            }
            context.SaveChanges();

            var empleados = new Empleado[]
            {
                new Empleado{Nombre="N1", Apellido="A1", Edad=30,TipoEmpleadoID=1},
                new Empleado{Nombre="N2", Apellido="A2", Edad=20,TipoEmpleadoID=1},
                new Empleado{Nombre="N3", Apellido="A3", Edad=24,TipoEmpleadoID=2},
                new Empleado{Nombre="N4", Apellido="A4", Edad=19,TipoEmpleadoID=3},
            };

            foreach (Empleado e in empleados)
            {
                context.Empleados.Add(e);
            }
            context.SaveChanges();
        }

        
    }
}
