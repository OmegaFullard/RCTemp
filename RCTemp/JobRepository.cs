using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace RCTemp
{
    public class Job
    {
        public int JobId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string EmploymentType { get; set; }
        public DateTime PostedDate { get; set; }
        public bool IsActive { get; set; }
    }
    public static class JobRepository
    {
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["RCTempConnection"].ConnectionString;
        }

 

            public static List<Job> GetAll()
            {
                var list = new List<Job>();
                using (var conn = new SqlConnection(GetConnectionString()))
                using (var cmd = new SqlCommand("SELECT JobId, Title, Description, Location, EmploymentType, PostedDate, IsActive FROM Jobs ORDER BY PostedDate DESC", conn))
                {
                    conn.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            list.Add(new Job
                            {
                                JobId = (int)rdr["JobId"],
                                Title = rdr["Title"] as string,
                                Description = rdr["Description"] as string,
                                Location = rdr["Location"] as string,
                                EmploymentType = rdr["EmploymentType"] as string,
                                PostedDate = (DateTime)rdr["PostedDate"],
                                IsActive = (bool)rdr["IsActive"]
                            });
                        }
                    }
                }
                return list;
            }

            public static Job GetById(int id)
            {
                using (var conn = new SqlConnection(GetConnectionString()))
                using (var cmd = new SqlCommand("SELECT JobId, Title, Description, Location, EmploymentType, PostedDate, IsActive FROM Jobs WHERE JobId = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            return new Job
                            {
                                JobId = (int)rdr["JobId"],
                                Title = rdr["Title"] as string,
                                Description = rdr["Description"] as string,
                                Location = rdr["Location"] as string,
                                EmploymentType = rdr["EmploymentType"] as string,
                                PostedDate = (DateTime)rdr["PostedDate"],
                                IsActive = (bool)rdr["IsActive"]
                            };
                        }
                    }
                }
                return null;
            }

            public static int Insert(Job job)
            {
                using (var conn = new SqlConnection(GetConnectionString()))
                using (var cmd = new SqlCommand(@"INSERT INTO Jobs (Title, Description, Location, EmploymentType, PostedDate, IsActive)
                                             VALUES (@title, @desc, @loc, @type, @posted, @active);
                                             SELECT SCOPE_IDENTITY();", conn))
                {
                    cmd.Parameters.AddWithValue("@title", job.Title ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@desc", job.Description ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@loc", job.Location ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@type", job.EmploymentType ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@posted", job.PostedDate == default ? DateTime.UtcNow : job.PostedDate);
                    cmd.Parameters.AddWithValue("@active", job.IsActive);
                    conn.Open();
                    var result = cmd.ExecuteScalar();
                    return Convert.ToInt32(result);
                }
            }

            public static void Update(Job job)
            {
                using (var conn = new SqlConnection(GetConnectionString()))
                using (var cmd = new SqlCommand(@"UPDATE Jobs SET Title=@title, Description=@desc, Location=@loc, EmploymentType=@type, PostedDate=@posted, IsActive=@active
                                             WHERE JobId=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@title", job.Title ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@desc", job.Description ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@loc", job.Location ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@type", job.EmploymentType ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@posted", job.PostedDate);
                    cmd.Parameters.AddWithValue("@active", job.IsActive);
                    cmd.Parameters.AddWithValue("@id", job.JobId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            public static void Delete(int id)
            {
                using (var conn = new SqlConnection(GetConnectionString()))
                using (var cmd = new SqlCommand("DELETE FROM Jobs WHERE JobId = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            public static List<Job> GetPaged(string title, string location, string type, int page, int pageSize, out int total)
            {
                // Example implementation: filter, paginate, and count
                var allJobs = GetAll();
                var filtered = allJobs;

                if (!string.IsNullOrWhiteSpace(title))
                    filtered = filtered.FindAll(j => j.Title != null && j.Title.IndexOf(title, StringComparison.OrdinalIgnoreCase) >= 0);
                if (!string.IsNullOrWhiteSpace(location))
                    filtered = filtered.FindAll(j => j.Location != null && j.Location.IndexOf(location, StringComparison.OrdinalIgnoreCase) >= 0);
                if (!string.IsNullOrWhiteSpace(type))
                    filtered = filtered.FindAll(j => j.EmploymentType != null && j.EmploymentType.IndexOf(type, StringComparison.OrdinalIgnoreCase) >= 0);

                total = filtered.Count;
                return filtered
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
    }
}