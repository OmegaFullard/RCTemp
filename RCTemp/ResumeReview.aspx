<%@ Page Title="Resume Review Upload" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResumeReview.aspx.cs" Inherits="RCTemp.ResumeReview" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="max-width:700px;margin:24px auto;">
        <h2>Request Resume Review</h2>
        <p>Upload your resume for a free review. We will email you feedback within 2 business days.</p>

        <asp:ValidationSummary ID="vs" runat="server" CssClass="text-danger" />

        <asp:HiddenField ID="hfJobId" runat="server" />

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
            <label class="form-label">Related job (optional)</label>
            <asp:DropDownList ID="ddlJob" runat="server" CssClass="form-select">
                <asp:ListItem Value="">-- Not applying to a specific job --</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="mb-3">
            <label class="form-label">Upload resume (PDF, DOC, DOCX) — max 4 MB</label>
            <asp:FileUpload ID="fuResume" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="rfvResume" runat="server" ControlToValidate="fuResume" InitialValue="" ErrorMessage="Resume required" CssClass="text-danger" Display="Dynamic" />
            <asp:Label ID="lblUploadError" runat="server" CssClass="text-danger" />
        </div>

        <div class="d-flex gap-2">
            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Submit for Review" OnClick="btnSubmit_Click" />
            <a class="btn btn-secondary" href="ClientResources.aspx">Back</a>
        </div>

        <asp:Label ID="lblResult" runat="server" CssClass="text-success" />
    </div>
</asp:Content>