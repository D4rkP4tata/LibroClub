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
	public partial class Perfil : System.Web.UI.Page
	{
		public static LibroClubWS.ServicioWSClient daoGerente;
		public static LibroClubWS.ServicioWSClient daoPersonal;
		public static LibroClubWS.ServicioWSClient daoSede;

		public bool mostrarPersonal { get; set; }
		public bool mostrarGerente { get; set; }

		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["Gerente"] != null)
			{
				TxtRol.Text = "Gerente";
				daoGerente = new LibroClubWS.ServicioWSClient();
				gerenteDeLocal gerente = (gerenteDeLocal)Session["Gerente"];
				gerenteDeLocal _gerente = daoGerente.obtenerGerenteID(gerente.id_persona);
				mostrarGerente = true;
				mostrarPersonal = false;
				CargarDatosGerente(gerente);
			}
			else if (Session["Personal"] != null)
			{
				TxtRol.Text = "Personal";
				daoPersonal = new LibroClubWS.ServicioWSClient();
				personal personal = (personal)Session["Personal"];
				personal _personal = daoPersonal.ObtenerPersonalID(personal.id_persona);
				mostrarPersonal = true;
				mostrarGerente = false;
				CargarDatosPersonal(personal);
			}
			else
			{
				Response.Redirect("/Login.aspx");
			}
			
		}

		private void CargarDatosGerente(gerenteDeLocal _gerente)
		{
			daoSede = new LibroClubWS.ServicioWSClient();
			TxtDni.Text = _gerente.dni;
			TxtFechaFinContrato.Text = _gerente.fin_contrato.ToString("yyyy-MM-dd");
			TxtFechaInicioContrato.Text = _gerente.inicio_contrato.ToString("yyyy-MM-dd");
			TxtFechaNacimiento.Text = _gerente.fecha_nacimiento.ToString("yyyy-MM-dd");
			TxtId.Text = _gerente.id_persona.ToString();
			TxtNombre.Text = _gerente.nombre;
			TxtPassword.Text = _gerente.password;
			foreach (sede sede in daoSede.listarSede())
			{
				if (_gerente.idSede == sede.id_sede)
				{
					TxtSede.Text = sede.direccion;
					break;
				}
			}
			TxtTelefono.Text = _gerente.telefono.ToString();
			TxtUsername.Text = _gerente.username;
			TxtInicioCargo.Text = _gerente.fecha_inicio_cargo.ToString("yyyy-MM-dd");
			if (_gerente.sexo == 'M')
			{
				RadioButtonListGenero.Items[0].Selected = true;
			}
			else if (_gerente.sexo == 'F')
			{
				RadioButtonListGenero.Items[1].Selected = true;
			}

			String estadoPersonal = _gerente.estado.ToString();
			if (estadoPersonal == "Activo")
			{
				ddlEstado.Items[0].Selected = true;
			}
			else if (estadoPersonal == "Vacaciones")
			{
				ddlEstado.Items[1].Selected = true;
			}
			else if (estadoPersonal == "DescansoMedico")
			{
				ddlEstado.Items[2].Selected = true;
			}
			else if (estadoPersonal == "LicenciaMaternidadPaternidad")
			{
				ddlEstado.Items[3].Selected = true;
			}

		}

		private void CargarDatosPersonal(personal _personal)
		{
			daoSede = new LibroClubWS.ServicioWSClient();
			TxtDni.Text = _personal.dni;
			TxtFechaFinContrato.Text = _personal.fin_contrato.ToString("yyyy-MM-dd");
			TxtFechaInicioContrato.Text = _personal.inicio_contrato.ToString("yyyy-MM-dd");
			TxtFechaNacimiento.Text = _personal.fecha_nacimiento.ToString("yyyy-MM-dd");
			TxtId.Text = _personal.id_persona.ToString();
			TxtNombre.Text = _personal.nombre;
			TxtPassword.Text = _personal.password;
			foreach (sede sede in daoSede.listarSede())
			{
				if (_personal.idSede == sede.id_sede)
				{
					TxtSede.Text = sede.direccion;
					break;
				}
			}
			TxtTelefono.Text = _personal.telefono.ToString();
			TxtUsername.Text = _personal.username;
			TxtCantEjemPrestados.Text = _personal.cant_ejemplares_prestados.ToString();
			TxtCantEjemVendidos.Text = _personal.cant_ejemplares_vendidos.ToString();

			if (_personal.sexo == 'M')
			{
				RadioButtonListGenero.Items[0].Selected = true;
			}
			else if (_personal.sexo == 'F')
			{
				RadioButtonListGenero.Items[1].Selected = true;
			}

			String estadoPersonal = _personal.estado.ToString();
			if (estadoPersonal == "Activo")
			{
				ddlEstado.Items[0].Selected = true;
			}
			else if (estadoPersonal == "Vacaciones")
			{
				ddlEstado.Items[1].Selected = true;
			}
			else if (estadoPersonal == "DescansoMedico")
			{
				ddlEstado.Items[2].Selected = true;
			}
			else if (estadoPersonal == "LicenciaMaternidadPaternidad")
			{
				ddlEstado.Items[3].Selected = true;
			}
		}

		protected void BtnRegresar_Click(object sender, EventArgs e)
		{
			Response.Redirect("/Views/Personal.aspx");
		}
	}
}