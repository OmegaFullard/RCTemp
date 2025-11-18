using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace RCTemp
{
    public partial class ResumeReview
    {
        public int ReviewId { get; set; }
        public string Username { get; set; }
        public string ApplicantName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? JobId { get; set; }
        public string JobTitle { get; set; }
        public string FilePath { get; set; }
        public string Status { get; set; }
        public string ReviewerComments { get; set; }
        public DateTime SubmittedDate { get; set; }
    }

    public static class ReviewRepository
    {
        private static string Conn => ConfigurationManager.ConnectionStrings["RCTempConnectionString"].ConnectionString;

        public static int Insert(ResumeReview r)
        {
            using (var conn = new SqlConnection(Conn))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
INSERT INTO ResumeReviews (Username, ApplicantName, Email, Phone, JobId, FilePath, Status, ReviewerComments, SubmittedDate)
VALUES (@u, @name, @email, @phone, @jobId, @file, @status, @comments, @submitted);
SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("@u", (object)r.Username ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@name", (object)r.ApplicantName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@email", (object)r.Email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@phone", (object)r.Phone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@jobId", (object)r.JobId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@file", r.FilePath);
                cmd.Parameters.AddWithValue("@status", (object)r.Status ?? "Pending");
                cmd.Parameters.AddWithValue("@comments", (object)r.ReviewerComments ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@submitted", r.SubmittedDate == default ? DateTime.UtcNow : r.SubmittedDate);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public static List<ResumeReview> GetAll(string statusFilter = null)
        {
            var list = new List<ResumeReview>();
            using (var conn = new SqlConnection(Conn))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
SELECT r.ReviewId, r.Username, r.ApplicantName, r.Email, r.Phone, r.JobId, r.FilePath, r.Status, r.ReviewerComments, r.SubmittedDate,
       ISNULL(j.Title,'') AS JobTitle
FROM ResumeReviews r
LEFT JOIN Jobs j ON r.JobId = j.JobId
WHERE (@status IS NULL OR r.Status = @status)
ORDER BY r.SubmittedDate DESC";
                cmd.Parameters.AddWithValue("@status", (object)statusFilter ?? DBNull.Value);
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(new ResumeReview
                        {
                            ReviewId = (int)rdr["ReviewId"],
                            Username = rdr["Username"] as string,
                            ApplicantName = rdr["ApplicantName"] as string,
                            Email = rdr["Email"] as string,
                            Phone = rdr["Phone"] as string,
                            JobId = rdr["JobId"] as int?,
                            FilePath = rdr["FilePath"] as string,
                            Status = rdr["Status"] as string,
                            ReviewerComments = rdr["ReviewerComments"] as string,
                            SubmittedDate = (DateTime)rdr["SubmittedDate"],
                            JobTitle = rdr["JobTitle"] as string
                        });
                    }
                }
            }
            return list;
        }

        public static ResumeReview GetById(int id)
        {
            using (var conn = new SqlConnection(Conn))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
SELECT r.ReviewId, r.Username, r.ApplicantName, r.Email, r.Phone, r.JobId, r.FilePath, r.Status, r.ReviewerComments, r.SubmittedDate,
       ISNULL(j.Title,'') AS JobTitle
FROM ResumeReviews r
LEFT JOIN Jobs j ON r.JobId = j.JobId
WHERE r.ReviewId = @id";
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        return new ResumeReview
                        {
                            ReviewId = (int)rdr["ReviewId"],
                            Username = rdr["Username"] as string,
                            ApplicantName = rdr["ApplicantName"] as string,
                            Email = rdr["Email"] as string,
                            Phone = rdr["Phone"] as string,
                            JobId = rdr["JobId"] as int?,
                            FilePath = rdr["FilePath"] as string,
                            Status = rdr["Status"] as string,
                            ReviewerComments = rdr["ReviewerComments"] as string,
                            SubmittedDate = (DateTime)rdr["SubmittedDate"],
                            JobTitle = rdr["JobTitle"] as string
                        };
                    }
                }
            }
            return null;
        }

        public static void UpdateStatus(int id, string status, string comments = null)
        {
            using (var conn = new SqlConnection(Conn))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "UPDATE ResumeReviews SET Status = @status, ReviewerComments = @comments WHERE ReviewId = @id";
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@comments", (object)comments ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void Delete(int id)
        {
            using (var conn = new SqlConnection(Conn))
            using (var cmd = conn.CreateCommand())
            {
                // get file path
                cmd.CommandText = "SELECT FilePath FROM ResumeReviews WHERE ReviewId = @id";
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                var obj = cmd.ExecuteScalar();
                var file = obj as string;
                conn.Close();

                // delete DB row
                using (var cmd2 = conn.CreateCommand())
                {
                    cmd2.CommandText = "DELETE FROM ResumeReviews WHERE ReviewId = @id";
                    cmd2.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                }

                // delete physical file if exists
                try
                {
                    if (!string.IsNullOrWhiteSpace(file))
                    {
                        var virtualPath = file.StartsWith("~/") ? file : "~" + file;
                        var physical = System.Web.HttpContext.Current.Server.MapPath(virtualPath);
                        if (System.IO.File.Exists(physical)) System.IO.File.Delete(physical);
                    }
                }
                catch { /* non-fatal */ }
            }
        }
    }
}