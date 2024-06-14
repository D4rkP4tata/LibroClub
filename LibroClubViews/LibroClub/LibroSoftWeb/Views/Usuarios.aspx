<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="LibroClubWeb.Views.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Listado de Usuarios
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server">
    <script src="/Scripts/Usuarios.js?version=2" type="text/javascript"></script>
    <style>
        .go-to-top{
          position: fixed;
          bottom: 2px;
          left: auto;
          max-width: 300px;
          height:auto;
          z-index: 10;
          border-radius: 15px;
          background-color: rgb(255, 255, 255);
          border-color: transparent;
          text-align: left;
          justify-content: center;
          box-shadow: 0px 0px 5px 0px;
          
        }
        .bg-specify-color-search{
            background: #2a3469 !important;
        }
        .bg-specify-color-add{
            /*background: linear-gradient(to right,#879dff, #de8ff6)   !important;*/
            background: #4719ae;
            padding: 0.7rem !important;
        }
        .bg-specify-color-update-trash{
            color: #0a00ff !important
        }
        .bg-specify-color-search:hover {
            background-color: #223390 !important; 

            color: #ffffff; 
        }
        .bg-specify-color-update-trash:hover{
            color: #3731e5 !important
        }
        .bg-specify-color-add:hover {
            background-color:  #4e0edf !important; 

            color: #ffffff; 
        }
    </style>
    <link rel="stylesheet" href="https://unpkg.com/bootstrap@5.3.3/dist/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">
    <link rel="stylesheet" href="https://unpkg.com/bs-brain@2.0.4/components/error-404s/error-404-1/assets/css/error-404-1.css">
        
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
        <h2> Listado de Usuarios </h2>

        <div class="container card-body my-sm-5"> 
            <div class="row align-items-center pb-3">
                <div class="col">
                    <div class="row">
                        <asp:Label ID="lblDniUsuario" CssClass="form-label" runat="server" Text="DNI:"></asp:Label>
                    </div>
                    <div class="row">
                            <div class="col">
                                <asp:TextBox ID="TxtDniUsuario" CssClass="form-control border-2" runat="server" Enabled="true" Width="210"></asp:TextBox>
                            </div>
                            
                            <div class="col">
                                <asp:LinkButton ID="BuscarDni" runat="server" OnClick="BuscarDni_Click" CssClass="btn col text-white bg-specify-color-search" Text="<i class='fa-solid fa-magnifying-glass'></i>"/>
                            </div>
                    </div>
                        
                </div>
                
                <div class="col">
                    <div class="row">
                        <asp:Label ID="lblFiltrarMembresia" CssClass="form-label" runat="server" Text="Membresía:"></asp:Label>
                    </div>
                    <div class ="row">
                        <asp:DropDownList ID="FiltrarMembresia" AutoPostBack="true" OnSelectedIndexChanged="FiltrarMembresia_SelectedIndexChanged" runat="server" CssClass="dropdown-item-text rounded" Width="210" Height="40" Style="border: 2px solid #dee2e6;">
                            <asp:ListItem Text="Todas" Value="Todas"></asp:ListItem>
                            <asp:ListItem Text="Ninguna" Value="Ninguno"></asp:ListItem>
                            <asp:ListItem Text="Plata" Value="Plata"></asp:ListItem>
                            <asp:ListItem Text="Oro" Value="Oro"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                   </div>   
                  

                <div class="col text-end mt-4 text" style="font-weight: bold;">
                  <asp:LinkButton ID="BtnAgregar" runat="server" Text="<i class='fas fa-plus pe-2'> </i> Agregar" 
                  OnClick="BtnAgregar_Click" CssClass="text-decoration-none text-white text-black bg-specify-color-add rounded-1" />
                </div>
            </div>

            <%--<div class="row align-items-center pb-4">
                 <div class="">
                    <asp:Label ID="lblFiltrarMembresia" CssClass="form-label" runat="server" Text="Membresía:"></asp:Label>
                </div>
                <div class="col-auto">
                    
                        <asp:DropDownList ID="FiltrarMembresia" runat="server" CssClass="dropdown-item-text my-2 rounded" Width="210" Height="40" Style="border: 2px solid #dee2e6;">
                            <asp:ListItem Text="Seleccionar" Value="Seleccionar"></asp:ListItem>
                            <asp:ListItem Text="Ninguna" Value="Ninguno"></asp:ListItem>
                            <asp:ListItem Text="Plata" Value="Plata"></asp:ListItem>
                            <asp:ListItem Text="Oro" Value="Oro"></asp:ListItem>
                        </asp:DropDownList>
                </div>
                <div class="col-sm-4">
                    <asp:LinkButton ID="FiltrarMembresiaUsuario" runat="server" OnClick="FiltrarMembresiaUsuario_Click" CssClass="btn btn-info" Text="<i class='fa-solid fa-magnifying-glass pe-2'></i> Buscar" />
                    <asp:LinkButton ID="LimpiarMembresia" OnClick="LimpiarMembresia_Click" runat="server" CssClass="btn btn-danger" Text="<i class='fa-solid'></i> Limpiar" />
                </div>
                <div class="text-end col">
                  <asp:LinkButton ID="BtnAgregar" runat="server" Text="<i class='fas fa-plus pe-2'> </i> Agregar" 
                  OnClick="BtnAgregar_Click" CssClass="btn btn-success" />
                </div>
                  
            </div>--%>

            <div CssClass="alert-warning p-2 align-content-center my-2" style="color: red;">
                <asp:Label ID="TxtErrorMembresia" runat="server" Text=""></asp:Label>
            </div>
            
            <asp:GridView ID="GridUsuarios" runat="server"  AutoGenerateColumns="false"
                AllowPaging="true" PageSize="5" OnPageIndexChanging="GridUsuarios_PageIndexChanging"
                CssClass="table table-hover table-responsive table-striped">
                <Columns>
                    <asp:BoundField DataField="id_persona" HeaderText="ID" />
                    <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="dni" HeaderText="DNI"/>  
                    <asp:BoundField DataField="telefono" HeaderText="Teléfono"/>  
                    <%--<asp:BoundField DataField="sexo" HeaderText="Genero"/>--%>
                    <asp:BoundField DataField="membresia" HeaderText="Tipo Membresia"/>
                    <asp:TemplateField HeaderText="">
                         <ItemTemplate>
                             <asp:LinkButton ID="BtnEditar" CssClass="bg-specify-color-update-trash" runat="server" Text="<i class='fas fa-edit ps-2 '>  </i>"
                                 OnClick="BtnEditar_Click" CommandArgument='<%# Eval("id_persona") %>'/>
                             <asp:LinkButton ID="BtnEliminar" CssClass="bg-specify-color-update-trash" runat="server" Text="<i class='fas fa-trash ps-2'>  </i>"
                                 OnClick="BtnEliminar_Click" CommandArgument='<%# Eval("id_persona") %>'
                                 OnClientClick="return confirm('¿Esta seguro de eliminar este registro?');" />
                         </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>

            
            <%--<div class='alert alert-success go-to-top p-2' role='alert'>El usuario hola ha sido ingresado correctamente</div>--%>
            
        </div>
    
      </div>
    <asp:Literal ID="AlertaMensajeNuevoUsuario" runat="server" Visible="false"></asp:Literal>

    <div id="modalForm" class="modal" tabindex="-1">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <asp:Label ID="TxtUsuarioBuscar" runat="server" Text="" CssClass="text-lg-start"></asp:Label>
                </div>
                <div class="modal-body">
                    <asp:Label ID="TxtUsuarioBusquedaBody" runat="server" Text="" CssClass="text-lg-start"></asp:Label>
                    <asp:GridView ID="GridViewUsuarioBuscar" runat="server"  AutoGenerateColumns="false"
                        AllowPaging="true" PageSize="5" OnPageIndexChanging="GridUsuarios_PageIndexChanging"
                        CssClass="table table-hover table-responsive table-striped">
                        <Columns>
                            <asp:BoundField DataField="id_persona" HeaderText="ID" />
                            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="dni" HeaderText="DNI"/>  
                            <asp:BoundField DataField="telefono" HeaderText="Teléfono"/>  
                            <%--<asp:BoundField DataField="sexo" HeaderText="Genero"/>--%>
                            <asp:BoundField DataField="membresia" HeaderText="Tipo Membresia"/>
                            <asp:TemplateField HeaderText="">
                                 <ItemTemplate>
                                     <asp:LinkButton ID="BtnEditar" CssClass="bg-specify-color-update-trash" runat="server" Text="<i class='fas fa-edit ps-2'>  </i>"
                                         OnClick="BtnEditar_Click" CommandArgument='<%# Eval("id_persona") %>'/>
                                     <asp:LinkButton ID="BtnEliminar" CssClass="bg-specify-color-update-trash" runat="server" Text="<i class='fas fa-trash ps-2'>  </i>"
                                         OnClick="BtnEliminar_Click" CommandArgument='<%# Eval("id_persona") %>'
                                         OnClientClick="return confirm('¿Esta seguro de eliminar este registro?');" />
                                 </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
               
            </div>
        </div>
    </div>

    <div id="modalFormError" class="modal" tabindex="-1">
        <div class="modal-dialog">
            <div class="modal-content">
<%--                <div class="modal-header">
                    <asp:Label ID="TxtErrorBusqueda" runat="server" Text="" CssClass="text-lg-start"></asp:Label>
                </div>--%>
                <div class="modal-body">
                    <div class="container p-2">
                        <div class="row">
                          <div class="col-12">
                            <div class="text-center alert-danger">
                              <h4 class="d-flex justify-content-center align-items-center gap-2 mb-2">
                                <i class="bi bi-exclamation-circle-fill text-danger display-4 px-2"></i>
                                <asp:Label ID="TxtErrorBusqueda" runat="server" Text="" CssClass="text-lg-start"></asp:Label>
                                
                              </h4>
                              <asp:Label CssClass="display-1 fw-bold" ID="TxtMensajeErrorBody" runat="server" Text=""></asp:Label>
                            </div>
                          </div>
                        </div>
                      </div>
                </div>
           
            </div>
        </div>
    </div>
</asp:Content>
