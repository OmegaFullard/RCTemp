<%@ Page Title="Admin - Resume Reviews" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminReviews.aspx.cs" Inherits="RCTemp.AdminReviews" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="max-width:1000px;margin-top:24px;">
        <h2>Resume Reviews (Admin)</h2>

        <asp:Panel runat="server" CssClass="mb-3">
            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                <asp:ListItem Value="">All</asp:ListItem>
                <asp:ListItem Value="Pending">Pending</asp:ListItem>
                <asp:ListItem Value="Reviewed">Reviewed</asp:ListItem>
                <asp:ListItem Value="Rejected">Rejected</asp:ListItem>
            </asp:DropDownList>
        </asp:Panel>

        <asp:GridView ID="grdReviews" runat="server" AutoGenerateColumns="False" CssClass="table table-striped"
            OnRowCommand="grdReviews_RowCommand" EmptyDataText="No submissions." DataKeyNames="ReviewId" AllowSorting="True" AllowPaging="True">
            <Columns>
                <asp:BoundField DataField="ReviewId" HeaderText="ReviewId" ItemStyle-Width="60px" InsertVisible="False" ReadOnly="True" SortExpression="ReviewId" />
                <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                <asp:BoundField DataField="ApplicantName" HeaderText="ApplicantName" SortExpression="ApplicantName"></asp:BoundField>
                <asp:BoundField DataField="ApplicantName" HeaderText="ApplicantName" SortExpression="ApplicantName" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
                <asp:BoundField DataField="JobId" HeaderText="JobId" SortExpression="JobId" />
                <asp:BoundField DataField="FilePath" HeaderText="FilePath" SortExpression="FilePath" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status"></asp:BoundField>
                <asp:BoundField DataField="ReviewerComments" HeaderText="ReviewerComments" SortExpression="ReviewerComments"></asp:BoundField>

            </Columns>
        </asp:GridView>

        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="Data Source=OIT-L-BY10S73\SQLEXPRESS2019;Initial Catalog=RCTemp;Integrated Security=True;Trust Server Certificate=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [ResumeReviews]"></asp:SqlDataSource>
        <asp:Label ID="lblMsg" runat="server" CssClass="text-danger"></asp:Label>
    </div>
</asp:Content>