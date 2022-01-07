using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReRopository.Libro
{
   public class LibroModelsApi
    {
        public int ID_LIBRO { get; set; }
        public string TITULO { get; set; }
        public Nullable<System.DateTime> ANO { get; set; }
        public int GENERO { get; set; }
        public string NUMERO_PAGINAS { get; set; }
        public int ID_AUTOR { get; set; }
    }
}
