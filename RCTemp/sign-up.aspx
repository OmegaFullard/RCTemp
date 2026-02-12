<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sign-up.aspx.cs" MasterPageFile="~/Site.Master" Inherits="RCTemp.sign_up" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


   <div class="container" style="max-width:420px;margin-top:40px;">

    <h2>Sign Up</h2>

  
 <div class="mb-2">
    <p class="lead">Please Enter Details</p>
    <br />
    
    <div class="col-md-6" style="padding-left:20px;">
        <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control" placeholder="First Name" />
        <label for="MainContent_txtFirstName" class="form-label">First Name</label>
    </div>
    <br />
    
    <div class="col-md-6" style="padding-left:20px;">
        <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control" placeholder="Last Name" />
        <label for="MainContent_txtLastName" class="form-label">Last Name</label>
    </div>
    <br />
    
    <div class="col-md-12" style="padding-left:20px;">
        <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control" placeholder="Address" />
        <label for="MainContent_txtAddress">Address</label>
    </div>
    <br />
    
    <div class="col-md-12" style="padding-left:20px;">
        <asp:TextBox runat="server" ID="txtAddress2" CssClass="form-control" placeholder="Address 2" />
        <label for="MainContent_txtAddress2">Address 2</label>
    </div>
    <br />
    
    <div class="col-md-6" style="padding-left:20px;">
        <asp:TextBox runat="server" ID="txtCity" CssClass="form-control" placeholder="City" />
        <label for="MainContent_txtCity" class="form-label">City</label>
    </div>
    <br />
    
    <div class="col-md-6" style="padding-left:20px;">
        <asp:DropDownList runat="server" ID="ddlState" CssClass="form-select">
            <asp:ListItem Text="Choose..." Value="" Selected="True" />
            <asp:ListItem Text="Alabama" Value="AL" />
            <asp:ListItem Text="Alaska" Value="AK" />
            <asp:ListItem Text="Arizona" Value="AZ" />
            <asp:ListItem Text="Arkansas" Value="AR" />
            <asp:ListItem Text="California" Value="CA" />
            <asp:ListItem Text="Colorado" Value="CO" />
            <asp:ListItem Text="Connecticut" Value="CT" />
            <asp:ListItem Text="Delaware" Value="DE" />
            <asp:ListItem Text="Florida" Value="FL" />
            <asp:ListItem Text="Georgia" Value="GA" />
            <asp:ListItem Text="Hawaii" Value="HI" />
            <asp:ListItem Text="Idaho" Value="ID" />
            <asp:ListItem Text="Illinois" Value="IL" />
            <asp:ListItem Text="Indiana" Value="IN" />
            <asp:ListItem Text="Iowa" Value="IA" />
            <asp:ListItem Text="Kansas" Value="KS" />
            <asp:ListItem Text="Kentucky" Value="KY" />
            <asp:ListItem Text="Louisiana" Value="LA" />
            <asp:ListItem Text="Maine" Value="ME" />
            <asp:ListItem Text="Maryland" Value="MD" />
            <asp:ListItem Text="Massachusetts" Value="MA" />
            <asp:ListItem Text="Michigan" Value="MI" />
            <asp:ListItem Text="Minnesota" Value="MN" />
            <asp:ListItem Text="Mississippi" Value="MS" />
            <asp:ListItem Text="Missouri" Value="MO" />
            <asp:ListItem Text="Montana" Value="MT" />
            <asp:ListItem Text="Nebraska" Value="NE" />
            <asp:ListItem Text="Nevada" Value="NV" />
            <asp:ListItem Text="New Hampshire" Value="NH" />
            <asp:ListItem Text="New Jersey" Value="NJ" />
            <asp:ListItem Text="New Mexico" Value="NM" />
            <asp:ListItem Text="New York" Value="NY" />
            <asp:ListItem Text="North Carolina" Value="NC" />
            <asp:ListItem Text="North Dakota" Value="ND" />
            <asp:ListItem Text="Ohio" Value="OH" />
            <asp:ListItem Text="Oklahoma" Value="OK" />
            <asp:ListItem Text="Oregon" Value="OR" />
            <asp:ListItem Text="Pennsylvania" Value="PA" />
            <asp:ListItem Text="Rhode Island" Value="RI" />
            <asp:ListItem Text="South Carolina" Value="SC" />
            <asp:ListItem Text="South Dakota" Value="SD" />
            <asp:ListItem Text="Tennessee" Value="TN" />
            <asp:ListItem Text="Texas" Value="TX" />
            <asp:ListItem Text="Utah" Value="UT" />
            <asp:ListItem Text="Vermont" Value="VT" />
            <asp:ListItem Text="Virginia" Value="VA" />
            <asp:ListItem Text="Washington" Value="WA" />
            <asp:ListItem Text="West Virginia" Value="WV" />
            <asp:ListItem Text="Wisconsin" Value="WI" />
            <asp:ListItem Text="Wyoming" Value="WY" />
        </asp:DropDownList>
        <label for="MainContent_ddlState" class="form-label">State</label>
    </div>
    <br />
    
    <div class="col-md-4" style="padding-left:20px;">
        <asp:TextBox runat="server" ID="txtZip" CssClass="form-control" placeholder="Zip" MaxLength="10" />
        <label for="MainContent_txtZip" class="form-label">Zip</label>
    </div>
    <br />
    
    <div class="col-md-12" style="padding-left:20px;">
        <asp:TextBox runat="server" ID="txtPhone" CssClass="form-control" TextMode="Phone" placeholder="000-000-0000" />
        <label for="MainContent_txtPhone">Phone</label>
    </div>
    <br />
    
    <div class="col-md-12" style="padding-left:20px;">
        <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email" placeholder="name@example.com" />
        <label for="MainContent_txtEmail">Email Address</label>
    </div>
    <br />
    
    <div class="col-md-12" style="padding-left:20px;">
        <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" TextMode="Password" placeholder="Password" />
        <label for="MainContent_txtPassword">Password</label>
    </div>
    <br />

    &nbsp;&nbsp;<div class="form-check text-start my-3" style="padding-left:20px;">
        <asp:CheckBox runat="server" ID="chkRememberMe" CssClass="form-check-input" />
        <label class="form-check-label" for="MainContent_chkRememberMe">
            Remember me
        </label>
    </div>
    <br />
    
    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button runat="server" ID="btnRegister" CssClass="btn btn-primary w-100 py-2" Text="Register" OnClick="btnRegister_Click" />
    <br />
    <br />
</div>
</div>

&nbsp;&nbsp; <p>
    <asp:HyperLink runat="server" ID="signinHyperLink" ViewStateMode="Disabled" NavigateUrl="~/sign-in.aspx">Sign In</asp:HyperLink>
    <br />  
    <br />
    Already have an account?
</p>
<br />
<br />
<script src="../assets/dist/js/bootstrap.bundle.min.js"></script>
  </asp:Content>