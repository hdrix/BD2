using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BD2.Model
{
    public class BusDestinos
    {
        public int ID { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }

        public int HorarioID { get; set; }
        public int BusID { get; set; }
        public int DestinoID { get; set; }


        public Bus Bus { get; set; }
        public Destino Destino { get; set; }
        public Horario Horario { get; set; }
    }
}
