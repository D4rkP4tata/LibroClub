using LibroClubWeb.LibroClubWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibroClubWeb
{
	public partial class Signin : System.Web.UI.Page
	{
		public static LibroClubWS.ServicioWSClient daoPersonal;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["Personal"] != null)
			{
				Response.Redirect("/Views/Usuarios.aspx");
			}
			else
			{
				TxtNewUserOK.Text = "";
				TxtNewUserERROR.Text = "";	
				TxtConfirmPass.Text = "";
				daoPersonal = new LibroClubWS.ServicioWSClient();
			}
		}

        protected void LinkLogIn_Click(object sender, EventArgs e)
        {
			Response.Redirect("/Login.aspx");
        }

		protected void BtnSignIn_Click(object sender, EventArgs e)
		{
			String user = TxtUsername.Text;
			personal personaLogin = new personal();
			Session["NewUser"] = null;
			bool seEncontro = false;
			foreach (personal personal in daoPersonal.listarPersonal())
			{
				if (personal.username == user)
				{
					seEncontro = true;
				}
			}
			if (!seEncontro)
			{
				TxtNewUserOK.Text = "El usuario es válido";
				TxtNewUserERROR.Text = "";
				Session["NewUser"] = user;
			}
			else
			{
				TxtNewUserERROR.Text = "El usuario ya está en uso";
				TxtUsername.Text = "";
				TxtNewUserOK.Text = "";
			}


			String password = TxtPassword.Text;
			String confirmPassword = TxtConfirmPassword.Text;

			bool resultado = false;
			if(password == confirmPassword)
			{
				if (Session["NewUser"] != null)
				{

				}
			}
			else
			{
				TxtConfirmPass.Text = "Las contraseñas deben ser iguales";
				TxtConfirmPassword.Text = "";
				TxtPassword.Text = "";
			}
		}

		
	}
}