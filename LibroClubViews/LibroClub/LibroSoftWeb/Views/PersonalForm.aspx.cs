using LibroClubWeb.LibroClubWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibroClubWeb.Views
{
	public partial class PersonalForm : System.Web.UI.Page
	{
		public static LibroClubWS.ServicioWSClient daoSede;
		public static LibroClubWS.ServicioWSClient daoPersonal;
		public static LibroClubWS.ServicioWSClient daoUsuario;
		public static LibroClubWS.ServicioWSClient daoGerente;
		public static string opcion = "";
		public static string sId = "-1";
		public static string _dni = null;
		public static string _username = null;
		public static int _telefono = 0;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["Gerente"] != null)
			{
				gerenteDeLocal gerente = (gerenteDeLocal)Session["Gerente"];
				daoSede = new LibroClubWS.ServicioWSClient();
				daoPersonal = new LibroClubWS.ServicioWSClient();
				daoGerente = new LibroClubWS.ServicioWSClient();
				daoUsuario = new LibroClubWS.ServicioWSClient();
				TxtErrorDni.Text = "";
				TxtErrorTelefono.Text = "";
				TxtUsernameError.Text = "";
				foreach (sede sede in daoSede.listarSede())
				{
					if (gerente.idSede == sede.id_sede)
					{
						TxtSede.Text = sede.direccion;
						break;
					}
				}
				if (!IsPostBack)
				{
					opcion = Request.QueryString["op"];
					sId = Request.QueryString["id"];
					if (opcion == "new")
					{
						TxtFechaInicioContrato.Text = DateTime.Now.ToString("yyyy-MM-dd");
						TxtCantEjemPrestados.Text = "0";
						TxtCantEjemVendidos.Text = "0";
						TxtCantEjemPrestados.Enabled = false;
						TxtCantEjemVendidos.Enabled = false;
					}
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

			foreach (personal personal in daoPersonal.listarPersonalSede((int)Session["GerenteIdSede"]))
			{
				if (personal.id_persona == idUpd)
				{
					TxtId.Text = "" + personal.id_persona;
					TxtNombre.Text = personal.nombre;
					TxtFechaNacimiento.Text = personal.fecha_nacimiento.ToString("yyyy-MM-dd");
					TxtDni.Text = personal.dni.ToString();
					if (personal.sexo == 'M')
					{
						RadioButtonListGenero.Items[0].Selected = true;
					}
					else if (personal.sexo == 'F')
					{
						RadioButtonListGenero.Items[1].Selected = true;
					}

					String estadoPersonal = personal.estado.ToString();
					if (estadoPersonal == "Activo")
					{
						ddlEstadoPersonal.Items[0].Selected = true;
					}
					else if (estadoPersonal == "Vacaciones")
					{
						ddlEstadoPersonal.Items[1].Selected = true;
					}
					else if (estadoPersonal == "DescansoMedico")
					{
						ddlEstadoPersonal.Items[2].Selected = true;
					}
					else if (estadoPersonal == "LicenciaMaternidadPaternidad")
					{
						ddlEstadoPersonal.Items[3].Selected = true;
					}

					TxtTelefono.Text = personal.telefono.ToString();
					TxtUsername.Text = personal.username;
					TxtPassword.Text = personal.password;
					TxtFechaInicioContrato.Text = personal.inicio_contrato.ToString("yyyy-MM-dd");
					TxtFechaInicioContrato.Enabled = false;
					TxtFechaFinContrato.Text = personal.fin_contrato.ToString("yyyy-MM-dd");
					TxtFechaFinContrato.Enabled = false;
					TxtCantEjemPrestados.Text = personal.cant_ejemplares_prestados.ToString();
					TxtCantEjemVendidos.Text = personal.cant_ejemplares_vendidos.ToString();
					TxtCantEjemPrestados.Enabled = true;
					TxtCantEjemVendidos.Enabled = true;
					_username = TxtUsername.Text;
					_dni = TxtDni.Text;
					_telefono = Int32.Parse(TxtTelefono.Text);
				}
			}
		}

		protected void BtnGuardar_Click(object sender, EventArgs e)
		{
			LibroClubWS.personal personal = new personal();

			String nombre = TxtNombre.Text;
			String dni = TxtDni.Text;

			DateTime fecha_nacimiento = DateTime.Parse(TxtFechaNacimiento.Text);

			char genero = RadioButtonListGenero.SelectedValue[0];
			int telefono = Int32.Parse(TxtTelefono.Text);

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

			if (opcion == "new")
			{
				foreach (personal personalDni in daoPersonal.listarPersonal())
				{
					if (dni == personalDni.dni)
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
				foreach (personal personalDni in daoPersonal.listarPersonal())
				{
					if (TxtDni.Text == personalDni.dni && TxtDni.Text != _dni)
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

			////////////////////////////////

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


			///////////////////////////////


			String username = TxtUsername.Text;
			if (opcion == "new")
			{
				foreach (personal personalUsername in daoPersonal.listarPersonal())
				{
					if (personalUsername.username == TxtUsername.Text)
					{
						TxtUsernameError.Text = "El username ingresado ya existe";
						TxtUsername.Text = "";
						return;
					}
				}
				foreach (gerenteDeLocal gerenteUsername in daoGerente.listarGerente())
				{
					if (gerenteUsername.username == TxtUsername.Text)
					{
						TxtUsernameError.Text = "El username ingresado ya existe";
						TxtUsername.Text = "";
						return;
					}
				}
			}
			else
			{
				foreach (personal personalUsername in daoPersonal.listarPersonal())
				{
					if (TxtUsername.Text == personalUsername.username && TxtUsername.Text != _username)
					{
						TxtUsernameError.Text = "El username ingresado ya existe";
						TxtUsername.Text = "";
						return;
					}
				}
				foreach (gerenteDeLocal gerenteUsername in daoGerente.listarGerente())
				{
					if (TxtUsername.Text == gerenteUsername.username && TxtUsername.Text != _username)
					{
						TxtUsernameError.Text = "El username ingresado ya existe";
						TxtUsername.Text = "";
						return;

					}
				}
			}
			String password = TxtPassword.Text;

			if (ddlEstadoPersonal.SelectedValue == "Activo")
			{
				personal.estado = estadoEmpleado.Activo;
			}
			else if (ddlEstadoPersonal.SelectedValue == "Vacaciones")
			{
				personal.estado = estadoEmpleado.Vacaciones;
			}
			else if (ddlEstadoPersonal.SelectedValue == "DescansoMedico")
			{
				personal.estado = estadoEmpleado.DescansoMedico;
			}
			else if (ddlEstadoPersonal.SelectedValue == "LicenciaMaternidadPaternidad")
			{
				personal.estado = estadoEmpleado.LicenciaMaternidadPaternidad;
			}
			personal.estadoSpecified = true;

			DateTime fecha_fin_contrato = DateTime.Parse(TxtFechaFinContrato.Text);
			int id_sede = (int)Session["GerenteIdSede"];


			personal.nombre = nombre;
			personal.dni = dni;
			personal.fecha_nacimiento = fecha_nacimiento;
			personal.fecha_nacimientoSpecified = true;
			personal.sexo = genero;
			personal.telefono = telefono;
			personal.fin_contrato = fecha_fin_contrato;
			personal.fin_contratoSpecified = true;
			personal.username = username;
			personal.password = password;
			personal.idSede = id_sede;

			if (opcion == "new")
			{
				daoPersonal.insertarPersonal(personal);
				Session["PersonalInsertado"] = personal;
			}
			else if (opcion == "upd")
			{
				int id = int.Parse(TxtId.Text);
				personal.id_persona = id;
				personal.cant_ejemplares_vendidos = int.Parse(TxtCantEjemVendidos.Text);
				personal.cant_ejemplares_prestados = int.Parse(TxtCantEjemPrestados.Text);
				daoPersonal.modificarPersonal(personal);
				Session["PersonalModificado"] = personal;
			}
			Response.Redirect("/Views/Personal.aspx");

		}
		protected void BtnRegresar_Click(object sender, EventArgs e)
		{
			Response.Redirect("/Views/Personal.aspx");
		}
	}
}