using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RCTemp
{
    public partial class Jobs : System.Web.UI.Page
    {
        protected TextBox txtTitle;
        protected TextBox txtLocation;
        protected TextBox txtType;
        protected DropDownList ddlPageSize;
        protected GridView grdJobs;
        protected Label lblResults;
        
        private int PageIndex => ParseInt(Request.QueryString["page"], 1);
        private int PageSize => ParseInt(Request.QueryString["pagesize"], 10);
        private string TitleFilter => Request.QueryString["title"] ?? string.Empty;
        private string LocationFilter => Request.QueryString["location"] ?? string.Empty;
        private string TypeFilter => Request.QueryString["type"] ?? string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Initialize form controls from querystring
                txtTitle.Text = TitleFilter;
                txtLocation.Text = LocationFilter;
                txtType.Text = TypeFilter;
                ddlPageSize.SelectedValue = PageSize.ToString();
                
                // Load jobs with current filters
                BindJobs(PageIndex);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // Redirect to same page with query string filters and reset to page 1
            var qs = HttpUtility.ParseQueryString(string.Empty);
            
            // Add filters to query string
            if (!string.IsNullOrWhiteSpace(txtTitle.Text))
                qs["title"] = txtTitle.Text.Trim();
                
            if (!string.IsNullOrWhiteSpace(txtLocation.Text))
                qs["location"] = txtLocation.Text.Trim();
                
            if (!string.IsNullOrWhiteSpace(txtType.Text))
                qs["type"] = txtType.Text.Trim();
                
            qs["pagesize"] = ddlPageSize.SelectedValue;
            qs["page"] = "1"; // Reset to first page on new search
            
            Response.Redirect("Jobs.aspx?" + qs.ToString());
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            // Redirect to page without any filters
            Response.Redirect("Jobs.aspx");
        }

        private void BindJobs(int page)
        {
            int total;
            
            // Get jobs from repository with filters
            var jobs = JobRepository.GetPaged(
                TitleFilter, 
                LocationFilter, 
                TypeFilter, 
                page, 
                PageSize, 
                out total
            );

            // Bind to GridView
            if (grdJobs != null)
            {
                grdJobs.DataSource = jobs;
                grdJobs.DataBind();
            }

            // Update results label
            if (lblResults != null)
            {
                int totalPages = Math.Max(1, (int)Math.Ceiling(total / (double)PageSize));
                
                if (total == 0)
                {
                    lblResults.Text = "No jobs found";
                }
                else
                {
                    int startItem = ((page - 1) * PageSize) + 1;
                    int endItem = Math.Min(page * PageSize, total);
                    lblResults.Text = $"Showing {startItem}-{endItem} of {total} job(s) (Page {page} of {totalPages})";
                }
            }

            // Render pagination
            RenderPager(total, page, PageSize);
        }

        protected void grdJobs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteJob")
            {
                if (int.TryParse(e.CommandArgument.ToString(), out int id))
                {
                    JobRepository.Delete(id);
                    
                    // Redirect back to current page with filters preserved
                    Response.Redirect(BuildQueryUrl(PageIndex));
                }
            }
        }

        private void RenderPager(int totalItems, int currentPage, int pageSize)
        {
            int totalPages = Math.Max(1, (int)Math.Ceiling(totalItems / (double)pageSize));
            var pagerControl = this.FindControl("pager");
            
            if (pagerControl != null)
            {
                // Clear existing pager
                pagerControl.Controls.Clear();
                
                // Don't show pager if only one page
                if (totalPages <= 1)
                    return;

                // Previous button
                if (currentPage > 1)
                {
                    var liPrev = new System.Web.UI.HtmlControls.HtmlGenericControl("li");
                    liPrev.Attributes["class"] = "page-item";
                    var aPrev = new System.Web.UI.HtmlControls.HtmlGenericControl("a");
                    aPrev.Attributes["class"] = "page-link";
                    aPrev.Attributes["href"] = BuildQueryUrl(currentPage - 1);
                    aPrev.InnerText = "Previous";
                    liPrev.Controls.Add(aPrev);
                    pagerControl.Controls.Add(liPrev);
                }

                // Page numbers
                int startPage = Math.Max(1, currentPage - 2);
                int endPage = Math.Min(totalPages, currentPage + 2);
                
                for (int i = startPage; i <= endPage; i++)
                {
                    var li = new System.Web.UI.HtmlControls.HtmlGenericControl("li");
                    li.Attributes["class"] = "page-item" + (i == currentPage ? " active" : "");
                    var a = new System.Web.UI.HtmlControls.HtmlGenericControl("a");
                    a.Attributes["class"] = "page-link";
                    a.Attributes["href"] = BuildQueryUrl(i);
                    a.InnerText = i.ToString();
                    li.Controls.Add(a);
                    pagerControl.Controls.Add(li);
                }

                // Next button
                if (currentPage < totalPages)
                {
                    var liNext = new System.Web.UI.HtmlControls.HtmlGenericControl("li");
                    liNext.Attributes["class"] = "page-item";
                    var aNext = new System.Web.UI.HtmlControls.HtmlGenericControl("a");
                    aNext.Attributes["class"] = "page-link";
                    aNext.Attributes["href"] = BuildQueryUrl(currentPage + 1);
                    aNext.InnerText = "Next";
                    liNext.Controls.Add(aNext);
                    pagerControl.Controls.Add(liNext);
                }
            }
        }

        private string BuildQueryUrl(int page)
        {
            var qs = HttpUtility.ParseQueryString(string.Empty);
            
            // Preserve current filters
            if (!string.IsNullOrWhiteSpace(TitleFilter))
                qs["title"] = TitleFilter;
                
            if (!string.IsNullOrWhiteSpace(LocationFilter))
                qs["location"] = LocationFilter;
                
            if (!string.IsNullOrWhiteSpace(TypeFilter))
                qs["type"] = TypeFilter;
                
            qs["pagesize"] = PageSize.ToString();
            qs["page"] = page.ToString();
            
            return "Jobs.aspx?" + qs.ToString();
        }

        private static int ParseInt(string value, int defaultValue)
        {
            if (int.TryParse(value, out int v))
                return v;
            return defaultValue;
        }
    }
}