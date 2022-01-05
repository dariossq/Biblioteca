using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Libro
{
   public class Libro
    {
        string url = "https://localhost:44360/api/";

        /// <summary>
        /// Metodo q retorna la lista de los viajes
        /// </summary>
        /// <returns></returns>
        public async Task<List<LibroModelsApi>> ListarTodo(string Datos)
        {

            string respuesta = await getTodo(Datos);
            List<LibroModelsApi> lst = JsonConvert.DeserializeObject<List<LibroModelsApi>>(respuesta);
            return lst;
        }
        /// <summary>
        /// Metodo que se cominuca con el API y retorna la lista de los viajes
        /// </summary>
        /// <returns></returns>
        public async Task<string> getTodo(string Datos)
        {
            WebRequest oRequest = WebRequest.Create(url + "Libros");
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());

            return await sr.ReadToEndAsync();
        }


    }
}
