<%@ Page Title="Skills Tests" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SkillsTests.aspx.cs" Inherits="RCTemp.SkillsTests" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="max-width:900px;margin:24px auto;">
        <h2>Candidate Skills Tests</h2>
        <p>Download a printable PDF with example skills tests for screening candidates.</p>

        <div class="mb-3">
            <asp:Button ID="btnDownload" runat="server" CssClass="btn btn-primary" Text="Download Skills Tests PDF" onclick="btnDownload_Click" />
        </div>
          <!-- Status label for showing generation/download errors or messages -->
  <div class="mb-2">
      <asp:Label ID="lblStatus" runat="server" CssClass="text-danger" />
  </div>
        <h4>Included tests</h4>
        <ul>
            <li>Math aptitude (word problems)</li>
            <li>Coding problem (algorithmic exercise)</li>
            <li>Excel / data task</li>
            <li>Customer service scenario (behavioral)</li>
        </ul>

    </div>
</asp:Content>