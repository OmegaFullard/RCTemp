<%@ Page Title="Job Listings" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Jobs.aspx.cs" Inherits="RCTemp.Jobs" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="max-width:1000px;margin-top:24px;">
        <div class="d-flex justify-content-between align-items-center mb-3">
            <h2>Job Listings</h2>
            <a class="btn btn-primary" href="JobEdit.aspx">Search Job</a>
        </div>

        <!-- Search / filter controls -->
        <div class="card mb-3 p-3">
            <div class="form-row">
                <div class="form-group col-md-3">
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" Placeholder="Title" />
                </div>
                <div class="form-group col-md-3">
                    <asp:TextBox ID="txtLocation" runat="server" CssClass="form-control" Placeholder="Location" />
                </div>
                <div class="form-group col-md-2">
                    <asp:TextBox ID="txtType" runat="server" CssClass="form-control" Placeholder="Type" />
                </div>
                <div class="form-group col-md-2">
                    <asp:DropDownList ID="ddlPageSize" runat="server" CssClass="form-control">
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <asp:ListItem Value="25">25</asp:ListItem>
                        <asp:ListItem Value="50">50</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group col-md-2 d-flex align-items-end">
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" Text="Search" OnClick="btnSearch_Click" />
                </div>
            </div>
        </div>

        <asp:GridView ID="grdJobs" runat="server" AutoGenerateColumns="False" CssClass="table table-striped"
            OnRowCommand="grdJobs_RowCommand" AllowPaging="True" AllowSorting="True">
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
                        
                        <asp:LinkButton runat="server" CommandName="ApplyJob" CommandArgument='<%# Eval("JobId") %>' CssClass="btn btn-sm btn-outline-primary" OnClientClick="return confirm('Appy to this job?');">Apply</asp:LinkButton>
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