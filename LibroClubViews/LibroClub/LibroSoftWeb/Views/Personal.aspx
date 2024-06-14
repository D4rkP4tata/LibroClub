    <%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Personal.aspx.cs" Inherits="LibroClubWeb.Views.Personal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Listado de Personal
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server">
    <script src="/Scripts/Usuarios.js?version=2" type="text/javascript"></script>
    <style>
        .go-to-top{
          position: fixed;
          bottom: 10px;
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
        .bg-specify-color-update-trash:hover{
            color: #3731e5 !important
        }
        .bg-specify-color-search:hover {
            background-color: #223390 !important; 

            color: #ffffff; 
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
        <li class="breadcrumb-item">Personal</li>
        <li class="breadcrumb-item">Listado</li>
    </ol>
</nav>

<div class="container">    
    <h2> Listado del Personal </h2>

    <div class="container card-body my-xl-5"> 
        <div class="row align-items-center pb-3">
            <div class="mb-2">
                <asp:Label ID="lblDniPersonal" CssClass="form-label" runat="server" Text="DNI:"></asp:Label>
            </div>
            <div class="col-auto">
                <asp:TextBox ID="TxtDniPersonal" CssClass="form-control" runat="server" Enabled="true" Width="210"></asp:TextBox>
            </div>
            <div class="col-sm-4">
                 <asp:LinkButton ID="BuscarDni" runat="server" OnClick="BuscarDni_Click" CssClass="btn col text-white bg-specify-color-search" Text="<i class='fa-solid fa-magnifying-glass'></i>" />
            </div>
            <div class="text-end col" style="font-weight:bold;">
              <asp:LinkButton ID="BtnAgregar" runat="server" Text="<i class='fas fa-plus pe-2'> </i> Agregar" 
              OnClick="BtnAgregar_Click" CssClass="text-decoration-none text-white bg-specify-color-add rounded-1" />
            </div>
        </div>

        <div CssClass="alert-warning p-2 align-content-center my-2" style="color: red;">
            <asp:Label ID="TxtErrorMembresia" runat="server" Text=""></asp:Label>
        </div>
        
        <asp:GridView ID="GridPersonales" runat="server"  AutoGenerateColumns="false"
            AllowPaging="true" PageSize="5" 
            OnPageIndexChanging="GridPersonales_PageIndexChanging"
            CssClass="table table-hover table-responsive table-striped">
            <Columns>
                <asp:BoundField DataField="id_persona" HeaderText="ID" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="dni" HeaderText="DNI"/>                   
                <asp:BoundField DataField="telefono" HeaderText="Telefono"/>
                <asp:BoundField DataField="nombreSede" HeaderText="Sede"/>
                <asp:TemplateField HeaderText="">
                     <ItemTemplate>
                         <asp:LinkButton ID="BtnEditar" runat="server" Text="<i class='fas fa-edit ps-2'>  </i>"
                             OnClick="BtnEditar_Click" CssClass="bg-specify-color-update-trash" CommandArgument='<%# Eval("id_persona") %>'/>
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
    <asp:Literal ID="AlertaMensajeNuevoPersonal" runat="server" Visible="false"></asp:Literal>

      <div id="modalForm" class="modal" tabindex="-1">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <asp:Label ID="TxtPersonalBuscar" runat="server" Text="" CssClass="text-lg-start"></asp:Label>
                </div>
                <div class="modal-body">
                    <asp:Label ID="TxtPersonalBusquedaBody" runat="server" Text="" CssClass="text-lg-start"></asp:Label>
                    <asp:GridView ID="GridViewPersonalBuscar" runat="server"  AutoGenerateColumns="false"
                        AllowPaging="true" PageSize="5" OnPageIndexChanging="GridPersonales_PageIndexChanging"
                        CssClass="table table-hover table-responsive table-striped">
                        <Columns>
                            <asp:BoundField DataField="id_persona" HeaderText="ID" />
                            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="dni" HeaderText="DNI"/>  
                            <asp:BoundField DataField="telefono" HeaderText="Teléfono"/>  
                            <%--<asp:BoundField DataField="sexo" HeaderText="Genero"/>--%>
                            <asp:BoundField DataField="nombreSede" HeaderText="Sede"/>
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
