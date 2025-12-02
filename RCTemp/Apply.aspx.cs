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
        private HiddenField hfJobId => FindControlRecursive(Page, "hfJobId") as HiddenField;
        private Label lblUploadError => FindControlRecursive(Page, "lblUploadError") as Label;
        private Label lblResult => FindControlRecursive(Page, "lblResult") as Label;
        private FileUpload fuResume => FindControlRecursive(Page, "fuResume") as FileUpload;
        private TextBox txtName => FindControlRecursive(Page, "txtName") as TextBox;
        private TextBox txtEmail => FindControlRecursive(Page, "txtEmail") as TextBox;
        private TextBox txtPhone => FindControlRecursive(Page, "txtPhone") as TextBox;
        private TextBox txtCover => FindControlRecursive(Page, "txtCover") as TextBox;
        private Button btnSubmit => FindControlRecursive(Page, "btnSubmit") as Button;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (int.TryParse(Request.QueryString["id"], out int id) && id > 0)
                {
                    if (hfJobId != null)
                    {
                        hfJobId.Value = id.ToString();
                    }
                    else
                    {
                        // fallback to ViewState if the hidden field is not present
                        ViewState["JobId"] = id.ToString();
                    }
                }
                else
                {
                    // No job selected — redirect back to jobs list
                   // Response.Redirect("Jobs.aspx");
                }
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
            string jobIdValue = hfJobId?.Value ?? (ViewState["JobId"] as string);
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