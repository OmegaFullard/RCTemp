<%@ Page Title="Post / Edit Job" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="JobEdit.aspx.cs" Inherits="RCTemp.JobEdit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="max-width:800px;margin-top:24px;">
        <h2 id="heading">Post / Edit Job</h2>

        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="text-danger" />

        <asp:HiddenField ID="hfJobId" runat="server" />
        <div class="mb-3">
            <label class="form-label">Title</label>
            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle" ErrorMessage="Title required" CssClass="text-danger" Display="Dynamic" />
        </div>

        <div class="mb-3">
            <label class="form-label">Location</label>
            <asp:TextBox ID="txtLocation" runat="server" CssClass="form-control" />
        </div>

        <div class="mb-3">
            <label class="form-label">Employment Type</label>
            <asp:TextBox ID="txtType" runat="server" CssClass="form-control" Placeholder="e.g., Full-time, Part-time, Contract" />
        </div>

        <div class="mb-3">
            <label class="form-label">Description</label>
            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="8" CssClass="form-control" />
        </div>

        <div class="mb-3 form-check">
            <asp:CheckBox ID="chkActive" runat="server" CssClass="form-check-input" />
            <label class="form-check-label" for="<%= chkActive.ClientID %>">Active</label>
        </div>

        <div class="d-flex gap-2">
            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click" />
            <a class="btn btn-secondary" href="Jobs.aspx">Cancel</a>
        </div>
    </div>
</asp:Content>