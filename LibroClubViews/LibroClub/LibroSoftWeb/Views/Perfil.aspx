<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="LibroClubWeb.Views.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Perfil
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Body" runat="server">
    <%--<nav style="--bs-breadcrumb-divider: '>'; font-size: 14px">
        <ol class="breadcrumb">
            <li class="breadcrumb-item">
                <i class="fa-solid fa-house"></i>
            </li>
            <li class="breadcrumb-item">Personal</li>
            <li class="breadcrumb-item">Registrar</li>
        </ol>
    </nav>--%>

    <div class="container">
        <div class="card">
            <div class="card-header">
                <h2>Perfil</h2>
            </div>
            <div class="card-body">

                <div class="mb-3 row">
                    <asp:Label ID="TextRol" runat="server" Text="" CssClass="col-sm-2 col-form-label">Rol</asp:Label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="TxtRol" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="mb-3 row">
                    <label for="TxtId" class="col-sm-2 col-form-label">Id Usuario</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="TxtId" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="mb-3 row">
                    <label for="TxtNombre" class="col-sm-2 col-form-label">Nombre</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="TxtNombre" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                </div>
                <div class="mb-3 row">
                    <div class="col">
                        <label for="TxtDni" class="col-form-label">DNI</label>
                    </div>
                    <div class="col-sm-10">
                        <asp:TextBox ID="TxtDni" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>

                </div>

                <%if (mostrarPersonal)
                    { %>
                    <div class="mb-3 row">
                        <div class="col">
                            <label for="TextCantEjemVendidos" class=" col-form-label">Ejemplares Vendidos</label>

                        </div>
                        <div  class="col-sm-10">
                            <asp:TextBox ID="TxtCantEjemVendidos" type="number" runat="server" CssClass="form-control" required="true" Enabled="false"></asp:TextBox>
                        </div>
                    </div>

                    <div class="mb-3 row">
                        <div class="col">
                            <label for="TextCantEjemPrestados" class=" col-form-label">Ejemplares Prestados</label>

                        </div>
                        <div  class="col-sm-10">
                            <asp:TextBox ID="TxtCantEjemPrestados" type="number" runat="server" CssClass="form-control" required="true" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                <%} %>

                <%if (mostrarGerente) 
                    { %>
                    <div class="mb-3 row">
                        <div class="col">
                            <label for="TextInicioCargo" class=" col-form-label">Inicio del Cargo</label>

                        </div>
                        <div  class="col-sm-10">
                            <asp:TextBox ID="TxtInicioCargo" type="date" runat="server" CssClass="form-control" required="true" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                <%} %>

                <div class="mb-3 row">
                    <label for="TextFechaNacimiento" class="col-sm-2 col-form-label">Fecha Nacimiento(dd/mm/aa)</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="TxtFechaNacimiento" runat="server" type="date" CssClass="form-control"  Enabled="false"></asp:TextBox>
                    </div>
                </div>
                <div class="mb-3 row">
                    <label for="RadioButtonListGenero" class="col-sm-2 col-form-label">Genero</label>
                    <div class="col-sm-10">
                        <asp:RadioButtonList ID="RadioButtonListGenero" runat="server">
                            <asp:ListItem Text="Masculino" Value="M" Enabled="false"></asp:ListItem>
                            <asp:ListItem Text="Femenino" Value="F" Enabled="false"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="mb-3 row">
                    <div class="col">
                        <label for="TextTelefono" class=" col-form-label">Telefono</label>
                
                    </div>
                    <div class="col-sm-10">
                        <asp:TextBox ID="TxtTelefono" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                </div>

                <div class="mb-3 row">
                    <div class="col">
                        <label for="TextSede" class=" col-form-label">Sede</label>
                    </div>
                    <div class="col-sm-10">
                        <asp:TextBox ID="TxtSede" runat="server" CssClass="form-control" Enabled="false" ></asp:TextBox>
                    </div>
                
                </div>

                <div class="mb-3 row">
                    <div class="col">
                        <label for="TextEstado" class=" col-form-label">Estado</label>
                    </div>
                    <div class="col-sm-10">
                        <asp:DropDownList Enabled="false" ID="ddlEstado" runat="server" CssClass="dropdown-item-text my-2 rounded" Width="210" Height="40" Style="border: 2px solid #dee2e6;">
                            <asp:ListItem Text="Activo" Value="Activo" ></asp:ListItem>
                            <asp:ListItem Text="Vacaciones" Value="Vacaciones"></asp:ListItem>
                            <asp:ListItem Text="DescansoMedico" Value="DescansoMedico"></asp:ListItem>
                            <asp:ListItem Text="LicenciaMaternidadPaternidad" Value="LicenciaMaternidadPaternidad"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="mb-3 row">
                    <div class="col">
                        <label for="TextUsername" class=" col-form-label">Username</label>
                    </div>
                    <div class="col-sm-10">
                        <asp:TextBox ID="TxtUsername" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                </div>

                <div class="mb-3 row">
                    <div class="col">
                        <label for="TextPassword" class=" col-form-label">Password</label>
                    </div>
                    <div  class="col-sm-10">
                        <asp:TextBox ID="TxtPassword" type="password" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                </div>

                <div class="mb-3 row">
                    <div class="col">
                        <label for="TxtFechaInicioContrato" class=" col-form-label">Inicio del Contrato</label>
                    </div>
                    <div class="col-sm-10">
                        <asp:TextBox ID="TxtFechaInicioContrato" Enabled="false" type="date" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="mb-3 row">
                    <div class="col">
                        <label for="TextFechaFinContrato" class=" col-form-label">Fin del Contrato</label>
                    </div>
                    <div class="col-sm-10">
                        <asp:TextBox ID="TxtFechaFinContrato" Enabled="false" type="date" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="card-footer clearfix">
                    <asp:Button ID="BtnRegresar" runat="server" Text="Regresar" UseSubmitBehavior="false"
                        CssClass="float-start btn btn-secondary" OnClick="BtnRegresar_Click"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
