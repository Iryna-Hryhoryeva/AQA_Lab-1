namespace Persons;

public class CandidateReportGenerator : IReportGenerator
{
    private IEnumerable<Candidate> _listOfCandidates;

    public CandidateReportGenerator(IEnumerable<Candidate> listOfCandidates)
    {
        _listOfCandidates = listOfCandidates;
    }

    public void Report()
    {
        const string template = "{0,36} | {1,20} | {2, -40} | {3,25} | {4, 18}";

        Console.WriteLine(template,
            "Id:", "Name Surname:", "Desired position:", "Position description:", "Desired salary:");
        
        var orderedCandidates = from selectedCandidate in _listOfCandidates
            orderby selectedCandidate.DesiredPosition, selectedCandidate.DesiredSalary
            select selectedCandidate;

        foreach (var candidate in orderedCandidates)
        {
            Console.WriteLine(template, candidate.Id,
                            candidate.Name + " " + candidate.Surname,
                            candidate.DesiredPosition, candidate.PositionDescription,
                            Math.Round(candidate.DesiredSalary, 2));
        }
    }
}
