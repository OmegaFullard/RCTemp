<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sign-up.aspx.cs" Inherits="RCTemp.sign_up" %>

<!DOCTYPE html>
<html lang="en" data-bs-theme="auto">
<head runat="server"><script src="../assets/js/color-modes.js"></script>

     <link rel="icon" href="images/favicon/favicon.ico" type="image/x-icon"/>
  <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" />
         <link rel="apple-touch-icon" sizes="180x180" href="images/favicon/apple-touch-icon.png"/>
<link rel="icon" type="image/png" sizes="32x32" href="images/favicon/favicon-32x32.png"/>
<link rel="icon" type="image/png" sizes="16x16" href="images/favicon/favicon-16x16.png"/>
<link rel="manifest" href="/site.webmanifest"/>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="Omega Fullard, Pipe Dreams Productions">
    <meta name="generator" content="Hugo 0.118.2">
    <title>Sign Up</title>

    <!-- Custom Styles -->

    <link rel="canonical" href="https://getbootstrap.com/docs/5.3/examples/sign-in/">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/@docsearch/css@3">
<link href="../assets/dist/css/bootstrap.min.css" rel="stylesheet">

      <link href="App_Themes/styles.css" rel="stylesheet" />
    <link href="App_Themes/Page.css" rel="stylesheet" />
    <link href="App_Themes/dropdowns.css" rel="stylesheet" />
    <link href="App_Themes/headers.css" rel="stylesheet" />
    <link href="App_Themes/modals.css" rel="stylesheet" />
    <link href="App_Themes/pricing.css" rel="stylesheet" />
    <link href="App_Themes/sign-in.css" rel="stylesheet" />
    <link href="App_Themes/sign-up.css" rel="stylesheet" />
	<link href="App_Themes/jumbotrons.css" rel="stylesheet" />
	
		  <link href="http://localhost:64954/Content/DataTables/css/dataTables.jqueryui.min.css" rel="stylesheet" />

    <link href="http://localhost:64954/css/font-awesome.css" rel="stylesheet" />

    <script src="http://localhost:64954/Scripts/jquery-3.4.1.slim.min.js"></script>

    <script src="http://localhost:64954/Scripts/popper.min.js"></script>
    <script src="http://localhost:64954/Scripts/bootstrap.min.js"></script>
	 
    <!-- Add icon library -->
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>



    
    <!-- Custom styles for this template -->
    <link href="sign-up.css" rel="stylesheet">
  </head>
  <body class="d-flex align-items-center py-4 bg-body-tertiary">
    
<main class="form-signin w-100 m-auto">
      <div>
                <nav class="navbar navbar-light" style="background-color:#a0d9ef">
                    <ul class="nav navbar-nav">
                        <li><a runat="server" href="~/Default">Home</a></li>
                        <li><a runat="server" href="~/Services">Services</a></li>
                        <li><a runat="server" href="~/Contact">Contact</a></li>
     <li><a runat="server" href="~/About">About</a></li>
     <li><a runat="server" href="~/Support">Support</a></li>


                    </ul>

                    <br />
                    <br />
     
                </nav>
         </div>
    <br />
    <br />
 <form class="row g-3">
    
   &nbsp;&nbsp;&nbsp;&nbsp; <h1 class="h3 mb-3 fw-normal">Please Enter Details</h1>
      <br />
      <div class="col-md-6" style="padding-left:20px;">
         
      <input type="text" class="form-control" id="floatingFName" placeholder="First Name">
              <label for="floatingFName" class="form-label">First Name</label>
    </div>
      <br />
    <div class="col-md-6" style="padding-left:20px;">
      <input type="text" class="form-control" id="floatingLName" placeholder="Last Name">
      <label for="floatingLName" class="form-label">Last Name</label>
    </div>
      <br />
<div class="col-md-12" style="padding-left:20px;">
      <input type="text" class="form-control" id="floatingAddress" placeholder="Address">
      <label for="floatingAddress">Address</label>
    </div>
      <br />
      <div class="col-md-12" style="padding-left:20px;">
      <input type="text" class="form-control" id="floatingAddress2" placeholder="Address">
      <label for="floatingAddress2">Address 2</label>
    </div>
      <br />
    <div class="col-md-6" style="padding-left:20px;">
 
        <input type="text" class="form-control" id="inputCity" placeholder="City">
   <label for="inputCity" class="form-label">City</label>
        </div>
      <br />
  <div class="col-md-6" style="padding-left:20px;">

    <select id="inputState" class="form-select">
        
      <option selected>Choose...</option>
                              <option>Alabama</option>
                              <option>Alaska<option/>
                              <option>Arizona<option/>
                              <option>Arkansas<option/>
                              <option>California<option/>
                              <option>Colorado<option/>
                              <option>Connecticut<option/>
                              <option>Delaware<option/>
                              <option>Florida<option/>
                              <option>Georgia<option/>
                              <option>Hawaii<option/>
                              <option>Idaho<option/>
                              <option>Illinois<option/>
                              <option>Indiana<option/>
                              <option>Iowa<option/>
                              <option>Kansas<option/>
                              <option>Kentucky<option/>
                              <option>Louisiana<option/>
                              <option>Maine<option/>
                              <option>Maryland<option/>
                              <option>Massachusetts<option/>
                              <option>Michigan<option/>
                              <option>Minnesota<option/>
                              <option>Mississippi<option/>
                              <option>Missouri<option/>
                              <option>Montana<option/>
                              <option>Nebraska<option/>
                              <option>Nevada<option/>
                              <option>New Hampshire<option/>
                             <option>New Jersey<option/>
                               <option>New Mexico<option/>
                               <option>New York<option/>
                               <option>North Carolina<option/>
                               <option>North Dakota<option/>
                               <option>Ohio<option/>
                               <option>Oklahoma<option/>
                               <option>Oregon<option/>
                               <option>Pennsylvania<option/>
                               <option>Rhode Island<option/>
                               <option>South Carolina<option/>
                               <option>South Dakota<option/>
                                <option>Tennessee<option/>
                                <option>Texas<option/>
                                <option>Utah<option/>
                                <option>Vermont<option/>
                                <option>Virginia<option/>
                                <option>Washington<option/>
                                <option>West Virginia<option/>
                               <option>Wisconsin<option/>
                                <option>Wyoming<option/>
    </select>
      <label for="inputState" class="form-label">State</label>
  </div>
      <br />
  <div class="col-md-4" style="padding-left:20px;">
    
    <input type="text" class="form-control" id="inputZip" placeholder="Zip">
      <label for="inputZip" class="form-label">Zip</label>
  </div>
      <br />
  <div class="col-md-12" style="padding-left:20px;">
      <input type="tel" class="form-control" id="floatingTel" placeholder="000-000-0000">
      <label for="floatingTel">Phone</label>
    </div>
      <br />
  <div class="col-md-12" style="padding-left:20px;">
      <input type="email" class="form-control" id="floatingEmail" placeholder="name@example.com">
      <label for="floatingEmail">Email Address</label>
    </div>
      <br />
     <div class="col-md-12" style="padding-left:20px;">
      <input type="password" class="form-control" id="floatingPassword" placeholder="Password">
      <label for="floatingPassword">Password</label>
    </div>
      <br />


    &nbsp;&nbsp;<div class="form-check text-start my-3" style="padding-left:20px;">
      <input class="form-check-input" type="checkbox" value="remember-me" id="flexCheckDefault">
      <label class="form-check-label" for="flexCheckDefault">
        Remember me
      </label>
    </div>
      <br />
    &nbsp;&nbsp;&nbsp;&nbsp;<button class="btn btn-primary w-100 py-2" type="submit">Register</button>
      <br />
      <br />
     
 
      &nbsp;&nbsp; <p>
                    <asp:HyperLink runat="server" ID="signinHyperLink" ViewStateMode="Disabled" NavigateUrl="~/sign-in.aspx">Sign In</asp:HyperLink>
           <br />         
           Already have an account?.
                </p>
      <br />
      <br />
  <footer class="d-flex flex-wrap justify-content-between align-items-center py-3 my-4 border-top">
    <div class="col-md-12 d-flex align-items-center">
      <a href="/" class="mb-3 me-2 mb-md-0 text-body-secondary text-decoration-none lh-1">
      
      </a>
      <span class="mb-3 mb-md-0 text-body-secondary">&copy; 2025 Royal City Temp Agency</span>
    </div>
      <br />
      <br />
 <a href="FollowUs.aspx" class="btn btn-primary">Follow Us on Social Media!</a> 
      <br />
      <br />
 <!-- Footer -->
 <div class="row">
        <div class="col-md-12">
    
 
            <!-- Add font awesome icons -->
<a href="#" class="fa fa-facebook"></a>
<a href="#" class="fa fa-twitter"></a>
<a href="#" class="fa fa-linkedin"></a>
<a href="#" class="fa fa-youtube"></a>
<a href="#" class="fa fa-instagram"></a>
    </div>
     </div>
 
  </footer>

  </form>
</main>
<script src="../assets/dist/js/bootstrap.bundle.min.js"></script>

    </body>
</html>
