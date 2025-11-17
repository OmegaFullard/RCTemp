using System;
using System.Collections.Generic;

namespace RCTemp
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string PhotoUrl { get; set; }
        public string Bio { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }

    public static class EmployeeRepository
    {
        // Replace with DB calls as needed.
        public static List<Employee> GetAll()
        {
            return new List<Employee>
            {
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "Samantha",
                    LastName = "Reed",
                    Title = "Director of Operations",
                    Location = "Royal City, WA",
                    Phone = "(555) 123-4567",
                    Email = "samantha.reed@royalcitytemps.com",
                    PhotoUrl = VirtualPaths.EmployeePhoto("images/Employee2.png"),
                    Bio = "Samantha leads client operations and ensures placements meet expectations."
                },
                new Employee
                {
                    EmployeeId = 2,
                    FirstName = "Marcus",
                    LastName = "Brown",
                    Title = "Senior Recruiter",
                    Location = "Seattle, WA",
                    Phone = "(555) 987-6543",
                    Email = "marcus.brown@royalcitytemps.com",
                    PhotoUrl = VirtualPaths.EmployeePhoto("images/employee-placeholder.png"),
                    Bio = "Marcus specializes in IT and engineering recruitment."
                },
                new Employee
                {
                    EmployeeId = 3,
                    FirstName = "Aisha",
                    LastName = "Patel",
                    Title = "Client Success Manager",
                    Location = "Spokane, WA",
                    Phone = "(555) 555-1212",
                    Email = "aisha.patel@royalcitytemps.com",
                    PhotoUrl = VirtualPaths.EmployeePhoto("images/employee-placeholder.png"),
                    Bio = "Aisha manages long-term client relationships and onboarding."
                },
                new Employee
                {
                    EmployeeId = 4,
                    FirstName = "John",
                    LastName = "Doe",
                    Title = "Intern",
                    Location = "Vancouver, WA",
                    Phone = "(555) 444-3333",
                    Email = "john.doe@royalcitytemps.com",
                    PhotoUrl = VirtualPaths.EmployeePhoto("images/employee-placeholder.png"),
                    Bio = "John is assisting the team while completing his degree in Human Resources."
                },
            };
        }

        public static Employee GetById(int id)
        {
            return GetAll().Find(e => e.EmployeeId == id);
        }
    }

    // Small helper to create app-rooted virtual paths consistently.
    internal static class VirtualPaths
    {
        public static string EmployeePhoto(string relativePath)
        {
            // Ensure path starts with /
            if (string.IsNullOrWhiteSpace(relativePath)) return "/images/employee-placeholder.png";
            return relativePath.StartsWith("~") ? relativePath.Substring(1) : (relativePath.StartsWith("/") ? relativePath : "/" + relativePath);
        }
    }
}