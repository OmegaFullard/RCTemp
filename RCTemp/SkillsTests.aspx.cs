using Humanizer;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using RCTemp.PdfFonts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using Telerik.Windows.Documents.Spreadsheet.Expressions.Functions;
using static Humanizer.In;
using static System.Net.Mime.MediaTypeNames;

namespace RCTemp
{
    public partial class SkillsTests : Page
    {
        protected void btnDownload_Click(object sender, EventArgs e)
        {
            GenerateAssessmentPdfAndRedirect();
        }

        private void GenerateAssessmentPdfAndRedirect()
        {
            try
            {
                // Ensure downloads folder exists
                string downloadsPath = Server.MapPath("~/downloads");
                if (!Directory.Exists(downloadsPath))
                {
                    Directory.CreateDirectory(downloadsPath);
                }

                string pdfPath = Path.Combine(downloadsPath, "Skills Assessment Test.pdf");

                // Example lines to write to PDF (replace with your actual data source)
                var lines = new List<string>
                {
                    "Royal City Temp - Assessment Test",
                     "Software Development",
                    "Math aptitude (word problems)",
                    "Coding problem (algorithmic exercise)",
                    "Excel / data task",
                    "Customer Service Scenario (Behavioral)",
                   
                };

                // Create PDF document
                var doc = new PdfDocument();
                doc.Info.Title = "Royal City Temp - Skills Assessment Test";

                var page = doc.AddPage();
                page.Size = PdfSharp.PageSize.A4;
                var gfx = XGraphics.FromPdfPage(page);

                var fontTitle = new XFont("Arial", 16);
                var fontNormal = new XFont("Arial", 11);

                double marginLeft = 40;
                double y = 40;

                // Draw title
                gfx.DrawString(lines[0], fontTitle, XBrushes.Black, new XRect(marginLeft, y, page.Width.Point - 80, 30), XStringFormats.TopLeft);
                y += 30;

                // Draw body lines
                for (int i = 1; i < lines.Count; i++)
                {
                    var text = lines[i];
                    if (string.IsNullOrWhiteSpace(text))
                    {
                        y += 10;
                        continue;
                    }

                    var layoutRect = new XRect(marginLeft, y, page.Width.Point - 80, page.Height.Point - y - 40);
                    var tf = new XTextFormatter(gfx);
                    tf.DrawString(text, fontNormal, XBrushes.Black, layoutRect, XStringFormats.TopLeft);

                    var size = gfx.MeasureString(text, fontNormal);
                    y += size.Height + 8;

                    if (y > page.Height.Point - 60)
                    {
                        page = doc.AddPage();
                        page.Size = PdfSharp.PageSize.A4;
                        gfx = XGraphics.FromPdfPage(page);
                        y = 40;
                    }
                }

                // Save PDF
                doc.Save(pdfPath);
                doc.Close();

                // Redirect to the generated PDF
                string relativeUrl = ResolveUrl("~/downloads/SkillsAssessmentTest.pdf");
                Response.Redirect(relativeUrl, false);
            }
            catch (Exception)
            {
                //lblStatus.ForeColor = System.Drawing.Color.Red;
                //lblStatus.Text = "Failed to create PDF: " + ex.Message;
            }
        }
    }
}