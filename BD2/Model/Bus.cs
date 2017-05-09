using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BD2.Model
{
    public class Bus
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int pasajeros { get; set; }

        public Estado Estado { get; set; }
    }
}
