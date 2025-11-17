using System;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace RCTemp
{
    public partial class ClientPortal : Page
    {
        private int PageIndex => ParseInt(Request.QueryString["page"], 1);
        private int PageSize => ParseInt(Request.QueryString["pagesize"], 10);
        private string TitleFilter => Request.QueryString["title"] ?? string.Empty;
        private string LocationFilter => Request.QueryString["location"] ?? string.Empty;
        private string TypeFilter => Request.QueryString["type"] ?? string.Empty;

        public HtmlGenericControl pagerClient { get; private set; }

        protected TextBox txtTitle;
        protected TextBox txtLocation;
        protected TextBox txtType;
        protected DropDownList ddlPageSize;
        protected GridView grdJobs;
        protected GridView grdClientJobs;
        protected Label lblResults;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtTitle.Text = TitleFilter;
                txtLocation.Text = LocationFilter;
                txtType.Text = TypeFilter;
                ddlPageSize.SelectedValue = PageSize.ToString();
                BindJobs(PageIndex);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var qs = HttpUtility.ParseQueryString(string.Empty);
            if (!string.IsNullOrWhiteSpace(txtTitle.Text)) qs["title"] = txtTitle.Text.Trim();
            if (!string.IsNullOrWhiteSpace(txtLocation.Text)) qs["location"] = txtLocation.Text.Trim();
            if (!string.IsNullOrWhiteSpace(txtType.Text)) qs["type"] = txtType.Text.Trim();
            qs["pagesize"] = ddlPageSize.SelectedValue;
            qs["page"] = "1";
            Response.Redirect("ClientPortal.aspx?" + qs.ToString());
        }

        private void BindJobs(int page)
        {
            int total;
            var jobs = JobRepository.GetPaged(TitleFilter, LocationFilter, TypeFilter, page, PageSize, out total);

            grdClientJobs.DataSource = jobs;
            grdClientJobs.DataBind();

            int totalPages = Math.Max(1, (int)Math.Ceiling(total / (double)PageSize));
            lblResults.Text = $"Showing page {page} of {totalPages} — {total} job(s)";

            RenderPager(total, page, PageSize);
        }

        private void RenderPager(int totalItems, int currentPage, int pageSize)
        {
            int totalPages = Math.Max(1, (int)Math.Ceiling(totalItems / (double)pageSize));
            var sb = new StringBuilder();

            // previous
            if (currentPage > 1)
                sb.AppendFormat("<li class=\"page-item\"><a class=\"page-link\" href=\"{0}\">Previous</a></li>", BuildQueryUrl(currentPage - 1));
            else
                sb.Append("<li class=\"page-item disabled\"><span class=\"page-link\">Previous</span></li>");

            // pages (show up to 7 pages with ellipsis)
            int start = Math.Max(1, currentPage - 3);
            int end = Math.Min(totalPages, currentPage + 3);
            if (start > 1) { sb.AppendFormat("<li class=\"page-item\"><a class=\"page-link\" href=\"{0}\">1</a></li>", BuildQueryUrl(1)); if (start > 2) sb.Append("<li class=\"page-item disabled\"><span class=\"page-link\">…</span></li>"); }
            for (int i = start; i <= end; i++)
            {
                if (i == currentPage)
                    sb.AppendFormat("<li class=\"page-item active\"><span class=\"page-link\">{0}</span></li>", i);
                else
                    sb.AppendFormat("<li class=\"page-item\"><a class=\"page-link\" href=\"{0}\">{1}</a></li>", BuildQueryUrl(i), i);
            }
            if (end < totalPages) { if (end < totalPages - 1) sb.Append("<li class=\"page-item disabled\"><span class=\"page-link\">…</span></li>"); sb.AppendFormat("<li class=\"page-item\"><a class=\"page-link\" href=\"{0}\">{1}</a></li>", BuildQueryUrl(totalPages), totalPages); }

            // next
            if (currentPage < totalPages)
                sb.AppendFormat("<li class=\"page-item\"><a class=\"page-link\" href=\"{0}\">Next</a></li>", BuildQueryUrl(currentPage + 1));
            else
                sb.Append("<li class=\"page-item disabled\"><span class=\"page-link\">Next</span></li>");

            pagerClient.InnerHtml = sb.ToString();
        }

        private string BuildQueryUrl(int page)
        {
            var qs = HttpUtility.ParseQueryString(string.Empty);
            if (!string.IsNullOrWhiteSpace(TitleFilter)) qs["title"] = TitleFilter;
            if (!string.IsNullOrWhiteSpace(LocationFilter)) qs["location"] = LocationFilter;
            if (!string.IsNullOrWhiteSpace(TypeFilter)) qs["type"] = TypeFilter;
            qs["pagesize"] = ddlPageSize.SelectedValue;
            qs["page"] = page.ToString();
            return "ClientPortal.aspx?" + qs.ToString();
        }

        private static int ParseInt(string value, int defaultValue)
        {
            if (int.TryParse(value, out int v)) return v;
            return defaultValue;
        }
    }
}