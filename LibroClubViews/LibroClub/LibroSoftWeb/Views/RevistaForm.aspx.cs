using LibroClubController.DAO;
using LibroClubController.MySQL;
using LibroClubModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibroClubWeb.Views
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private RevistaDAO _daoRevista;
        public static string opcion = "";
        public static string sId = "-1";

        protected void Page_Load(object sender, EventArgs e)
        {
            _daoRevista = new RevistaMySQL();
            if (!IsPostBack)
            {
                opcion = Request.QueryString["op"];
                sId = Request.QueryString["id"];
                if (opcion == "upd" && !string.IsNullOrEmpty(sId))
                    CargarDatos();
            }
        }
        private void CargarDatos()
        {
            int idUpd = int.Parse(sId);
            foreach (Revista rev in _daoRevista.lista())
            {
                if (rev.ID_Producto == idUpd)
                {
                    TxtId.Text = "" + rev.ID_Producto;
                    TxtTitulo.Text = rev.Titulo;
                    TxtPrecio.Text = rev.Precio.ToString();
                    TxtEditor.Text = rev.Editor;
                    TxtISSN.Text = rev.ISSN;
                }
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            Revista rev = new Revista();
            Clasificador clasificador = new Clasificador();

            clasificador.ID_Clasificador = 1;
            clasificador.Cantidad = 1;
            clasificador.Nombre = "Test";
            clasificador.Tipo = TipoClasificador.Revista;

            String titulo = TxtTitulo.Text;
            double precio = double.Parse(TxtPrecio.Text);
            String editor = TxtEditor.Text;
            String ISSN = TxtISSN.Text;

            rev.Titulo = titulo;
            rev.Precio = precio;
            rev.Editor = editor;
            rev.ISSN = ISSN;
            rev.StockDisponiblePrestamo = 1;
            rev.StockPrestamo = 1;
            rev.StockVenta = 1;
            rev.Clasificador = clasificador;


            _daoRevista.insertar(rev);
            Response.Redirect("/Views/Articulos.aspx");
        }

        protected void BtnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Views/Articulos.aspx");
        }
    }
}