<%@ Page Title="Follow Us" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FollowUs.aspx.cs" Inherits="RCTemp.FollowUs" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .follow-container {
            max-width: 1000px;
            margin: 24px auto;
            padding: 20px;
            background: #fff;
            border-radius: 8px;
            box-shadow: 0 6px 18px rgba(0,0,0,0.06);
            font-family: "Segoe UI", Roboto, Arial, sans-serif;
        }
        .follow-header {
            text-align: center;
            margin-bottom: 18px;
        }
        .follow-header h2 { margin: 0 0 6px; }
        .follow-intro { text-align:center; color: #444; margin-bottom: 20px; }
        .social-grid {
            display: flex;
            flex-wrap: wrap;
            gap: 14px;
            justify-content: center;
        }
        .social-card {
            display: flex;
            align-items: center;
            gap: 12px;
            width: 260px;
            padding: 12px 16px;
            background: linear-gradient(180deg, #f9f9f9, #ffffff);
            border: 1px solid #e6e6e6;
            border-radius: 8px;
            text-decoration: none;
            color: #111;
            transition: transform .12s ease, box-shadow .12s ease;
        }
        .social-card:hover {
            transform: translateY(-4px);
            box-shadow: 0 8px 24px rgba(0,0,0,0.08);
            text-decoration: none;
        }
        .social-icon {
            width: 44px;
            height: 44px;
            flex: 0 0 44px;
        }
        .social-info { font-size: 15px; }
        .social-name { font-weight: 600; }
        .social-handle { color:#666; font-size:13px; }
        @media (max-width:640px) {
            .social-card { width: calc(100% - 40px); }
        }
    </style>

    <div class="follow-container" role="main" aria-labelledby="followTitle">
        <div class="follow-header">
            <h2 id="followTitle">Follow Royal City Temporary Agency</h2>
            <p class="follow-intro">Stay connected for updates, job postings, and company news. Click any platform to follow or message us.</p>
        </div>

        <div class="social-grid" role="list">
            <a class="social-card" role="listitem" href="https://www.facebook.com/YourPage" target="_blank" rel="noopener noreferrer" aria-label="Follow us on Facebook">
                <svg class="social-icon" viewBox="0 0 24 24" fill="#1877F2" xmlns="http://www.w3.org/2000/svg" aria-hidden="true">
                    <path d="M22 12.07C22 6.5 17.52 2 11.94 2S2 6.5 2 12.07C2 17.06 5.66 21.14 10.44 21.98v-6.99H7.9v-2.92h2.54V9.57c0-2.5 1.49-3.88 3.77-3.88 1.09 0 2.24.2 2.24.2v2.46h-1.26c-1.24 0-1.63.77-1.63 1.56v1.86h2.78l-.44 2.92h-2.34V21.98C18.34 21.14 22 17.06 22 12.07z"/>
                </svg>
                <div class="social-info">
                    <div class="social-name">Facebook</div>
                    <div class="social-handle">@RoyalCityTemps</div>
                </div>
            </a>

            <a class="social-card" role="listitem" href="https://twitter.com/YourHandle" target="_blank" rel="noopener noreferrer" aria-label="Follow us on X (Twitter)">
                <svg class="social-icon" viewBox="0 0 24 24" fill="#1DA1F2" xmlns="http://www.w3.org/2000/svg" aria-hidden="true">
                    <path d="M22 5.92c-.66.3-1.37.5-2.12.59a3.7 3.7 0 0 0 1.62-2.04 7.2 7.2 0 0 1-2.34.9 3.67 3.67 0 0 0-6.26 3.35A10.42 10.42 0 0 1 3 4.9a3.66 3.66 0 0 0 1.13 4.89 3.56 3.56 0 0 1-1.66-.46v.05c0 1.8 1.28 3.3 2.98 3.64a3.7 3.7 0 0 1-1.65.06 3.68 3.68 0 0 0 3.43 2.55A7.36 7.36 0 0 1 2 18.58 10.38 10.38 0 0 0 7.29 20c6.05 0 9.36-5.02 9.36-9.37v-.43A6.7 6.7 0 0 0 22 5.92z"/>
                </svg>
                <div class="social-info">
                    <div class="social-name">X (Twitter)</div>
                    <div class="social-handle">@RoyalCityTemps</div>
                </div>
            </a>

            <a class="social-card" role="listitem" href="https://www.linkedin.com/company/YourCompany" target="_blank" rel="noopener noreferrer" aria-label="Follow us on LinkedIn">
                <svg class="social-icon" viewBox="0 0 24 24" fill="#0A66C2" xmlns="http://www.w3.org/2000/svg" aria-hidden="true">
                    <path d="M4.98 3.5a2.5 2.5 0 1 1 .02 0zM3 8.98H7v12H3v-12zM9 8.98h3.7v1.64h.05c.52-.99 1.8-2.04 3.7-2.04 3.95 0 4.68 2.6 4.68 6V20h-4v-5.06c0-1.2 0-2.74-1.67-2.74-1.68 0-1.94 1.31-1.94 2.66V20H9v-11.02z"/>
                </svg>
                <div class="social-info">
                    <div class="social-name">LinkedIn</div>
                    <div class="social-handle">Royal City Temporary Agency</div>
                </div>
            </a>

            <a class="social-card" role="listitem" href="https://www.instagram.com/YourHandle" target="_blank" rel="noopener noreferrer" aria-label="Follow us on Instagram">
                <svg class="social-icon" viewBox="0 0 24 24" fill="#E1306C" xmlns="http://www.w3.org/2000/svg" aria-hidden="true">
                    <path d="M7 2h10a5 5 0 0 1 5 5v10a5 5 0 0 1-5 5H7a5 5 0 0 1-5-5V7a5 5 0 0 1 5-5zm5 5.5A4.5 4.5 0 1 0 16.5 12 4.5 4.5 0 0 0 12 7.5zm6.6-1.9a1.1 1.1 0 1 0 1.1 1.1 1.1 1.1 0 0 0-1.1-1.1z"/>
                </svg>
                <div class="social-info">
                    <div class="social-name">Instagram</div>
                    <div class="social-handle">@RoyalCityTemps</div>
                </div>
            </a>

            <a class="social-card" role="listitem" href="https://www.youtube.com/YourChannel" target="_blank" rel="noopener noreferrer" aria-label="Subscribe on YouTube">
                <svg class="social-icon" viewBox="0 0 24 24" fill="#FF0000" xmlns="http://www.w3.org/2000/svg" aria-hidden="true">
                    <path d="M23.5 6.2s-.2-1.6-.8-2.3c-.8-.9-1.7-.9-2.2-1-3-.2-7.5-.2-7.5-.2h-.1s-4.6 0-7.6.2c-.6 0-1.5.1-2.2 1C.7 4.6.5 6.2.5 6.2S.3 8 .3 9.8v.4c0 1.8.2 3.6.2 3.6s.2 1.6.8 2.3c.8.9 1.9.9 2.4 1 1.7.1 7.3.2 7.3.2s4.6 0 7.6-.2c.6 0 1.4-.1 2.2-1 .6-.7.8-2.3.8-2.3s.2-1.8.2-3.6v-.4c0-1.8-.2-3.6-.2-3.6zM9.5 15.6V8.4l6.2 3.6-6.2 3.6z"/>
                </svg>
                <div class="social-info">
                    <div class="social-name">YouTube</div>
                    <div class="social-handle">Royal City Temps</div>
                </div>
            </a>
        </div>

        <p style="text-align:center; color:#666; margin-top:20px;">Questions? <a href="Contact.aspx">Contact us</a> or email <a href="mailto:info@royalcitytemps.com">info@royalcitytemps.com</a></p>
    </div>
</asp:Content>