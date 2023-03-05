namespace SoftUni;

using Data;
using Models;
using System.Text;

public class StartUp
{
    static void Main(string[] args)
    {
        SoftUniContext context = new SoftUniContext();

        Console.WriteLine(RemoveTown(context));
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

    // Problem 07. Employees and Projects
    public static string GetEmployeesInPeriod(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employeesAndProjects = context.Employees
            .Take(10)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                ManagerFirstName = e.Manager.FirstName,
                ManagerLastName = e.Manager.LastName,
                Projects = e.EmployeesProjects
                .Where(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003)
                .Select(ep => new
                {
                    ProjectName = ep.Project.Name,
                    StartDate = ep.Project.StartDate,
                    EndDate = ep.Project.EndDate
                })
            });


        foreach (var e in employeesAndProjects)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");

            foreach (var p in e.Projects)
            {
                sb.AppendLine($"--{p.ProjectName} - {p.StartDate} - {(p.EndDate == null ? "not finished" : p.EndDate)}");
            }
        }

        return sb.ToString().TrimEnd();
    }

    // Problem 08. Addresses by Town
    public static string GetAddressesByTown(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var addressesByOccupants = context.Addresses
            .OrderByDescending(e => e.Employees.Count)
            .ThenBy(e => e.Town!.Name)
            .ThenBy(e => e.AddressText)
            .Take(10)
            .Select(e => new
            {
                e.AddressText,
                TownName = e.Town!.Name,
                Occupants = e.Employees.Count
            });

        foreach (var address in addressesByOccupants)
        {
            sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.Occupants} employees");
        }

        return sb.ToString().TrimEnd();
    }

    // Problem 09. Employee 147
    public static string GetEmployee147(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employee = context.Employees
            .Where(e => e.EmployeeId == 147)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.JobTitle,
                Projects = e.EmployeesProjects
                .Select(ep => new
                {
                    ProjectName = ep.Project.Name
                })
                .OrderBy(ep => ep.ProjectName)
                .ToList()
            })
            .FirstOrDefault();

        sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

        foreach (var e in employee!.Projects)
        {
            sb.AppendLine($"{e.ProjectName}");
        }


        return sb.ToString().TrimEnd();
    }

    // Problem 10. Departments with More Than 5 Employees
    public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var departments = context.Departments
            .Where(d => d.Employees.Count > 5)
            .OrderBy(d => d.Employees.Count == 5)
            .ThenBy(d => d.Name)
            .Select(d => new
            {
                d.Name,
                ManagerFirstName = d.Manager.FirstName,
                ManagerLastName = d.Manager.LastName,
                Employees = d.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray()
            })
            .ToArray();

        foreach (var d in departments)
        {
            sb.AppendLine($"{d.Name} - {d.ManagerFirstName + " " + d.ManagerLastName}");

            foreach (var e in d.Employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
            }
        }

        // The same solution with for loop + counter
        //for (int i = 0; i < departments.Length; i++)
        //{
        //    sb.AppendLine($"{departments[i].Name} - {departments[i].ManagerFirstName} {departments[i].ManagerLastName}");

        //    for (int j = 0; j < departments[i].Employees.Length; j++)
        //    {
        //        sb.AppendLine($"{j + 1}. {departments[i].Employees[j].FirstName} {departments[i].Employees[j].LastName} {departments[i].Employees[j].JobTitle}");
        //    }
        //}

        return sb.ToString().TrimEnd();
    }

    // Problem 11. Find Latest 10 Projects
    public static string GetLatestProjects(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var projects = context.Projects
            .OrderByDescending(p => p.StartDate)
            .Take(10)
            .OrderBy(p => p.Name)
            .Select(p => new
            {
                p.Name,
                p.Description,
                p.StartDate
            })
            .ToArray();

        foreach (var p in projects)
        {
            sb.AppendLine($"{p.Name}");
            sb.AppendLine($"{p.Description}");
            sb.AppendLine($"{p.StartDate}");
        }


        return sb.ToString().TrimEnd();
    }

    // Problem 12. Increase Salaries
    public static string IncreaseSalaries(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employees = context.Employees
            .Where(e => e.Department.Name == "Engineering" ||
                        e.Department.Name == "Tool Design" ||
                        e.Department.Name == "Marketing" ||
                        e.Department.Name == "Information Services")
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .ToArray();

        foreach (var e in employees)
        {
            e.Salary += e.Salary * 0.12m;
            sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:F2})");
        }

        context.SaveChanges();

        return sb.ToString().TrimEnd();
    }

    // Problem 13. Find Employees by First Name Starting with "Sa"
    public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employees = context.Employees
            .Where(e => e.FirstName.StartsWith("Sa"))
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.JobTitle,
                e.Salary
            })
            .ToArray();

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:F2})");
        }

        return sb.ToString().TrimEnd();
    }

    // Problem 14. Delete Project by Id
    public static string DeleteProjectById(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employeeProjectDeleted = context.EmployeesProjects.Where(ep => ep.ProjectId == 2);
        context.EmployeesProjects.RemoveRange(employeeProjectDeleted);

        Project projectToRemove = context.Projects.Find(2);

        if (projectToRemove != null)
        {
            context.Projects.Remove(projectToRemove);

            context.SaveChanges();
        }

        var projects = context.Projects.Select(p => new { p.Name }).Take(10).ToArray();

        foreach (var p in projects)
        {
            sb.AppendLine($"{p.Name}");
        }

        return sb.ToString().TrimEnd();
    }

    // Problem 15. Remove Town
    public static string RemoveTown(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employeesToChange = context.Employees
            .Where(e => e.Address.Town.Name == "Seattle")
            .ToArray();

        foreach (var e in employeesToChange)
        {
            e.AddressId = null;
        }

        IQueryable<Address> addressesToDelete = context.Addresses.Where(a => a.Town.Name == "Seattle");
        int addressesRemoved = addressesToDelete.ToArray().Length;
        sb.AppendLine($"{addressesRemoved} addresses in Seattle were deleted");
        context.Addresses.RemoveRange(addressesToDelete);

        Town townToDelete = context.Towns.FirstOrDefault(t => t.Name == "Seattle");
        context.Towns.Remove(townToDelete);

        context.SaveChanges();

        return sb.ToString().TrimEnd();
    }
}
