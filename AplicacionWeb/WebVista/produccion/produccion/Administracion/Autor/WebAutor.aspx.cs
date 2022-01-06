
using Microsoft.Graph;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


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
                CargarAutores();
            }
        }

        /// <summary>
        /// Méetodo para listar todos los autores registrados
        /// </summary>
        private async void CargarAutores()
        {
            try
            {
                string datos = await autor.getAutores(url);
                var definicion = new { ID_AUTOR = 0.0, NOMBRE_COMPLETO = "", FECHA_NACIMIENTO = "", CIUDAD_PROCEDENCIA = "", CORREOELECTRONICO = "" };
                //var definicion = new CargarDefinicion();
                var listaDefinicion = new[] { definicion };
                var productos = JsonConvert.DeserializeObject(datos);
                var listProductos = JsonConvert.DeserializeAnonymousType(Convert.ToString(productos), listaDefinicion);
                GvDatos.DataSource = listProductos;
                GvDatos.DataBind();

                if (GvDatos.Rows.Count <= 0)
                {
                    ShowMessage("No hay datos con la información suministrada. ", MessageType.Informacion);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //private object CargarDefinicion()
        //{
        //    return  new { ID_AUTOR = 0.0, NOMBRE_COMPLETO = "", FECHA_NACIMIENTO = "", CIUDAD_PROCEDENCIA = "", CORREOELECTRONICO = "" };

        //}


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
                CargarAutores();
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
                CargarAutores();
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
                CargarAutores();
                ShowMessage("Registro eliminado correctamente. ", MessageType.Informacion);
                //CargarAutores();

            }
            else
            {
                ShowMessage("Lo sentimos no se ha podigo eliminar la información. ", MessageType.Informacion);

            }
        }
    }
}

