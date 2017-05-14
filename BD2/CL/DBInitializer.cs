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

            var encomienda = new Encomienda[]
            {
                new Encomienda{Nombre="N1", Descrip="Descrip 1"},
                new Encomienda{Nombre="N2", Descrip="Descrip 2"},
                new Encomienda{Nombre="N3", Descrip="Descrip 3"},
                new Encomienda{Nombre="N4", Descrip="Descrip 4"},
                new Encomienda{Nombre="N5", Descrip="Descrip 5"},
            };

            foreach (Encomienda enc in encomienda)
            {
                context.Encomienda.Add(enc);
            }
            context.SaveChanges();


            var passwords = new Passwords[]
            {
                new Passwords{Fecha=new DateTime(2013, 12, 01), Secret="Secret 1"},
                new Passwords{Fecha=new DateTime(2017, 11, 07), Secret="Secret 2"},
                new Passwords{Fecha=new DateTime(2016, 09, 14), Secret="Secret 3"},
                new Passwords{Fecha=new DateTime(2015, 08, 05), Secret="Secret 4"},
                new Passwords{Fecha=new DateTime(2014, 10, 23), Secret="Secret 5"},
            };

            foreach (Passwords pass in passwords)
            {
                context.Passwords.Add(pass);
            }
            context.SaveChanges();

            var tipoEstado = new TipoEstado[]
            {
                new TipoEstado{Nombre="N1", Descrip="Descrip 1"},
                new TipoEstado{Nombre="N2", Descrip="Descrip 2"},
                new TipoEstado{Nombre="N3", Descrip="Descrip 3"},
                new TipoEstado{Nombre="N4", Descrip="Descrip 4"},
                new TipoEstado{Nombre="N5", Descrip="Descrip 5"},
            };

            foreach (TipoEstado ties in tipoEstado)
            {
                context.TipoEstado.Add(ties);
            }
            context.SaveChanges();

            var bus = new Bus[]
           {
                new Bus{Nombre="bus1", pasajeros=20},
                new Bus{Nombre="bus2", pasajeros=30},
                new Bus{Nombre="bus3", pasajeros=50},
                new Bus{Nombre="bus4", pasajeros=20},
                new Bus{Nombre="bus5", pasajeros=30}
           };

            foreach (Bus bu in bus)
            {
                context.Bus.Add(bu);
            }
            context.SaveChanges();

            //DESTINO
            var destino = new Destino[]
          {
                new Destino{Nombre="destino1",Salida="Peten" },
                new Destino{Nombre="destino2",Salida="Coban" },
                new Destino{Nombre="destino3",Salida="Izabal" },
                new Destino{Nombre="destino4",Salida="Huehuetenango" },
                new Destino{Nombre="destino5",Salida="Quiche" }
          };

            foreach (Destino destin in destino)
            {
                context.Destino.Add(destin);
            }
            context.SaveChanges();

            //CLIENTE
            var cliente = new Cliente[]
          {
                new Cliente{ nombre="Eduardito", Descrip="Descrip 1"},
                new Cliente{ nombre="Andresito", Descrip="Descrip 2"},
                new Cliente{ nombre="Tambito", Descrip="Descrip 3"},
                new Cliente{ nombre="Danielito", Descrip="Descrip 4"},
                new Cliente{ nombre="Emilito", Descrip="Descrip 5"}
          };

            foreach (Cliente client in cliente)
            {
                context.Cliente.Add(client);
            }
            context.SaveChanges();

            var estado = new Estado[]
            {
                new Estado{Descrip="Descrip 1", Nombre="N1", TipoEstadoID=1},
                new Estado{Descrip="Descrip 2", Nombre="N2", TipoEstadoID=1},
                new Estado{Descrip="Descrip 3", Nombre="N3", TipoEstadoID=3},
                new Estado{Descrip="Descrip 4", Nombre="N4", TipoEstadoID=1},
                new Estado{Descrip="Descrip 5", Nombre="N5", TipoEstadoID=2},
            };

            foreach (Estado ties in estado)
            {
                context.Estado.Add(ties);
            }
            context.SaveChanges();

            var encomiendaBus = new EncomiendaBus[]
            {
                new EncomiendaBus{BusID=1,EncomiendaID=2,EstadoID=1},
                new EncomiendaBus{BusID=3,EncomiendaID=2,EstadoID=1},
                new EncomiendaBus{BusID=2,EncomiendaID=1,EstadoID=2},
                new EncomiendaBus{BusID=1,EncomiendaID=3,EstadoID=3},
                new EncomiendaBus{BusID=4,EncomiendaID=1,EstadoID=2},
            };

            foreach (EncomiendaBus ties in encomiendaBus)
            {
                context.EncomiendaBus.Add(ties);
            }
            context.SaveChanges();

            var clienteEncomienda = new ClienteEncomienda[]
            {
                new ClienteEncomienda{Fecha=new DateTime(2013, 12, 01), ClienteID=1,EncomiendaID=2,EstadoID=1},
                new ClienteEncomienda{Fecha=new DateTime(2010, 03, 12), ClienteID=2,EncomiendaID=3,EstadoID=1},
                new ClienteEncomienda{Fecha=new DateTime(2009, 07, 11), ClienteID=3,EncomiendaID=2,EstadoID=2},
                new ClienteEncomienda{Fecha=new DateTime(2011, 11, 09), ClienteID=4,EncomiendaID=3,EstadoID=1},
                new ClienteEncomienda{Fecha=new DateTime(2012, 01, 02), ClienteID=5,EncomiendaID=1,EstadoID=3},
            };

            foreach (ClienteEncomienda ties in clienteEncomienda)
            {
                context.ClienteEncomienda.Add(ties);
            }
            context.SaveChanges();

            var horario = new Horario[]
            {
                new Horario{inicial=new TimeSpan(12,24,23), final = new TimeSpan(14,32,20), EstadoID = 1},
                new Horario{inicial=new TimeSpan(8,11,12), final = new TimeSpan(19,05,01), EstadoID = 4},
                new Horario{inicial=new TimeSpan(13,03,45), final = new TimeSpan(21,19,45), EstadoID = 2},
                new Horario{inicial=new TimeSpan(06,45,06), final = new TimeSpan(10,01,10), EstadoID = 3},
                new Horario{inicial=new TimeSpan(10,56,14), final = new TimeSpan(18,56,59), EstadoID = 1},
            };

            foreach (Horario ties in horario)
            {
                context.Horario.Add(ties);
            }
            context.SaveChanges();

            // BUS DESTINO

            var busdestino = new BusDestinos[]
           {
                new BusDestinos{BusID=1,DestinoID=5,HorarioID=1,Estado="1"},
                new BusDestinos{BusID=2,DestinoID=4,HorarioID=1,Estado="1"},
                new BusDestinos{BusID=3,DestinoID=3,HorarioID=1,Estado="1"},
                new BusDestinos{BusID=4,DestinoID=2,HorarioID=1,Estado="1"},
                new BusDestinos{BusID=5,DestinoID=1,HorarioID=1,Estado="1"}
           };

            foreach (BusDestinos budesti in busdestino)
            {
                context.BusDestinos.Add(budesti);
            }
            context.SaveChanges();

            // BUS DESTINO

            var passwordEmpleados = new PasswordEmpleados[]
           {
                new PasswordEmpleados{PasswordsID=1,EmpleadoID=1,enable=1,fecha_Modificado=new DateTime(2014,04,27)},
                new PasswordEmpleados{PasswordsID=2,EmpleadoID=2,enable=1,fecha_Modificado=new DateTime(2014,04,27)},
                new PasswordEmpleados{PasswordsID=3,EmpleadoID=3,enable=1,fecha_Modificado=new DateTime(2014,04,27)},
                new PasswordEmpleados{PasswordsID=4,EmpleadoID=4,enable=1,fecha_Modificado=new DateTime(2014,04,27)},

           };

            foreach (PasswordEmpleados pe in passwordEmpleados)
            {
                context.PasswordEmpleados.Add(pe);
            }
            context.SaveChanges();
        }

        
    }
}
