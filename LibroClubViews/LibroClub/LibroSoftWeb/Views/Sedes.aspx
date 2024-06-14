<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Sedes.aspx.cs" Inherits="LibroClubWeb.Views.Sedes" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Listado de areas
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server">
    <script src="/Scripts/Sedes.js?version=2" type="text/javascript"></script>    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Body" runat="server">
    <nav style="--bs-breadcrumb-divider: '>'; font-size: 14px">
        <ol class="breadcrumb">
            <li class="breadcrumb-item">
                <i class="fa-solid fa-house"></i>
            </li>
            <li class="breadcrumb-item">Area</li>
            <li class="breadcrumb-item">Listado</li>
        </ol>
    </nav>

    <div class="container">
        <h2>Listado de Sedes</h2>

        <div class="container row">
            <div class="text-end p-3">
                <asp:Button ID="BtnNuevo" runat="server" Text="Agregar" OnClick="BtnNuevo_Click" CssClass="btn btn-success" />
            </div>
        </div>               
        
        <div class="container row">
            <asp:GridView ID="GridSedes" runat="server" AutoGenerateColumns="false"
                CssClass="table table-bordered table-condensed table-responsive-sm table-hover table-striped">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText ="ID"/>
                    <asp:BoundField DataField="Direccion" HeaderText ="Direccion"/>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="editRow" runat="server" Text="Editar" CssClass="btn btn-warning"
                                        CommandArgument='<%# Eval("Id") %>' OnClick="EditRow_Click" />
                            <asp:Button ID="delRow" runat="server" Text="Eliminar" CssClass="btn btn-danger"
                                        CommandArgument='<%# Eval("Id") %>' OnClick="DelRow_Click"
                                        OnClientClick="return confirm('¿Está seguro que desea eliminar?');"/>                            
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="200px" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <div id="modalForm" class="modal" tabindex="-1">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Area</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="container p-3 ">
                        <div class="col-md-12  mb-3">
                            <asp:Label ID="LblId" runat="server" Text="Id:" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="TxtId" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="col-md-12 mb-3">
                            <asp:Label ID="LblDireccion" runat="server" Text="Direccion" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="TxtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                    <asp:Button ID="ButGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" 
                        OnClick="ButGuardar_Click" OnClientClick="return validarFormulario();" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
