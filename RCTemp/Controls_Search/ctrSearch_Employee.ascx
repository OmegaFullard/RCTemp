<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrSearch_Employee.ascx.cs" Inherits="RCTemp.Controls_Search.ctrEmployee_Search" %>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                       
                       <asp:Table ID="Table1" runat="server" ForeColor="#6082b6" >
                             <asp:TableRow>
                                          <asp:TableCell>Employee ID:&nbsp;&nbsp;</asp:TableCell>
                                          <asp:TableCell>
                                              <asp:TextBox ID="txtempid" runat="server" Width="180" AutoPostBack="True"></asp:TextBox>
                                          </asp:TableCell>
                              </asp:TableRow>
                             <asp:TableRow>
                                          <asp:TableCell>&nbsp;</asp:TableCell>
                                         <asp:TableCell VerticalAlign="Top">
                                               <asp:Button ID="btnSearch" runat="server" Text="Search" Width="180"  />
                                        </asp:TableCell>
                              </asp:TableRow>
                         </asp:Table>
