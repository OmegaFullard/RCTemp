<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Employee_Find.aspx.cs" Inherits="RCTemp.Employee_Find" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/Controls_Search/ctrSearch_Employee.ascx" TagPrefix="uc1" TagName="ctrSearch_Employee" %>
<%@ Register Src="~/Controls_Find/ctrEmployee_Find.ascx" TagPrefix="uc1" TagName="ctrEmployee_Find" %>

           <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent" >
              <div aria-dropeffect="move" style="padding-left:5px; padding-right:10px; height:500px;overflow: auto; background:rgba(236, 236, 236, 1);">    
                       <div class="HeadingB" >Employee Details</div>
                            <asp:Table ID="Table1" runat="server" ForeColor="#cfcfcf" >        
                                     <asp:TableRow>
                                          <asp:TableCell> <asp:Panel ID="Panel1" runat="server" BackColor="#2176d2"   Height="90px" HorizontalAlign="Center"  Width="180px">
                                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/defaultuser.png"  BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" Height="80px" style="margin-top: 5px" Width="160px" />
                                                       </asp:Panel> 
                                         </asp:TableCell>
                                          <asp:TableCell>&nbsp;&nbsp;&nbsp</asp:TableCell>
                                        <asp:TableCell VerticalAlign="Top"><uc1:ctrSearch_Employee runat="server" id="ctrSearch_Employee" /></asp:TableCell>
                                    </asp:TableRow>
                         </asp:Table>
                          <div class="clear hideSkiplink">
                                      <asp:Menu ID="NavigationMenu" runat="server" CssClass="sub_menu" EnableViewState="false" IncludeStyleBlock="false" Orientation="Horizontal">
                                          <Items>
                                              <asp:MenuItem Text="Find" NavigateUrl="Employee_Find.aspx"></asp:MenuItem> 
                                                   <asp:MenuItem  Text="Add"  NavigateUrl="Employee_Add.aspx"></asp:MenuItem>
                                                  <asp:MenuItem Text="Update" NavigateUrl="Employee_Update.aspx"></asp:MenuItem> 
                                              
                                          </Items>
                                       </asp:Menu>
                             </div>
               <uc1:ctrEmployee_Find runat="server" id="ctrEmployee_Find" />
             </div>
              </asp:Content> 