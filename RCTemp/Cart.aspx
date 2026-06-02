<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Cart.aspx.cs" Inherits="RCTemp.Cart" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <webopt:bundlereference runat="server" path="~/Content/css" />

    <div class="container py-3">
        <div class="py-5 text-center">
            <h2>Checkout Form</h2>
            <p class="lead">Review your selected services, add more items, or remove items before submitting your order.</p>
        </div>

        <asp:Label ID="lblCartMessage" runat="server" EnableViewState="false" CssClass="alert d-block" Visible="false"></asp:Label>

        <div class="row g-5">
            <div class="col-md-5 col-lg-4 order-md-last">
                <h4 class="d-flex justify-content-between align-items-center mb-3">
                    <span class="text-secondary">Your cart</span>
                    <asp:Label ID="lblCartCount" runat="server" CssClass="badge bg-info rounded-pill">0</asp:Label>
                </h4>

                <asp:Repeater ID="rptCartItems" runat="server" OnItemCommand="rptCartItems_ItemCommand">
                    <HeaderTemplate>
                        <ul class="list-group mb-3">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li class="list-group-item d-flex justify-content-between lh-sm align-items-start">
                            <div class="me-2">
                                <h6 class="my-0"><%# Eval("Name") %></h6>
                                <small class="text-body-secondary"><%# Eval("Description") %></small>
                                <div class="mt-2">
                                    <asp:LinkButton ID="btnAddItem" runat="server" CommandName="AddOne" CommandArgument='<%# Eval("Code") %>' CssClass="btn btn-sm btn-outline-primary me-1">Add</asp:LinkButton>
                                    <asp:LinkButton ID="btnRemoveItem" runat="server" CommandName="RemoveOne" CommandArgument='<%# Eval("Code") %>' CssClass="btn btn-sm btn-outline-danger">Remove</asp:LinkButton>
                                </div>
                            </div>
                            <div class="text-end">
                                <span class="d-block">Qty: <%# Eval("Quantity") %></span>
                                <span class="text-body-secondary">$<%# Eval("LineTotal", "{0:0.00}") %></span>
                            </div>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>

                <asp:Panel ID="pnlEmptyCart" runat="server" CssClass="alert alert-light border" Visible="false">
                    Your cart is empty. Add a service plan to continue.
                </asp:Panel>

                <div class="d-flex justify-content-between align-items-center mb-3">
                    <span>Total (USD)</span>
                    <strong><asp:Label ID="lblCartTotal" runat="server">$0.00</asp:Label></strong>
                </div>

                <div class="d-grid gap-2">
                    <asp:Button ID="btnClearCart" runat="server" CssClass="btn btn-outline-secondary" Text="Clear Cart" OnClick="btnClearCart_Click" />
                    <asp:Button ID="btnContinueShopping" runat="server" CssClass="btn btn-primary" Text="Continue Shopping" OnClick="btnContinueShopping_Click" />
                </div>
            </div>

            <div class="col-md-7 col-lg-8">
                <h4 class="mb-3">Billing address</h4>
                <asp:ValidationSummary ID="vsCheckout" runat="server" CssClass="text-danger" ShowSummary="true" />

                <div class="row g-3">
                    <div class="col-sm-6">
                        <asp:Label ID="lblFirstName" runat="server" AssociatedControlID="txtFirstName" CssClass="form-label" Text="First name"></asp:Label>
                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName" ErrorMessage="First name is required." CssClass="text-danger" Display="Dynamic" />
                    </div>

                    <div class="col-sm-6">
                        <asp:Label ID="lblLastName" runat="server" AssociatedControlID="txtLastName" CssClass="form-label" Text="Last name"></asp:Label>
                        <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName" ErrorMessage="Last name is required." CssClass="text-danger" Display="Dynamic" />
                    </div>

                    <div class="col-12">
                        <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail" CssClass="form-label" Text="Email"></asp:Label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" placeholder="you@example.com"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is required." CssClass="text-danger" Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Enter a valid email address." CssClass="text-danger" Display="Dynamic" ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" />
                    </div>

                    <div class="col-12">
                        <asp:Label ID="lblAddress" runat="server" AssociatedControlID="txtAddress" CssClass="form-label" Text="Address"></asp:Label>
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress" ErrorMessage="Address is required." CssClass="text-danger" Display="Dynamic" />
                    </div>

                    <div class="col-12">
                        <asp:Label ID="lblCity" runat="server" AssociatedControlID="txtCity" CssClass="form-label" Text="City"></asp:Label>
                        <asp:TextBox ID="txtCity" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="txtCity" ErrorMessage="City is required." CssClass="text-danger" Display="Dynamic" />
                    </div>

                    <div class="col-md-6">
                        <asp:Label ID="lblState" runat="server" AssociatedControlID="ddlState" CssClass="form-label" Text="State"></asp:Label>
                        <asp:DropDownList ID="ddlState" runat="server" CssClass="form-select">
                            <asp:ListItem Text="Choose..." Value="" />
                            <asp:ListItem>Alabama</asp:ListItem>
                            <asp:ListItem>Alaska</asp:ListItem>
                            <asp:ListItem>Arizona</asp:ListItem>
                            <asp:ListItem>Arkansas</asp:ListItem>
                            <asp:ListItem>California</asp:ListItem>
                            <asp:ListItem>Colorado</asp:ListItem>
                            <asp:ListItem>Connecticut</asp:ListItem>
                            <asp:ListItem>Delaware</asp:ListItem>
                            <asp:ListItem>Florida</asp:ListItem>
                            <asp:ListItem>Georgia</asp:ListItem>
                            <asp:ListItem>Hawaii</asp:ListItem>
                            <asp:ListItem>Idaho</asp:ListItem>
                            <asp:ListItem>Illinois</asp:ListItem>
                            <asp:ListItem>Indiana</asp:ListItem>
                            <asp:ListItem>Iowa</asp:ListItem>
                            <asp:ListItem>Kansas</asp:ListItem>
                            <asp:ListItem>Kentucky</asp:ListItem>
                            <asp:ListItem>Louisiana</asp:ListItem>
                            <asp:ListItem>Maine</asp:ListItem>
                            <asp:ListItem>Maryland</asp:ListItem>
                            <asp:ListItem>Massachusetts</asp:ListItem>
                            <asp:ListItem>Michigan</asp:ListItem>
                            <asp:ListItem>Minnesota</asp:ListItem>
                            <asp:ListItem>Mississippi</asp:ListItem>
                            <asp:ListItem>Missouri</asp:ListItem>
                            <asp:ListItem>Montana</asp:ListItem>
                            <asp:ListItem>Nebraska</asp:ListItem>
                            <asp:ListItem>Nevada</asp:ListItem>
                            <asp:ListItem>New Hampshire</asp:ListItem>
                            <asp:ListItem>New Jersey</asp:ListItem>
                            <asp:ListItem>New Mexico</asp:ListItem>
                            <asp:ListItem>New York</asp:ListItem>
                            <asp:ListItem>North Carolina</asp:ListItem>
                            <asp:ListItem>North Dakota</asp:ListItem>
                            <asp:ListItem>Ohio</asp:ListItem>
                            <asp:ListItem>Oklahoma</asp:ListItem>
                            <asp:ListItem>Oregon</asp:ListItem>
                            <asp:ListItem>Pennsylvania</asp:ListItem>
                            <asp:ListItem>Rhode Island</asp:ListItem>
                            <asp:ListItem>South Carolina</asp:ListItem>
                            <asp:ListItem>South Dakota</asp:ListItem>
                            <asp:ListItem>Tennessee</asp:ListItem>
                            <asp:ListItem>Texas</asp:ListItem>
                            <asp:ListItem>Utah</asp:ListItem>
                            <asp:ListItem>Vermont</asp:ListItem>
                            <asp:ListItem>Virginia</asp:ListItem>
                            <asp:ListItem>Washington</asp:ListItem>
                            <asp:ListItem>West Virginia</asp:ListItem>
                            <asp:ListItem>Wisconsin</asp:ListItem>
                            <asp:ListItem>Wyoming</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="ddlState" InitialValue="" ErrorMessage="State is required." CssClass="text-danger" Display="Dynamic" />
                    </div>

                    <div class="col-md-6">
                        <asp:Label ID="lblZip" runat="server" AssociatedControlID="txtZip" CssClass="form-label" Text="Zip"></asp:Label>
                        <asp:TextBox ID="txtZip" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvZip" runat="server" ControlToValidate="txtZip" ErrorMessage="Zip code is required." CssClass="text-danger" Display="Dynamic" />
                    </div>
                </div>

                <hr class="my-4" />

                <div class="form-check">
                    <asp:CheckBox ID="chkSameAddress" runat="server" CssClass="form-check-input" />
                    <asp:Label ID="lblSameAddress" runat="server" AssociatedControlID="chkSameAddress" CssClass="form-check-label" Text="Shipping address is the same as my billing address"></asp:Label>
                </div>

                <div class="form-check">
                    <asp:CheckBox ID="chkSaveInfo" runat="server" CssClass="form-check-input" />
                    <asp:Label ID="lblSaveInfo" runat="server" AssociatedControlID="chkSaveInfo" CssClass="form-check-label" Text="Save this information for next time"></asp:Label>
                </div>

                <hr class="my-4" />

                <h4 class="mb-3">Payment</h4>
                <div class="my-3">
                    <div class="form-check">
                        <asp:RadioButton ID="rbCredit" runat="server" GroupName="paymentMethod" CssClass="form-check-input" Checked="true" />
                        <asp:Label ID="lblCredit" runat="server" AssociatedControlID="rbCredit" CssClass="form-check-label" Text="Credit card"></asp:Label>
                    </div>
                    <div class="form-check">
                        <asp:RadioButton ID="rbDebit" runat="server" GroupName="paymentMethod" CssClass="form-check-input" />
                        <asp:Label ID="lblDebit" runat="server" AssociatedControlID="rbDebit" CssClass="form-check-label" Text="Debit card"></asp:Label>
                    </div>
                    <div class="form-check">
                        <asp:RadioButton ID="rbPaypal" runat="server" GroupName="paymentMethod" CssClass="form-check-input" />
                        <asp:Label ID="lblPaypal" runat="server" AssociatedControlID="rbPaypal" CssClass="form-check-label" Text="PayPal"></asp:Label>
                    </div>
                </div>

                <div class="row gy-3">
                    <div class="col-md-6">
                        <asp:Label ID="lblCardName" runat="server" AssociatedControlID="txtCardName" CssClass="form-label" Text="Name on card"></asp:Label>
                        <asp:TextBox ID="txtCardName" runat="server" CssClass="form-control" placeholder="required"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvCardName" runat="server" ControlToValidate="txtCardName" ErrorMessage="Name on card is required." CssClass="text-danger" Display="Dynamic" />
                    </div>

                    <div class="col-md-6">
                        <asp:Label ID="lblCardNumber" runat="server" AssociatedControlID="txtCardNumber" CssClass="form-label" Text="Credit card number"></asp:Label>
                        <asp:TextBox ID="txtCardNumber" runat="server" CssClass="form-control" placeholder="required"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvCardNumber" runat="server" ControlToValidate="txtCardNumber" ErrorMessage="Credit card number is required." CssClass="text-danger" Display="Dynamic" />
                    </div>

                    <div class="col-md-3">
                        <asp:Label ID="lblExpiration" runat="server" AssociatedControlID="txtExpiration" CssClass="form-label" Text="Expiration"></asp:Label>
                        <asp:TextBox ID="txtExpiration" runat="server" CssClass="form-control" placeholder="required"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvExpiration" runat="server" ControlToValidate="txtExpiration" ErrorMessage="Expiration date is required." CssClass="text-danger" Display="Dynamic" />
                    </div>

                    <div class="col-md-3">
                        <asp:Label ID="lblCvv" runat="server" AssociatedControlID="txtCvv" CssClass="form-label" Text="CVV"></asp:Label>
                        <asp:TextBox ID="txtCvv" runat="server" CssClass="form-control" placeholder="required"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvCvv" runat="server" ControlToValidate="txtCvv" ErrorMessage="Security code is required." CssClass="text-danger" Display="Dynamic" />
                    </div>
                </div>

                <hr class="my-4" />

                <asp:Button ID="btnSubmitOrder" runat="server" CssClass="btn btn-success" Text="Submit Order" OnClick="btnSubmitOrder_Click" />
            </div>
        </div>

        <div class="mt-4">
            <br />
            <br />
            &nbsp;&nbsp;&nbsp
            <ul class="list-inline">
                &nbsp;&nbsp;&nbsp <li class="list-inline-item"><a href="Privacy.aspx">Privacy</a></li>
                <li class="list-inline-item"><a href="Terms.aspx">Terms</a></li>
                <li class="list-inline-item"><a href="Support.aspx">Support</a></li>
            </ul>
        </div>
    </div>
</asp:Content>
