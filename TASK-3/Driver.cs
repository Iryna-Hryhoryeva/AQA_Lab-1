namespace TASK;

public class Driver : Person
{
    private DrivingLicense _drivingLicense;
    private Vehicle _vehicle;

    public DrivingLicense DrivingLicense
    {
        set => _drivingLicense = value;
        get => _drivingLicense;
    }

    public Vehicle Vehicle
    {
        get => _vehicle;
        set => _vehicle = value;
    }

    public Driver(DrivingLicense drivingLicense, Vehicle vehicle, Person person) : base(person.FirstName,
        person.LastName, person.DateOfBirth)
    {
        DrivingLicense = drivingLicense;
        Vehicle = vehicle;
    }
}
