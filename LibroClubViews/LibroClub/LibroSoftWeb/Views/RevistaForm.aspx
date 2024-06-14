<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RevistaForm.aspx.cs" Inherits="LibroClubWeb.Views.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Registrar Revista
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="Body" runat="server">
    <nav style="--bs-breadcrumb-divider: '>'; font-size: 14px">
        <ol class="breadcrumb">
            <li class="breadcrumb-item">
                <i class="fa-solid fa-house"></i>
            </li>
            <li class="breadcrumb-item">Alumnos</li>
            <li class="breadcrumb-item">Registrar</li>
        </ol>
    </nav>

    <div class="container">
        <div class="card">
            <div class="card-header">
                <h2>Registrar Revista</h2>
            </div>
            <div class="card-body">
                <div class="mb-3 row">
                    <label for="TxtId" class="col-sm-2 col-form-label">Id Producto</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="TxtId" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="mb-3 row">
                    <label for="TxtTitulo" class="col-sm-2 col-form-label">Titulo</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="TxtTitulo" runat="server" CssClass="form-control"  required="true"></asp:TextBox>
                    </div>
                </div>
                <div class="mb-3 row">
                    <label for="TxtPrecio" class="col-sm-2 col-form-label">Precio</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="TxtPrecio" runat="server" CssClass="form-control"  required="true"></asp:TextBox>
                    </div>
                </div>
                <div class="mb-3 row">
                    <label for="TxtEditor" class="col-sm-2 col-form-label">Editor</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="TxtEditor" runat="server" CssClass="form-control"  required="true"></asp:TextBox>
                    </div>
                </div>
                <div class="mb-3 row">
                    <label for="TxtISSN" class="col-sm-2 col-form-label">ISSN</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="TxtISSN" runat="server" CssClass="form-control"  required="true"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="card-footer clearfix">
                <asp:Button ID="BtnRegresar" runat="server" Text="Regresar" UseSubmitBehavior="false"
                    CssClass="float-start btn btn-secondary" OnClick="BtnRegresar_Click" />
                <asp:Button ID="BtnGuardar" runat="server" Text="Guardar"
                    CssClass="float-end btn btn-primary" OnClick="BtnGuardar_Click"/>
            </div>
        </div>
    </div>


</asp:Content>
