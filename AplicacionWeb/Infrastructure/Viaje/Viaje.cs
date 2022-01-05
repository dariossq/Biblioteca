using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Infrastructure.Viaje
{
    
     public class Viaje
    {
        string url = "https://localhost:44360/api/";     
        
        /// <summary>
        /// Metodo q retorna la lista de los viajes
        /// </summary>
        /// <returns></returns>
        public async Task<List<ViajeModelsApi>>  ListarTodo(string Datos)
        {
            string respuesta = await getTodo(Datos);
            List<ViajeModelsApi> lst = JsonConvert.DeserializeObject<List<ViajeModelsApi>>(respuesta);
            return  lst;                     
        }
        /// <summary>
        /// Metodo que se cominuca con el API y retorna la lista de los viajes
        /// </summary>
        /// <returns></returns>
        public async Task<string> getTodo(string Datos)
        {
            WebRequest oRequest = WebRequest.Create(url + "Viajes");
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());

            return await sr.ReadToEndAsync();
        }


        public async Task<List<ViajeModelsApi>> ListarViajesEmpleado(string Datos, int EmpleadoId, int VehiculoId, string Fecha)
        {
            string respuesta = await getViajesPorEmpleado(Datos, EmpleadoId, VehiculoId, Fecha);
            List<ViajeModelsApi> lst = JsonConvert.DeserializeObject<List<ViajeModelsApi>>(respuesta);
            return lst;
        }

        public async Task<string> getViajesPorEmpleado(string Datos, int EmpleadoId, int VehiculoId, string Fecha)
        {
            string cadena = Fecha;
           
            WebRequest oRequest = WebRequest.Create(url + "Viajes" + "/" + EmpleadoId + "/" + VehiculoId + "/" + Fecha);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());

            return await sr.ReadToEndAsync();
        }


    }
}
