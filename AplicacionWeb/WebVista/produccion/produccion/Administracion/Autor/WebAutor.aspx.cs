
using Microsoft.Graph;
using Newtonsoft.Json;
using ReRopository.AutorRepository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Text.Json.Net;


namespace WebVista.produccion.produccion.Administracion.Autor
{
    public partial class WebAutor : System.Web.UI.Page
    {
        Infrastructure.Autor.Autor autor = new Infrastructure.Autor.Autor();
        DataSet Ds = new DataSet();
        dynamic Biblioteca = new System.Dynamic.ExpandoObject();
        string url = ConfigurationManager.AppSettings["ApiAutor"];

        public enum MessageType { Mensaje, Error, Informacion, Advertencia };

        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            { return; }
            else
            {
                CargarAutores(url);
                CargarAutor();
            }
        }

        public async void CargarAutor()
        {
            try
            {
                DdlAutor.DataSource = null;
                DdlAutor.Items.Add("");
                DdlAutor.DataSource = await autor.getAutores(url);
                DdlAutor.DataTextField = "NOMBRE_COMPLETO";
                DdlAutor.DataValueField = "ID_AUTOR";
                DdlAutor.DataBind();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Méetodo para listar todos los autores registrados
        /// </summary>
        private async void CargarAutores(string urlEntrada)
        {
            try
            {
                object datos = await autor.getAutores(urlEntrada);
                var definicion = new { ID_AUTOR = 0.0, NOMBRE_COMPLETO = "", FECHA_NACIMIENTO = "", CIUDAD_PROCEDENCIA = "", CORREOELECTRONICO = "" };
                var listaDefinicion = new[] { definicion };
                var productos = JsonConvert.DeserializeObject(Convert.ToString(datos));
                var listProductos = JsonConvert.DeserializeAnonymousType(Convert.ToString(productos), listaDefinicion);
                GvDatos.DataSource = listProductos;
                GvDatos.DataBind();

                if (GvDatos.Rows.Count <= 0)
                {
                    ShowMessage("No hay datos con la información suministrada. ", MessageType.Informacion);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //private object CargarDefinicion()
        //{
        //    return  new { ID_AUTOR = 0.0, NOMBRE_COMPLETO = "", FECHA_NACIMIENTO = "", CIUDAD_PROCEDENCIA = "", CORREOELECTRONICO = "" };

        //}




        private async void CargarAutore(string urlEntrada)
        {
            try
            {


                urlEntrada = urlEntrada.Remove(urlEntrada.Length - 2);
                string datos = "{'Table1': [ " +  await autor.getAutores(urlEntrada) + " ]}";
                DataSet dataSet1 = JsonConvert.DeserializeObject<DataSet>(datos);
                GvDatos.DataSource = dataSet1;
                GvDatos.DataBind();

                if (GvDatos.Rows.Count <= 0)
                {
                    ShowMessage("No hay datos con la información suministrada. ", MessageType.Informacion);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public dynamic Datos()
        {
            try
            {
                if (string.IsNullOrEmpty(HfAutorId.Value))
                {
                    Biblioteca.ID_AUTOR = 0;
                }
                else
                {
                    Biblioteca.ID_AUTOR = Convert.ToInt32(HfAutorId.Value);
                }

                if (string.IsNullOrEmpty(TxtNombre.Text))
                {
                    Biblioteca.NOMBRE_COMPLETO = 0;
                }
                else
                {
                    Biblioteca.NOMBRE_COMPLETO = TxtNombre.Text;
                }

                if (string.IsNullOrEmpty(TxtFechaNacimiento.Text))
                {
                    Biblioteca.FECHA_NACIMIENTO = 0;
                }
                else
                {
                    Biblioteca.FECHA_NACIMIENTO = TxtFechaNacimiento.Text;
                }

                if (string.IsNullOrEmpty(TxtCiudad.Text))
                {
                    Biblioteca.CIUDAD_PROCEDENCIA = 0;
                }
                else
                {
                    Biblioteca.CIUDAD_PROCEDENCIA = TxtCiudad.Text;
                }

                if (string.IsNullOrEmpty(TxtMail.Text))
                {
                    Biblioteca.CORREOELECTRONICO = 0;
                }
                else
                {
                    Biblioteca.CORREOELECTRONICO = TxtMail.Text;
                }

                return Biblioteca;
            }
            catch (Exception)
            {
                return Biblioteca;
            }
        }

        protected async void BtnRegistrar_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var productos = JsonConvert.SerializeObject(Datos());
            string datos = await autor.postAutores(url, productos);

            if (string.IsNullOrEmpty(datos))
            {
                ShowMessage("Lo sentimos no se ha podigo guardar la información. ", MessageType.Informacion);
            }
            else
            {
                ShowMessage("Datos almacenados correctamente. ", MessageType.Informacion);
                CargarAutores(url);
                LimpiarTxt();
            }
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarTxt();
            ActivarBotones();
        }

        /// <summary>
        /// Métido para limpiar los Txt
        /// </summary>
        private void LimpiarTxt()
        {
            HfAutorId.Value = "";
            TxtCiudad.Text = "";
            TxtFechaNacimiento.Text = "";
            TxtNombre.Text = "";
            TxtMail.Text = "";
            ActivarBotones();
        }

        protected void GvDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Seleccionar();
            ActivarBotones();
        }

        /// <summary>
        /// Metodo para seleccionar informacion
        /// </summary>
        private void Seleccionar()
        {
            HfAutorId.Value = GvDatos.SelectedDataKey["ID_AUTOR"].ToString();
            TxtNombre.Text = GvDatos.SelectedDataKey["NOMBRE_COMPLETO"].ToString();
            DateTime fechaExpedicion = Convert.ToDateTime(GvDatos.SelectedDataKey["FECHA_NACIMIENTO"].ToString());
            TxtFechaNacimiento.Text = fechaExpedicion.ToString("dd/MM/yyyy");
            TxtCiudad.Text = GvDatos.SelectedDataKey["CIUDAD_PROCEDENCIA"].ToString();
            TxtMail.Text = GvDatos.SelectedDataKey["CORREOELECTRONICO"].ToString();
        }

        private void ActivarBotones()
        {
            if (string.IsNullOrEmpty(HfAutorId.Value))
            {
                BtnRegistrar.Visible = true;
                BtnActualiza.Visible = false;
                BtnEliminar.Visible = false;
            }
            else
            {
                BtnActualiza.Visible = true;
                BtnEliminar.Visible = true;
                BtnRegistrar.Visible = false;
            }
        }

        protected async void BtnActualiza_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var url1 = url + "/" + HfAutorId.Value;
            var productos = JsonConvert.SerializeObject(Datos());
            bool datos = await autor.putAutores(url1, productos);

            if (datos)
            {
                LimpiarTxt();
                CargarAutores(url);
                ShowMessage("Datos actualizados correctamente. ", MessageType.Informacion);
                //CargarAutores();
                
            }
            else
            {
                ShowMessage("Lo sentimos no se ha podigo actualizar la información. ", MessageType.Informacion);

            }
        }

        protected async void BtnEliminar_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var url1 = url + "/" + HfAutorId.Value;
            var productos = JsonConvert.SerializeObject(Datos());
            bool datos = await autor.deleteAutores(url1);

            if (datos)
            {
                LimpiarTxt();
                CargarAutores(url);
                ShowMessage("Registro eliminado correctamente. ", MessageType.Informacion);
                //CargarAutores();

            }
            else
            {
                ShowMessage("Lo sentimos no se ha podigo eliminar la información. ", MessageType.Informacion);

            }
        }

        protected void DdlAutor_SelectedIndexChanged(object sender, EventArgs e)
        {
            var urlAutor = url + "/" + DdlAutor.Text;
            CargarAutore(urlAutor);
        }

        
    }
}

