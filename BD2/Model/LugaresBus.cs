using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BD2.Model
{
    public class LugaresBus
    {
        public int ID { get; set; }
        public int BusID { get; set; }
        public int lugar { get; set; }
        public bool ocupado { get; set; }

        public Bus Bus { get; set; }
    }
}
