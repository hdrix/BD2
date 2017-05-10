using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BD2.Model
{
    public class Encomienda
    {
        public readonly string DisplaName = "Encomienda";
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descrip { get; set; }

<<<<<<< HEAD
       
=======
        public ICollection<Estado> Estados { get; set; }
>>>>>>> 460e55d6493c502f2e1620c511684e27bd784bea
    }
}
