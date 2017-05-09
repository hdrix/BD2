using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BD2.Model
{
    public class Horario
    {
        public int ID { get; set; }
        public TimeSpan inicial { get; set; }
        public TimeSpan final { get; set; }
        public int EstadoID { get; set; }

        public Estado Estado { get; set; }
    }
}
