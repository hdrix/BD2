using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BD2.Model
{
    public class TipoEmpleado
    {
        public readonly string DisplaName = "Tipo Empleado";
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descrip { get; set; }

        public ICollection<Empleado> Empleados { get; set; }
    }
}
