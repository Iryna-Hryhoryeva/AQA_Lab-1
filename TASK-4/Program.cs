﻿namespace Persons;

public class Program
{
    public static void Main(string[] args)
    {
        var random = new Random();
        var numberOfObjects = random.Next(5, 20);

        var listOfObjectsCandidates = new List<Candidate>();
        var listOfObjectsEmployees = new List<Employee>();

        for (var i = 0; i < numberOfObjects; i++)
        {
            var candidate = new Candidate();
            listOfObjectsCandidates.Add(candidate);

            var employee = new Employee();
            listOfObjectsEmployees.Add(employee);
        }

        var repository = new PersonsRepository();

        var candidates = repository.GetCandidates(listOfObjectsCandidates);
        var employees = repository.GetEmployees(listOfObjectsEmployees);

        Console.WriteLine("\n");

        candidates.ElementAt(0).ShowUserInfo();
        employees.ElementAt(0).ShowUserInfo();

        Console.WriteLine("\n");

        var reportEmployees = new EmployeeReportGenerator(employees);
        reportEmployees.Report();

        Console.WriteLine("\n");

        var reportCandidates = new CandidateReportGenerator(candidates);
        reportCandidates.Report();
    }
}