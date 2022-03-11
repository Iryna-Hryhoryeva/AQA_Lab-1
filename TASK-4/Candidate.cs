namespace Persons;

public class Candidate : User, IUserInfo
{
    private string _desiredPosition;
    private string _positionDescription;
    private double _desiredSalary;

    public string DesiredPosition
    {
        get { return _desiredPosition; }
        set { _desiredPosition = value; }
    }

    public string PositionDescription
    {
        get { return _positionDescription; }
        set { _positionDescription = value; }
    }

    public double DesiredSalary
    {
        get { return _desiredSalary; }
        set { _desiredSalary = value; }
    }

    public void ShowUserInfo()
    {
        var typecastedSalary = (int)DesiredSalary;
        
        Console.WriteLine(
            $"Hello, I am {Name} {Surname}, I want to be a {DesiredPosition} ({PositionDescription}) with a salary from {typecastedSalary}");
    }
}
