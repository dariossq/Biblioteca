using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Autor
{
   public class AutorModelsApi
    {
        public decimal ID_AUTOR { get; set; }
        public string NOMBRE_COMPLETO { get; set; }
        public Nullable<System.DateTime> FECHA_NACIMIENTO { get; set; }
        public string CIUDAD_PROCEDENCIA { get; set; }
        public string CORREOELECTRONICO { get; set; }
    }
}
