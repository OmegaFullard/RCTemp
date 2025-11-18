<%@ Page Title="Login" Language="C#" AutoEventWireup="true"  CodeBehind="Login.aspx.cs" Inherits="RCTemp.Login" %>
<!DOCTYPE html>
 <div>
           <nav class="navbar navbar-light" style="background-color:#a0d9ef">
               <ul class="nav navbar-nav">
                   <li><a runat="server" href="~/Default">Home</a></li>
                   <li><a runat="server" href="~/Services">Services</a></li>
                   <li><a runat="server" href="~/Contact">Contact</a></li>
<li><a runat="server" href="~/About">About</a></li>
<li><a runat="server" href="~/Support">Support</a></li>


               </ul>

               <br />
               <br />

           </nav>
    </div>
<html>

<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server" class="container" style="max-width:420px;margin-top:40px;">
        <h3>Sign in</h3>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="text-danger" />
        <div class="mb-2">
            <asp:TextBox ID="txtUser" runat="server" CssClass="form-control" Placeholder="Username" />
        </div>
        <div class="mb-2">
            <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" runat="server" CssClass="form-control" Placeholder="Password" />
        </div>
        <div class="d-flex gap-2">
            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
            <a class="btn btn-secondary" href="Default.aspx">Cancel</a>
        </div>
        <asp:Label ID="lblError" runat="server" CssClass="text-danger" />
    </form>

    &nbsp;&nbsp; <p>
              <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled" NavigateUrl="~/Register.aspx">Register</asp:HyperLink>
     <br />         
     If you don't have a local account.
          </p>
<br />
<br />

</body>
</html>