using System;
using System.IO;
using System.Web;
using System.Web.UI;

namespace RCTemp
{
    public partial class ResumeReview : Page
    {
        private static readonly string[] AllowedExt = { ".pdf", ".doc", ".docx" };
        private const int MaxBytes = 4 * 1024 * 1024;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // populate jobs dropdown
                var jobs = JobRepository.GetPaged(null, null, null, 1, 1000, out _);
                ddlJob.Items.Clear();
                ddlJob.Items.Add(new System.Web.UI.WebControls.ListItem("-- Not applying to a specific job --", ""));
                foreach (var j in jobs)
                {
                    ddlJob.Items.Add(new System.Web.UI.WebControls.ListItem(j.Title, j.JobId.ToString()));
                }

                if (int.TryParse(Request.QueryString["jobId"], out int jobId))
                {
                    var item = ddlJob.Items.FindByValue(jobId.ToString());
                    if (item != null) item.Selected = true;
                    hfJobId.Value = jobId.ToString();
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblUploadError.Text = string.Empty;
            lblResult.Text = string.Empty;

            if (!Page.IsValid) return;

            if (!fuResume.HasFile)
            {
                lblUploadError.Text = "Please select a resume file.";
                return;
            }

            var ext = Path.GetExtension(fuResume.FileName).ToLowerInvariant();
            if (Array.IndexOf(AllowedExt, ext) < 0)
            {
                lblUploadError.Text = "Unsupported file type. Allowed: PDF, DOC, DOCX.";
                return;
            }

            if (fuResume.PostedFile.ContentLength > MaxBytes)
            {
                lblUploadError.Text = "File too large. Max 4 MB.";
                return;
            }

            try
            {
                var uploads = Server.MapPath("~/Uploads/Reviews");
                if (!Directory.Exists(uploads)) Directory.CreateDirectory(uploads);

                var safeName = $"{Guid.NewGuid():N}{ext}";
                var savePath = Path.Combine(uploads, safeName);
                fuResume.SaveAs(savePath);

                var virtualPath = "~/Uploads/Reviews/" + safeName;

                int? jobId = null;
                if (int.TryParse(ddlJob.SelectedValue, out int jid) && jid > 0) jobId = jid;

                var review = new ResumeReview
                {
                    Username = User?.Identity?.Name,
                    ApplicantName = txtName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    JobId = jobId,
                    FilePath = virtualPath,
                    Status = "Pending",
                    SubmittedDate = DateTime.UtcNow
                };

                var newId = ReviewRepository.Insert(review);

                lblResult.Text = "Resume submitted. We'll review and email you with feedback.";
                btnSubmit.Enabled = false;
            }
            catch (Exception)
            {
                lblUploadError.Text = "An error occurred while submitting your resume. Please try again later.";
            }
        }
    }
}