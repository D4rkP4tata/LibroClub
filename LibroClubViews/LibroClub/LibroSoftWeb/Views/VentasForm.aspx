<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="VentasForm.aspx.cs" Inherits="LibroClubWeb.Views.VentasForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Formulario De Ventas
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server">
    <script src="/Scripts/Ventas.js?version=1.1" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Body" runat="server">
         <nav style="--bs-breadcrumb-divider: '>'; font-size: 14px">
     <ol class="breadcrumb">
         <li class="breadcrumb-item">
             <i class="fa-solid fa-house"></i>
         </li>
         <li class="breadcrumb-item">Usuarios</li>
         <li class="breadcrumb-item">Registrar</li>
     </ol>
 </nav>


 <div class="container">
     <div class="card">
         <div class="card-header">
             <h2>Registrar Venta</h2>
         </div>
         <div class="card-body">
             <div class="card border">
                 <div class="card-header bg-light">
                     <h5 class="card-title mb-0">Vendedor</h5>
                 </div>
                 <div class="card-body">
                     <div class="mb-2 row">
                         <asp:Label ID="lblIdPersonal" runat="server" Text="Id Personal" CssClass="col-sm-1 col-form-label" />
                         <div class="col-sm-3">
                             <asp:TextBox ID="txtIdPersonal" runat="server" Enabled="false" CssClass="form-control" />
                         </div>
                         <asp:Label ID="lblNombrePersonal" runat="server" Text="Personal:" CssClass="col-sm-2 col-form-label text-end" />
                         <div class="col-sm-4">
                             <asp:TextBox ID="txtNombrePersonal" runat="server" Enabled="false" CssClass="form-control" />
                         </div>

                     </div>
                     <div class="mb-2 row">
                         
                     </div>
                     
                 </div>
             </div>
             <div class="card border">
                 <div class="card-header bg-light">
                     <h5 class="card-title mb-0">Usuario</h5>
                 </div>
                 <div class="card-body">
                     <div class="mb-3 row">
                         <asp:Label ID="lblIdUsuario" runat="server" Text="Id Usuario" CssClass="col-sm-1 col-form-label" />
                         <div class="col-sm-3">
                             <asp:TextBox ID="txtIdUsuario" runat="server" Enabled="false" CssClass="form-control" />
                         </div>
                         <asp:Label ID="lblDniUsuario" runat="server" Text="DNI" CssClass="col-sm-2 col-form-label text-end" />
                         <div class="col-sm-3">
                             <asp:TextBox ID="txtDniUsuario" runat="server" Enabled="false" CssClass="form-control" />
                         </div>
                     </div>
                     <div class="mb-3 row">
                         <asp:Label ID="lblNombreUsuario" runat="server" Text="Nombre:" CssClass="col-sm-1 col-form-label" />
                         <div class="col-sm-4">
                             <asp:TextBox ID="txtNombreUsuario" runat="server" Enabled="false" CssClass="form-control" />
                         </div>
                         <asp:Label ID="lblMembresia" runat="server" Text="Membresia" CssClass="col-sm-2 col-form-label text-end" />
                         <div class="col-sm-3">
                             <asp:TextBox ID="txtMembresia" runat="server" Enabled="false" CssClass="form-control" />
                         </div>
                         <div class="col-sm-2">
                             <asp:Button ID="btnBuscarUsuario" CssClass="btn btn-primary" runat="server" Text="Buscar Usuario" OnClick="btnBuscarUsuario_Click" />
                         </div>
                             
                         
                         
                     </div>
                 </div>
             </div>
             <div class="card border">
                 <div class="card-header bg-light">
                     <h5 class="card-title mb-0">Producto</h5>
                 </div>
                 <div class="card-body">
                     <div class="mb-3 row">
                         <asp:Label ID="lblIDProducto" runat="server" Text="ID Producto:" CssClass="col-sm-2 col-form-label" />
                         <div class="col-sm-2">
                             <asp:TextBox ID="txtIDProducto" runat="server" Enabled="false" CssClass="form-control" />
                         </div>
                         <asp:Label ID="lblNombreProducto" runat="server" Text="Titulo:" CssClass="col-sm-2 col-form-label text-end" />
                         <div class="col-sm-5">
                             <asp:TextBox ID="txtNombreProducto" runat="server" Enabled="false" CssClass="form-control" />
                         </div>
                         
                     </div>
                     <div class="mb-3 row">
                         <asp:Label ID="lblTipoProducto" runat="server" Text="Tipo:" CssClass="col-sm-1 col-form-label" />
                         <div class="col-sm-3">
                             <asp:TextBox ID="TxtTipoProducto" runat="server" Enabled="false" CssClass="form-control" />
                         </div>
                         <asp:Label ID="lblClasificador" runat="server" Text="Clasificador:" CssClass="col-sm-2 col-form-label text-end" />
                         <div class="col-sm-3">
                             <asp:TextBox ID="TxtClasificador" runat="server" Enabled="false" CssClass="form-control" />
                         </div>
                         <div class="col text-end">
                             <asp:Button ID="btnBuscarProducto" CssClass="btn btn-primary" runat="server" Text="Buscar Producto" OnClick="btnBuscarProducto_Click" />
                         </div>
                     </div>
                     <div class="mb-4 row">
                         <asp:Label ID="lblPrecioUnitProducto" runat="server" Text="Precio:" CssClass="col-sm-1 col-form-label" />
                         <div class="col-sm-3">
                             <asp:TextBox ID="txtPrecioUnitProducto" runat="server" Enabled="false" CssClass="form-control" />
                         </div>
                         <asp:Label ID="lblDescuento" runat="server" Text="Descuento:" CssClass="col-sm-2 col-form-label text-end" />
                         <div class="col-sm-3">
                             <asp:TextBox ID="txtDescuento" runat="server" Enabled="false" CssClass="form-control" />
                         </div>
                     </div>
                    
                     <div class="mb-4 row align-items-center justify-content-end">
                         <asp:Label ID="lblTotal" runat="server" Text="TOTAL:" CssClass="col-form-label col-sm-2 fw-bold text-end"/>
                         <div class="col-sm-2">
                             <asp:TextBox ID="txtTotal" CssClass="form-control col-sm-2" Enabled="false" runat="server"></asp:TextBox>
                         </div>
                     </div>
                 </div>
             </div>
             <div class="card border">
                 <div class="card-header bg-light">
                     <h5 class="card-title mb-0">Sede</h5>
                 </div>
                 <div class="card-body">
                     <div class="mb-2 row">
                         <asp:Label ID="LabelIdSede" runat="server" Text="Id Sede" CssClass="col-sm-2 col-form-label" />
                         <div class="col-sm-3">
                             <asp:TextBox ID="TxtIdSede" runat="server" Enabled="false" CssClass="form-control" />
                         </div>
                         <asp:Label ID="lblDireccionSede" runat="server" Text="Direccion:" CssClass="col-sm-2 col-form-label text-end" />
                         <div class="col-sm-4">
                             <asp:TextBox ID="TxtDirecSede" runat="server" Enabled="false" CssClass="form-control" />
                         </div>
                     </div>

                        
                 </div>
             </div>
         </div>


         <div class="card-footer clearfix">
             <asp:Button ID="btnRegresar" runat="server" Text="Regresar"
                 CssClass="float-start btn btn-secondary" OnClick="btnRegresar_Click"/>
             <div cssclass="alert-warning p-2 align-content-center my-2" style="color: red;">
                 <asp:Label ID="TxtErrorGuardar" runat="server" Text=""></asp:Label>
             </div>
             <asp:Button ID="btnGuardar" runat="server" Text="Guardar"
                 CssClass="float-end btn btn-primary" OnClick="btnGuardar_Click" />
         </div>
     </div>
 </div>
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <div class="modal" id="form-modal-usuario">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Búsqueda de Usuarios</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="container row pb-3 pt-3">
                                <div class="row align-content-center">
                                    <div class="col-sm-1">
                                        <asp:Label CssClass="form-label" runat="server" Text="Nombre:"></asp:Label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox CssClass="form-control" ID="txtNombreUsuarioModal" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-2">
                                        <asp:LinkButton ID="lbBusquedaUsuarioModal" runat="server" CssClass="btn btn-info" Text="<i class='fa-solid fa-magnifying-glass pe-2'></i> Buscar" OnClick="lbBusquedaUsuarioModal_Click" />
                                    </div>
                                    <div class="col-sm-1">
                                        <asp:Label CssClass="form-label" runat="server" Text="DNI:"></asp:Label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox CssClass="form-control" ID="txtDniUsuarioModal" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-2">
                                        <asp:LinkButton ID="btnBuscarUsuarioDNI" runat="server" CssClass="btn btn-info" Text="<i class='fa-solid fa-magnifying-glass pe-2'></i> Buscar" OnClick="btnBuscarUsuarioDNI_Click" />
                                    </div>

                                </div>
                            </div>
                            <div class="container row">
                                <asp:GridView ID="gvUsuarios" runat="server" AllowPaging="true" PageSize="5" AutoGenerateColumns="false" CssClass="table table-hover table-responsive table-striped" OnPageIndexChanging="gvUsuarios_PageIndexChanging" OnRowDataBound="gvUsuarios_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="id_persona" HeaderText="Id Usuario"  />
                                        <asp:BoundField DataField="nombre" HeaderText="Nombre"  />
                                        <asp:BoundField DataField="dni" HeaderText="DNI"  />
                                        <asp:BoundField DataField="membresia" HeaderText="Membresia"  />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnSeleccionUsuario" class="btn btn-success" runat="server" Text="<i class='fa-solid fa-check ps-2'></i> Seleccionar" OnClick="btnSeleccionUsuario_Click" CommandArgument='<%# Eval("id_persona") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>

    <div class="modal" id="form-modal-producto">
    <div class="modal-dialog modal-xl">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title">Búsqueda de Productos</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="container row pb-3 pt-3">
                            <div class="row align-items-center">
                                <div class="col-sm-1">
                                    <asp:Label CssClass="form-label" runat="server" Text="Titulo :"></asp:Label>
                                </div>
                                <div class="col-sm-4">
                                    <asp:TextBox CssClass="form-control" ID="txtNombreProductoModal" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="FiltrarTipo" AutoPostBack="true" OnSelectedIndexChanged="FiltrarTipo_SelectedIndexChanged" runat="server" CssClass="dropdown-item-text rounded" Width="210" Height="40" Style="border: 2px solid #dee2e6;">
                                        <asp:ListItem Text="Todos" Value="Todas"></asp:ListItem>
                                        <asp:ListItem Text="Pelicula" Value="Pelicula"></asp:ListItem>
                                        <asp:ListItem Text="Revista" Value="Revista"></asp:ListItem>
                                        <asp:ListItem Text="Libro" Value="Libro"></asp:ListItem>
                                        <asp:ListItem Text="CDMusica" Value="CDMusica"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-2">
                                    <asp:LinkButton ID="lbBusquedaProductoModal" runat="server" CssClass="btn btn-info" Text="<i class='fa-solid fa-magnifying-glass pe-2'></i> Buscar" OnClick="lbBusquedaProductoModal_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="container row">
                            <asp:GridView ID="gvProductos" runat="server" AllowPaging="true" PageSize="5" AutoGenerateColumns="false" CssClass="table table-hover table-responsive table-striped" OnPageIndexChanging="gvProductos_PageIndexChanging" OnRowDataBound="gvProductos_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="id_producto" HeaderText="Id Producto"  />
                                    <asp:BoundField DataField="nombre" HeaderText="Titulo"  />
                                    <asp:BoundField DataField="precio" HeaderText="Precio"  />
                                    <asp:BoundField DataField="tipoProducto" HeaderText="Tipo"  />
                                    <asp:BoundField DataField="clasificador" HeaderText="Clasificacion"  />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnSeleccionProducto" class="btn btn-success" runat="server" Text="<i class='fa-solid fa-check ps-2'></i> Seleccionar" OnClick="btnSeleccionProducto_Click" CommandArgument='<%# Eval("id_producto") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</div>

    <div class="modal fade" id="errorModal">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="errorModalLabel">Error</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <!-- Error message will be injected here -->
                    <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger"></asp:Label>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
    function showErrorModal() {
        var myModal = new bootstrap.Modal(document.getElementById('errorModal'));
        myModal.show();
    }
</script>
</asp:Content>
