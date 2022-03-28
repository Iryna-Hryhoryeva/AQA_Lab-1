namespace TASK;

public class DrivingLicense
{
    private DateOnly _dateDrivingLicense;
    private Guid _idNumber;

    public DrivingLicense(DateOnly dateDrivingLicense, Guid idNumber)
    {
        DateDrivingLicense = dateDrivingLicense;
        IdNumber = idNumber;
    }
    
    public DateOnly DateDrivingLicense { get => _dateDrivingLicense; set => _dateDrivingLicense = value; }
    public Guid IdNumber { get => _idNumber; set => _idNumber = value; }
}
