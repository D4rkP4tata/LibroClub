<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Chart.aspx.cs" Inherits="LibroClubWeb.Views.Chart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server">
    <link rel="stylesheet" href="https://unpkg.com/bootstrap@5.3.3/dist/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://unpkg.com/bs-brain@2.0.4/components/charts/chart-1/assets/css/chart-1.css">
    <script src="https://cdn.jsdelivr.net/npm/apexcharts"></script>
    <script src="https://unpkg.com/bs-brain@2.0.4/components/charts/chart-1/assets/controller/chart-1.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Body" runat="server">
    <!-- Chart 1 - Bootstrap Brain Component -->
    <section class="">
      <div class="container">
            <div class="row justify-content-center">
                <div class="col-12 col-lg-9 col-xl-8">
                    <div class="card widget-card border-light shadow-sm">
                        <div class="card-body p-4">
                            <div class="d-block d-sm-flex align-items-center justify-content-between mb-3">
                                <div class="mb-3 mb-sm-0">
                                    <h5 class="card-title widget-card-title">Personal Overview</h5>
                                </div>
                                <div>
                                    <asp:DropDownList ID="ddlChart" runat="server" CssClass="form-select text-secondary border-light-subtle" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Text="Ventas" Value="Ventas"></asp:ListItem>
                                        <asp:ListItem Text="Prestamos" Value="Prestamos"></asp:ListItem>
                                    </asp:DropDownList>
                                
                                </div>
                            </div>
                            <div id="chart" class="p-5"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
