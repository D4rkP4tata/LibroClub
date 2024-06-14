using System;
using System.Collections.Generic;
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
	public partial class UsuariosForm : System.Web.UI.Page
	{
		public static LibroClubWS.UsuarioWSClient daoUsuario;
		public static LibroClubWS.ServicioWSClient daoPersonal;
		public static LibroClubWS.ServicioWSClient daoGerente;
		public static string opcion = "";
		public static string sId = "-1";
		public static string _dni = "-1";
		public static int _telefono = 0;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["Personal"] != null || Session["Gerente"] != null)
			{
				daoUsuario = new LibroClubWS.UsuarioWSClient();
				daoPersonal = new LibroClubWS.ServicioWSClient();
				daoGerente = new LibroClubWS.ServicioWSClient();
				TxtErrorDni.Text = "";
				TxtErrorTelefono.Text = "";
				if (!IsPostBack)
				{
					opcion = Request.QueryString["op"];
					sId = Request.QueryString["id"];
					if (opcion == "upd" && !string.IsNullOrEmpty(sId))
						CargarDatos();
				}
			}
			else
			{
				Response.Redirect("/Login.aspx");
			}

		}

		private void CargarDatos()
		{
			int idUpd = int.Parse(sId);
			foreach (usuario usuario in daoUsuario.listarUsuario())
			{
				if (usuario.id_persona == idUpd)
				{
					TxtId.Text = "" + usuario.id_persona;
					TxtNombre.Text = usuario.nombre;
					TxtFechaNacimiento.Text = usuario.fecha_nacimiento.ToString("yyyy-MM-dd");
					TxtDni.Text = usuario.dni.ToString();
					if (usuario.sexo == 'M')
					{
						RadioButtonListGenero.Items[0].Selected = true;
					}
					else if (usuario.sexo == 'F')
					{
						RadioButtonListGenero.Items[1].Selected = true;
					}
					TxtTelefono.Text = usuario.telefono.ToString();
					DropDownListTipoMembresia.SelectedValue = usuario.membresia.ToString();
					_dni = TxtDni.Text;
					_telefono = Int32.Parse(TxtTelefono.Text);
				}
			}
		}
		protected void BtnGuardar_Click(object sender, EventArgs e)
		{
			LibroClubWS.usuario usuario = new usuario();

			String nombre = TxtNombre.Text;
			String dni = TxtDni.Text;

			DateTime fecha_nacimiento = DateTime.Parse(TxtFechaNacimiento.Text);

			char genero = RadioButtonListGenero.SelectedValue[0];
			int telefono = Int32.Parse(TxtTelefono.Text);
			if (DropDownListTipoMembresia.SelectedValue == "Ninguno")
			{
				usuario.membresia = tipoMembresia.Ninguna;
			}
			else if (DropDownListTipoMembresia.SelectedValue == "Plata")
			{
				usuario.membresia = tipoMembresia.Plata;
			}
			else if (DropDownListTipoMembresia.SelectedValue == "Oro")
			{
				usuario.membresia = tipoMembresia.Oro;
			}

			if (dni.Length != 8 && telefono.ToString().Length == 9)
			{
				TxtErrorDni.Text = "Ingrese un dni válido";
				TxtDni.Text = "";
				return;
			}

			if (telefono.ToString().Length != 9 && dni.Length == 8)
			{
				TxtErrorTelefono.Text = "Ingrese un teléfono válido";
				TxtTelefono.Text = "";
				return;
			}
			if (telefono.ToString().Length != 9 && dni.Length != 8)
			{
				TxtErrorDni.Text = "Ingrese un dni válido";
				TxtDni.Text = "";
				TxtErrorTelefono.Text = "Ingrese un teléfono válido";
				TxtTelefono.Text = "";
				return;
			}

			/////////////////////////////////////dni/////////////////////////
			if (opcion == "new")
			{
				foreach (usuario usuarioDni in daoUsuario.listarUsuario())
				{
					if (dni == usuarioDni.dni)
					{
						TxtErrorDni.Text = "El dni ingresado ya existe";
						TxtDni.Text = "";
						return;
					}
				}
				foreach (usuario usuarioDni in daoUsuario.listarUsuario())
				{
					if (dni == usuarioDni.dni)
					{
						TxtErrorDni.Text = "El dni ingresado ya existe";
						TxtDni.Text = "";
						return;
					}
				}
				foreach (gerenteDeLocal gerenteDni in daoGerente.listarGerente())
				{
					if (dni == gerenteDni.dni)
					{
						TxtErrorDni.Text = "El dni ingresado ya existe";
						TxtDni.Text = "";
						return;
					}
				}
			}
			else
			{
				foreach (usuario usuarioDni in daoUsuario.listarUsuario())
				{
					if (TxtDni.Text == usuarioDni.dni && TxtDni.Text != _dni)
					{
						TxtErrorDni.Text = "El dni ingresado ya existe";
						TxtDni.Text = "";
						return;
					}
				}
				foreach (usuario usuarioDni in daoUsuario.listarUsuario())
				{
					if (TxtDni.Text == usuarioDni.dni && TxtDni.Text != _dni)
					{
						TxtErrorDni.Text = "El dni ingresado ya existe";
						TxtDni.Text = "";
						return;
					}
				}
				foreach (gerenteDeLocal gerenteDni in daoGerente.listarGerente())
				{
					if (TxtDni.Text == gerenteDni.dni && TxtDni.Text != _dni)
					{
						TxtErrorDni.Text = "El dni ingresado ya existe";
						TxtDni.Text = "";
						return;
					}
				}
			}
			//////////////////////////////////////////////////////////////

			/////////////////////telefono/////////////////////////////

			if (opcion == "new")
			{
				foreach (personal personalTelefono in daoPersonal.listarPersonal())
				{
					if (telefono == personalTelefono.telefono)
					{
						TxtErrorTelefono.Text = "El teléfono ingresado ya existe";
						TxtTelefono.Text = "";
						return;
					}
				}
				foreach (usuario usuarioTelefono in daoUsuario.listarUsuario())
				{
					if (telefono == usuarioTelefono.telefono)
					{
						TxtErrorTelefono.Text = "El teléfono ingresado ya existe";
						TxtTelefono.Text = "";
						return;
					}
				}
				foreach (gerenteDeLocal gerenteTelefono in daoGerente.listarGerente())
				{
					if (telefono == gerenteTelefono.telefono)
					{
						TxtErrorTelefono.Text = "El teléfono ingresado ya existe";
						TxtTelefono.Text = "";
						return;
					}
				}
			}
			else
			{
				foreach (personal personalTelefono in daoPersonal.listarPersonal())
				{
					if (telefono == personalTelefono.telefono && telefono != _telefono)
					{
						TxtErrorTelefono.Text = "El teléfono ingresado ya existe";
						TxtTelefono.Text = "";
						return;

					}
				}
				foreach (usuario usuarioTelefono in daoUsuario.listarUsuario())
				{
					if (telefono == usuarioTelefono.telefono && telefono != _telefono)
					{
						TxtErrorTelefono.Text = "El teléfono ingresado ya existe";
						TxtTelefono.Text = "";
						return;
					}
				}
				foreach (gerenteDeLocal gerenteTelefono in daoGerente.listarGerente())
				{
					if (telefono == gerenteTelefono.telefono && telefono != _telefono)
					{
						TxtErrorTelefono.Text = "El teléfono ingresado ya existe";
						TxtTelefono.Text = "";
						return;
					}
				}
			}

			//////////////////////////////////////////////////////////////

			usuario.membresiaSpecified = true;

			usuario.nombre = nombre;
			usuario.dni = dni;
			usuario.fecha_nacimiento = fecha_nacimiento;
			usuario.fecha_nacimientoSpecified = true;
			usuario.sexo = genero;
			usuario.telefono = telefono;


			if (opcion == "new")
			{
				daoUsuario.insertarUsuario(usuario);
				Session["UsuarioInsertado"] = usuario;
			}
			else if (opcion == "upd")
			{
				int id = int.Parse(TxtId.Text);
				usuario.id_persona = id;
				daoUsuario.modificarUsuario(usuario);
				Session["UsuarioModificado"] = usuario;
			}
			Response.Redirect("/Views/Usuarios.aspx");
		}

		protected void BtnRegresar_Click(object sender, EventArgs e)
		{
			Response.Redirect("/Views/Usuarios.aspx");
		}
	}
}