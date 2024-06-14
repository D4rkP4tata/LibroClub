using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibroClubController.DAO;
using LibroClubController.MySQL;
using LibroClubModels;

namespace LibroClubWeb.Views
{
	public partial class Sedes : System.Web.UI.Page
	{
		
		public static List<Sede> ListaDatos;
		public static int SequenciaIds;
		public static SedeDAO _daoSede;
		static Sedes()
		{
			_daoSede = new SedeMySQL();
			ListaDatos = new List<Sede>();
			ListaDatos = _daoSede.lista();
			SequenciaIds = ListaDatos.Count;
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			CargarTabla();
		}
		private void CargarTabla()
		{
			ListaDatos = _daoSede.lista();
			GridSedes.DataSource = ListaDatos;
			GridSedes.DataBind();
		}
		protected void EditRow_Click(object sender, EventArgs e)
		{
			int id = int.Parse(((Button)sender).CommandArgument);
			TxtId.Text = "" + id;
			TxtDireccion.Text = "";

			CallJavascritp("showModalForm()");
		}
		protected void DelRow_Click(object sender, EventArgs e)
		{
			int id = int.Parse(((Button)sender).CommandArgument);
			_daoSede.eliminar(id);
			CargarTabla();
			Response.Redirect(Request.Url.AbsoluteUri);
		}
		protected void ButGuardar_Click(object sender, EventArgs e)
		{
			Sede sede = null;
			if (string.IsNullOrEmpty(TxtId.Text)) // crear
			{
				sede = new Sede();
				sede.ID = ++SequenciaIds;
				sede.Direccion = TxtDireccion.Text;
				_daoSede.insertar(sede);
			}
			else //actualizar
			{
				int id = int.Parse(TxtId.Text);
				String direccion;
				direccion = TxtDireccion.Text;
				_daoSede.modificar(id, direccion);
			}
			CargarTabla();
			Response.Redirect(Request.Url.AbsoluteUri);
		}
		protected void BtnNuevo_Click(object sender, EventArgs e)
		{
			TxtId.Text = "";
			TxtDireccion.Text = "";
			CallJavascritp("showModalForm()");
		}
		private void CallJavascritp(string function)
		{
			string script = "window.onload = function() {" + function + "; };";
			ClientScript.RegisterStartupScript(GetType(), "", script, true);
		}
	}
}