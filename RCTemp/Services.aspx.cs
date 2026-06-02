using System;
using System.Web.UI;

namespace RCTemp
{
    public partial class Services : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnBronze_Click(object sender, EventArgs e)
        {
            ServiceCartManager.AddItem(Session, "bronze");
            Response.Redirect("Cart.aspx");
        }

        protected void btnSilver_Click(object sender, EventArgs e)
        {
            ServiceCartManager.AddItem(Session, "silver");
            Response.Redirect("Cart.aspx");
        }

        protected void btnGold_Click(object sender, EventArgs e)
        {
            ServiceCartManager.AddItem(Session, "gold");
            Response.Redirect("Cart.aspx");
        }

        protected void btnContinueToCheckout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cart.aspx");
        }
    }
}