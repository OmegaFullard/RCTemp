<%@ Page Title="Job Listings" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Jobs.aspx.cs" Inherits="RCTemp.Jobs" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="max-width:1000px;margin-top:24px;">
        <div class="d-flex justify-content-between align-items-center mb-3">
            <h2>Job Listings</h2>
            <a class="btn btn-primary" href="JobEdit.aspx">Post New Job</a>
        </div>

        

        <asp:GridView ID="grdJobs" runat="server" AutoGenerateColumns="False" CssClass="table table-striped"
            OnRowCommand="grdJobs_RowCommand" AllowPaging="True" AllowSorting="True" DataKeyNames="JobId" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="JobId" HeaderText="JobId" InsertVisible="False" ReadOnly="True" SortExpression="JobId" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description"></asp:BoundField>
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location" />
                <asp:BoundField DataField="EmploymentType" HeaderText="EmploymentType" SortExpression="EmploymentType" />
                <asp:BoundField DataField="PostedDate" HeaderText="PostedDate" SortExpression="PostedDate"></asp:BoundField>
                <asp:CheckBoxField DataField="IsActive" HeaderText="IsActive" SortExpression="IsActive"></asp:CheckBoxField>

          
        <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" href='JobEdit.aspx?id=<%# Eval("JobId") %>' class="btn btn-sm btn-outline-primary">Edit</asp:LinkButton>
                        &nbsp;
                        <asp:LinkButton runat="server" CommandName="DeleteJob" CommandArgument='<%# Eval("JobId") %>' CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Delete this job?');">Delete</asp:LinkButton>
    </ItemTemplate>
                </asp:TemplateField>
                        </Columns>
</asp:GridView>


        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:RCTempConnection %>' SelectCommand="SELECT * FROM [Jobs]"></asp:SqlDataSource>
        <div class="d-flex justify-content-between align-items-center mt-2">
            <asp:Label ID="lblResults" runat="server" CssClass="mb-0" />
            <ul id="pager" runat="server" class="pagination mb-0"></ul>
        </div>
    </div>
</asp:Content>