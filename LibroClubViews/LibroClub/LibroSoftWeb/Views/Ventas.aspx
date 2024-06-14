<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="LibroClubWeb.Views.Ventas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Ventas
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server">
    <style>
        .go-to-top {
            position: fixed;
            bottom: 2px;
            left: auto;
            max-width: 300px;
            height: auto;
            z-index: 10;
            border-radius: 15px;
            background-color: rgb(255, 255, 255);
            border-color: transparent;
            text-align: left;
            justify-content: center;
            box-shadow: 0px 0px 5px 0px;
        }

        .bg-specify-color-search {
            background: #081f49 !important;
        }

        .bg-specify-color-add {
            /*background: linear-gradient(to right,#879dff, #de8ff6)   !important;*/
            background: #732988;
            padding: 0.7rem !important;
        }

        .hover-effect-search:hover {
            background-color: #204383 !important;
            color: #ffffff;
        }

        .hover-effect-add:hover {
            background-color: #8b1eab !important;
            color: #ffffff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Body" runat="server">
    <nav style="--bs-breadcrumb-divider: '>'; font-size: 14px">
        <ol class="breadcrumb">
            <li class="breadcrumb-item">
                <i class="fa-solid fa-house"></i>
            </li>
            <li class="breadcrumb-item">Usuarios</li>
            <li class="breadcrumb-item">Listado</li>
        </ol>
    </nav>
    <div class="container">
        <h2>Listado de Ventas</h2>
        <div class="container">
            <div class="col">
                <div class="row mt-4">
                    <div class="col-sm-3">
                        <asp:Label ID="lblDniCliente" CssClass="form-label" runat="server" Text="DNI:"></asp:Label>
                    </div>
                    <div class="col-sm-2">
                        <asp:Label ID="LblDesde" CssClass="form-label" runat="server" Text="Desde:"></asp:Label>
                    </div>
                    <div class="col-sm-5">
                        <asp:Label ID="Label1" CssClass="form-label" runat="server" Text="Hasta:"></asp:Label>
                    </div>
                    
                </div>
                <div class="row">
                    <div class="col-sm-2">
                        <asp:TextBox ID="TxtDniCliente" CssClass="form-control border-2" runat="server" Enabled="true" Width="200"></asp:TextBox>
                    </div>

                    <div class="col-sm-1">
                        <asp:LinkButton ID="BuscarDni" runat="server" OnClick="BuscarDni_Click" CssClass="btn hover-effect-search col text-white bg-specify-color-search" Text="<i class='fa-solid fa-magnifying-glass'></i>" />
                    </div>

                    <div class="col-sm-2">
                        <asp:TextBox ID="TxtFechaDesde" runat="server" type="date" CssClass="form-control" required="true"></asp:TextBox>
                    </div>
                    <div class="col-sm-2">
                        <asp:TextBox ID="TxtFechaHasta" runat="server" type="date" CssClass="form-control" required="true"></asp:TextBox>
                    </div>
                    <div class="col-sm-1">
                        <asp:LinkButton ID="btnFecha" runat="server" OnClick="btnFecha_Click" CssClass="btn hover-effect-search col text-white bg-specify-color-search" Text="<i class='fa-solid fa-magnifying-glass'></i>" />
                    </div>

            <div class="col text-end text" style="font-weight: bold;">
                <asp:LinkButton ID="lbRegistrarOrdenVenta" runat="server" CssClass="text-decoration-none text-white hover-effect-add text-black bg-specify-color-add rounded-1" Text="<i class='fas fa-plus pe-2'> </i> Registrar Venta" OnClick="lbRegistrarOrdenVenta_Click" />
            </div>
        </div>
    

</div>
        </div>
        <div class="container row mt-4">
            <div cssclass="alert-warning p-2 align-content-center my-2" style="color: red;">
                <asp:Label ID="TxtErrorBuscar" runat="server" Text=""></asp:Label>
            </div>
    <asp:GridView ID="gvVenta" runat="server" AllowPaging="true" PageSize="5" AutoGenerateColumns="false" CssClass="table table-hover table-responsive table-striped" OnRowDataBound="gvVenta_RowDataBound" OnPageIndexChanging="gvVenta_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="id_venta" HeaderText ="ID Venta"/>
            <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false" />
            <asp:BoundField DataField="cliente.dni" HeaderText ="DNI"/>
            <asp:BoundField DataField="cliente.nombre" HeaderText ="Cliente"/>
            <asp:BoundField DataField="articulo.producto.nombre" HeaderText ="Producto"/>
            <asp:BoundField DataField="total" HeaderText="Total" />
            <asp:BoundField DataField="vendedor.nombre" HeaderText="Vendedor" />
            <%--<asp:BoundField DataField="Ejemplar.Producto.Titulo" HeaderText ="Producto"/>
            <asp:BoundField DataField="usuario.nombre" HeaderText ="Usuario"/>
            <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" />
            <asp:BoundField DataField="Descuento_Membresia" HeaderText="Descuento" />
            <asp:BoundField DataField="Total" HeaderText="Total" />
            <asp:BoundField DataField="Personal.Nombre" HeaderText="Vendedor" />
            <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:yyyy-MM-dd}" />--%>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:LinkButton ID="BtnEditar" runat="server" Text="<i class='fas fa-edit ps-2'>  </i>"
                        OnClick="BtnEditar_Click" CommandArgument='<%# Eval("id_venta") %>' />
                    <asp:LinkButton ID="BtnEliminar" runat="server" Text="<i class='fas fa-trash ps-2'>  </i>"
                        OnClick="BtnEliminar_Click" CommandArgument='<%# Eval("id_venta") %>'
                        OnClientClick="return confirm('¿Esta seguro de eliminar este registro?');" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
</asp:Content>
