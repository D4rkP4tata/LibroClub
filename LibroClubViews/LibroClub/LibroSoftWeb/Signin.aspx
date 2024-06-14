<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signin.aspx.cs" Inherits="LibroClubWeb.Signin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="/Public/css/bootstrap.css" rel="stylesheet" />
<script src="/Public/js/bootstrap.js" type="text/javascript"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
                <!-- Login 13 - Bootstrap Brain Component -->
<section class="bg-light py-3 py-md-5">
  <div class="container">
    <div class="row justify-content-center">
      <div class="col-12 col-sm-10 col-md-8 col-lg-6 col-xl-5 col-xxl-4">
        <div class="card border border-light-subtle rounded-3 shadow-sm">
          <div class="card-body p-3 p-md-4 p-xl-5">
            <div class="text-center mb-3">
              <a href="#!">
                <img src="/Public/images/LibroClub_logo.png" alt="BootstrapBrain Logo" width="175" height="57">
              </a>
            </div>
            <h2 class="fs-6 fw-normal text-center text-secondary mb-4">Sign in to your account</h2>
              
            <form action="#!">
              <div class="row gy-2 overflow-hidden">

                <div class="col-12">
                    <asp:Label ID="TxtNewUserOK" CssClass="alert-success" runat="server" Text="NewUser" style="color: forestgreen;"></asp:Label>
                    <asp:Label ID="TxtNewUserERROR" CssClass="alert-warning" runat="server" Text="NewUser" style="color: red;"></asp:Label>
                  <div class="form-floating mb-3">
                      <asp:TextBox ID="TxtUsername" runat="server" type="text" CssClass="form-control" required></asp:TextBox>
                    <label for="text" class="form-label">Username</label>
                  </div>
                    <%--<asp:Button ID="BtnUsername" runat="server" Text="Verificar" OnClick="BtnUsername_Click" />--%>
                </div>

                   <asp:Label ID="TxtConfirmPass" runat="server" Text="TxtConfirmPass" CssClass="alert-warning" style="color: red;"></asp:Label>
                <div class="col-12">
                  <div class="form-floating mb-3">
                    <asp:TextBox ID="TxtPassword" runat="server" type="password" CssClass="form-control" required></asp:TextBox>
                    <label for="password" class="form-label">Password</label>
                  </div>
                </div>
                 
                  <div class="col-12">
                      <div class="form-floating mb-3">
                        <asp:TextBox ID="TxtConfirmPassword" runat="server" type="password" CssClass="form-control" required></asp:TextBox>
                        <label for="password" class="form-label">Confirm Password</label>
                      </div>
                    </div>

                <div class="col-12">
                  <div class="d-grid my-3">
                      <asp:Button ID="BtnSignIn" runat="server" type="submit" OnClick="BtnSignIn_Click" Text="Sign in" 
                          CssClass="btn btn-primary btn-lg"/>
                  </div>
                </div>
                <div class="col-12 text-center">
                  <p class="m-0 text-secondary text-center">I have an account</p>
                    <asp:LinkButton ID="LinkLogIn" runat="server" OnClick="LinkLogIn_Click">Log in</asp:LinkButton>
                </div>
              </div>
            </form>
          </div>
        </div>
      </div>
    </div>
  </div>
</section>
    </form>
</body>
</html>
