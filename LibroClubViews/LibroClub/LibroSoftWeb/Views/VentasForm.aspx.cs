using LibroClubModels;
using LibroClubWeb.LibroClubWS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibroClubWeb.Views
{
    public partial class VentasForm : System.Web.UI.Page
    {

        string opcion;
        string empleadoId;
        string idVenta;
        string idProd;

        productoMultimedia producto;

        UsuarioWSClient daoUsuario = new UsuarioWSClient();
        private BindingList<usuario> usuarios;
        usuario[] usuariosArreglo;
        usuario usuario;

        ProductoWSClient daoProducto = new ProductoWSClient();
        private BindingList<productoMultimedia> productos;
        productoMultimedia[] productosArreglo;
        VentaWSClient daoVenta;

        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["Personal"] != null || Session["Gerente"] != null)
            {
                daoVenta = new VentaWSClient();

                usuariosArreglo = daoUsuario.listarPorNombreUsuario("");

                if (usuariosArreglo != null)
                    usuarios = new BindingList<usuario>(usuariosArreglo);
                gvUsuarios.DataSource = usuarios;
                gvUsuarios.DataBind();


                productosArreglo = daoProducto.listarPorNombreProducto("");
                opcion = Request.QueryString["op"];
                if (productosArreglo != null)
                    productos = new BindingList<productoMultimedia>(productosArreglo);
                gvProductos.DataSource = productos;
                gvProductos.DataBind();

                if (!IsPostBack)
                {
                    Session["igualProd"] = "1";
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
            venta venta = Session["Venta"] as venta;


            if (opcion == "upd")
            {
                txtIdPersonal.Text = venta.vendedor.id_persona.ToString();
                txtNombrePersonal.Text = venta.vendedor.nombre;

                usuario = daoUsuario.ObtenerUsuarioDni(venta.cliente.dni);

                txtIdUsuario.Text = usuario.id_persona.ToString();
                txtDniUsuario.Text = usuario.dni;
                txtNombreUsuario.Text = usuario.nombre;
                txtMembresia.Text = usuario.membresia.ToString();

                producto = daoProducto.buscarPorIDProducto(venta.articulo.producto.id_producto);

                txtIDProducto.Text = producto.id_producto.ToString();
                txtNombreProducto.Text = producto.nombre;
                TxtTipoProducto.Text = producto.tipoProducto.ToString();
                TxtClasificador.Text = producto.clasificador;
                txtPrecioUnitProducto.Text = producto.precio.ToString();

                txtTotal.Text = venta.total.ToString();
                TxtIdSede.Text = venta.sede.id_sede.ToString();
                TxtDirecSede.Text = venta.sede.direccion;

                double descuento = hallarDescuento();
                txtDescuento.Text = descuento.ToString();

                idVenta = Request.QueryString["id"];
                idProd = Request.QueryString["idp"];
            }
            else
            {
                personal personal = Session["Personal"] as personal;
                txtIdPersonal.Text = personal.id_persona.ToString();
                txtNombrePersonal.Text = personal.nombre;

                TxtIdSede.Text = personal.idSede.ToString();
                TxtDirecSede.Text = personal.nombreSede;

            }






        }



        protected void btnBuscarUsuario_Click(object sender, EventArgs e)
        {
            string script = "window.onload = function() { showModalFormUsuario() ;};";
            ClientScript.RegisterStartupScript(GetType(), "", script, true);
        }

        protected void lbBusquedaUsuarioModal_Click(object sender, EventArgs e)
        {
            usuariosArreglo = daoUsuario.listarPorNombreUsuario(txtNombreUsuarioModal.Text);
            usuarios = new BindingList<usuario>(usuariosArreglo);
            gvUsuarios.DataSource = usuarios;
            gvUsuarios.DataBind();
        }

        protected void btnBuscarUsuarioDNI_Click(object sender, EventArgs e)
        {
            usuario = daoUsuario.ObtenerUsuarioDni(txtDniUsuarioModal.Text);
            usuarios = new BindingList<usuario> { usuario };
            gvUsuarios.DataSource = usuarios;
            gvUsuarios.DataBind();
        }

        protected void btnSeleccionUsuario_Click(object sender, EventArgs e)
        {
            int idUsuario = Int32.Parse(((LinkButton)sender).CommandArgument);
            usuario usuarioSeleccionado = usuarios.SingleOrDefault(x => x.id_persona == idUsuario);
            Session["usuario"] = usuarioSeleccionado;
            Session["descuento"] = usuarioSeleccionado.membresia.ToString();
            txtIdUsuario.Text = usuarioSeleccionado.id_persona.ToString();
            txtDniUsuario.Text = usuarioSeleccionado.dni;
            txtNombreUsuario.Text = usuarioSeleccionado.nombre;
            txtMembresia.Text = usuarioSeleccionado.membresia.ToString();
            double descuento = hallarDescuento();
            if (descuento != -1)
            {
                txtDescuento.Text = descuento.ToString() + "%";
                txtTotal.Text = ((100 - descuento) / 100 * Double.Parse(txtPrecioUnitProducto.Text)) + "";
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "", "__doPostBack('','');", true);

        }


        protected void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            string script = "window.onload = function() { showModalFormProducto() ;};";
            ClientScript.RegisterStartupScript(GetType(), "", script, true);
        }

        protected void lbBusquedaProductoModal_Click(object sender, EventArgs e)
        {
            string tipoProd = FiltrarTipo.SelectedValue;
            if (tipoProd == "Todos")
            {
                productosArreglo = daoProducto.listarPorNombreYTipoProducto(txtNombreProductoModal.Text, "");
            }
            else
            {
                productosArreglo = daoProducto.listarPorNombreYTipoProducto(txtNombreProductoModal.Text, tipoProd);
            }

            productos = new BindingList<productoMultimedia>(productosArreglo);
            gvProductos.DataSource = productos;
            gvProductos.DataBind();
        }

        protected void btnSeleccionProducto_Click(object sender, EventArgs e)
        {
            int idProducto = Int32.Parse(((LinkButton)sender).CommandArgument);
            productoMultimedia productoSeleccionado = productos.SingleOrDefault(x => x.id_producto == idProducto);
            Session["producto"] = productoSeleccionado;
            if (Request.QueryString["op"] == "upd")
            {
                if (txtIDProducto.Text == productoSeleccionado.id_producto.ToString())
                {
                    Session["igualProd"] = "1";
                }
                else
                {
                    Session["igualProd"] = "0";
                }
            }
            txtIDProducto.Text = productoSeleccionado.id_producto.ToString();
            txtNombreProducto.Text = productoSeleccionado.nombre;
            TxtTipoProducto.Text = productoSeleccionado.tipoProducto.ToString();
            TxtClasificador.Text = productoSeleccionado.clasificador;
            txtPrecioUnitProducto.Text = productoSeleccionado.precio.ToString();
            double descuento = hallarDescuento();
            if (descuento != -1)
            {
                txtDescuento.Text = descuento.ToString() + "%";
                txtTotal.Text = ((100 - descuento) / 100 * Double.Parse(txtPrecioUnitProducto.Text)) + "";
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "", "__doPostBack('','');", true);
        }

        private double hallarDescuento()
        {
            String membresia;
            if (opcion == "upd")
            {
                membresia = txtMembresia.Text;
                if (membresia == "Ninguna")
                {
                    return 0;
                }
                if (membresia == "Plata")
                {
                    return 10;
                }
                if (membresia == "Oro")
                {
                    return 20;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(txtMembresia.Text) || string.IsNullOrEmpty(txtIDProducto.Text))
                {
                    return -1;
                }
                else
                {
                    membresia = txtMembresia.Text;
                    if (membresia == "Ninguna")
                    {
                        return 0;
                    }
                    if (membresia == "Plata")
                    {
                        return 10;
                    }
                    if (membresia == "Oro")
                    {
                        return 20;
                    }
                    return -1;
                }
            }
            return -1;

        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIDProducto.Text) && !string.IsNullOrEmpty(txtIdUsuario.Text))
            {


                venta ventaGuardar = new venta();
                double descuento;

                ventaGuardar.articulo = new ejemplarVenta();
                ventaGuardar.articulo.producto = new productoMultimedia();
                ventaGuardar.articulo.producto.id_producto = Int32.Parse(txtIDProducto.Text);
                ventaGuardar.cliente = new usuario();
                ventaGuardar.cliente.id_persona = Int32.Parse(txtIdUsuario.Text);

                ventaGuardar.sede = new sede();
                ventaGuardar.sede.id_sede = Int32.Parse(TxtIdSede.Text);

                ventaGuardar.vendedor = new personal();
                ventaGuardar.vendedor.id_persona = Int32.Parse(txtIdPersonal.Text);
                ventaGuardar.subtotal = Double.Parse(txtPrecioUnitProducto.Text);
                ventaGuardar.total = Double.Parse(txtTotal.Text);
                descuento = hallarDescuento();
                ventaGuardar.descuento = descuento;



                if (opcion == "new")
                {
                    daoVenta.insertarVenta(ventaGuardar);
                    Response.Redirect("/Views/Ventas.aspx");
                }
                else
                {
                    String igual = Session["igualProd"] as String;
                    ventaGuardar.id_venta = Int32.Parse(Request.QueryString["id"]);
                    if (igual == "1")
                    {
                        daoVenta.modificarVentaIgualProducto(ventaGuardar);
                        Response.Redirect("/Views/Ventas.aspx");
                    }
                    else
                    {
                        daoVenta.modificarVentaDiferenteProducto(ventaGuardar);
                        Response.Redirect("/Views/Ventas.aspx");

                    }


                }


            }
            else
            {
                ShowErrorModal("Necesita rellenar todos los campos");
            }
        }

        private void ShowErrorModal(string errorMessage)
        {
            lblErrorMessage.Text = errorMessage;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowErrorModal", "showErrorModal();", true);
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Views/Ventas.aspx");
        }




        protected void gvUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUsuarios.PageIndex = e.NewPageIndex;
            gvUsuarios.DataSource = usuarios;
            gvUsuarios.DataBind();
        }

        protected void gvUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }



        protected void gvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProductos.PageIndex = e.NewPageIndex;
            gvProductos.DataSource = usuarios;
            gvProductos.DataBind();
        }

        protected void gvProductos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int id_sede = (int)Session["IDSEDE"];
            idProd = Request.QueryString["idp"];
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                productoMultimedia productoRow = (productoMultimedia)e.Row.DataItem;
                int idprod = productoRow.id_producto;
                LinkButton btnSeleccionProducto = (LinkButton)e.Row.FindControl("btnSeleccionProducto");

                int existeEjemplar = daoProducto.existeEjemplarProductoSede(idprod, id_sede);


                if (existeEjemplar != 1)
                {
                    btnSeleccionProducto.Visible = false;

                    if (opcion == "upd" && Int32.Parse(idProd) == idprod)
                    {
                        btnSeleccionProducto.Visible = true;
                    }

                }
            }
        }

        protected void FiltrarTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}