<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrEmployee_Delete.ascx.cs" Inherits="RCTemp.Controls_Delete.ctrEmployee_Delete" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

 <script>
     function OnClientLoad0(sender, args) {

         $telerik.$(".k-input")[0].setAttribute("readonly", "true");
     }
     function OnClientLoad1(sender, args) {

         $telerik.$(".k-input")[1].setAttribute("readonly", "true");
     }
     function OnClientLoad2(sender, args) {

         $telerik.$(".k-input")[2].setAttribute("readonly", "true");
     }
     function OnClientLoad3(sender, args) {

         $telerik.$(".k-input")[3].setAttribute("readonly", "true");
     }
     function OnClientLoad4(sender, args) {

         $telerik.$(".k-input")[4].setAttribute("readonly", "true");
     }

 </script>
               
<div style="padding-left:5px; padding-top:5px; padding-bottom:5px">
<div class="Heading" >Add Employee</div>
<span class="required"><asp:Label ID="lblResult" runat="server" Text=""></asp:Label></span>
    <asp:Table ID="Table1" runat="server" ForeColor="#6082b6" Width="1100px" >
<asp:TableRow>
<asp:TableCell>Employee ID<span class="required">*</span>:</asp:TableCell>
  <asp:TableCell > 
                                                  <telerik:RadTextBox ID="txtempid" runat="server" Width="200px" Height="25px" Enabled="True" AutoPostBack="false" ></telerik:RadTextBox>

                                                   <asp:RequiredFieldValidator  ID="valRequiredFieldempid" runat="server" ControlToValidate="txtempid" ValidationGroup="Submit"
                                                      ErrorMessage  ="Please enter ID!"><span class="required">!</span></asp:RequiredFieldValidator>

                                                      <ajaxtoolkit:ValidatorCalloutExtender ID="Requere_Name"  TargetControlID="valRequiredFieldempid"  Width="250px"  
                                                               HighlightCssClass="highlight" runat="server">
                                                       </ajaxtoolkit:ValidatorCalloutExtender>
                                          </asp:TableCell>
                                     <asp:TableCell>&nbsp;&nbsp;</asp:TableCell> <asp:TableCell>&nbsp;&nbsp;</asp:TableCell> 
                                    <asp:TableCell>&nbsp;&nbsp;</asp:TableCell> <asp:TableCell>&nbsp;&nbsp;</asp:TableCell>
                             </asp:TableRow>
                              <asp:TableRow>
                                         <asp:TableCell>&nbsp;&nbsp;</asp:TableCell><asp:TableCell>&nbsp;&nbsp;</asp:TableCell><asp:TableCell>&nbsp;&nbsp;</asp:TableCell><asp:TableCell>&nbsp;&nbsp;</asp:TableCell>
                                          <asp:TableCell>&nbsp;&nbsp;</asp:TableCell> <asp:TableCell>&nbsp;&nbsp;</asp:TableCell>
                              </asp:TableRow>
                             <asp:TableRow>
                                          <asp:TableCell>First Name<span class="required">*</span>:</asp:TableCell>
                                          <asp:TableCell>
                                                   <telerik:RadTextBox ID="txtFN" runat="server" Width="200px" Height="25px" Enabled="True" AutoPostBack="False" ></telerik:RadTextBox>

                                                   <asp:RequiredFieldValidator  ID="valRequiredFN" runat="server" ControlToValidate="txtFN" ValidationGroup="Submit"
                                                      ErrorMessage  ="Please enter First Name!"><span class="required">!</span></asp:RequiredFieldValidator>

                                                      <ajaxtoolkit:ValidatorCalloutExtender ID="Requere_FN"  TargetControlID="valRequiredFN"  Width="250px"  
                                                               HighlightCssClass="highlight" runat="server">
                                                       </ajaxtoolkit:ValidatorCalloutExtender>
                                          </asp:TableCell>
                                          <asp:TableCell>Last Name<span class="required">*</span>:</asp:TableCell>
                                          <asp:TableCell>
                                                   <telerik:RadTextBox ID="txtLN" runat="server" Width="200px" Height="25px" Enabled="True" AutoPostBack="False"></telerik:RadTextBox>

                                                   <asp:RequiredFieldValidator  ID="valRequiredFieldLN" runat="server" ControlToValidate="txtLN" ValidationGroup="Submit"
                                                      ErrorMessage  ="Please enter Last Name!"><span class="required">!</span></asp:RequiredFieldValidator>

                                                      <ajaxtoolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender1"  TargetControlID="valRequiredLN"  Width="250px"  
                                                               HighlightCssClass="highlight" runat="server">
                                                       </ajaxtoolkit:ValidatorCalloutExtender>

                                          </asp:TableCell>
                              </asp:TableRow>
                             

                                   <asp:TableRow  > 
                                                     <asp:TableCell HorizontalAlign="Right">&nbsp;&nbsp;</asp:TableCell>
                                                     <asp:TableCell HorizontalAlign="Left">&nbsp;&nbsp;</asp:TableCell>
                                             </asp:TableRow> 
                                   <asp:TableRow  > 
                                                     <asp:TableCell HorizontalAlign="Right">&nbsp;&nbsp;</asp:TableCell>
                                                     <asp:TableCell HorizontalAlign="Left">&nbsp;&nbsp;</asp:TableCell>
                                             </asp:TableRow> 

                                             <asp:TableRow>                     
                                                    <asp:TableCell HorizontalAlign="Right" Font-Bold="true">Phone:</asp:TableCell>
                                                    <asp:TableCell HorizontalAlign="Left">
                                                       &nbsp;&nbsp; <telerik:RadTextBox ID="txtphone" runat="server" Height="20px" Width="300px" MaxLength="127" ReadOnly="False" Enabled="True" AutoPostBack="False"></telerik:RadTextBox>
                                                    </asp:TableCell>
                                             </asp:TableRow>
                                              <asp:TableRow  > 
                                                     <asp:TableCell HorizontalAlign="Right">&nbsp;&nbsp;</asp:TableCell>
                                                     <asp:TableCell HorizontalAlign="Left">&nbsp;&nbsp;</asp:TableCell>
                                             </asp:TableRow> 
                                             <asp:TableRow> 
                                                    <asp:TableCell HorizontalAlign="Right" Font-Bold="true">Email:</asp:TableCell>
                                                    <asp:TableCell HorizontalAlign="Left">
                                                        &nbsp;&nbsp;<telerik:RadTextBox ID="txtemail" runat="server" Height="20px" Width="300px" MaxLength="127" ReadOnly="False" Enabled="True" AutoPostBack="False"></telerik:RadTextBox>     
                                                    </asp:TableCell>
                                                </asp:TableRow> 
                                   <asp:TableRow  > <telerik:RadTextBox Runat="server"></telerik:RadTextBox>
                                                     <asp:TableCell HorizontalAlign="Right">&nbsp;&nbsp;</asp:TableCell>
                                                     <asp:TableCell HorizontalAlign="Left">&nbsp;&nbsp;</asp:TableCell>
                                             </asp:TableRow> 
											 
                                                                <asp:TableRow> 
                                                    <asp:TableCell HorizontalAlign="Right" Font-Bold="true">Available:</asp:TableCell>
                                                    <asp:TableCell HorizontalAlign="Left">
                                                        &nbsp;&nbsp;<telerik:RadTextBox ID="txtavailable" runat="server" Height="20px" Width="300px" MaxLength="127" ReadOnly="True" Enabled="True" AutoPostBack="False"></telerik:RadTextBox>     
                                                    </asp:TableCell>
                                                </asp:TableRow> 

			
                                                 

                       <asp:TableRow  > 
                                                     <asp:TableCell HorizontalAlign="Right">&nbsp;&nbsp;</asp:TableCell>
                                                     <asp:TableCell HorizontalAlign="Left">&nbsp;&nbsp;</asp:TableCell>
                                          </asp:TableRow> 

                                     </asp:Table>        
                  </div>
                 <div style="padding-left:700px;padding-bottom:10px;"  ><asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="150" Height="25px"  />&nbsp;&nbsp;
                <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="150" Height="25px" ValidationGroup="Submit" /></div>

 
 

 