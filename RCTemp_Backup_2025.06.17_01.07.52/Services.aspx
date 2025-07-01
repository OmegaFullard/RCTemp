<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Services.aspx.cs" Inherits="RCTemp.Services" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  
 
<svg xmlns="http://www.w3.org/2000/svg" class="d-none">
  <symbol id="check" viewBox="0 0 16 16">
    <title>Check</title>
    <path d="M13.854 3.646a.5.5 0 0 1 0 .708l-7 7a.5.5 0 0 1-.708 0l-3.5-3.5a.5.5 0 1 1 .708-.708L6.5 10.293l6.646-6.647a.5.5 0 0 1 .708 0z"/>
  </symbol>
</svg>

<div class="container py-3">

    <div class="d-flex flex-column flex-md-row align-items-center pb-3 mb-4 border-bottom">
      <a href="/" class="d-flex align-items-center link-body-emphasis text-decoration-none"></a>
      <nav>
	  
	  </nav>
    </div>
      <hr />
    <div class="pricing-header p-3 pb-md-4 mx-auto text-center">
      
     <center> <h4><strong>Compare our competitive pricing below</strong></h4></center>
    </div>

    <hr />
        </div>


    <div class="row row-cols-1 row-cols-md-3 mb-3 text-center">
      <div class="col">
        <div class="card mb-4 rounded-3 shadow-sm">
          <div class="card-header py-3">
            <h4 class="my-0 fw-normal">Bronze</h4>
          </div>
          <div class="card-body">
            <h4 class="card-title pricing-card-title">$100<small class="text-body-secondary fw-light">/mo</small></h4>
            <ul class="list-unstyled mt-3 mb-4">
              <li>5 users included</li>
              <li>20 GB of storage</li>
              <li>limited email support</li>
              
            </ul>
            <button type="button" class="w-100 btn btn-lg btn-outline-primary" style="color: #2097db;">Sign up for free</button>
          </div>
        </div>
      </div>
      <div class="col">
        <div class="card mb-4 rounded-3 shadow-sm">
          <div class="card-header py-3">
            <h4 class="my-0 fw-normal">Silver</h4>
          </div>
          <div class="card-body">
            <h4 class="card-title pricing-card-title">$200<small class="text-body-secondary fw-light">/mo</small></h4>
            <ul class="list-unstyled mt-3 mb-4">
              <li>10 users included</li>
              <li>100 GB of storage</li>
              <li>Priority email support</li>
              <li>Royal City Notification Center</li>
            </ul>
            <button type="button" class="w-100 btn btn-lg btn-primary" >Get started</button>
          </div>
        </div>
      </div>
      <div class="col">
        <div class="card mb-4 rounded-3 shadow-sm border-primary">
          <div class="card-header py-3 text-bg-primary border-primary">
            <h4 class="my-0 fw-normal">Gold</h4>
          </div>
          <div class="card-body">
            <h4 class="card-title pricing-card-title">$300<small class="text-body-secondary fw-light">/mo</small></h4>
            <ul class="list-unstyled mt-3 mb-4">
              <li>20 users included</li>
              <li>unlimited storage</li>
              <li>Phone and email support 24/7</li>
              <li>Royal City Notification Center</li>
            </ul>
            <button type="button" class="w-100 btn btn-lg btn-primary" >Contact us</button>
          </div>
        </div>
      </div>
    </div>
      <hr />
    <h2 class="display-6 text-center mb-4">Compare plans</h2>

    <div class="table-responsive">
      <table class="table text-center">
        <thead>
          <tr>
            <th style="width: 34%;"></th>
            <th style="width: 22%;">Bronze</th>
            <th style="width: 22%;">Silver</th>
            <th style="width: 22%;">Gold</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <th scope="row" class="text-start">Public</th>
            <td><svg class="bi bi-check" width="24" height="24"><use href="#check"/></svg></td>
            <td><svg class="bi bi-check" width="24" height="24"><use href="#check"/></svg></td>
            <td><svg class="bi bi-check" width="24" height="24"><use href="#check"/></svg></td>
          </tr>
          <tr>
            <th scope="row" class="text-start">Private</th>
            <td></td>
            <td><svg class="bi bi-check" width="24" height="24"><use href="#check"/></svg></td>
            <td><svg class="bi bi-check" width="24" height="24"><use href="#check"/></svg></td>
          </tr>
        </tbody>

        <tbody>
          <tr>
            <th scope="row" class="text-start">Permissions</th>
            <td><svg class="bi bi-check" width="24" height="24"><use href="#check"/></svg></td>
            <td><svg class="bi bi-check" width="24" height="24"><use href="#check"/></svg></td>
            <td><svg class="bi bi-check" width="24" height="24"><use href="#check"/></svg></td>
          </tr>
          <tr>
            <th scope="row" class="text-start">Sharing</th>
            <td></td>
            <td><svg class="bi bi-check" width="24" height="24"><use href="#check"/></svg></td>
            <td><svg class="bi bi-check" width="24" height="24"><use href="#check"/></svg></td>
          </tr>
          
        </tbody>
      </table>
    </div>
      <br />
      <br />
    
    <center><a class="btn btn-primary" href="Cart.aspx" role="button">Continue to Checkout!</a></center>
             <br/>
            <a href="default.aspx"><< Back to Home</a>
         
             <br/>
    <hr />

    <div class="row">
      <div class="col-12 col-md">
        <img src="images/RCLogo.png" alt="logo" style="width:50px;height:50px;" />
        <small class="d-block mb-3 text-body-secondary">&copy; 2018–2025</small>
      </div>
        <br />
        <hr />
      <div class="col-4 col-md">
        <h5>Features</h5>
        <ul class="list-unstyled text-small">
          <li class="mb-1"><a class="link-secondary text-decoration-none" href="#">Job Portal</a></li>
          <li class="mb-1"><a class="link-secondary text-decoration-none" href="#">Client Portal</a></li>
          <li class="mb-1"><a class="link-secondary text-decoration-none" href="#">Customized</a></li>
          <li class="mb-1"><a class="link-secondary text-decoration-none" href="#">Local</a></li>
          
          
        </ul>
      </div>
      <div class="col-4 col-md">
        <h5>Resources</h5>
        <ul class="list-unstyled text-small">
          <li class="mb-1"><a class="link-secondary text-decoration-none" href="#">Job Search</a></li>
          <li class="mb-1"><a class="link-secondary text-decoration-none" href="#">Prep Interviews</a></li>
          <li class="mb-1"><a class="link-secondary text-decoration-none" href="#">Resume Review</a></li>
          <li class="mb-1"><a class="link-secondary text-decoration-none" href="#">Skills Test</a></li>
        </ul>
      </div>
      <div class="col-4 col-md">
        <h5>About</h5>
        <ul class="list-unstyled text-small">
          <li class="mb-1"><a class="link-secondary text-decoration-none" href="#">Team</a></li>
          <li class="mb-1"><a class="link-secondary text-decoration-none" href="#">Locations</a></li>
          <li class="mb-1"><a class="link-secondary text-decoration-none" href="#">Privacy</a></li>
          <li class="mb-1"><a class="link-secondary text-decoration-none" href="#">Terms</a></li>
        </ul>
      </div>
    </div>

   
</asp:Content>