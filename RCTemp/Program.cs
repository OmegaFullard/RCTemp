RCTemp.AlertWorker\Program.cs
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace RCTemp.AlertWorker
{
    class Program
    {
        static string ConnString = ConfigurationManager.ConnectionStrings["RCTempConnection"].ConnectionString;
        static string SiteBaseUrl = ConfigurationManager.AppSettings["SiteBaseUrl"] ?? "https://localhost/";
        static string SmtpHost = ConfigurationManager.AppSettings["SmtpHost"];
        static int SmtpPort = int.TryParse(ConfigurationManager.AppSettings["SmtpPort"], out var p) ? p : 25;
        static bool SmtpSsl = bool.TryParse(ConfigurationManager.AppSettings["SmtpEnableSsl"], out var s) ? s : false;
        static string SmtpUser = ConfigurationManager.AppSettings["SmtpUser"];
        static string SmtpPass = ConfigurationManager.AppSettings["SmtpPass"];
        static string EmailFrom = ConfigurationManager.AppSettings["EmailFrom"];

        static void Main(string[] args)
        {
            Console.WriteLine($"Alert worker starting at {DateTime.UtcNow:u}");
            try
            {
                var alerts = LoadActiveAlerts();
                Console.WriteLine($"Found {alerts.Count} active alert(s).");

                foreach (var alert in alerts)
                {
                    try
                    {
                        if (!IsAlertDue(alert)) { Console.WriteLine($"Skipping alert {alert.JobAlertId} (not due)."); continue; }

                        var jobs = LoadJobsForAlert(alert, 50);
                        Console.WriteLine($"Alert {alert.JobAlertId}: {jobs.Count} matching job(s).");

                        if (jobs.Count == 0)
                        {
                            // Nothing to send; update LastSentDate to avoid repeated checks if you prefer, or skip update to allow future matches
                            Console.WriteLine($"No jobs for alert {alert.JobAlertId}; skipping send.");
                            continue;
                        }

                        // look up recipient email - assumes Username is an email or you have Users table with Email column
                        var recipient = LookupUserEmail(alert.Username) ?? alert.Username;
                        if (string.IsNullOrWhiteSpace(recipient))
                        {
                            Console.WriteLine($"No recipient email for username '{alert.Username}' - skipping alert {alert.JobAlertId}.");
                            continue;
                        }

                        var subject = $"Job Alert — {jobs.Count} new match(es)";
                        var body = BuildEmailBody(alert, jobs);

                        SendEmail(recipient, subject, body);

                        UpdateAlertLastSent(alert.JobAlertId);
                        Console.WriteLine($"Sent alert {alert.JobAlertId} to {recipient}.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error processing alert {alert.JobAlertId}: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fatal error: " + ex);
            }

            Console.WriteLine($"Alert worker finished at {DateTime.UtcNow:u}");
        }

        #region Data access / helper methods

        class JobAlert
        {
            public int JobAlertId { get; set; }
            public string Username { get; set; }
            public string TitleFilter { get; set; }
            public string LocationFilter { get; set; }
            public string TypeFilter { get; set; }
            public string CompanyFilter { get; set; }
            public string Frequency { get; set; } // Daily / Weekly
            public bool IsActive { get; set; }
            public DateTime? LastSentDate { get; set; }
        }

        class JobInfo
        {
            public int JobId { get; set; }
            public string Title { get; set; }
            public string CompanyName { get; set; }
            public string Location { get; set; }
            public string EmploymentType { get; set; }
            public DateTime PostedDate { get; set; }
        }

        static List<JobAlert> LoadActiveAlerts()
        {
            var list = new List<JobAlert>();
            using (var conn = new SqlConnection(ConnString))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT JobAlertId, Username, TitleFilter, LocationFilter, TypeFilter, CompanyFilter, Frequency, IsActive, LastSentDate
                                    FROM JobAlerts
                                    WHERE IsActive = 1";
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(new JobAlert
                        {
                            JobAlertId = (int)rdr["JobAlertId"],
                            Username = rdr["Username"] as string,
                            TitleFilter = rdr["TitleFilter"] as string,
                            LocationFilter = rdr["LocationFilter"] as string,
                            TypeFilter = rdr["TypeFilter"] as string,
                            CompanyFilter = rdr["CompanyFilter"] as string,
                            Frequency = rdr["Frequency"] as string,
                            IsActive = Convert.ToBoolean(rdr["IsActive"]),
                            LastSentDate = rdr["LastSentDate"] as DateTime?
                        });
                    }
                }
            }
            return list;
        }

        static bool IsAlertDue(JobAlert alert)
        {
            if (!alert.LastSentDate.HasValue) return true;
            var last = alert.LastSentDate.Value;
            if (string.Equals(alert.Frequency, "Weekly", StringComparison.OrdinalIgnoreCase))
            {
                return last.AddDays(7) <= DateTime.UtcNow;
            }
            // default daily
            return last.AddDays(1) <= DateTime.UtcNow;
        }

        static List<JobInfo> LoadJobsForAlert(JobAlert alert, int maxResults = 50)
        {
            var list = new List<JobInfo>();
            var where = new StringBuilder("WHERE IsActive = 1");
            var parameters = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(alert.TitleFilter))
            {
                where.Append(" AND Title LIKE @title");
                parameters.Add(new SqlParameter("@title", "%" + alert.TitleFilter.Trim() + "%"));
            }
            if (!string.IsNullOrWhiteSpace(alert.LocationFilter))
            {
                where.Append(" AND Location LIKE @location");
                parameters.Add(new SqlParameter("@location", "%" + alert.LocationFilter.Trim() + "%"));
            }
            if (!string.IsNullOrWhiteSpace(alert.TypeFilter))
            {
                where.Append(" AND EmploymentType LIKE @type");
                parameters.Add(new SqlParameter("@type", "%" + alert.TypeFilter.Trim() + "%"));
            }
            if (!string.IsNullOrWhiteSpace(alert.CompanyFilter))
            {
                where.Append(" AND CompanyName = @company");
                parameters.Add(new SqlParameter("@company", alert.CompanyFilter));
            }

            var sql = $@"
SELECT TOP (@max) JobId, Title, CompanyName, Location, EmploymentType, PostedDate
FROM Jobs
{where}
ORDER BY PostedDate DESC;";

            using (var conn = new SqlConnection(ConnString))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@max", maxResults);
                foreach (var p in parameters) cmd.Parameters.Add(p);
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(new JobInfo
                        {
                            JobId = (int)rdr["JobId"],
                            Title = rdr["Title"] as string,
                            CompanyName = rdr["CompanyName"] as string,
                            Location = rdr["Location"] as string,
                            EmploymentType = rdr["EmploymentType"] as string,
                            PostedDate = (DateTime)rdr["PostedDate"]
                        });
                    }
                }
            }
            return list;
        }

        static string LookupUserEmail(string username)
        {
            // If your Users table stores emails separately, query it here. Otherwise assume username is email.
            // Attempt to look up Users.Email if exists.
            try
            {
                using (var conn = new SqlConnection(ConnString))
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT TOP 1 Username FROM Users WHERE Username = @u"; // change to Email if available
                    cmd.Parameters.AddWithValue("@u", username);
                    conn.Open();
                    var obj = cmd.ExecuteScalar();
                    if (obj != null) return obj.ToString();
                }
            }
            catch
            {
                // ignore and fallback
            }
            return null;
        }

        static string BuildEmailBody(JobAlert alert, List<JobInfo> jobs)
        {
            var sb = new StringBuilder();
            sb.Append("<html><body>");
            sb.AppendFormat("<p>Here are the latest job matches for your alert (Frequency: {0}).</p>", alert.Frequency);
            sb.Append("<table border='0' cellpadding='6' cellspacing='0' style='border-collapse:collapse;width:100%'>");
            sb.Append("<thead><tr><th align='left'>Title</th><th align='left'>Company</th><th align='left'>Location</th><th align='left'>Posted</th></tr></thead><tbody>");
            foreach (var j in jobs)
            {
                var url = SiteBaseUrl.TrimEnd('/') + $"/JobDetails.aspx?id={j.JobId}";
                sb.Append("<tr>");
                sb.AppendFormat("<td><a href=\"{0}\">{1}</a></td>", WebUtility.HtmlEncode(url), WebUtility.HtmlEncode(j.Title));
                sb.AppendFormat("<td>{0}</td>", WebUtility.HtmlEncode(j.CompanyName));
                sb.AppendFormat("<td>{0}</td>", WebUtility.HtmlEncode(j.Location));
                sb.AppendFormat("<td>{0:yyyy-MM-dd}</td>", j.PostedDate);
                sb.Append("</tr>");
            }
            sb.Append("</tbody></table>");
            sb.Append("<p>If you no longer want to receive these alerts, edit your alerts in the client portal.</p>");
            sb.Append("</body></html>");
            return sb.ToString();
        }

        static void SendEmail(string to, string subject, string htmlBody)
        {
            using (var msg = new MailMessage())
            {
                msg.From = new MailAddress(EmailFrom);
                msg.To.Add(new MailAddress(to));
                msg.Subject = subject;
                msg.IsBodyHtml = true;
                msg.Body = htmlBody;

                using (var client = new SmtpClient(SmtpHost, SmtpPort))
                {
                    client.EnableSsl = SmtpSsl;
                    if (!string.IsNullOrWhiteSpace(SmtpUser))
                    {
                        client.Credentials = new NetworkCredential(SmtpUser, SmtpPass);
                    }
                    client.Send(msg);
                }
            }
        }

        static void UpdateAlertLastSent(int alertId)
        {
            using (var conn = new SqlConnection(ConnString))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "UPDATE JobAlerts SET LastSentDate = GETUTCDATE() WHERE JobAlertId = @id";
                cmd.Parameters.AddWithValue("@id", alertId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        #endregion
    }
}