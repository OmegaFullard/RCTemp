using System;
using System.IO;
using System.Web;
using System.Web.UI;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;

namespace RCTemp
{
    public partial class SkillsTests : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ms = GeneratePdf())
                {
                    Response.Clear();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("Content-Disposition", "attachment; filename=SkillsTests.pdf");
                    Response.BinaryWrite(ms.ToArray());
                    Response.Flush();
                    Response.End();
                }
            }
            catch (HttpException)
            {
                // ignore client disconnects
            }
        }

        private MemoryStream GeneratePdf()
        {
            var stream = new MemoryStream();
            var doc = new PdfDocument();
            doc.Info.Title = "Skills Tests - Royal City Temporary Agency";

            // fonts
            XFont titleFont = new XFont("Verdana", 20, XFontStyleEx.Bold);
            XFont subtitleFont = new XFont("Verdana", 12, XFontStyleEx.Regular);
            XFont headerFont = new XFont("Verdana", 12, XFontStyleEx.Bold);
            XFont bodyFont = new XFont("Verdana", 10, XFontStyleEx.Regular);
            XFont footerFont = new XFont("Verdana", 8, XFontStyleEx.Regular);

            // Candidate instructions (cover page)
            string instructions = "Candidate instructions:\n\n" +
                                  "• Time yourself for each section and write your answers clearly. For coding problems, provide pseudocode or runnable code and explain complexity.\n" +
                                  "• Show your work on math questions and include assumptions.\n" +
                                  "• For Excel/data tasks, describe steps and provide formulas or screenshots when possible.\n" +
                                  "• For behavioral questions, use the STAR method (Situation, Task, Action, Result).\n\n" +
                                  "Good luck!";

            // content blocks and sample answers
            var sections = new[]
            {
                new {
                    Heading = "1) Math Aptitude (10 minutes)",
                    Body = "Solve the following problems. Show your work and final answers.\n\n" +
                           "a) A team of 6 people completes a task in 8 days. How many days would 4 people take assuming the same rate?\n\n" +
                           "b) You place $5,000 in an account that yields 4% simple interest per year. How much interest do you earn in 3 years?",
                    Sample = "Sample Answers:\n\na) Work: total person-days = 6 * 8 = 48 person-days. With 4 people, days = 48 / 4 = 12 days.\n\n" +
                             "Answer: 12 days.\n\n" +
                             "b) Simple interest = principal * rate * time = 5000 * 0.04 * 3 = $600.\n\n" +
                             "Answer: $600."
                },
                new {
                    Heading = "2) Coding Problem (30 minutes)",
                    Body = "Write a function that, given an array of integers, returns the length of the longest sequence of consecutive integers (order of input not guaranteed).\n\n" +
                           "Example: [100, 4, 200, 1, 3, 2] -> longest consecutive sequence is [1,2,3,4] length = 4.\n\n" +
                           "Instructions: Provide clear pseudocode or runnable code in your preferred language. Discuss time and space complexity.",
                    Sample = "Sample Answer (concept):\n\nUse a hash set of all numbers. For each number, if num-1 not in set, iterate forward num+1, num+2... counting length while values exist in set. Track max length.\n\nPseudocode:\nset = set(nums)\nmaxLen = 0\nfor n in nums:\n  if n-1 not in set:\n    length = 1\n    while n+length in set:\n      length++\n    maxLen = max(maxLen, length)\nreturn maxLen\n\nTime complexity: O(n) average, Space: O(n)."
                },
                new {
                    Heading = "3) Excel / Data Task (20 minutes)",
                    Body = "You have a spreadsheet containing sales records with columns: Date, Salesperson, Region, Amount.\n\n" +
                           "Tasks: (a) Create a pivot that shows total Amount by Region. (b) Using formulas, compute the 3-month rolling average for Amount. (c) Describe how you'd flag outliers.",
                    Sample = "Sample Guidance:\n\na) Pivot: Rows = Region, Values = Sum of Amount.\n\nb) 3-month rolling average (assuming Amount in column D and Date sorted): use AVERAGEIF with relative ranges or use AVERAGE(OFFSET(currentRow,-2,0,3,1)) and handle start-of-data with conditional logic.\n\nc) Flag outliers: compute z-score or IQR (Q1/Q3). Mark rows where Amount > Q3 + 1.5*IQR or z-score > 3."
                },
                new {
                    Heading = "4) Customer Service Scenario (Behavioral)",
                    Body = "Scenario: A long-term client calls frustrated about a repeated billing error. They demand an immediate refund and threaten to take business elsewhere.\n\n" +
                           "Question: Using the STAR method, explain how you would handle the call, what steps you would take to resolve the issue, and how you'd prevent recurrence.",
                    Sample = "Sample STAR Answer:\n\nSituation: Long-term client receiving repeated incorrect invoices.\nTask: Resolve client's concern, issue refund if appropriate, and restore trust.\nAction: Listen empathetically, apologize, verify account details and previous invoices, escalate to billing team, calculate refund and apply immediately, and offer interim compensation (if policy allows). Communicate timeline and follow up in writing.\nResult: Client received refund within 48 hours, billing root cause fixed (misapplied tax code), and client continued engagement; reduced similar errors by 80% after a process fix."
                }
            };

            // helper for drawing a page with header/footer and wrapped text
            int pageNumber = 0;
            Action<PdfPage, XGraphics, string, string, bool> drawContent = (page, gfx, heading, body, drawHeader) =>
            {
                double margin = 40;
                double y = margin;
                double width = page.Width.Point - margin * 2;

                var tf = new XTextFormatter(gfx);

                // optional header (company name and line)
                if (drawHeader)
                {
                    gfx.DrawString("Royal City Temporary Agency", headerFont, XBrushes.DarkSlateGray, new XRect(margin, 20, width, 20), XStringFormats.TopLeft);
                    gfx.DrawLine(XPens.Gray, margin, 42, page.Width.Point - margin, 42);
                }

                y = drawHeader ? 60 : y;

                // heading
                gfx.DrawString(heading, headerFont, XBrushes.Black, new XRect(margin, y, width, 20), XStringFormats.TopLeft);
                y += 24;

                // body (wrapped)
                var bodyRect = new XRect(margin, y, width, page.Height.Point - y - margin - 20);
                tf.DrawString(body, bodyFont, XBrushes.Black, bodyRect, XStringFormats.TopLeft);

                // footer with page number
                pageNumber++;
                var footerText = $"Page {pageNumber}";
                gfx.DrawString(footerText, footerFont, XBrushes.Gray, new XRect(margin, page.Height.Point - margin + 5, width, 20), XStringFormats.Center);
            };

            // COVER PAGE
            {
                var page = doc.AddPage();
                page.Size = PdfSharp.PageSize.Letter;
                var gfx = XGraphics.FromPdfPage(page);

                double margin = 40;
                double width = page.Width.Point - margin * 2;
                double y = margin;

                // try draw logo (top-right)
                try
                {
                    var logoPath = Server.MapPath("~/images/RCLogo.png");
                    if (File.Exists(logoPath))
                    {
                        using (var img = XImage.FromFile(logoPath))
                        {
                            double logoWidth = 120;
                            double ratio = img.PixelHeight > 0 ? img.PixelWidth / (double)img.PixelHeight : 1;
                            double logoHeight = logoWidth / ratio;
                            gfx.DrawImage(img, page.Width.Point - margin - logoWidth, margin, logoWidth, logoHeight);
                        }
                    }
                }
                catch
                {
                    // ignore missing logo or load errors
                }

                // title
                gfx.DrawString("Skills Tests", titleFont, XBrushes.DarkBlue, new XRect(margin, y, width, 40), XStringFormats.TopLeft);
                y += 48;

                gfx.DrawString("Example tests for candidate screening. Includes math, coding, Excel/data and behavioral scenarios.", subtitleFont, XBrushes.Black, new XRect(margin, y, width, 40), XStringFormats.TopLeft);
                y += 36;

                // instructions block
                var tf = new XTextFormatter(gfx);
                var instrRect = new XRect(margin, y, width, page.Height.Point - y - margin - 20);
                tf.DrawString(instructions, bodyFont, XBrushes.Black, instrRect, XStringFormats.TopLeft);

                // footer
                pageNumber++;
                gfx.DrawString($"Page {pageNumber}", footerFont, XBrushes.Gray, new XRect(margin, page.Height.Point - margin + 5, width, 20), XStringFormats.Center);
            }

            // SECTIONS + SAMPLE ANSWER PAGES
            for (int i = 0; i < sections.Length; i++)
            {
                // test page
                {
                    var page = doc.AddPage();
                    page.Size = PdfSharp.PageSize.Letter;
                    var gfx = XGraphics.FromPdfPage(page);
                    drawContent(page, gfx, sections[i].Heading, sections[i].Body, true);
                }

                // sample answers page
                {
                    var page = doc.AddPage();
                    page.Size = PdfSharp.PageSize.Letter;
                    var gfx = XGraphics.FromPdfPage(page);
                    drawContent(page, gfx, "Sample Answers — " + sections[i].Heading, sections[i].Sample, true);
                }
            }

            // Save document to stream
            doc.Save(stream, false);
            stream.Position = 0;
            return stream;
        }
    }
}