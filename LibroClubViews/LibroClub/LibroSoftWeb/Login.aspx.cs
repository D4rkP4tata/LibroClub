using LibroClubModels;
using LibroClubWeb.LibroClubWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibroClubWeb
{
	public partial class Login : System.Web.UI.Page
	{
		public static LibroClubWS.ServicioWSClient daoPersonal;
		public static LibroClubWS.ServicioWSClient daoGerente;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["Personal"] != null || Session["Gerente"] != null)
			{
				Response.Redirect("/Views/Usuarios.aspx");
			}
			else
			{
				TxtError.Text = "";
				daoPersonal = new LibroClubWS.ServicioWSClient();
				daoGerente = new LibroClubWS.ServicioWSClient();
				Session["Personal"] = null;
				Session["Gerente"] = null;
			}	
		}

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
			//TxtUsername.Enabled = false;
			//TxtUsername.Enabled = false;
			//BtnLogin.Enabled = false;
			String user = TxtUsername.Text;
			String password = TxtPassword.Text;
			bool usernameRegistrado = false;
			if(daoPersonal.listarPersonal() != null)
			{
				foreach (personal personal in daoPersonal.listarPersonal())
				{
					if (personal.username == user)
					{
						usernameRegistrado = true;//SÍ hay un usuario en personal entonces no deberia buscarse ya en gerentes
						if (personal.password == password)
						{
							Session["Personal"] = personal;//si entra aca es porque ya se encontró
                            Session["IDSEDE"] = personal.idSede;
                            break;
						}
					}
				}
			}
			
			if (Session["Personal"] == null && !usernameRegistrado)
			{
				foreach (gerenteDeLocal gerente in daoGerente.listarGerente())
				{
					if (gerente.username == user)
					{
						if (gerente.password == password)
						{
							Session["Gerente"] = gerente;
							Session["GerenteIdSede"] = gerente.idSede;
                            Session["IDSEDE"] = gerente.idSede;
                            break;
						}
					}
				}
			}


			if (Session["Personal"] != null || Session["Gerente"] != null)
			{
				Response.Redirect("/Home.aspx");
			}
			else
			{
				TxtError.Text = "Usuario o contraseña inválida";
				TxtUsername.Text = "";
				TxtUsername.Enabled = true;
				TxtPassword.Text = "";
				TxtPassword.Enabled = true;
				BtnLogin.Enabled = true;
			}

        }

		protected void LinkSignIn_Click(object sender, EventArgs e)
		{
			Response.Redirect("/Signin.aspx");
		}
	}
}