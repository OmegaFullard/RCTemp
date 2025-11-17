<%@ Page Title="Job Listings" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Jobs.aspx.cs" Inherits="RCTemp.Jobs" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="max-width:1000px;margin-top:24px;">
        <div class="d-flex justify-content-between align-items-center mb-3">
            <h2>Job Listings</h2>
            <a class="btn btn-primary" href="JobEdit.aspx">Post New Job</a>
        </div>

        <asp:GridView ID="grdJobs" runat="server" AutoGenerateColumns="False" CssClass="table table-striped"
            OnRowCommand="grdJobs_RowCommand" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True">
            <Columns>
                <asp:BoundField DataField="JobId" HeaderText="ID" />
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Location" HeaderText="Location" />
                <asp:BoundField DataField="EmploymentType" HeaderText="Type" />
                <asp:BoundField DataField="PostedDate" HeaderText="Posted" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:TemplateField HeaderText="Active">
                    <ItemTemplate>
                        <%# ((bool)Eval("IsActive")) ? "Yes" : "No" %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <a runat="server" href='JobEdit.aspx?id=<%# Eval("JobId") %>' class="btn btn-sm btn-outline-primary">Edit</a>
                        &nbsp;
                        <asp:LinkButton runat="server" CommandName="DeleteJob" CommandArgument='<%# Eval("JobId") %>' CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Delete this job?');">Delete</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="Data Source=OIT-L-BY10S73\SQLEXPRESS2019;Initial Catalog=RCTemp;Integrated Security=True;Trust Server Certificate=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [Jobs]"></asp:SqlDataSource>
    </div>
</asp:Content>