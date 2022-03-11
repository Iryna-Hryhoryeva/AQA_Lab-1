namespace Persons;

public class CandidateReportGenerator : IReportGenerator
{
    public IEnumerable<Candidate> ListOfCandidates;

    public CandidateReportGenerator(IEnumerable<Candidate> listOfCandidates)
    {
        ListOfCandidates = listOfCandidates;
    }

    public void Report()
    {
        const string template = "{0,36} | {1,20} | {2, -40} | {3,25} | {4, 18}";

        Console.WriteLine(template,
            "Id:", "Name Surname:", "Desired position:", "Position description:", "Desired salary:");
        for (int i = 0; i < ListOfCandidates.Count(); i++)
        {
            var orderedCandidates = from selectedCandidate in ListOfCandidates
                                    orderby selectedCandidate.DesiredPosition, selectedCandidate.DesiredSalary
                                    select selectedCandidate;

            Candidate candidate = orderedCandidates.ElementAt(i);

            Console.WriteLine(template, candidate.Id,
                candidate.Name + " " + candidate.Surname,
                candidate.DesiredPosition, candidate.PositionDescription,
                Math.Round(orderedCandidates.ElementAt(i).DesiredSalary, 2, MidpointRounding.ToEven));
        }
    }
}
