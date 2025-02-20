namespace HtmlRender
{
        public class Employee
        {
            // Properties
            public string Name { get; set; }
            public string JobTitle { get; set; }
            public int EmployeeID { get; set; }
            public int DepartmentID { get; set; }

            // Constructor
            public Employee(string name, string jobTitle, int employeeID, int departmentID)
            {
                Name = name;
                JobTitle = jobTitle;
                EmployeeID = employeeID;
                DepartmentID = departmentID;
            }

            // Static method to get mock employee data
            public static List<Employee> GetEmployees()
            {
                // Mock data
                return new List<Employee>
            {
                new Employee("John Doe", "Software Engineer", 101, 1),
                new Employee("Jane Smith", "Project Manager", 102, 2),
                new Employee("Emily Davis", "HR Specialist", 103, 3),
                new Employee("Michael Brown", "QA Tester", 104, 1),
                new Employee("David Wilson", "DevOps Engineer", 105, 4)
            };
            }

            // Optional: Override ToString() for easy debugging or display
            public override string ToString()
            {
                return $"Name: {Name}, Job Title: {JobTitle}, Employee ID: {EmployeeID}, Department ID: {DepartmentID}";
            }
        }


}
