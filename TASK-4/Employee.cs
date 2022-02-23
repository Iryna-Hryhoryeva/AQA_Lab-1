using Persons;

public class Employee : User, IUserInfo
{
    public string Position { get; set; }

    public string PositionDescription { get; set; }

    public double Salary { get; set; }

    public string CompanyName { get; set; }

    public string CompanyCountry { get; set; }

    public string CompanyCity { get; set; }

    public string CompanyAddress { get; set; }

    public void ShowUserInfo()
    {
        Name = Name;
        Surname = Surname;
        Position = Position;
        Salary = Salary;
        CompanyName = CompanyName;
        CompanyCountry = CompanyCountry;
        CompanyCity = CompanyCity;
        CompanyAddress = CompanyAddress;

        Console.WriteLine(
            $"Hello, I am {Name} {Surname}, {Position} in {CompanyName} ({CompanyCountry}, {CompanyCity}, " +
            $"{CompanyAddress}) and my salary is {Salary}");
    }

    // DEV_NOTE: May be used someday...
    // public Employee() : base(Guid.NewGuid(), "Mike", "Chomsky")
    // {
    //     throw new NotImplementedException();
    // }
}
