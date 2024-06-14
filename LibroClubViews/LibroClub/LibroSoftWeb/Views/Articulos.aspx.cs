using LibroClubController.DAO;
using LibroClubController.MySQL;
using LibroClubModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibroClubWeb.Views
{
    public partial class Articulos : System.Web.UI.Page
    {
        public static RevistaDAO _daoRevista;
        public static List<Revista> ListaRevista;
        public static LibroDAO _daoLibro;
        public static List<Libro> ListaLibro;
        public static PeliculaDAO _daoPelicula;
        public static List<Pelicula> ListaPelicula;
        public static CDMusicaDAO _daoCD;
        public static List<CDMusica> ListaCD;
        public static int SequenciaIds;

        static Articulos()
        {
            _daoRevista = new RevistaMySQL();
            ListaRevista = new List<Revista>();
            ListaRevista = _daoRevista.lista();
            _daoLibro = new LibroMySQL();
            ListaLibro = new List<Libro>();
            ListaLibro = _daoLibro.lista();
            _daoPelicula = new PeliculaMySQL();
            ListaPelicula = new List<Pelicula>();
            ListaPelicula = _daoPelicula.lista();
            _daoCD = new CDMusicaMySQL();
            ListaCD = new List<CDMusica>();
            ListaCD = _daoCD.lista();
            SequenciaIds = ListaRevista.Count + ListaLibro.Count + ListaCD.Count + ListaPelicula.Count;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            Cargar_Tablas();
        }

        private void Cargar_Tablas()
        {
            GridRevistas.DataSource = _daoRevista.lista();
            GridRevistas.DataBind();
        }

        protected void BtnAgregarRev_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Views/RevistaForm.aspx?op=new");
        }

        protected void BtnEliminarRev_Click(object sender, EventArgs e)
        {
            string sid = ((LinkButton)sender).CommandArgument;
            int id = int.Parse(sid);
            _daoRevista.eliminar(id);
            Cargar_Tablas();
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void GridRevistas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridRevistas.PageIndex = e.NewPageIndex;
            GridRevistas.DataBind();
        }
    }
}