<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Support.aspx.cs" Inherits="RCTemp.Support" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <h1>Royal City Help Desk</h1>
	
    
<div class="b-example-divider"></div>

<div class="container my-5">
  <div class="position-relative p-5 text-center text-muted bg-body border border-dashed rounded-5">
    <button type="button" class="position-absolute top-0 end-0 p-3 m-3 btn-close bg-secondary bg-opacity-10 rounded-pill" aria-label="Close"></button>
    <svg class="bi mt-5 mb-3" width="48" height="48"><use href="#check2-circle"/></svg>
  
    <p class="col-lg-6 mx-auto mb-4">
        <center><img src="images/support.png" alt="support logo" style="width:150px;height:150px; Border-Radius:25px;" /></center>
        <br />

    Offering 24/7 Support to our clients through our partner "Royal City Help Desk".
               <br />
               Please feel free to contact us for addtional infromation.
               <a href="Contact.aspx"></a> 
  
    </p>
    <button class="btn btn-primary px-5 mb-5" type="button">
      
    </button>
  </div>
</div>

    <br />

               <h2>Contact Support</h2>
      <br />
      <img src="images/RCLogo.png" alt="company logo" />
      <br />
 <address>
           <strong>Royal City Inc.</strong>
     <br />
            13 Majesty Way 
            Royal City, PA 19106
     <br />
            <abbr title="Phone">P:</abbr>
            1.800.222.2222
     <br />
            <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@example.com</a>
     <br />
            <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>
        </address>
              
               <br />  
			   
            <iframe src="https://www.google.com/maps/embed?pb=!1m16!1m12!1m3!1d12234.543958929013!2d-75.16621169999999!3d39.94953124999999!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!2m1!1s39.57.09%2C75.10.14.8!5e0!3m2!1sen!2sus!4v1723056453703!5m2!1sen!2sus" width="600" height="450" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
     <br />
            <a href="#" class="btn btn-primary">Directions</a>
            <a href="https://google.com/maps?q=39.57.09,75.10.14.8"></a>
        
    <br />

<script src="../assets/dist/js/bootstrap.bundle.min.js"></script>
</asp:Content>