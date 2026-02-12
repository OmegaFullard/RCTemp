using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

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

    public class SavedSearch
    {
        public int Id { get; set; }
        public string SearchName { get; set; }
        public string Query { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class JobAlert
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }

    public static class JobRepository
    {
        // private static readonly List<Job> _jobs;
        // private static readonly Dictionary<string, List<SavedSearch>> _savedSearchesByUser = new Dictionary<string, List<SavedSearch>>(StringComparer.OrdinalIgnoreCase);
        // private static readonly Dictionary<string, List<JobAlert>> _alertsByUser = new Dictionary<string, List<JobAlert>>(StringComparer.OrdinalIgnoreCase);
       // private static int _nextSavedSearchId = 1;
        //private static int _nextAlertId = 1;
        private static string GetConnectionString()
        {
            var cs = ConfigurationManager.ConnectionStrings["RCTempConnection"];
            if (cs == null) throw new InvalidOperationException("Connection string 'RCTempConnection' not found.");
            return cs.ConnectionString;
        }

       

        public static int InsertApplication(Application application)
        {
            // Implement your database insert logic here.
            // For demonstration, return a dummy id.
            return 1;
        }
        public static List<Job> GetPaged(string titleFilter, string locationFilter, string typeFilter, int pageIndex, int pageSize, out int totalCount)
        {
            var list = new List<Job>();
            totalCount = 0;

            var where = new StringBuilder("WHERE 1=1");
            var hasTitle = !string.IsNullOrWhiteSpace(titleFilter);
            var hasLocation = !string.IsNullOrWhiteSpace(locationFilter);
            var hasType = !string.IsNullOrWhiteSpace(typeFilter);

            // Build WHERE clause
            if (hasTitle)
            {
                where.Append(" AND Title LIKE @title");
            }
            if (hasLocation)
            {
                where.Append(" AND Location LIKE @location");
            }
            if (hasType)
            {
                where.Append(" AND EmploymentType LIKE @type");
            }

            var offset = (Math.Max(1, pageIndex) - 1) * pageSize;

            var countSql = $"SELECT COUNT(*) FROM Jobs {where}";
            var pageSql = $@"
SELECT JobId, Title, Description, Location, EmploymentType, PostedDate, IsActive
FROM Jobs
{where}
ORDER BY PostedDate DESC
OFFSET @offset ROWS
FETCH NEXT @pageSize ROWS ONLY;";

            using (var conn = new SqlConnection(GetConnectionString()))
            using (var countCmd = new SqlCommand(countSql, conn))
            using (var pageCmd = new SqlCommand(pageSql, conn))
            {
                // Add filter parameters to countCmd
                if (hasTitle)
                    countCmd.Parameters.AddWithValue("@title", "%" + titleFilter.Trim() + "%");
                if (hasLocation)
                    countCmd.Parameters.AddWithValue("@location", "%" + locationFilter.Trim() + "%");
                if (hasType)
                    countCmd.Parameters.AddWithValue("@type", "%" + typeFilter.Trim() + "%");

                // Add filter parameters to pageCmd (separate instances)
                if (hasTitle)
                    pageCmd.Parameters.AddWithValue("@title", "%" + titleFilter.Trim() + "%");
                if (hasLocation)
                    pageCmd.Parameters.AddWithValue("@location", "%" + locationFilter.Trim() + "%");
                if (hasType)
                    pageCmd.Parameters.AddWithValue("@type", "%" + typeFilter.Trim() + "%");
                
                // Add pagination parameters
                pageCmd.Parameters.AddWithValue("@offset", offset);
                pageCmd.Parameters.AddWithValue("@pageSize", pageSize);

                conn.Open();

                // Get total count
                totalCount = Convert.ToInt32(countCmd.ExecuteScalar());

                // Get paged results
                using (var rdr = pageCmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(new Job
                        {
                            JobId = Convert.ToInt32(rdr["JobId"]),
                            Title = rdr["Title"] as string,
                            Description = rdr["Description"] as string,
                            Location = rdr["Location"] as string,
                            EmploymentType = rdr["EmploymentType"] as string,
                            PostedDate = (DateTime)rdr["PostedDate"],
                            IsActive = Convert.ToBoolean(rdr["IsActive"])
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
                            JobId = Convert.ToInt32(rdr["JobId"]),
                            Title = rdr["Title"] as string,
                            Description = rdr["Description"] as string,
                            Location = rdr["Location"] as string,
                            EmploymentType = rdr["EmploymentType"] as string,
                            PostedDate = (DateTime)rdr["PostedDate"],
                            IsActive = Convert.ToBoolean(rdr["IsActive"])
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
    }
}