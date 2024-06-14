using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibroClubController.DAO;
using LibroClubController.MySQL;
using LibroClubModels;
using LibroClubWeb.LibroClubWS;

namespace LibroClubWeb.Views
{
	public partial class Usuarios : System.Web.UI.Page
	{
		public static int SequenciaIds;
		public static LibroClubWS.UsuarioWSClient daoUsuario;
		public static BindingList<LibroClubWS.usuario> usuarios;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["Personal"] != null || Session["Gerente"] != null)
			{
				TxtErrorMembresia.Text = "";
				daoUsuario = new LibroClubWS.UsuarioWSClient();
				TxtUsuarioBuscar.Text = "";
				TxtUsuarioBusquedaBody.Text = "";
				TxtErrorBusqueda.Text = "";

				//if (Session["BuscarDniUsuario"] !=  null){
				//	TxtDniUsuario.Text = "";
				//	Session["BuscarDniUsuario"] = null;
				//}
				if (daoUsuario.listarUsuario() != null)
				{
					object[] usuariosArray = daoUsuario.listarUsuario();
					usuarios = new BindingList<LibroClubWS.usuario>(
						usuariosArray.Cast<LibroClubWS.usuario>().ToList()
					);
					SequenciaIds = usuarios.Count;
					CargarTabla();
				}

				if (Session["UsuarioInsertado"] != null)
				{
					AlertaMensajeNuevoUsuario.Visible = true;
					usuario usuarioInsertado = (usuario)Session["UsuarioInsertado"];
					AlertaMensajeNuevoUsuario.Text = "<div id='AlertaMensajeNuevoUsuario' class='alert alert-success go-to-top' role='alert'>El usuario " + usuarioInsertado.nombre + " ha sido ingresado correctamente</div>";

					Session.Remove("UsuarioInsertado");

					ScriptManager.RegisterStartupScript(this, GetType(), "HideAlertMessage", "hideAlertMessage();", true);
				}
				else if (Session["UsuarioModificado"] != null)
				{
					AlertaMensajeNuevoUsuario.Visible = true;
					usuario usuarioModificado = (usuario)Session["UsuarioModificado"];
					AlertaMensajeNuevoUsuario.Text = "<div id='AlertaMensajeNuevoUsuario' class='alert alert-success go-to-top' role='alert'>El usuario " + usuarioModificado.nombre + " ha sido modificado correctamente</div>";

					Session.Remove("UsuarioModificado");

					ScriptManager.RegisterStartupScript(this, GetType(), "HideAlertMessage", "hideAlertMessage();", true);
				}
				else if (Session["UsuarioEliminado"] != null)
				{
					AlertaMensajeNuevoUsuario.Visible = true;
					usuario usuarioEliminado = (usuario)Session["UsuarioEliminado"];
					AlertaMensajeNuevoUsuario.Text = "<div id='AlertaMensajeNuevoUsuario' class='alert alert-success go-to-top' role='alert'>El usuario " + usuarioEliminado.nombre + " ha sido eliminado correctamente</div>";

					Session.Remove("UsuarioEliminado");

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
			GridUsuarios.DataSource = usuarios;
			GridUsuarios.DataBind();
		}

		private void CargarTablaUsuarioBuscar(BindingList<usuario> usuario)
		{
			GridViewUsuarioBuscar.DataSource = usuario;
			GridViewUsuarioBuscar.DataBind();
		}
		protected void BtnAgregar_Click(object sender, EventArgs e)
		{

			Response.Redirect("/Views/UsuariosForm.aspx?op=new");

		}
		protected void BtnEditar_Click(object sender, EventArgs e)
		{
			string sId = ((LinkButton)sender).CommandArgument;
			Response.Redirect("/Views/UsuariosForm.aspx?op=upd&id=" + sId);
		}
		protected void BtnEliminar_Click(object sender, EventArgs e)
		{
			string sid = ((LinkButton)sender).CommandArgument;
			int id = int.Parse(sid);

			foreach (usuario usuario in daoUsuario.listarUsuario())
			{
				if(usuario.id_persona == id)
				{
					Session["UsuarioEliminado"] = usuario;
					break;
				}
			}
			daoUsuario.eliminarUsuario(id);

			CargarTabla();
			Response.Redirect(Request.Url.AbsoluteUri);
		}
		protected void GridUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			GridUsuarios.PageIndex = e.NewPageIndex;
			GridUsuarios.DataBind();
		}

		protected void BuscarDni_Click(object sender, EventArgs e)
		{
			if(TxtDniUsuario.Text.Length == 8)
			{
				usuario usuario = usuarios.FirstOrDefault(p => p.dni == TxtDniUsuario.Text);
				if(usuario != null)
				{
					usuario usuarioBusquedaDni = daoUsuario.ObtenerUsuarioDni(TxtDniUsuario.Text);
					BindingList<usuario> usuarioBuscquedaDniLista = new BindingList<usuario> { usuarioBusquedaDni };
					

					TxtUsuarioBuscar.Text = "Usuariocon dni: " + TxtDniUsuario.Text;
					TxtUsuarioBusquedaBody.Text = "Se encontró al usuario " + usuarioBusquedaDni.nombre;
					Session["BuscarDniUsuario"] = TxtDniUsuario.Text;
					CargarTablaUsuarioBuscar(usuarioBuscquedaDniLista);
					CallJavascritp("showModalForm()");
					TxtDniUsuario.Text = "";
				}
				else
				{
					TxtErrorBusqueda.Text = "No se encontró ningun usuario con dni " + TxtDniUsuario.Text;
					CallJavascritp("showModalFormError()");
					
				}
			}
			
			
		}

		private void CallJavascritp(string function)
		{
			string script = "window.onload = function() {" + function + "; };";
			ClientScript.RegisterStartupScript(GetType(), "", script, true);
		}

		protected void FiltrarMembresiaUsuario_Click(object sender, EventArgs e)
		{
			String membresiaUsuario = FiltrarMembresia.SelectedValue;
			int idMembresia = 0;
			bool membresiaSeleccionar = false;
			switch (membresiaUsuario)
			{
				case "Seleccionar":
					membresiaSeleccionar = true;
					break;
				case "Ninguno":
					idMembresia = 0;
					break;
				case "Plata":
					idMembresia = 1;
					break;
				case "Oro":
					idMembresia = 2;
					break;
				default:
					break;
			}

			object[] usuariosArray = null;
			if (!membresiaSeleccionar)
			{
				usuariosArray = daoUsuario.listarUsuarioMembresia(idMembresia);
				if(usuariosArray == null)
				{
					TxtErrorMembresia.Text = "No se encontraron usuarios con la membresía de: " + membresiaUsuario;
				}
				else
				{
					TxtErrorMembresia.Text = "";
					usuarios = new BindingList<LibroClubWS.usuario>(
					usuariosArray.Cast<LibroClubWS.usuario>().ToList()
					);
					CargarTabla();
				}
			}
			
		}

		protected void LimpiarMembresia_Click(object sender, EventArgs e)
		{
			object[]  usuariosArray = daoUsuario.listarUsuario();
			usuarios = new BindingList<LibroClubWS.usuario>(
				usuariosArray.Cast<LibroClubWS.usuario>().ToList()
			);
			FiltrarMembresia.Items[0].Selected = true;
			FiltrarMembresia.Items[1].Selected = false;
			FiltrarMembresia.Items[2].Selected = false;
			FiltrarMembresia.Items[3].Selected = false;

			CargarTabla();
		}

		protected void LimpiarDni_Click(object sender, EventArgs e)
		{
			TxtDniUsuario.Text = "";
			object[] usuariosArray = daoUsuario.listarUsuario();
			usuarios = new BindingList<LibroClubWS.usuario>(
				usuariosArray.Cast<LibroClubWS.usuario>().ToList()
			);
			FiltrarMembresia.Items[0].Selected = true;
			FiltrarMembresia.Items[1].Selected = false;
			FiltrarMembresia.Items[2].Selected = false;
			FiltrarMembresia.Items[3].Selected = false;
			CargarTabla();
		}

		protected void FiltrarMembresia_SelectedIndexChanged(object sender, EventArgs e)
		{
			String membresiaUsuario = FiltrarMembresia.SelectedValue;
			int idMembresia = 0;
			bool membresiaSeleccionar = false;
			switch (membresiaUsuario)
			{
				case "Todas":
					membresiaSeleccionar = true;
					break;
				case "Ninguno":
					idMembresia = 0;
					break;
				case "Plata":
					idMembresia = 1;
					break;
				case "Oro":
					idMembresia = 2;
					break;
				default:
					break;
			}

			object[] usuariosArray = null;
			if (!membresiaSeleccionar)
			{
				usuariosArray = daoUsuario.listarUsuarioMembresia(idMembresia);
				if (usuariosArray == null)
				{
					TxtErrorMembresia.Text = "No se encontraron usuarios con la membresía de: " + membresiaUsuario;
				}
				else
				{
					TxtErrorMembresia.Text = "";
					usuarios = new BindingList<LibroClubWS.usuario>(
					usuariosArray.Cast<LibroClubWS.usuario>().ToList()
					);
					CargarTabla();
				}
			}
		}
	}
}