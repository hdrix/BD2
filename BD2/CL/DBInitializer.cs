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


            //table Encomienda, Passwords and TipoEstado

            var encomienda = new Encomienda[]
            {
                new Encomienda{ID=1,Nombre="N1", Descrip="Descrip 1"},
                new Encomienda{ID=2,Nombre="N2", Descrip="Descrip 2"},
                new Encomienda{ID=3,Nombre="N3", Descrip="Descrip 3"},
                new Encomienda{ID=4,Nombre="N4", Descrip="Descrip 4"},
                new Encomienda{ID=5,Nombre="N5", Descrip="Descrip 5"},
            };

            foreach (Encomienda enc in encomienda)
            {
                context.Encomienda.Add(enc);
            }
            context.SaveChanges();

            var passwords = new Passwords[]
            {
                new Passwords{ID=1,Fecha=new DateTime(2013, 12, 01), Secret="Secret 1"},
                new Passwords{ID=2,Fecha=new DateTime(2017, 11, 07), Secret="Secret 2"},
                new Passwords{ID=3,Fecha=new DateTime(2016, 09, 14), Secret="Secret 3"},
                new Passwords{ID=4,Fecha=new DateTime(2015, 08, 05), Secret="Secret 4"},
                new Passwords{ID=5,Fecha=new DateTime(2014, 10, 23), Secret="Secret 5"},
            };

            foreach (Passwords pass in passwords)
            {
                context.Passwords.Add(pass);
            }
            context.SaveChanges();

            var tipoEstado = new TipoEstado[]
           {
                new TipoEstado{ID=1,Nombre="N1", Descrip="Descrip 1"},
                new TipoEstado{ID=2,Nombre="N2", Descrip="Descrip 2"},
                new TipoEstado{ID=3,Nombre="N3", Descrip="Descrip 3"},
                new TipoEstado{ID=4,Nombre="N4", Descrip="Descrip 4"},
                new TipoEstado{ID=5,Nombre="N5", Descrip="Descrip 5"},
           };

            foreach (TipoEstado ties in tipoEstado)
            {
                context.TipoEstado.Add(ties);
            }
            context.SaveChanges();
        }

        
    }
}
