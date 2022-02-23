namespace Persons;

public class EmployeeReportGenerator : IReportGenerator
{
    // отсортировывает всех работников по компании и по убыванию зп.
    // ***Вывод : UserId || Company Name || Users Full Name || Salary***

    public IEnumerable<Employee> ListOfEmployees;

    public EmployeeReportGenerator(IEnumerable<Employee> pear)
    {
        ListOfEmployees = pear;
    }

    public IEnumerable<Employee> DescendingSort()
    {
        return ListOfEmployees.OrderByDescending(e => String.Format("{0,70}{1,10}", e.CompanyName, e.Salary));
    }

    public void Report()
    {
        
        Console.WriteLine("{0,36} | {1,20} | {2, 40} | {3,8} | {4, 25}",
            "Id:", "Name Surname:", "Position:", "Salary:", "Company name:");
        for (var i = 0; i < DescendingSort().Count(); i++)
        {
            var sorted = DescendingSort();
            
            Console.WriteLine("{0,36} | {1,20} | {2, 40} | {3, 8} | {4, 25}", sorted.ElementAt(i).Id,
                sorted.ElementAt(i).Name + " " + sorted.ElementAt(i).Surname,
                sorted.ElementAt(i).Position, Math.Round(sorted.ElementAt(i).Salary, 2, MidpointRounding.ToEven),
                sorted.ElementAt(i).CompanyName);
        }
    }
}
