using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BD2.Model
{
    public class PasswordEmpleados
    {
        public int ID { get; set; }
        public int PasswordsID { get; set; }
        public int EmpleadoID { get; set; }
        public int enable { get; set; }
        public DateTime fecha_Modificado { get; set; }

        public Passwords Passwords { get; set; }
        public Empleado Empleado { get; set; }
    }
}
