<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrEmployee.ascx.cs" Inherits="RCTemp.ctrEmployee" %>

<div style="width: 1200px; height:500px;  overflow: auto; padding-left:5px" >
           <div class="Heading" >Employee</div>&nbsp;&nbsp;&nbsp 
           <div><asp:HiddenField ID="ctrHiddebField" runat="server" /></div><br />
<div style="width: 1200px; height:500px;  overflow: auto; padding-left:5px" >
   
           <div style="padding-bottom:10px; font-weight:400"> <asp:Label ID="lblSearchResult" runat="server" Text=""></asp:Label></div>
    <asp:GridView ID="grdEmployee" runat="server"
        AutoGenerateColumns="False"
        ShowFooter="True"
        EmptyDataText="There are no records matching this search criteria."
        BackColor="#6082b6" ForeColor="#cfcfcf" CssClass="grdRecords"
        HeaderStyle-CssClass="grdHeader"
        Width="1200px" AllowPaging="True" AllowSorting="True" PageSize="15" OnPageIndexChanging="grdEmployee_PageIndexChanging" OnSorting="grdEmployee_Sorting" OnLoad="Page_Load">
        <PagerSettings Mode="NumericFirstLast" Position="Bottom" />
        <Columns>
            <asp:BoundField DataField="EmpID" HeaderText="Employee ID" HtmlEncode="False" ItemStyle-Width="100"
                ReadOnly="True" Visible="True" SortExpression="EmpID" />
            <asp:BoundField DataField="FN" HeaderText="First Name" HtmlEncode="False" ItemStyle-Width="100"
                ReadOnly="True" Visible="True" />
            <asp:BoundField DataField="LN" HeaderText="Last Name" HtmlEncode="False" ItemStyle-Width="100"
                ReadOnly="True" Visible="True" />
            <asp:BoundField DataField="Phone" HeaderText="Phone" HtmlEncode="False" ItemStyle-Width="100"
                ReadOnly="True" Visible="True" />
            <asp:BoundField DataField="Email" HeaderText="Email" HtmlEncode="False" ItemStyle-Width="100"
                ReadOnly="True" Visible="True" />
            <asp:BoundField DataField="Available" HeaderText="Available" HtmlEncode="False" ItemStyle-Width="100"
                ReadOnly="True" Visible="True" />
            
        </Columns>


        <FooterStyle BackColor="#CCCCCC" ForeColor="black" />
        <HeaderStyle HorizontalAlign="Left" ForeColor="#303030" />
        <AlternatingRowStyle CssClass="grdAlternatingRow"></AlternatingRowStyle>
    </asp:GridView>

</div>
    </div>