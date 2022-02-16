namespace Task4;

public class Driver
{
    public Person Person { get; set; }
    public DrivingLicense DrivingLicense { get; set; }
    public Vehicle Vehicle { get; set; }

    public Driver(Person person, DrivingLicense drivingLicense, Vehicle vehicle)
    {
        if (DateTime.Today.Year - person.DateOfBirth.Year >= 16)
        {
            Person = person;
        }
        else
        {
            throw new Exception("Age must be 16+");
        }

        if (drivingLicense.DateDrivingLicense > person.DateOfBirth)
        {
            DrivingLicense = drivingLicense;
        }
        else
        {
            throw new Exception("Invalid dates");
        }

        Vehicle = vehicle;
    }
}
