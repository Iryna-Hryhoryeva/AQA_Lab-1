using Persons;

public class Candidate : User, IUserInfo
{
    public string DesiredPosition { get; set; }

    public string PositionDescription { get; set; }

    public double DesiredSalary { get; set; }

    public void ShowUserInfo()
    {
        var typecastedSalary = (int)DesiredSalary;
        
        Console.WriteLine(
            $"Hello, I am {Name} {Surname}, I want to be a {DesiredPosition} ({PositionDescription}) with a salary from {typecastedSalary}");
    }
}
