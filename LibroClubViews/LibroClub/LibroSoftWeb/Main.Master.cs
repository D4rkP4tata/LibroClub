using LibroClubWeb.LibroClubWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibroClubWeb
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
		public bool MostrarPersonal { get; set; }
		protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Personal"] != null || Session["Gerente"] != null)
            {
                if (Session["Personal"] != null)
                {
					personal personal = new personal();
					personal = (personal)Session["Personal"];
					TxtUser.Text = personal.username;
                    MostrarPersonal = false;
				}
                else
                {
                    gerenteDeLocal gerente = new gerenteDeLocal();
                    gerente = (gerenteDeLocal)Session["Gerente"];
                    TxtUser.Text = gerente.username;
                    MostrarPersonal = true;
                }
                
            }
		}

		protected void BtnCerrarSesion_Click(object sender, EventArgs e)
		{
            Session.Clear();
			Response.Redirect("/Login.aspx");
		}

        protected void Perfil_Click(object sender, EventArgs e)
        {
            if (Session["Personal"] != null || Session["Gerente"] != null)
            {
				Response.Redirect("/Views/Perfil.aspx");
			}
        }
    }
}