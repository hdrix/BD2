using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BD2.Model
{
    public class EncomiendaBus
    {
        public int ID { get; set; }
        public int BusID { get; set; }
        public int EncomiendaID { get; set; }
        public int EstadoID { get; set; }

        public Bus Bus { get; set; }
        public Encomienda Encomienda { get; set; }
        public Estado Estado { get; set; }
    }
}
