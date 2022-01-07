
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


namespace WebVista.produccion.produccion.Administracion.Buscar
{
    public partial class WebBuscar : System.Web.UI.Page
    {
        Infrastructure.Autor.Autor autor = new Infrastructure.Autor.Autor();
        DataSet Ds = new DataSet();
        dynamic Biblioteca = new System.Dynamic.ExpandoObject();
        string url = ConfigurationManager.AppSettings["ApiLibro"];
        string urlAutor = ConfigurationManager.AppSettings["ApiAutor"];

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
                CargarPersona();
                CargarLibros();
               
            }
        }

        public async void CargarPersona()
        {
            try
            {
                DdlPersona.DataSource = null;
                DdlPersona.Items.Add("");
                DdlPersona.DataSource = await autor.ListarAutores(urlAutor);
                DdlPersona.DataTextField = "NOMBRE_COMPLETO";
                DdlPersona.DataValueField = "ID_AUTOR";
                DdlPersona.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Méetodo para listar todos los libros registrados
        /// </summary>
        private async void CargarLibros()
        {
            try
            {
                string datos = await autor.getAutores(url);
                var definicion = new { ID_LIBRO = 0.0, TITULO = "", ANO = "", GENERO = "", NUMERO_PAGINAS = "" , ID_AUTOR = 0.0 };
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
               
        //public dynamic Datos()
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(HfLibroId.Value))
        //        {
        //            Biblioteca.ID_LIBRO = 0;
        //        }
        //        else
        //        {
        //            Biblioteca.ID_LIBRO = Convert.ToInt32(HfLibroId.Value);
        //        }

        //        if (string.IsNullOrEmpty(TxtTitulo.Text))
        //        {
        //            Biblioteca.TITULO = "";
        //        }
        //        else
        //        {
        //            Biblioteca.TITULO = TxtTitulo.Text;
        //        }

        //        if (string.IsNullOrEmpty(TxtAnio.Text))
        //        {
        //            Biblioteca.ANO = "";
        //        }
        //        else
        //        {
        //            Biblioteca.ANO = "12/12/12";
        //        }

        //        if (string.IsNullOrEmpty(TxtGenro.Text))
        //        {
        //            Biblioteca.GENERO = 0;
        //        }
        //        else
        //        {
        //            Biblioteca.GENERO = TxtGenro.Text;
        //        }

        //        if (string.IsNullOrEmpty(TxtPaginas.Text))
        //        {
        //            Biblioteca.NUMERO_PAGINAS = 0;
        //        }
        //        else
        //        {
        //            Biblioteca.NUMERO_PAGINAS = TxtPaginas.Text;
        //        }

        //        if (string.IsNullOrEmpty(HfAutorId.Value))
        //        {
        //            Biblioteca.ID_AUTOR = 1;
        //        }
        //        else
        //        {
        //            Biblioteca.ID_AUTOR = 1;
        //        }

        //        return Biblioteca;
        //    }
        //    catch (Exception)
        //    {
        //        return Biblioteca;
        //    }
        //}

        protected async void BtnRegistrar_Click(object sender, EventArgs e)
        {
            //var client = new HttpClient();
            //var productos = JsonConvert.SerializeObject(Datos());
            //string datos = await autor.postAutores(url, productos);

            //if (string.IsNullOrEmpty(datos))
            //{
            //    ShowMessage("Lo sentimos no se ha podigo guardar la información. ", MessageType.Informacion);
            //}
            //else
            //{
            //    ShowMessage("Datos almacenados correctamente. ", MessageType.Informacion);
            //    CargarLibros();
            //    LimpiarTxt();
            //}
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
            HfLibroId.Value = "";
            //TxtTitulo.Text = "";
            //TxtAnio.Text = "";
            //TxtGenro.Text = "";
            TxtPaginas.Text = "";
            HfAutorId.Value = "";
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
            
            //HfLibroId.Value = GvDatos.SelectedDataKey["ID_LIBRO"].ToString();
            //HfAutorId.Value = GvDatos.SelectedDataKey["ID_AUTOR"].ToString();
            //DdlPersona.SelectedValue = HfAutorId.Value + ".0";
            //TxtTitulo.Text = GvDatos.SelectedDataKey["TITULO"].ToString();
            //DateTime fechaAnio = Convert.ToDateTime(GvDatos.SelectedDataKey["ANO"].ToString());
            //TxtAnio.Text = fechaAnio.ToString("yyyy");            
            //TxtGenro.Text = GvDatos.SelectedDataKey["GENERO"].ToString();
            //TxtPaginas.Text = GvDatos.SelectedDataKey["NUMERO_PAGINAS"].ToString();

        }

        private void ActivarBotones()
        {
            if (string.IsNullOrEmpty(HfLibroId.Value))
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
            //var client = new HttpClient();
            //var url1 = url + "/" + HfLibroId.Value;
            //var productos = JsonConvert.SerializeObject(Datos());
            //bool datos = await autor.putAutores(url1, productos);

            //if (datos)
            //{
            //    LimpiarTxt();
            //    CargarLibros();
            //    ShowMessage("Datos actualizados correctamente. ", MessageType.Informacion);
            //    //CargarAutores();
                
            //}
            //else
            //{
            //    ShowMessage("Lo sentimos no se ha podigo actualizar la información. ", MessageType.Informacion);

            //}
        }

        protected async void BtnEliminar_Click(object sender, EventArgs e)
        {
            //var client = new HttpClient();
            //var url1 = url + "/" + HfLibroId.Value;
            //var productos = JsonConvert.SerializeObject(Datos());
            //bool datos = await autor.deleteAutores(url1);

            //if (datos)
            //{
            //    LimpiarTxt();
            //    CargarLibros();
            //    ShowMessage("Registro eliminado correctamente. ", MessageType.Informacion);
            //    //CargarAutores();

            //}
            //else
            //{
            //    ShowMessage("Lo sentimos no se ha podigo eliminar la información. ", MessageType.Informacion);

            //}
        }

        protected void DdlPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var hola = GvDatos.SelectedDataKey["ID_AUTOR"].ToString();
        }
    }
}

