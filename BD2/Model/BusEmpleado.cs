using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BD2.Model
{
    public class BusEmpleado
    {
        public int ID { get; set; }
        public int BusID { get; set; }
        public int EmpleadoID { get; set; }

        public Bus Bus { get; set; }
        public Empleado Empleado { get; set; }
    }
}
