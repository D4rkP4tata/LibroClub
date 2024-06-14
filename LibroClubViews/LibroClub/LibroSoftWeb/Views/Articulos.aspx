<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Articulos.aspx.cs" Inherits="LibroClubWeb.Views.Articulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Listado de Articulos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Body" runat="server">
    <nav style="--bs-breadcrumb-divider: '>'; font-size: 14px">
        <ol class="breadcrumb">
            <li class="breadcrumb-item">
                <i class="fa-solid fa-house"></i>
            </li>
            <li class="breadcrumb-item">Articulos</li>
            <li class="breadcrumb-item">Listado</li>
        </ol>
    </nav>

    <div class="container">
        <h2> Listado de Articulos </h2>
        <div class="container row">  
            <div class="text-end p-3">  
                <asp:LinkButton ID="BtnAgregarRev" runat="server" Text="<i class='fas fa-plus pe-2'> </i> Agregar" 
                    OnClick="BtnAgregarRev_Click" CssClass="btn btn-success" />
            </div>
        </div>

        <div class="container row">   
            <asp:GridView ID="GridRevistas" runat="server"  AutoGenerateColumns="false"
                AllowPaging="true" PageSize="5" OnPageIndexChanging="GridRevistas_PageIndexChanging"
                CssClass="table table-hover table-responsive table-striped">
                <Columns>
                    <asp:BoundField DataField="ID_Producto" HeaderText="ID_Producto" />
                    <asp:BoundField DataField="Titulo" HeaderText="Titulo" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio"/>                   
                    <asp:BoundField DataField="Editor" HeaderText="Editor"/>
                    <asp:BoundField DataField="ISSN" HeaderText="ISSN"/>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton ID="BtnEliminarRev" runat="server" Text="<i class='fas fa-trash ps-2'>  </i>"
                                OnClick="BtnEliminarRev_Click" CommandArgument='<%# Eval("ID_Producto") %>'
                                OnClientClick="return confirm('¿Esta seguro de eliminar este registro?');" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
