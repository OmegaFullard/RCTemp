<%@ Page Title="Job Listings" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Jobs.aspx.cs" Inherits="RCTemp.Jobs" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="max-width:1200px;margin-top:24px;">
        <div class="d-flex justify-content-between align-items-center mb-3">
            <h2>Job Listings</h2>
            <a class="btn btn-primary" href="JobEdit.aspx">Post New Job</a>
        </div>

<asp:TextBox ID="txtTitle" runat="server" Placeholder="Title" Width="300px" />
<asp:TextBox ID="txtLocation" runat="server" Placeholder="Location" Width="300px" />
<asp:TextBox ID="txtType" runat="server" Placeholder="Type" Width="300px" />
<asp:DropDownList ID="ddlPageSize" runat="server">
    <asp:ListItem>10</asp:ListItem>
    <asp:ListItem>25</asp:ListItem>
    <asp:ListItem>50</asp:ListItem>
  </asp:DropDownList>

        <asp:GridView ID="grdJobs" runat="server" AutoGenerateColumns="False" CssClass="table table-striped"
            OnRowCommand="grdJobs_RowCommand" AllowPaging="True" AllowSorting="True" DataKeyNames="JobId">
            <Columns>
                <asp:BoundField DataField="JobId" HeaderText="JobId" InsertVisible="False" ReadOnly="True" SortExpression="JobId" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location" />

                <asp:BoundField DataField="EmploymentType" HeaderText="EmploymentType" SortExpression="EmploymentType" />
                <asp:BoundField DataField="PostedDate" HeaderText="PostedDate" SortExpression="PostedDate"></asp:BoundField>
               

          
        <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" href='JobEdit.aspx?id=<%# Eval("JobId") %>' class="btn btn-sm btn-outline-primary">Edit</asp:LinkButton>
                        &nbsp;
                        <asp:LinkButton runat="server" CommandName="DeleteJob" CommandArgument='<%# Eval("JobId") %>' CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Delete this job?');">Delete</asp:LinkButton>
    </ItemTemplate>
                </asp:TemplateField>
                        </Columns>
</asp:GridView>


        <div class="d-flex justify-content-between align-items-center mt-2">
            <asp:Label ID="lblResults" runat="server" CssClass="mb-0" />
            <ul id="pager" runat="server" class="pagination mb-0"></ul>
        </div>
    </div>
</asp:Content>