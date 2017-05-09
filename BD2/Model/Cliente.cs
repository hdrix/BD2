using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BD2.Model
{
    public class Cliente
    {
        public int ID { get; set; }
        public string nombre { get; set; }
        public string Descrip { get; set; }

        public Estado Estado { get; set; }
        
    }
}
