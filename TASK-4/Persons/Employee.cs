using TASK_4.Interfaces;

namespace TASK_4.Persons;

public class Employee : User, IUserInfo
{
    private string _position;
    private string _positionDescription;
    private double _salary;
    private string _companyName;
    private string _companyCountry;
    private string _companyCity;
    private string _companyAddress;

    public string Position 
    { 
        get { return _position; }
        set { _position = value; }
    }
    
    public string PositionDescription
    {
        get { return _positionDescription; }
        set { _positionDescription = value; }
    }
    
    public double Salary
    {
        get { return _salary; }
        set { _salary = value; }
    }
    
    public string CompanyName
    {
        get { return _companyName; }
        set { _companyName = value; }
    }
    
    public string CompanyCountry
    {
        get { return _companyCountry; }
        set { _companyCountry = value; }
    }
    
    public string CompanyCity
    {
        get { return _companyCity; }
        set { _companyCity = value; }
    }
    
    public string CompanyAddress
    {
        get { return _companyAddress; }
        set { _companyAddress = value; }
    }

    public void ShowUserInfo()
    {
        var typecastedSalary = Math.Round(Salary, 2);

        Console.WriteLine(
            $"Hello, I am {Name} {Surname}, {Position} in {CompanyName} ({CompanyCountry}, {CompanyCity}, " +
            $"{CompanyAddress}) and my salary is {typecastedSalary}");
    }
}
