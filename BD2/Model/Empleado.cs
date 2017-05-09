using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BD2.Model
{
    public class Empleado
    {
        public int ID { get; set; }
        public int TipoEmpleadoID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }

        public TipoEmpleado TipoEmpleado { get; set; }


    }
}
