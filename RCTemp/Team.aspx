<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Team.aspx.cs" Inherits="RCTemp.Team" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Our Team</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <style>
        .team-card { border: 1px solid #e6e6e6; border-radius: 8px; padding: 16px; background:#fff; }
        .team-photo { width: 96px; height:96px; object-fit:cover; border-radius:8px; }
        .contact-small { font-size: .95rem; color:#333; }
        .card-bio { color:#555; margin-top:8px; font-size: .95rem; }
        @media (max-width:576px) { .team-photo { width:72px; height:72px; } }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container" style="max-width:1100px; margin-top:24px;">
            <div class="d-flex justify-content-between align-items-center mb-3">
                <h2>Meet Our Team</h2>
            </div>

            <asp:Repeater ID="rptEmployees" runat="server">
                <HeaderTemplate>
                    <div class="row g-3">
                </HeaderTemplate>

                <ItemTemplate>
                    <div class="col-sm-6 col-md-4 col-lg-3">
                        <div class="team-card h-100">
                            <div class="d-flex">
                                <img src='<%# Eval("PhotoUrl") %>' alt='<%# Eval("FullName") %>' class="team-photo me-3" />
                                <div>
                                    <h5 style="margin:0;"><%# Eval("FullName") %></h5>
                                    <div class="text-muted" style="font-size:.95rem;"><%# Eval("Title") %></div>
                                    <div class="card-bio"><%# Eval("Bio") %></div>
                                </div>
                            </div>

                            <hr />

                            <div class="contact-small">
                                <div><strong>Location:</strong> <%# Eval("Location") %></div>
                                <div><strong>Phone:</strong> <a href='tel:<%# Eval("Phone") %>'><%# Eval("Phone") %></a></div>
                                <div><strong>Email:</strong> <a href='mailto:<%# Eval("Email") %>'><%# Eval("Email") %></a></div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>

                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
