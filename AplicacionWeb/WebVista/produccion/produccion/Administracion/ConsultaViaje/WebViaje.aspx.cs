
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Infrastructure;

namespace WebVista.produccion.produccion.Administracion.ConsultaViaje
{
    public   partial class WebViaje : System.Web.UI.Page
    {
        Infrastructure.Viaje.Viaje Viajes = new Infrastructure.Viaje.Viaje();
        Infrastructure.Autor.Autor Personas = new Infrastructure.Autor.Autor();
        Infrastructure.Libro.Libro Vehiculo = new Infrastructure.Libro.Libro();

        //string url = "https://localhost:44322/api/";       
        DataSet Ds = new DataSet();         

        public enum MessageType { Mensaje, Error, Informacion, Advertencia };

        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }

        protected  void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            { return; }
            else
            {
                CargarPersona();
                //CargarVehiculo();
            }
        }

        #region  Mètodo para buscar informacion de viajes

        protected void BtnBuscarTodo_Click(object sender, EventArgs e)
        {
            ListarTodo();
        }

        /// <summary>
        /// Metodo que carga todo el listado de viajes que se han realizado
        /// </summary>
        public async void ListarTodo()
        {
            string BuscarEn = "Viajes";
            GvDatos.DataSource = await Viajes.ListarTodo(BuscarEn);
            GvDatos.DataBind();
        }

        /// <summary>
        /// Metodo para cargar la lista de los empleados
        /// </summary>
        public async void CargarPersona()
        {
            DdlPersona.DataSource = null;
            DdlPersona.Items.Add("");
            DdlPersona.DataSource = await Personas.ListarAutores("Autores");
            DdlPersona.DataTextField = "NOMBRE_COMPLETO";
            DdlPersona.DataValueField = "ID_AUTOR";
            DdlPersona.DataBind();
        }

        /// <summary>
        /// Metodo para cargar la lista de vehiculos
        /// </summary>
        public async void CargarVehiculo()
        {
            DdlVehiculo.DataSource = null;
            DdlVehiculo.Items.Add("");
            DdlVehiculo.DataSource = await Vehiculo.ListarTodo("Vehiculos");
            DdlVehiculo.DataTextField = "vehiculoPlaca";
            DdlVehiculo.DataValueField = "vehiculoId";
            DdlVehiculo.DataBind();
        }       

        protected void BtnBuscarViajes_Click(object sender, EventArgs e)
        {
            ListarViajesPorEmpleado();
        }

        /// <summary>
        /// Carga la lista de viajes por empleado, fecha, vehiculo
        /// </summary>
        public async void ListarViajesPorEmpleado()
        {
            string BuscarEn = "Viajes";
            GvDatos.DataSource = await Viajes.ListarViajesEmpleado(BuscarEn, Convert.ToInt32(DdlPersona.Text), Convert.ToInt32(DdlVehiculo.Text), TxtFecha.Text);
            GvDatos.DataBind();

            if (GvDatos.Rows.Count <= 0)
            {
                ShowMessage("No hay datos con la información suministrada. ", MessageType.Informacion);
            }

        }
        #endregion  
    }
}