namespace SoftUni;

using Data;
using Models;
using System.Text;

public class StartUp
{
    static void Main(string[] args)
    {
        SoftUniContext context = new SoftUniContext();

        Console.WriteLine(AddNewAddressToEmployee(context));
    }

    // Problem 03. Employees Full Information
    public static string GetEmployeesFullInformation(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employees = context.Employees
                               .OrderBy(e => e.EmployeeId)
                               .Select(e => new
                               {
                                   e.FirstName,
                                   e.LastName,
                                   e.MiddleName,
                                   e.JobTitle,
                                   e.Salary
                               })
                               .ToArray();

        foreach (var employee in employees)
        {
            sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
        }

        return sb.ToString().TrimEnd();
    }

    // Problem 04. Employees with Salary Over 50 000
    public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employees = context.Employees
                .OrderBy(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .Where(e => e.Salary > 50000)
                .ToArray();

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} - {e.Salary:f2}");
        }

        return sb.ToString().TrimEnd();
    }

    // Problem 05. Employees from Research and Development
    public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employees = context.Employees
            .OrderBy(e => e.Salary)
            .ThenByDescending(e => e.FirstName)
            .Where(e => e.Department.Name == "Research and Development")
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.Salary,
                DepartmentName = e.Department.Name
            })
            .ToArray();

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:F2}");
        }

        return sb.ToString().TrimEnd();
    }

    // Problem 06. Adding a New Address and Updating Employee
    public static string AddNewAddressToEmployee(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        Address address = new Address()
        {
            AddressText = "Vitoshka 15",
            TownId = 4
        };

        var employee = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");
        
        if (employee != null)
        {
            employee.Address = address;
        }

        context.SaveChanges();

        string[] employeesAddress = context.Employees
            .OrderByDescending(e => e.AddressId)
            .Take(10)
            .Select(e => e.Address!.AddressText)
            .ToArray();

        foreach (string addressText in employeesAddress)
        {
            sb.AppendLine($"{addressText}");
        }

        return sb.ToString().TrimEnd();
    }
}