<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Site.Master" CodeBehind="Employee.aspx.cs" Inherits="RCTemp.Employee" %>
<%@ Register Src="ctrEmployee.ascx" TagPrefix="uc1" TagName="ctrEmployee" %>
<%@ Register Src="Controls_Search/ctrSearch_Employee.ascx" TagPrefix="uc1" TagName="ctrSearch_Employee" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent" >
    <div class="HeadingB">Employee</div>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
    
                      <asp:Table ID="Table1" runat="server" ForeColor="#6082b6" Height="113px" Width="179px" >

<asp:TableRow>
                                         <asp:TableCell> <asp:Panel ID="Panel1" runat="server" BackColor="#2176d2"   Height="90px" HorizontalAlign="Center"  Width="180px">
                                          <asp:Image ID="employee" runat="server" ImageUrl="images/defaultuser.png"  BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" Height="80px" style="margin-top: 5px" Width="160px" />
                                                      </asp:Panel> 
                                        </asp:TableCell>
                                          <asp:TableCell>&nbsp;&nbsp;&nbsp</asp:TableCell>
                                       <asp:TableCell VerticalAlign="Top"><uc1:ctrSearch_Employee runat="server" id="ctrSearch_Employee" Visible="false" /></asp:TableCell>
                                                 
                                   </asp:TableRow>
                        </asp:Table>
                 <br />               
              <uc1:ctrEmployee runat="server" id="ctrEmployee" />
            <br />
    <div>
            <a href="Default.aspx"><< Back to Home</a><br />
        </div>
  
</asp:Content>