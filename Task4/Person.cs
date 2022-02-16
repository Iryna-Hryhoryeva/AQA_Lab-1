namespace Task4;

public class Person
{
    public Person(string firstName, string lastName, DateOnly dateOfBirth, bool driver)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Driver = driver;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public bool Driver { get; set; }
}
