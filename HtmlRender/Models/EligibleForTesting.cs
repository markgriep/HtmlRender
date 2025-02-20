

using System;
using System.Collections.Generic;

namespace HtmlRender.Models
{

    public partial class EligibleForTesting
    {
        public int Id { get; set; }

        public int TestNumber { get; set; }

        public int? EmployeeId { get; set; }

        public string? OtherAlcohol { get; set; }

        public string EmployeeName { get; set; } = string.Empty;   // TODO

        public string JobTitle { get; set; } = string.Empty;   // TODO

        public string? TestType { get; set; }   // Drug (D) or Alcohol (A)






        // Static method to generate mock data
        public static List<EligibleForTesting> GetEligibleForTestingData()
        {
            // Mock data with the same TestNumber for all entries
            return new List<EligibleForTesting>
            {
                new EligibleForTesting
                {
                    Id = 1,
                    TestNumber = 12345, // Same test number for all entries
                    EmployeeId = 101,
                    EmployeeName = "John Doe",
                    JobTitle = "Software Engineer",
                    TestType = "Drug (D)"
                },
                new EligibleForTesting
                {
                    Id = 2,
                    TestNumber = 12345, // Same test number for all entries
                    EmployeeId = 102,
                    EmployeeName = "Jane Smith",
                    JobTitle = "Project Manager",
                    TestType = "Alcohol (A)"
                },
                new EligibleForTesting
                {
                    Id = 3,
                    TestNumber = 12345, // Same test number for all entries
                    EmployeeId = 103,
                    EmployeeName = "Emily Davis",
                    JobTitle = "HR Specialist",
                    TestType = "Drug (D)"
                },
                new EligibleForTesting
                {
                    Id = 4,
                    TestNumber = 12345, // Same test number for all entries
                    EmployeeId = 104,
                    EmployeeName = "Michael Brown",
                    JobTitle = "QA Tester",
                    TestType = "Alcohol (A)"
                },
                new EligibleForTesting
                {
                    Id = 5,
                    TestNumber = 12345, // Same test number for all entries
                    EmployeeId = 105,
                    EmployeeName = "David Wilson",
                    JobTitle = "DevOps Engineer",
                    TestType = "Drug (D)"
                }
            };
        }

        // Optional: Override ToString() for easy debugging or display
        public override string ToString()
        {
            return $"ID: {Id}, Test Number: {TestNumber}, Employee ID: {EmployeeId}, " +
                   $"Employee Name: {EmployeeName}, Job Title: {JobTitle}, Test Type: {TestType}";
        }





    }
}