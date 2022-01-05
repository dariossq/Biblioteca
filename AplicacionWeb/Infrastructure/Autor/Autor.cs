using Newtonsoft.Json;
using ReRopository.AutorRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Infrastructure.Autor
{
   public class Autor
    {
        DataSet ds = new DataSet();
        DataTable Dt = new DataTable();
        string url = "https://localhost:44360/api/";


        public async Task<List<AutorModelsApi>> ListarEmpleados(string Datos)
        {
            string respuesta = await getEmpleados(Datos);
            List<AutorModelsApi> lst = JsonConvert.DeserializeObject<List<AutorModelsApi>>(respuesta);
            return lst;
        }
        /// <summary>
        /// Metodo que se cominuca con el API y retorna la lista de los empleados
        /// </summary>
        /// <returns></returns>
        public async Task<string> getEmpleados(string Datos)
        {
            WebRequest oRequest = WebRequest.Create(url + Datos);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());

            return await sr.ReadToEndAsync();
        }





        /// <summary>
        /// ////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <returns></returns>

        //public DataSet ObtenerEmpleados()
        //{
        //    //#region Codigo para obtener un solo dato del JSON
        //    //// var url = $"https://localhost:44322/api/Persona/5";
        //    //var request = (HttpWebRequest)WebRequest.Create(url);
        //    //request.Method = "GET";
        //    //request.ContentType = "application/json";
        //    //request.Accept = "application/json";

        //    //try
        //    //{
        //    //    using (WebResponse response = request.GetResponse())
        //    //    {
        //    //        using (Stream strReader = response.GetResponseStream())
        //    //        {
        //    //            if (strReader == null) return ds;
        //    //            using (StreamReader objReader = new StreamReader(strReader))
        //    //            {
        //    //                string responseBody = objReader.ReadToEnd();

        //    //                XmlDocument xd = new XmlDocument();
        //    //                responseBody = "{ \"rootNode\": {" + responseBody.Trim().TrimStart('{').TrimEnd('}') + "} }";
        //    //                xd = (XmlDocument)Newtonsoft.Json.JsonConvert.DeserializeXmlNode(responseBody);
                           
        //    //                ds.ReadXml(new XmlNodeReader(xd));
        //    //                //acceso = ds.Tables[0].Rows[0][0].ToString();


        //    //                Dt = ds.Tables[0];
        //    //                //dataGridView1.DataSource = ds.Tables[0];
        //    //                // TxtDescrip.Text = ds.Tables["rootNode"].Rows[0]["viajeId"].ToString();
        //    //                //dataGridView1.DataSource=  Dt.Rows[0]["viajeId"].ToString().ToUpper();

        //    //            }
        //    //        }
        //    //    }
        //    //}
        //    //catch (WebException ex)
        //    //{
        //    //    return ds;
        //    //}
        //    //return ds;
        //    //#endregion
        //}















        //public async Task<List<ViajeModelsApi>> ListarTodo()
        //{
        //    string respuesta = await getTodo();
        //    List<ViajeModelsApi> lst = JsonConvert.DeserializeObject<List<ViajeModelsApi>>(respuesta);
        //    return lst;
        //}

        //public async Task<string> getTodo()
        //{
        //    WebRequest oRequest = WebRequest.Create(url);
        //    WebResponse oResponse = oRequest.GetResponse();
        //    StreamReader sr = new StreamReader(oResponse.GetResponseStream());

        //    return await sr.ReadToEndAsync();
        //}
    }
}
