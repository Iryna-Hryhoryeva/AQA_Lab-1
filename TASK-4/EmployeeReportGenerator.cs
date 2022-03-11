namespace Persons;

public class EmployeeReportGenerator : IReportGenerator
{
    public IEnumerable<Employee> ListOfEmployees;

    public EmployeeReportGenerator(IEnumerable<Employee> listOfEmployees)
    {
        ListOfEmployees = listOfEmployees;
    }

    public void Report()
    {
        const string template = "{0,36} | {1,25} | {2, 40} | {3,8} | {4, -30}";
        Console.WriteLine(template, "Id:", "Name Surname:", "Position:", "Salary:", "Company name:");

        var orderedEmployees = from selectedEmployee in ListOfEmployees
                               orderby selectedEmployee.CompanyName, selectedEmployee.Salary descending
                               select selectedEmployee;
        Employee employee;

        for (int i = 0; i < orderedEmployees.Count(); i++)
        {
            employee = orderedEmployees.ElementAt(i);

            Console.WriteLine(template, employee.Id,
                employee.Name + " " + employee.Surname,
                employee.Position, Math.Round(employee.Salary, 2, MidpointRounding.ToEven),
                employee.CompanyName);
        }
    }
}
