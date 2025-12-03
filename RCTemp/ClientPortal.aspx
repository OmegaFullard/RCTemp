<%@ Page Title="Client Portal - Job Search" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClientPortal.aspx.cs" Inherits="RCTemp.ClientPortal" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="max-width:1000px;margin-top:24px;">
        <div class="d-flex justify-content-between align-items-center mb-3">
            <h2>Client Portal - Job Search</h2>
            <a class="btn btn-secondary" href="Jobs.aspx">Employer View</a>
        </div>

        <!-- Use a non-server container here because the master page already provides a server-side form -->
        <div class="mb-3">
            <div class="row g-2">
                <div class="col-md-4">
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" Placeholder="Job title or keywords" />
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="txtLocation" runat="server" CssClass="form-control" Placeholder="Location" />
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="txtType" runat="server" CssClass="form-control" Placeholder="Employment type" />
                </div>
                <div class="col-md-2 d-flex gap-2">
                    <asp:DropDownList ID="ddlPageSize" runat="server" CssClass="form-select">
                        <asp:ListItem Value="5">5</asp:ListItem>
                        <asp:ListItem Value="10" Selected="True">10</asp:ListItem>
                        <asp:ListItem Value="15">15</asp:ListItem>
                        <asp:ListItem Value="25">25</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                </div>
            </div>
        </div>

        <div class="mb-2">
            <asp:Label ID="lblResults" runat="server" />
        </div>

        <asp:GridView ID="grdClientJobs" runat="server" AutoGenerateColumns="False" CssClass="table table-hover"
            EmptyDataText="No jobs match your search." AllowPaging="True" DataKeyNames="JobId">
            
            <Columns>
                <asp:BoundField DataField="JobId" HeaderText="ID" ItemStyle-Width="60px" />
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Location" HeaderText="Location" />
                <asp:BoundField DataField="EmploymentType" HeaderText="Type" />
                <asp:BoundField DataField="PostedDate" HeaderText="Posted" DataFormatString="{0:yyyy-MM-dd}" ItemStyle-Width="120px" />
                <asp:TemplateField HeaderText="Actions" ItemStyle-Width="220px">
                    <ItemTemplate>
                        <a class="btn btn-sm btn-outline-success" href='JobDetails.aspx?id=<%# Eval("JobId") %>'>View</a>
                        &nbsp;
                        <a class="btn btn-sm btn-primary" href='Apply.aspx?id=<%# Eval("JobId") %>'>Apply</a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        
        <nav aria-label="Client job pages" class="mt-3">
            <ul runat="server" id="pagerClient" class="pagination"></ul>
        </nav>
    </div>
</asp:Content>