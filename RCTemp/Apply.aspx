<%@ Page Title="Apply" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Apply.aspx.cs" Inherits="RCTemp.Apply" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="max-width:800px;margin-top:24px;">
        <h2>Apply for Job</h2>

        <asp:Panel ID="pnlSearch" runat="server" CssClass="card p-3 mb-3">
            <div class="form-row">
                <div class="form-group col-md-4">
                    <asp:TextBox ID="txtSearchTitle" runat="server" CssClass="form-control" Placeholder="Title" />
                </div>
                <div class="form-group col-md-4">
                    <asp:TextBox ID="txtSearchLocation" runat="server" CssClass="form-control" Placeholder="Location" />
                </div>
                <div class="form-group col-md-2">
                    <asp:Button ID="btnSearchJobs" runat="server" CssClass="btn btn-primary" Text="Search Jobs" OnClick="btnSearchJobs_Click" />
                </div>
            </div>

            <asp:GridView ID="grdSearchResults" runat="server" AutoGenerateColumns="False" CssClass="table table-striped mt-3" OnRowCommand="grdSearchResults_RowCommand">
                <Columns>
                    <asp:BoundField DataField="JobId" HeaderText="ID" />
                    <asp:BoundField DataField="Title" HeaderText="Title" />
                    <asp:BoundField DataField="Location" HeaderText="Location" />
                    <asp:BoundField DataField="EmploymentType" HeaderText="Type" />
                    <asp:BoundField DataField="PostedDate" HeaderText="Posted" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" CommandName="SelectJob" CommandArgument='<%# Eval("JobId") %>' CssClass="btn btn-sm btn-outline-primary">Apply</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:Panel>

        <asp:Panel ID="pnlApply" runat="server" CssClass="card p-3" Visible="false">
            <asp:HiddenField ID="hfJobId" runat="server" />
            <div class="form-group">
                <asp:Label ID="lblJobTitle" runat="server" CssClass="font-weight-bold" />
            </div>
            <div class="form-group">
                <asp:Label ID="lblUploadError" runat="server" CssClass="text-danger" />
            </div>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control" Placeholder="Full name" />
                </div>
                <div class="form-group col-md-6">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="Email" />
                </div>
            </div>
            <div class="form-group">
                <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" Placeholder="Phone" />
            </div>
            <div class="form-group">
                <asp:TextBox ID="txtCover" runat="server" CssClass="form-control" Placeholder="Cover letter" TextMode="MultiLine" Rows="6" />
            </div>
            <div class="form-group">
                <asp:FileUpload ID="fuResume" runat="server" CssClass="form-control-file" />
            </div>
            <div class="form-group">
                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Submit Application" OnClick="btnSubmit_Click" />
                &nbsp; <asp:Label ID="lblResult" runat="server" CssClass="text-success" />
            </div>
        </asp:Panel>
    </div>
</asp:Content>