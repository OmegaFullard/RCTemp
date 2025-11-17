using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RCTemp
{
    public partial class AdminReviews : Page
    {
        protected DropDownList ddlPageSize;
        protected DropDownList ddlStatus;
        protected GridView grdReviews;
        protected Label lblResults;
        protected Label lblMsg;
        protected void Page_Load(object sender, EventArgs e)
        {
            // require authentication (and role if you use roles)
            if (!User?.Identity?.IsAuthenticated ?? true)
            {
                Response.Redirect("Login.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.RawUrl));
                return;
            }

            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            var status = string.IsNullOrWhiteSpace(ddlStatus.SelectedValue) ? null : ddlStatus.SelectedValue;
            var list = ReviewRepository.GetAll(status);
            grdReviews.DataSource = list;
            grdReviews.DataBind();
            lblMsg.Text = string.Empty;
        }

        protected void grdReviews_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "MarkReviewed")
            {
                if (int.TryParse(e.CommandArgument?.ToString(), out int id))
                {
                    ReviewRepository.UpdateStatus(id, "Reviewed", "Reviewed by admin");
                    BindGrid();
                }
            }
            else if (e.CommandName == "Delete")
            {
                if (int.TryParse(e.CommandArgument?.ToString(), out int id))
                {
                    try
                    {
                        ReviewRepository.Delete(id);
                        BindGrid();
                    }
                    catch (Exception)
                    {
                        lblMsg.Text = "Error deleting submission.";
                    }
                }
            }
        }
    }
}