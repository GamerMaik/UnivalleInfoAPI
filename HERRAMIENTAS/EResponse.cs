using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HERRAMIENTAS
{
    public class EResponse<T>
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
        public string Excepcion { get; set; }
        public T Datos { get; set; } 

        public EResponse()
        {
            Exitoso = false;
            Mensaje = string.Empty;
            Excepcion = string.Empty;
            Datos = default(T);
        }
    }
}
