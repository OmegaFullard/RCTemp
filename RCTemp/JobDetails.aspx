<%@ Page Title="Job Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="JobDetails.aspx.cs" Inherits="RCTemp.JobDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="max-width:800px;margin-top:24px;">
        <asp:Panel ID="pnlJob" runat="server" CssClass="card p-3 mb-3" Visible="false">
            <h2 class="mb-2">
                <asp:Label ID="lblTitle" runat="server" CssClass="h4"></asp:Label>
            </h2>

            <div class="text-muted mb-2">
                <asp:Label ID="lblLocation" runat="server" CssClass="me-2"></asp:Label>
                <asp:Label ID="lblType" runat="server" CssClass="me-2"></asp:Label>
                <span class="float-end">
                    <asp:Label ID="lblPosted" runat="server"></asp:Label>
                </span>
            </div>

            <hr />

            <asp:Label ID="litDescription" runat="server" CssClass="d-block"></asp:Label>

            <div class="mt-3">
                <a id="lnkApply" runat="server" class="btn btn-primary">Apply</a>
                <a class="btn btn-secondary" href="Jobs.aspx">Back to jobs</a>
            </div>
        </asp:Panel>

        <!-- Server controls referenced by code-behind (kept hidden for display-only page) -->
        <asp:TextBox ID="txtTitle" runat="server" CssClass="d-none" />
        <asp:TextBox ID="txtLocation" runat="server" CssClass="d-none" />
        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="3" CssClass="d-none" />
        <asp:TextBox ID="txtType" runat="server" CssClass="d-none" />
    </div>
</asp:Content>