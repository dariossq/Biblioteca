using Newtonsoft.Json;
using ReRopository.Libro;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Libro
{
   public class Libro
    {
        DataSet ds = new DataSet();
        DataTable Dt = new DataTable();

        public async Task<List<LibroModelsApi>> ListarLibros(string Datos)
        {
            string respuesta = await getAutores(Datos);
             List<LibroModelsApi> lst = JsonConvert.DeserializeObject<List<LibroModelsApi>>(Convert.ToString(respuesta));

            return lst;
        }

        /// <summary>
        /// Metodo que se cominuca con el API y retorna la lista de los empleados
        /// </summary>
        /// <returns></returns>
        public async Task<string> getAutores(string url)
        {
            WebRequest oRequest = WebRequest.Create(url);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());

            return await sr.ReadToEndAsync();
        }

        public async Task<string> getLibro(string url)
        {
            WebRequest oRequest = WebRequest.Create(url);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());

            return await sr.ReadToEndAsync();
        }

        /// <summary>
        /// Metodo para guardar la informacion 
        /// </summary>
        /// <param name="Datos"></param>
        /// <param name="jsonn"></param>
        /// <returns></returns>
        public async Task<string> postLibros(string Datos, string jsonn)
        {
            var client = new HttpClient();
            var result = "";
            WebRequest oRequest = WebRequest.Create(Datos);
            HttpContent content = new StringContent(jsonn, System.Text.Encoding.UTF8, "application/json");
            var httpResponse = await client.PostAsync(Datos, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                result = await httpResponse.Content.ReadAsStringAsync();
            }

            return result;
        }

        public async Task<bool> putLibros(string url, string jsonn)
        {
            var client = new HttpClient();
            bool result = false;
            WebRequest oRequest = WebRequest.Create(url);
            HttpContent content = new StringContent(jsonn, System.Text.Encoding.UTF8, "application/json");
            var httpResponse = await client.PutAsync(url, content);
            if (httpResponse.IsSuccessStatusCode)
            {
                result = httpResponse.IsSuccessStatusCode;
            }

            return result;
        }

        public async Task<bool> deleteLibros(string url)
        {
            var client = new HttpClient();
            bool result = false;
            WebRequest oRequest = WebRequest.Create(url);
            var httpResponse = await client.DeleteAsync(url);
            if (httpResponse.IsSuccessStatusCode)
            {
                result = httpResponse.IsSuccessStatusCode;
            }
            return result;
        }

    }
}
