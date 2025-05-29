<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Employee_Add.aspx.cs" Inherits="RCTemp.Employee_Add" %>
<%@ Register Src="Controls_Search/ctrSearch_Employee.ascx" TagPrefix="uc1" TagName="ctrSearch_Employee" %>
<%@ Register Src="Controls_Add/ctrEmployee_Add.ascx" TagPrefix="uc1" TagName="ctrEmployee_Add" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
       
              <div aria-dropeffect="move" style="padding-left:10px; padding-right:10px; height:850px;overflow: auto; background:#cfcfcf">    
                     <div class="HeadingB" >Add Employee </div><br />

                       <asp:Table ID="Table1" runat="server" ForeColor="#6082b6" Height="113px" Width="179px" >

 <asp:TableRow>
                                          <asp:TableCell> <asp:Panel ID="Panel1" runat="server" BackColor="#2176d2"   Height="90px" HorizontalAlign="Center"  Width="180px">
                                           <asp:Image ID="employee" runat="server" ImageUrl="images/Employee2.png"  BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" Height="80px" style="margin-top: 5px" Width="160px" />
                                                       </asp:Panel> 
                                         </asp:TableCell>
                                           <asp:TableCell>&nbsp;&nbsp;&nbsp</asp:TableCell>
                                        <asp:TableCell VerticalAlign="Top"><uc1:ctrSearch_Employee runat="server" id="ctrSearch_Employee" Visible="false" /></asp:TableCell>
                                                 
                                    </asp:TableRow>
                         </asp:Table>
                  <br />

                   <div class="clear hideSkiplink">
                                          <asp:Menu ID="NavigationMenu" runat="server" CssClass="sub_menu" EnableViewState="false" IncludeStyleBlock="false" Orientation="Horizontal">
                                              <Items>
                                                  <asp:MenuItem Text="Find" NavigateUrl="Employee_Find.aspx"></asp:MenuItem> 
                                                   <asp:MenuItem  Text="Add"  NavigateUrl="Employee_Add"></asp:MenuItem>
                                                  <asp:MenuItem Text="Update" NavigateUrl="Employee_Update.aspx"></asp:MenuItem> 
                                               
                                              </Items>
                                           </asp:Menu>
                                 </div>
<uc1:ctrEmployee_Add runat="server" id="ctrEmployee_Add" />

                     </div>                  
    </asp:Content>
