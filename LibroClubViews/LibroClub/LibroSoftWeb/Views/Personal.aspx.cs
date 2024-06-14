using LibroClubWeb.LibroClubWS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibroClubWeb.Views
{
	public partial class Personal : System.Web.UI.Page
	{
		public static int SequenciaIds;
		public static LibroClubWS.ServicioWSClient daoPersonal;
		public static BindingList<LibroClubWS.personal> personales;
		public static LibroClubWS.ServicioWSClient daoSede;
		public static BindingList<LibroClubWS.sede> sedes;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["Gerente"] != null)
			{
				TxtErrorMembresia.Text = "";
				daoPersonal = new LibroClubWS.ServicioWSClient();
				daoSede = new LibroClubWS.ServicioWSClient();
				//if (Session["BuscarDniPersonal"] != null)
				//{
				//	TxtDniUsuario.Text = "";
				//	Session["BuscarDniPersonal"] = null;
				//}

				if (daoPersonal.listarPersonal() != null)
				{
					object[] usuariosArray = daoPersonal.listarPersonalSede((int)Session["GerenteIdSede"]);
					personales = new BindingList<LibroClubWS.personal>(
						usuariosArray.Cast<LibroClubWS.personal>().ToList()
					);
					SequenciaIds = personales.Count;
					CargarTabla();
				}

				if (Session["PersonalInsertado"] != null)
				{
					AlertaMensajeNuevoPersonal.Visible = true;
					personal personalInsertado = (personal)Session["PersonalInsertado"];
					AlertaMensajeNuevoPersonal.Text = "<div id='AlertaMensajeNuevoUsuario' class='alert alert-success go-to-top' role='alert'>El personal " + personalInsertado.nombre + " ha sido ingresado correctamente</div>";

					Session.Remove("PersonalInsertado");

					ScriptManager.RegisterStartupScript(this, GetType(), "HideAlertMessage", "hideAlertMessage();", true);
				}
				else if (Session["PersonalModificado"] != null)
				{
					AlertaMensajeNuevoPersonal.Visible = true;
					personal personalModificado = (personal)Session["PersonalModificado"];
					AlertaMensajeNuevoPersonal.Text = "<div id='AlertaMensajeNuevoUsuario' class='alert alert-success go-to-top' role='alert'>El personal " + personalModificado.nombre + " ha sido modificado correctamente</div>";

					Session.Remove("PersonalModificado");

					ScriptManager.RegisterStartupScript(this, GetType(), "HideAlertMessage", "hideAlertMessage();", true);
				}
				else if (Session["PersonalEliminado"] != null)
				{
					AlertaMensajeNuevoPersonal.Visible = true;
					personal personalEliminado = (personal)Session["PersonalEliminado"];
					AlertaMensajeNuevoPersonal.Text = "<div id='AlertaMensajeNuevoUsuario' class='alert alert-success go-to-top' role='alert'>El personal " + personalEliminado.nombre + " ha sido eliminado correctamente</div>";

					Session.Remove("PersonalEliminado");

					ScriptManager.RegisterStartupScript(this, GetType(), "HideAlertMessage", "hideAlertMessage();", true);
				}
			}
			else
			{
				Response.Redirect("/Login.aspx");
			}
		}

		private void CargarTabla()
		{
			//object[] sedesArray = daoSede.listarSede();
			//sedes = new BindingList<LibroClubWS.sede>(
			//	sedesArray.Cast<LibroClubWS.sede>().ToList()
			//);

			GridPersonales.DataSource = personales;
			GridPersonales.DataBind();

			//ddlFiltrarSede.DataSource = sedes;
			//ddlFiltrarSede.DataTextField = "direccion";
			//ddlFiltrarSede.DataValueField = "id_sede";
			//ddlFiltrarSede.DataBind();

		}
		private void CargarTablaPersonalBuscar(BindingList<personal> personal)
		{
			GridViewPersonalBuscar.DataSource = personal;
			GridViewPersonalBuscar.DataBind();
		}
		protected void GridPersonales_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			GridPersonales.PageIndex = e.NewPageIndex;
			GridPersonales.DataBind();
		}

		protected void BtnAgregar_Click(object sender, EventArgs e)
		{
			Response.Redirect("/Views/PersonalForm.aspx?op=new");
		}
		protected void BtnEditar_Click(object sender, EventArgs e)
		{
			string sId = ((LinkButton)sender).CommandArgument;
			Response.Redirect("/Views/PersonalForm.aspx?op=upd&id=" + sId);
		}
		protected void BtnEliminar_Click(object sender, EventArgs e)
		{
			string sid = ((LinkButton)sender).CommandArgument;
			int id = int.Parse(sid);

			foreach (personal personal in daoPersonal.listarPersonal())
			{
				if (personal.id_persona == id)
				{
					Session["PersonalEliminado"] = personal;
					break;
				}
			}
			daoPersonal.eliminarPersonal(id);

			CargarTabla();
			Response.Redirect(Request.Url.AbsoluteUri);
		}

		//protected void LimpiarDni_Click(object sender, EventArgs e)
		//{
		//	 TxtPersonalUsuario.Text = "";
		//	object[] personalesArray = daoPersonal.listarPersonalSede((int)Session["GerenteIdSede"]);
		//	personales = new BindingList<LibroClubWS.personal>(
		//		personalesArray.Cast<LibroClubWS.personal>().ToList()
		//	);
		//	CargarTabla();
		//}

		protected void BuscarDni_Click(object sender, EventArgs e)
		{
			if (TxtDniPersonal.Text.Length == 8)
			{
				personal personal = personales.FirstOrDefault(p => p.dni == TxtDniPersonal.Text);
				if (personal != null)
				{
					personal personalBusquedaDni = daoPersonal.ObtenerPersonalDNI(TxtDniPersonal.Text);
					if (personalBusquedaDni.idSede == (int)Session["GerenteIdSede"])
					{
						BindingList<personal> personalBusquedaDniLista = new BindingList<personal> { personalBusquedaDni };

						TxtPersonalBuscar.Text = "Personal con dni: " + TxtDniPersonal.Text;
						TxtPersonalBusquedaBody.Text = "Se encontró al personal " + personalBusquedaDni.nombre;
						//Session["BuscarDniPersonal"] = TxtDniPersonal.Text;
						CargarTablaPersonalBuscar(personalBusquedaDniLista);
						CallJavascritp("showModalForm()");
						TxtDniPersonal.Text = "";
					}
				}
				else
				{
					TxtErrorBusqueda.Text = "No se encontró ningun personal con dni " + TxtDniPersonal.Text;
					CallJavascritp("showModalFormError()");
				}
			}
			else
			{
				CallJavascritp("validarFormularioDni()");
				
			}

		}

		private void CallJavascritp(string function)
		{
			string script = "window.onload = function() {" + function + "; };";
			ClientScript.RegisterStartupScript(GetType(), "", script, true);
		}

	}
}