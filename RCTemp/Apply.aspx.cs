using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RCTemp
{
    public partial class Apply : Page
    {
        // allowed resume extensions and max size (4 MB)
        private static readonly string[] AllowedExtensions = { ".pdf", ".doc", ".docx" };
        private const int MaxFileBytes = 4 * 1024 * 1024;

        // Control accessors that search the page markup if designer fields are missing.
        //private HiddenField hfJobId => FindControlRecursive(Page, "hfJobId") as HiddenField;
        //private Label lblUploadError => FindControlRecursive(Page, "lblUploadError") as Label;
        //private Label lblResult => FindControlRecursive(Page, "lblResult") as Label;
        //private FileUpload fuResume => FindControlRecursive(Page, "fuResume") as FileUpload;
        //private TextBox txtName => FindControlRecursive(Page, "txtName") as TextBox;
        //private TextBox txtEmail => FindControlRecursive(Page, "txtEmail") as TextBox;
        //private TextBox txtPhone => FindControlRecursive(Page, "txtPhone") as TextBox;
        //private TextBox txtCover => FindControlRecursive(Page, "txtCover") as TextBox;
        //private Button btnSubmit => FindControlRecursive(Page, "btnSubmit") as Button;

        //// Accessors for search / selection controls added to markup
        //private Panel pnlSearch => FindControlRecursive(Page, "pnlSearch") as Panel;
        //private Panel pnlApply => FindControlRecursive(Page, "pnlApply") as Panel;
        //private TextBox txtSearchTitle => FindControlRecursive(Page, "txtSearchTitle") as TextBox;
        //private TextBox txtSearchLocation => FindControlRecursive(Page, "txtSearchLocation") as TextBox;
        //private Button btnSearchJobs => FindControlRecursive(Page, "btnSearchJobs") as Button;
        //private GridView grdSearchResults => FindControlRecursive(Page, "grdSearchResults") as GridView;
        //private Label lblJobTitle => FindControlRecursive(Page, "lblJobTitle") as Label;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (int.TryParse(Request.QueryString["id"], out int id) && id > 0)
                {
                    if (this.hfJobId != null)
                    {
                        this.hfJobId.Value = id.ToString();
                    }
                    else
                    {
                        // fallback to ViewState if the hidden field is not present
                        ViewState["JobId"] = id.ToString();
                    }

                    // If a job id was passed via querystring, show the apply panel and populate title if possible.
                    ShowApplyForJob(id);
                }
                else
                {
                    // No job selected — keep search visible, apply panel hidden
                    if (pnlApply != null) pnlApply.Visible = false;
                }
            }
        }

        // Search button - binds matching jobs to the search results grid
        protected void btnSearchJobs_Click(object sender, EventArgs e)
        {
            var title = txtSearchTitle?.Text?.Trim() ?? string.Empty;
            var location = txtSearchLocation?.Text?.Trim() ?? string.Empty;

            // Use repository paging method to retrieve a reasonable number of results (first page)
            int total;
            var results = JobRepository.GetPaged(title, location, string.Empty, 1, 100, out total);

            var grid = grdSearchResults;
            if (grid != null)
            {
                grid.DataSource = results;
                grid.DataBind();
            }

            // Ensure the apply panel is hidden until a job is selected
            if (pnlApply != null) pnlApply.Visible = false;
        }

        // Handle the Apply link in search results - show the apply form for the selected job
        protected void grdSearchResults_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SelectJob")
            {
                if (!int.TryParse(e.CommandArgument?.ToString(), out int jobId) || jobId <= 0) return;

                string jobTitle = null;
                // Try to extract title from the row that raised the command
                if (e.CommandSource is Control src)
                {
                    var row = src.NamingContainer as GridViewRow;
                    if (row != null)
                    {
                        // Column layout: 0=JobId, 1=Title, ...
                        if (row.Cells.Count > 1) jobTitle = row.Cells[1].Text;
                    }
                }

                // Set hidden field or ViewState fallback
                if (this.hfJobId != null) this.hfJobId.Value = jobId.ToString();
                else ViewState["JobId"] = jobId.ToString();

                // Populate job title label
                if (lblJobTitle != null)
                {
                    lblJobTitle.Text = !string.IsNullOrEmpty(jobTitle) ? HttpUtility.HtmlEncode(jobTitle) : $"Job #{jobId}";
                }

                // Show apply panel
                if (pnlApply != null) pnlApply.Visible = true;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Use null-conditional operator so compilation succeeds when controls are missing
            if (lblUploadError != null) lblUploadError.Text = string.Empty;
            if (lblResult != null) lblResult.Text = string.Empty;

            if (!Page.IsValid) return;

            // server-side validation for file upload
            var resumeControl = fuResume;
            if (resumeControl == null || !resumeControl.HasFile)
            {
                if (lblUploadError != null)
                    lblUploadError.Text = "Please upload your resume.";
                return;
            }

            var ext = Path.GetExtension(resumeControl.FileName).ToLowerInvariant();
            if (Array.IndexOf(AllowedExtensions, ext) < 0)
            {
                if (lblUploadError != null)
                    lblUploadError.Text = "Unsupported file type. Allowed types: PDF, DOC, DOCX.";
                return;
            }

            var postedFile = resumeControl.PostedFile;
            if (postedFile == null || postedFile.ContentLength <= 0 || postedFile.ContentLength > MaxFileBytes)
            {
                if (lblUploadError != null)
                    lblUploadError.Text = "File is too large. Maximum 4 MB allowed.";
                return;
            }

            // obtain jobId from hidden field or ViewState fallback
            string jobIdValue = this.hfJobId?.Value ?? (ViewState["JobId"] as string);
            if (!int.TryParse(jobIdValue, out int jobId) || jobId <= 0)
            {
                if (lblUploadError != null)
                    lblUploadError.Text = "Invalid job selected.";
                return;
            }

            try
            {
                // Ensure Uploads folder exists
                var uploadsFolder = Server.MapPath("~/Uploads");
                if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

                // Save file with unique name
                var uniqueName = Guid.NewGuid().ToString("N") + ext;
                var physicalPath = Path.Combine(uploadsFolder, uniqueName);
                resumeControl.SaveAs(physicalPath);

                // store virtual/absolute path to the file for retrieval
                var resumeVirtualPath = VirtualPathUtility.ToAbsolute("~/Uploads/" + uniqueName);

                var application = new Application
                {
                    JobId = jobId,
                    ApplicantName = txtName?.Text?.Trim(),
                    Email = txtEmail?.Text?.Trim(),
                    Phone = txtPhone?.Text?.Trim(),
                    CoverLetter = txtCover?.Text?.Trim(),
                    ResumePath = resumeVirtualPath,
                    AppliedDate = DateTime.UtcNow
                };

                // insert into database (JobRepository.InsertApplication returns new id)
                var newId = JobRepository.InsertApplication(application);

                if (lblResult != null)
                    lblResult.Text = "Application submitted. Thank you!";
                if (btnSubmit != null)
                    btnSubmit.Enabled = false;
            }
            catch (Exception)
            {
                // in production log the exception
                if (lblUploadError != null)
                    lblUploadError.Text = "An error occurred while submitting your application. Please try again later.";
            }
        }

        // Show apply panel and populate title if possible (used on Page_Load when ?id=... is provided)
        private void ShowApplyForJob(int jobId)
        {
            string title = null;

            // Attempt to retrieve title via repository if such method exists — guarded by try/catch to avoid compile-time assumptions.
            try
            {
                // If the repository exposes a Get(int) or GetById, uncomment and use it:
                // var job = JobRepository.Get(jobId);
                // if (job != null) title = job.Title;

                // Fallback: use a generic label if repository lookup isn't available
            }
            catch
            {
                // ignore and fallback
            }

            if (hfJobId != null) hfJobId.Value = jobId.ToString();
            else ViewState["JobId"] = jobId.ToString();

            if (lblJobTitle != null) lblJobTitle.Text = !string.IsNullOrEmpty(title) ? HttpUtility.HtmlEncode(title) : $"Job #{jobId}";
            if (pnlApply != null) pnlApply.Visible = true;
        }

        // Recursive control finder to avoid missing-designer-field compilation errors
        private static Control FindControlRecursive(Control root, string id)
        {
            if (root == null || string.IsNullOrEmpty(id)) return null;
            var found = root.FindControl(id);
            if (found != null) return found;

            foreach (Control child in root.Controls)
            {
                var result = FindControlRecursive(child, id);
                if (result != null) return result;
            }
            return null;
        }
    }

    // Minimal model to allow compilation - replace with the real model in your project.
    public class Application
    {
        public int JobId { get; set; }
        public string ApplicantName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CoverLetter { get; set; }
        public string ResumePath { get; set; }
        public DateTime AppliedDate { get; set; }
    }
}