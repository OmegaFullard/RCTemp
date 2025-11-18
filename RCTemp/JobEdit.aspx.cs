using System;
using System.Web.UI.WebControls;

namespace RCTemp
{
    public partial class JobEdit : System.Web.UI.Page
    {
        protected TextBox txtTitle;
        protected TextBox txtLocation;
        protected TextBox txtDescription;
        protected TextBox txtType;
        protected HiddenField hfJobId;
        protected CheckBox chkActive;
        protected Label lblResults;
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
                    hfJobId.Value = "0";
                    chkActive.Checked = true;
                }
            }

            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
            {
                Response.Redirect("Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
                return;
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

            hfJobId.Value = job.JobId.ToString();
            txtTitle.Text = job.Title;
            txtLocation.Text = job.Location;
            txtType.Text = job.EmploymentType;
            txtDescription.Text = job.Description;
            chkActive.Checked = job.IsActive;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            var job = new Job
            {
                Title = txtTitle.Text.Trim(),
                Location = txtLocation.Text.Trim(),
                EmploymentType = txtType.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                IsActive = chkActive.Checked,
                PostedDate = DateTime.UtcNow
            };

            if (int.TryParse(hfJobId.Value, out int id) && id > 0)
            {
                job.JobId = id;
                JobRepository.Update(job);
            }
            else
            {
                JobRepository.Insert(job);
            }

            Response.Redirect("Jobs.aspx");
        }
    }
}