<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrSearch_Employee_Update.ascx.cs" Inherits="RCTemp.Controls_Search.ctrSearch_Employee_Update" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

                       <asp:Table ID="Table1" runat="server" ForeColor="#6082b6" >
                             <asp:TableRow>
                                     
                                         <asp:TableCell VerticalAlign="Top">
                                                 
                                             <telerik:RadMultiColumnComboBox ID="cmbEmployee" runat="server" AutoPostBack="True" ClearButton="false" ClientEvents-OnLoad="OnClientLoad0" DropDownStyle="DropDownList"
                                                 Placeholder="--Select" EnableViewState="true">
                                              <ColumnsCollection> 
                                                   <telerik:MultiColumnComboBoxColumn Field="EmpID" Title="ID" Width="150px" />
                                                        <telerik:MultiColumnComboBoxColumn Field="LN" Title="Last Name" Width="75px" />
                                                  </ColumnsCollection>
                                             </telerik:RadMultiColumnComboBox>&nbsp;&nbsp;&nbsp
                                        </asp:TableCell>
                              </asp:TableRow>
                           
                               
                 </asp:Table>