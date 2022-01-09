
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


namespace WebVista.produccion.produccion.Administracion.Libro
{
    public partial class WebLibro : System.Web.UI.Page
    {
        Infrastructure.Autor.Autor autor = new Infrastructure.Autor.Autor();
        Infrastructure.Libro.Libro libro = new Infrastructure.Libro.Libro();
        DataSet Ds = new DataSet();
        dynamic Biblioteca = new System.Dynamic.ExpandoObject();
        string urlLibro = ConfigurationManager.AppSettings["ApiLibro"];
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
                CargarAutor();
                CargarLibros();
                CargarLibro(); 
            }
        }

        public async void CargarLibro()
        {
            try
            {
                
                DdlLibro.DataSource = null;
                DdlLibro.Items.Add("");
                DdlLibro.DataSource = await libro.ListarLibros(urlLibro);
                DdlLibro.DataTextField = "TITULO";
                DdlLibro.DataValueField = "ID_LIBRO";
                DdlLibro.DataBind();
            }
            catch (Exception ex)
            {
              throw;
            }
        }

        public async void CargarAutor()
        {
            try
            {
                DdlAutor.DataSource = null;
                DdlAutor.Items.Add("");
                DdlAutor.DataSource = await autor.ListarAutores(urlAutor);
                DdlAutor.DataTextField = "NOMBRE_COMPLETO";
                DdlAutor.DataValueField = "ID_AUTOR";
                DdlAutor.DataBind();
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
                string datos = await libro.getLibro(urlLibro);
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
               
        public dynamic Datos()
        {
            try
            {
                if (string.IsNullOrEmpty(HfLibroId.Value))
                {
                    Biblioteca.ID_LIBRO = 0;
                }
                else
                {
                    Biblioteca.ID_LIBRO = Convert.ToInt32(HfLibroId.Value);
                }

                if (string.IsNullOrEmpty(TxtTitulo.Text))
                {
                    Biblioteca.TITULO = "";
                }
                else
                {
                    Biblioteca.TITULO = TxtTitulo.Text;
                }

                if (string.IsNullOrEmpty(TxtAnio.Text))
                {
                    Biblioteca.ANO = "";
                }
                else
                {
                    Biblioteca.ANO = "01/" + TxtAnio.Text + "/01";
                }

                if (string.IsNullOrEmpty(TxtGenro.Text))
                {
                    Biblioteca.GENERO = 0;
                }
                else
                {
                    Biblioteca.GENERO = TxtGenro.Text;
                }

                if (string.IsNullOrEmpty(TxtPaginas.Text))
                {
                    Biblioteca.NUMERO_PAGINAS = 0;
                }
                else
                {
                    Biblioteca.NUMERO_PAGINAS = TxtPaginas.Text;
                }

                if (string.IsNullOrEmpty(DdlAutor.Text))
                {
                    Biblioteca.ID_AUTOR = 0;
                }
                else
                {
                    Biblioteca.ID_AUTOR = DdlAutor.Text;
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
            string datos = await libro.postLibros(urlLibro, productos);

            if (string.IsNullOrEmpty(datos))
            {
                ShowMessage("Lo sentimos no se ha podigo guardar la información. ", MessageType.Informacion);
            }
            else
            {
                ShowMessage("Datos almacenados correctamente. ", MessageType.Informacion);
                CargarLibros();
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
            HfLibroId.Value = "";
            TxtTitulo.Text = "";
            TxtAnio.Text = "";
            TxtGenro.Text = "";
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
            
            HfLibroId.Value = GvDatos.SelectedDataKey["ID_LIBRO"].ToString();
            HfAutorId.Value = GvDatos.SelectedDataKey["ID_AUTOR"].ToString();
            DdlAutor.SelectedValue = HfAutorId.Value + ".0";
            TxtTitulo.Text = GvDatos.SelectedDataKey["TITULO"].ToString();
            DateTime fechaAnio = Convert.ToDateTime(GvDatos.SelectedDataKey["ANO"].ToString());
            TxtAnio.Text = fechaAnio.ToString("yyyy");            
            TxtGenro.Text = GvDatos.SelectedDataKey["GENERO"].ToString();
            TxtPaginas.Text = GvDatos.SelectedDataKey["NUMERO_PAGINAS"].ToString();

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
            var client = new HttpClient();
            var url1 = urlLibro + "/" + HfLibroId.Value;
            var productos = JsonConvert.SerializeObject(Datos());
            bool datos = await libro.putLibros(url1, productos);

            if (datos)
            {
                LimpiarTxt();
                CargarLibros();
                ShowMessage("Datos actualizados correctamente. ", MessageType.Informacion);                                
            }
            else
            {
                ShowMessage("Lo sentimos no se ha podigo actualizar la información. ", MessageType.Informacion);
             }
        }

        protected async void BtnEliminar_Click(object sender, EventArgs e)
        {
           // var client = new HttpClient();
            var url1 = urlLibro + "/" + HfLibroId.Value;
            //var productos = JsonConvert.SerializeObject(Datos());
            bool datos = await libro.deleteLibros(url1);

            if (datos)
            {
                LimpiarTxt();
                CargarLibros();
                ShowMessage("Registro eliminado correctamente. ", MessageType.Informacion);
               
            }
            else
            {
                ShowMessage("Lo sentimos no se ha podigo eliminar la información. ", MessageType.Informacion);

            }
        }

        protected void DdlLibro_SelectedIndexChanged(object sender, EventArgs e)
        {
            var urlLibroo = urlLibro + "/" + DdlLibro.Text;
            CargarLibro(urlLibroo);
        }

        private async void CargarLibro(string urlEntrada)
        {
            try
            {
                urlEntrada = urlEntrada.Remove(urlEntrada.Length - 2);
                string datos = "{'Table1': [ " + await libro.getLibro(urlEntrada) + " ]}";
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

    }
}

