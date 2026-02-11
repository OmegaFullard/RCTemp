<%@ Page Title="Login" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.cs" Inherits="RCTemp.Login" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


   <div class="container" style="max-width:420px;margin-top:40px;">
      

        <h3>Sign in</h3>

        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="text-danger mb-2" />

        <asp:HiddenField ID="hfReturnUrl" runat="server" />

        <div class="mb-2">
            <asp:TextBox ID="txtUser" runat="server" CssClass="form-control" Placeholder="Username" />
            <asp:RequiredFieldValidator ID="rfvUser" runat="server" ControlToValidate="txtUser"
                ErrorMessage="Username is required." CssClass="text-danger" Display="Dynamic" />
        </div>

        <div class="mb-2">
            <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" CssClass="form-control" Placeholder="Password" />
            <asp:RequiredFieldValidator ID="rfvPwd" runat="server" ControlToValidate="txtPwd"
                ErrorMessage="Password is required." CssClass="text-danger" Display="Dynamic" />
        </div>

        <div class="d-flex gap-2 mb-3">
            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary" CausesValidation="false" OnClick="btnCancel_Click" />
        </div>

        <asp:Label ID="lblError" runat="server" CssClass="text-danger" />

        <p class="mt-3">
            <asp:HyperLink runat="server" ID="RegisterHyperLink" NavigateUrl="~/Register.aspx">Register</asp:HyperLink>
            <br />
            <br />
            If you don't have a local account.
        </p>
    </div>
</asp:Content>