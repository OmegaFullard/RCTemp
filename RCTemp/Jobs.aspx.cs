using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RCTemp
{
    public partial class Jobs : System.Web.UI.Page
    {
        private int PageIndex => ParseInt(Request.QueryString["page"], 1);
        private int PageSize => ParseInt(Request.QueryString["pagesize"], 10);
        private string TitleFilter => Request.QueryString["title"] ?? string.Empty;
        private string LocationFilter => Request.QueryString["location"] ?? string.Empty;
        private string TypeFilter => Request.QueryString["type"] ?? string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // initialize form controls from querystring
                BindJobs(PageIndex);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // redirect to same page with query string filters and page=1
            var qs = HttpUtility.ParseQueryString(string.Empty);
            if (!string.IsNullOrWhiteSpace(txtTitle.Text)) qs["title"] = txtTitle.Text.Trim();
            if (!string.IsNullOrWhiteSpace(txtLocation.Text)) qs["location"] = txtLocation.Text.Trim();
            if (!string.IsNullOrWhiteSpace(txtType.Text)) qs["type"] = txtType.Text.Trim();
            qs["pagesize"] = (ddlPageSize != null) ? ddlPageSize.SelectedValue : PageSize.ToString();
            qs["page"] = "1";
            Response.Redirect("Jobs.aspx?" + qs.ToString());
        }

        private void BindJobs(int page)
        {
            int total;
            var jobs = JobRepository.GetPaged(TitleFilter, LocationFilter, TypeFilter, page, PageSize, out total);

            if (grdJobs != null)
            {
                grdJobs.DataSource = jobs;
                grdJobs.DataBind();
            }

            if (lblResults != null)
            {
                lblResults.Text = $"Showing page {page} of {Math.Max(1, (int)Math.Ceiling(total / (double)PageSize))} — {total} job(s) total";
            }

            RenderPager(total, page, PageSize);
        }

        protected void grdJobs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteJob")
            {
                if (int.TryParse(e.CommandArgument.ToString(), out int id))
                {
                    JobRepository.Delete(id);
                    // keep the current page in querystring
                    Response.Redirect(BuildQueryUrl(PageIndex));
                }
            }
        }

        private void RenderPager(int totalItems, int currentPage, int pageSize)
        {
            int totalPages = Math.Max(1, (int)Math.Ceiling(totalItems / (double)pageSize));
            var ul = (System.Web.UI.HtmlControls.HtmlGenericControl)FindControl("pager") ?? new System.Web.UI.HtmlControls.HtmlGenericControl();

            // clear existing pager (rebuild)
            var pagerControl = this.FindControl("pager");
            if (pagerControl != null)
            {
                // remove child nodes
                pagerControl.Controls.Clear();
            }

            for (int i = 1; i <= totalPages; i++)
            {
                var li = new System.Web.UI.HtmlControls.HtmlGenericControl("li");
                li.Attributes["class"] = "page-item" + (i == currentPage ? " active" : "");
                var a = new System.Web.UI.HtmlControls.HtmlGenericControl("a");
                a.Attributes["class"] = "page-link";
                a.Attributes["href"] = BuildQueryUrl(i);
                a.InnerText = i.ToString();
                li.Controls.Add(a);
                if (pagerControl != null) pagerControl.Controls.Add(li);
            }
        }

        private string BuildQueryUrl(int page)
        {
            var qs = HttpUtility.ParseQueryString(string.Empty);
            if (!string.IsNullOrWhiteSpace(TitleFilter)) qs["title"] = TitleFilter;
            if (!string.IsNullOrWhiteSpace(LocationFilter)) qs["location"] = LocationFilter;
            if (!string.IsNullOrWhiteSpace(TypeFilter)) qs["type"] = TypeFilter;
            qs["pagesize"] = (ddlPageSize != null) ? ddlPageSize.SelectedValue : PageSize.ToString();
            qs["page"] = page.ToString();
            return "Jobs.aspx?" + qs.ToString();
        }

        private static int ParseInt(string value, int defaultValue)
        {
            if (int.TryParse(value, out int v)) return v;
            return defaultValue;
        }
    }
}