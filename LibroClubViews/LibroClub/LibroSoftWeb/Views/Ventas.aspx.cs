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
    public partial class Ventas : System.Web.UI.Page
    {

        public bool MostrarPersonal { get; set; }

        private VentaWSClient daoVenta;
        private venta venta;
        private BindingList<venta> ventas;
        private int id_Sede;
        venta[] ventasArreglo;
        protected void Page_Load(object sender, EventArgs e)
        {

            id_Sede = (int)Session["IDSEDE"];
            if (!IsPostBack)
            {
                if (Session["Personal"] != null)
                {
                    lbRegistrarOrdenVenta.Visible = true;
                }
                else
                {
                    lbRegistrarOrdenVenta.Visible = false;
                }
            }

            daoVenta = new VentaWSClient();
            cargarTabla();

        }

        private void cargarTabla()
        {

            ventasArreglo = daoVenta.listarVentas(id_Sede);
            if (ventasArreglo != null)
                ventas = new BindingList<venta>(ventasArreglo);
            gvVenta.DataSource = ventas;
            gvVenta.DataBind();
        }

        protected void lbRegistrarOrdenVenta_Click(object sender, EventArgs e)
        {

            Response.Redirect("/Views/VentasForm.aspx?op=new");


        }

        protected void gvVenta_RowDataBound(object sender, GridViewRowEventArgs e)
        {



        }

        protected void gvVenta_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvVenta.PageIndex = e.NewPageIndex;
            gvVenta.DataBind();
        }

        protected void BtnEditar_Click(object sender, EventArgs e)
        {
            int ventaId = Int32.Parse(((LinkButton)sender).CommandArgument);
            venta = daoVenta.buscarPorIDVenta(ventaId);
            int prodId = venta.articulo.producto.id_producto;
            if (Session["Gerente"] != null)
            {

                Session["Venta"] = venta;
                Response.Redirect("/Views/VentasForm.aspx?op=upd&id=" + ventaId + "&idp=" + prodId);
            }
            else
            {
                personal personal = Session["Personal"] as personal;

                if (venta.vendedor.id_persona == personal.id_persona)
                {
                    Session["Venta"] = venta;
                    Response.Redirect("/Views/VentasForm.aspx?op=upd&id=" + ventaId + "&idp=" + prodId);
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Usted no tiene permiso para editar esta venta');", true);
                }
            }
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            int ventaId = Int32.Parse(((LinkButton)sender).CommandArgument);
            daoVenta.eliminarVenta(ventaId);
            cargarTabla();
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void BuscarDni_Click(object sender, EventArgs e)
        {
            bool tieneSede = !string.IsNullOrEmpty(TxtDniCliente.Text);
            bool tieneFechas = (string.IsNullOrEmpty(TxtFechaDesde.Text) == false && string.IsNullOrEmpty(TxtFechaHasta.Text) == false);
            string fecha_desde;
            string fecha_hasta;

            if (tieneSede && !tieneFechas)
            {
                ventasArreglo = daoVenta.listarVentasBusqueda(id_Sede, TxtDniCliente.Text, "", "");
                cargarTablaBusqueda(ventasArreglo);
            }
            if (!tieneSede && tieneFechas)
            {
                fecha_desde = TxtFechaDesde.Text;
                fecha_hasta = TxtFechaHasta.Text;
                ventasArreglo = daoVenta.listarVentasBusqueda(id_Sede, "", fecha_desde, fecha_hasta);
                cargarTablaBusqueda(ventasArreglo);
            }
            if (tieneSede && tieneFechas)
            {
                fecha_desde = TxtFechaDesde.Text;
                fecha_hasta = TxtFechaHasta.Text;
                ventasArreglo = daoVenta.listarVentasBusqueda(id_Sede, TxtDniCliente.Text, fecha_desde, fecha_hasta);
                cargarTablaBusqueda(ventasArreglo);
            }
            if (!tieneSede && !tieneFechas)
            {
                cargarTabla();
            }
        }

        private void cargarTablaBusqueda(venta[] ventasArreglo)
        {
            if (ventasArreglo != null)
            {
                ventas = new BindingList<venta>(ventasArreglo);
            }
            else
            {
                TxtErrorBuscar.Text = "No se encontró algun elemento con dichos filtros";
            }

            gvVenta.DataSource = ventas;
            gvVenta.DataBind();
        }

        protected void btnFecha_Click(object sender, EventArgs e)
        {
            BuscarDni_Click(sender, e);
        }
    }
}