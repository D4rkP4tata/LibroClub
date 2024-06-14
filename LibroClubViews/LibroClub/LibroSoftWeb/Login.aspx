<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LibroClubWeb.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="height:100%">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="/Public/css/bootstrap.css" rel="stylesheet" />
    <script src="/Public/js/bootstrap.js" type="text/javascript"></script>
    <title></title>
    <style>
        .background-image {
            background-image: url('/Public/images/biblioteca2.jpg'); /* Ruta de tu imagen */
            background-size: cover;
            background-position: center;
            background-repeat: no-repeat;
            height: 100%;
            width: 100%;
            position: absolute;
            top: 0;
            left: 0;
        }
        .btn-hover:hover {
          background-color: #ad7f46;
           /* Cambia este color según tus necesidades */
        }
    </style>
</head>
<body style="height:100%">
    <form id="form1" runat="server" style="height:100%">
        <!-- Login 13 - Bootstrap Brain Component -->

  <div class="background-image container-fluid justify-content-center align-content-center flex" style="height:100%">
    <div class="row justify-content-center">
      <div class="col-12 col-sm-10 col-md-8 col-lg-6 col-xl-5 col-xxl-4 ">
        <div class="card rounded-3 " style="background: rgba(0, 0, 0, 0.8);">
          <div class="card-body p-3 p-md-4 p-xl-5">
            <div class="text-center mb-3">
              <a href="#!">
                <img src="/Public/images/logoBiblio4_transparente.png" alt="BootstrapBrain Logo" width="350" height="200">
              </a>
            </div>
            <h2 class="fs-6 fw-normal text-center text-secondary mb-4">Log in to your account</h2>
              <div CssClass="alert-warning p-2 align-content-center " style="color: red;">
                <asp:Label ID="TxtError" runat="server" Text="TxtError" ></asp:Label>
                  
            </div>
            <form action="#!">
              <div class="row gy-2 overflow-hidden">

                <div class="col-12">
                  <div class="form-floating mb-3">
                    <%--<input type="email" class="form-control" name="email" id="email" placeholder="name@example.com" required>--%>
                      <asp:TextBox ID="TxtUsername" runat="server" type="text" CssClass="form-control" required></asp:TextBox>
                    <label for="text" class="form-label" style="color:#333">Username</label>
                  </div>
                </div>

                <div class="col-12">
                  <div class="form-floating mb-3">
                    <asp:TextBox ID="TxtPassword" runat="server" type="password" CssClass="form-control" required></asp:TextBox>
                    <label for="password" class="form-label" style="color:#333">Password</label>
                  </div>
                </div>

                <%--<div class="col-12">
                  <div class="d-flex gap-2 justify-content-between">
                    <div class="form-check">
                      <input class="form-check-input" type="checkbox" value="" name="rememberMe" id="rememberMe">
                      <label class="form-check-label text-secondary" for="rememberMe">
                        Keep me logged in
                      </label>
                    </div>
                    <a href="#!" class="link-primary text-decoration-none">Forgot password?</a>
                  </div>
                </div>--%>
                <div class="col-12">
                  <div class="d-grid my-3 rounded-3 text-white" style="background-color:#b07a37;">
                      <asp:Button ID="BtnLogin" runat="server" type="submit" OnClick="BtnLogin_Click" Text="Log in" 
                          CssClass="btn btn-lg text-black rounded-3 btn-hover"/>
                  </div>
                </div>
                <%--<div class="flex text-center">
                    <p class="m-0 text-secondary text-center">Don't have an account? </p>
                    <asp:LinkButton ID="LinkSignIn"  runat="server" OnClick="LinkSignIn_Click">Sign in</asp:LinkButton>
                </div>--%>
              </div>
            </form>
          </div>
        </div>
      </div>
    </div>
  </div>

    </form>
</body>
</html>
