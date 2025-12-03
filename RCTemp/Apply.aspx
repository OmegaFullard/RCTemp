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

            <asp:GridView ID="grdSearchResults" runat="server" AutoGenerateColumns="False" CssClass="table table-striped mt-3" OnRowCommand="grdSearchResults_RowCommand" DataKeyNames="JobId" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="JobId" HeaderText="JobId" InsertVisible="False" ReadOnly="True" SortExpression="JobId" />
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title"></asp:BoundField>
                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description"></asp:BoundField>
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                    <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location" />
                    <asp:BoundField DataField="EmploymentType" HeaderText="EmploymentType" SortExpression="EmploymentType" />
                    <asp:BoundField DataField="PostedDate" HeaderText="PostedDate" SortExpression="PostedDate"></asp:BoundField>

                </Columns>
            </asp:GridView>
            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:RCTempConnection %>' SelectCommand="SELECT * FROM [Jobs]"></asp:SqlDataSource>
        </asp:Panel>
 <div class="mb-3">
            <label class="form-label">Full name</label>
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="Name required" CssClass="text-danger" Display="Dynamic" />
        </div>

        <div class="mb-3">
            <label class="form-label">Email</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email required" CssClass="text-danger" Display="Dynamic" />
            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" CssClass="text-danger" Display="Dynamic"
                ValidationExpression="^\S+@\S+\.\S+$" ErrorMessage="Invalid email" />
        </div>

        <div class="mb-3">
            <label class="form-label">Phone (optional)</label>
            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" />
        </div>

        <div class="mb-3">
            <label class="form-label">Cover letter (optional)</label>
            <asp:TextBox ID="txtCover" runat="server" TextMode="MultiLine" Rows="6" CssClass="form-control" />
        </div>

        <div class="mb-3">
            <label class="form-label">Upload resume (PDF, DOC, DOCX) � max 4 MB</label>
            <asp:FileUpload ID="fuResume" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="rfvResume" runat="server" ControlToValidate="fuResume" InitialValue="" ErrorMessage="Resume is required" CssClass="text-danger" Display="Dynamic" />
            <asp:Label ID="lblUploadError" runat="server" CssClass="text-danger" />
        </div>

        <div class="d-flex gap-2">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit Application" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
            <a class="btn btn-secondary" href="Jobs.aspx">Back to jobs</a>
        </div>

        <asp:Label ID="lblResult" runat="server" CssClass="text-success" />
    </div>
</asp:Content>