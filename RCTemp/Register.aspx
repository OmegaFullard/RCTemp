<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="RCTemp.Register" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="max-width:480px;margin:40px auto;">
        <h3>Create an account</h3>

        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="text-danger" />

        <div class="mb-3">
            <asp:Label ID="lblUsername" runat="server" AssociatedControlID="txtUsername" Text="Username (email recommended)" />
            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername" ErrorMessage="Username required" CssClass="text-danger" Display="Dynamic" />
            <asp:RegularExpressionValidator ID="revUsername" runat="server" ControlToValidate="txtUsername" CssClass="text-danger" Display="Dynamic"
                ValidationExpression="^\S+@\S+\.\S+$" ErrorMessage="Enter a valid email address" />
        </div>

        <div class="mb-3">
            <asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword" Text="Password" />
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password required" CssClass="text-danger" Display="Dynamic" />
            <asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="txtPassword" CssClass="text-danger" Display="Dynamic"
                ValidationExpression="^.{6,}$" ErrorMessage="Password must be at least 6 characters" />
        </div>

        <div class="mb-3">
            <asp:Label ID="lblConfirm" runat="server" AssociatedControlID="txtConfirm" Text="Confirm password" />
            <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="rfvConfirm" runat="server" ControlToValidate="txtConfirm" ErrorMessage="Confirm password" CssClass="text-danger" Display="Dynamic" />
            <asp:CompareValidator ID="cmpPasswords" runat="server" ControlToValidate="txtConfirm" ControlToCompare="txtPassword" ErrorMessage="Passwords do not match" CssClass="text-danger" Display="Dynamic" />
        </div>

        <div class="d-flex gap-2">
            <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn btn-primary" OnClick="btnRegister_Click" />
            <a class="btn btn-secondary" href="Login.aspx">Already have an account?</a>
        </div>

        <div style="margin-top:12px;">
            <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" />
        </div>
    </div>
</asp:Content>