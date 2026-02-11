<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sign-in.aspx.cs"  MasterPageFile="~/Site.Master" Inherits="RCTemp.sign_in" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


   <div class="container" style="max-width:420px;margin-top:40px;">
   <h2>Sign In</h2>
 <p class="lead">Welcome Back! Please sign in to continue to your account.</p>
    <br />
        <br />
        <br />
  
                   
                    <div class="mb-2">
                         <input type="email" class="form-control" id="Email" placeholder="name@example.com"/>
      <label for="Email">Email address</label>
    </div>
                    <div class="col-md-3">
                        <input type="password" class="form-control" id="Password" placeholder="Password"/>
      <label for="Password">Password</label>
                    </div>

    <br/>
    <br/>
                    <div class="d-flex gap-2 mb-3">
                       
    &nbsp;&nbsp;&nbsp;&nbsp;<button class="btn btn-success" type="submit">Sign In</button>
      </div>
                               </div>
                       
      <br />
      
      &nbsp;&nbsp; <p>
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled" NavigateUrl="~/sign-up.aspx">Register</asp:HyperLink>
           <br />
          <br />
           If you don't have a local account.
                </p>
      <br />
      <br />



<script src="../assets/dist/js/bootstrap.bundle.min.js"></script>


    </asp:Content>
