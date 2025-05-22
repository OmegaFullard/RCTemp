<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ErrorPage.aspx.cs" Inherits="RCTemp.ErrorPage" %>

asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
            </asp:Content>
           <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder2" >
              <div aria-dropeffect="move" style="padding-left:30px; padding-right:10px; height:500px;overflow: auto; background:rgba(236, 236, 236, 1);">    
                     <h2>CP Inventory</h2><br />
                   
                 <p>A fatal error has occurred. We cannot process your 
                                  request at this time.</p>

                       <ul class="error">
                                <li class="error">Click the “Go Back” button to try again.</li>
                        </ul>

                     <asp:Button ID="btnBack" runat="server" Text="Go Home"  CssClass="btnAction"  BorderStyle="None" />

                
               </div>
                  
             
    </asp:Content>