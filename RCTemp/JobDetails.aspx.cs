using System;

namespace RCTemp
{
    public partial class JobDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (int.TryParse(Request.QueryString["id"], out int id))
                {
                    LoadJob(id);
                }
                else
                {
                    Response.Redirect("Jobs.aspx");
                }
            }
        }

        private void LoadJob(int id)
        {
            var job = JobRepository.GetById(id);
            if (job == null)
            {
                Response.Redirect("Jobs.aspx");
                return;
            }

            pnlJob.Visible = true;
            lblTitle.Text = job.Title;
            lblLocation.Text = job.Location;
            lblType.Text = job.EmploymentType;
            lblPosted.Text = job.PostedDate.ToString("yyyy-MM-dd");
            litDescription.Text = HttpUtility.HtmlEncode(job.Description).Replace("\n", "<br/>");

            // link to apply page
            lnkApply.HRef = $"Apply.aspx?id={job.JobId}";
        }
    }
}