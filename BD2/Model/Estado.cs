using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BD2.Model
{
    public class Estado
    {
        public int ID { get; set; }
        public string Descrip { get; set; }
        public string Nombre { get; set; }
        public int TipoEstadoID { get; set; }

        public TipoEstado TipoEstado { get; set; }
    }
}
