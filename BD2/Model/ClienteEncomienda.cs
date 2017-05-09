using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BD2.Model
{
    public class ClienteEncomienda
    {
        public int ID { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteID { get; set; }
        public int EncomiendaID { get; set; }
        public int EstadoID { get; set; }

        public Cliente Cliente { get; set; }
        public Encomienda Encomienda { get; set; }
        public Estado Estado { get; set; }
    }
}
