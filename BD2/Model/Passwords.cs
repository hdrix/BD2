using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BD2.Model
{
    public class Passwords
    {
        public int ID { get; set; }
        public DateTime Fecha { get; set; }
        public string Secret { get; set; }

        public ICollection<Estado> Estados { get; set; }
        public ICollection<Empleado> Empleados { get; set; }

    }
}
