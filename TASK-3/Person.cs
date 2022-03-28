namespace TASK;

public class Person 
{
    private string _firstName;
    private string _lastName;
    private DateOnly _dateOfBirth;

    public Person(string firstName, string lastName, DateOnly dateOfBirth)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
    }
    
    public string FirstName { get => _firstName; set => _firstName = value; }
    public string LastName { get => _lastName; set => _lastName = value; }
    public DateOnly DateOfBirth { get => _dateOfBirth; set => _dateOfBirth = value; }
    public bool CanBeDriver => DateTime.Today.Year - _dateOfBirth.Year >= 16;
}
