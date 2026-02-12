<%@ Page Title="Job Listings" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Jobs.aspx.cs" Inherits="RCTemp.Jobs" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="max-width:1200px;margin-top:24px;">
        <div class="d-flex justify-content-between align-items-center mb-3">
            <h2>Job Listings</h2>
            <a class="btn btn-primary" href="JobEdit.aspx">Post New Job</a>
        </div>

        <!-- Search Panel -->
        <div class="card mb-4">
            <div class="card-body">
                <h5 class="card-title">Search Jobs</h5>
                <div class="row g-3">
                    <div class="col-md-3">
                        <label for="MainContent_txtTitle" class="form-label">Job Title</label>
                        <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" Placeholder="e.g. Software Engineer" />
                    </div>
                    <div class="col-md-3">
                        <label for="MainContent_txtLocation" class="form-label">Location</label>
                        <asp:TextBox ID="txtLocation" runat="server" CssClass="form-control" Placeholder="e.g. New York" />
                    </div>
                    <div class="col-md-3">
                        <label for="MainContent_txtType" class="form-label">Employment Type</label>
                        <asp:TextBox ID="txtType" runat="server" CssClass="form-control" Placeholder="e.g. Full-time" />
                    </div>
                    <div class="col-md-2">
                        <label for="MainContent_ddlPageSize" class="form-label">Results Per Page</label>
                        <asp:DropDownList ID="ddlPageSize" runat="server" CssClass="form-select">
                            <asp:ListItem Value="10" Selected="True">10</asp:ListItem>
                            <asp:ListItem Value="25">25</asp:ListItem>
                            <asp:ListItem Value="50">50</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-1 d-flex align-items-end">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-success w-100" OnClick="btnSearch_Click" />
                    </div>
                </div>
                <div class="row mt-2">
                    <div class="col-12">
                        <asp:Button ID="btnClear" runat="server" Text="Clear Filters" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnClear_Click" />
                    </div>
                </div>
            </div>
        </div>

        <!-- Results Grid -->
        <asp:GridView ID="grdJobs" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-hover"
            OnRowCommand="grdJobs_RowCommand" DataKeyNames="JobId">
            <Columns>
                <asp:BoundField DataField="JobId" HeaderText="ID" ItemStyle-Width="60px" />
                <asp:TemplateField HeaderText="Job Title">
                    <ItemTemplate>
                        <a href='JobDetails.aspx?id=<%# Eval("JobId") %>' class="text-decoration-none">
                            <strong><%# Eval("Title") %></strong>
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Location" HeaderText="Location" ItemStyle-Width="150px" />
                <asp:BoundField DataField="EmploymentType" HeaderText="Type" ItemStyle-Width="120px" />
                <asp:TemplateField HeaderText="Posted Date" ItemStyle-Width="120px">
                    <ItemTemplate>
                        <%# ((DateTime)Eval("PostedDate")).ToString("MM/dd/yyyy") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Actions" ItemStyle-Width="150px">
                    <ItemTemplate>
                        <a href='JobEdit.aspx?id=<%# Eval("JobId") %>' class="btn btn-sm btn-outline-primary">Edit</a>
                        <asp:LinkButton runat="server" CommandName="DeleteJob" CommandArgument='<%# Eval("JobId") %>' 
                            CssClass="btn btn-sm btn-outline-danger" 
                            OnClientClick="return confirm('Are you sure you want to delete this job?');">
                            Delete
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <div class="alert alert-info text-center">
                    No jobs found matching your search criteria. Try adjusting your filters.
                </div>
            </EmptyDataTemplate>
        </asp:GridView>

        <!-- Pagination and Results Info -->
        <div class="d-flex justify-content-between align-items-center mt-3">
            <asp:Label ID="lblResults" runat="server" CssClass="mb-0 text-muted" />
            <ul id="pager" runat="server" class="pagination mb-0"></ul>
        </div>
    </div>
</asp:Content>