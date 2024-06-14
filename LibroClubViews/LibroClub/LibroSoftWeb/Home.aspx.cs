using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibroClubWeb
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Personal"] == null && Session["Gerente"] == null )
            {
                Response.Redirect("/Login.aspx");
            }
            else if(Session["Personal"] != null || Session["Gerente"] != null)
			{
				Response.Redirect("/Views/Usuarios.aspx");
			}
        }

		protected void LinkButton1_Click(object sender, EventArgs e)
		{
		}
	}
}