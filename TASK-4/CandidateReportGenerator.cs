namespace Persons;

// отсортировывает всех кандидатов по позиции по возрастанию зп
// ***Вывод : UserId || Users Full Name || JobTittle || Salary***
public class CandidateReportGenerator : IReportGenerator
{
    public IEnumerable<Candidate> ListOfCandidates;

    public CandidateReportGenerator(IEnumerable<Candidate> apple)
    {
        ListOfCandidates = apple;
    }

    public IEnumerable<Candidate> AscendingSort()
    {
        return ListOfCandidates.OrderBy(c => String.Format("{0,70}{1,10}", c.DesiredPosition, c.DesiredSalary));
    }

    public void Report()
    {
        
        Console.WriteLine("{0,36} | {1,20} | {2, 40} | {3,25} | {4, 18}",
            "Id:", "Name Surname:", "Desired position:", "Position description:", "Desired salary:");
        for (int i = 0; i < ListOfCandidates.Count(); i++)
        {
            var sorted = AscendingSort();
            
            Console.WriteLine("{0,36} | {1,20} | {2, 40} | {3,25} | {4, 18}", sorted.ElementAt(i).Id,
                sorted.ElementAt(i).Name + " " + sorted.ElementAt(i).Surname,
                sorted.ElementAt(i).DesiredPosition, sorted.ElementAt(i).PositionDescription,
                Math.Round(sorted.ElementAt(i).DesiredSalary, 2, MidpointRounding.ToEven));
        }
    }
}
