using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.CViaje
{
    public  class CViaje
    {
        public int viajeId { get; set; }
        public string viajeOrigen { get; set; }
        public string viajeDestino { get; set; }
        public string viajeTiempo { get; set; }
        public string viajeHora { get; set; }
        public int vehiculoId { get; set; }
        public int personaId { get; set; }
        public int personaEmpleadoId { get; set; }
        //public int persona { get; set; }
        //public int personaEmpleado { get; set; }
        //public int vehiculo { get; set; }
    }
}