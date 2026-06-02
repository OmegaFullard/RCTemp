using System;
using System.Collections.Generic;
using System.Web.UI;

namespace RCTemp
{
    public partial class Cart : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCart();
            }
        }

        protected void rptCartItems_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            if (string.Equals(e.CommandName, "AddOne", StringComparison.OrdinalIgnoreCase))
            {
                ServiceCartManager.AddItem(Session, Convert.ToString(e.CommandArgument));
            }
            else if (string.Equals(e.CommandName, "RemoveOne", StringComparison.OrdinalIgnoreCase))
            {
                ServiceCartManager.RemoveOne(Session, Convert.ToString(e.CommandArgument));
            }

            BindCart();
        }

        protected void btnClearCart_Click(object sender, EventArgs e)
        {
            ServiceCartManager.Clear(Session);
            BindCart();
            ShowMessage("Your cart has been cleared.", System.Drawing.Color.DarkOrange);
        }

        protected void btnContinueShopping_Click(object sender, EventArgs e)
        {
            Response.Redirect("Services.aspx");
        }

        protected void btnSubmitOrder_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                ShowMessage("Please fix validation errors before submitting.", System.Drawing.Color.Red);
                return;
            }

            if (ServiceCartManager.GetItemCount(Session) == 0)
            {
                ShowMessage("Add at least one service to your cart before submitting.", System.Drawing.Color.Red);
                return;
            }

            ServiceCartManager.Clear(Session);
            BindCart();
            ShowMessage("Your order has been submitted successfully.", System.Drawing.Color.Green);
        }

        private void BindCart()
        {
            var cart = ServiceCartManager.GetCart(Session);
            rptCartItems.DataSource = cart;
            rptCartItems.DataBind();

            pnlEmptyCart.Visible = cart.Count == 0;
            lblCartCount.Text = ServiceCartManager.GetItemCount(Session).ToString();
            lblCartTotal.Text = ServiceCartManager.GetTotal(Session).ToString("$0.00");
        }

        private void ShowMessage(string message, System.Drawing.Color color)
        {
            lblCartMessage.Visible = true;
            lblCartMessage.Text = message;
            lblCartMessage.BackColor = color;
            lblCartMessage.ForeColor = System.Drawing.Color.White;
        }
    }
}
