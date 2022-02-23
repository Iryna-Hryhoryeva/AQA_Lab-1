namespace TASK;

public class DrivingLicense
{
    public DateOnly DateDrivingLicense { get; set; }
    public Guid IdNumber { get; set; }

    public DrivingLicense(DateOnly dateDrivingLicense, Guid idNumber)
    {
        DateDrivingLicense = dateDrivingLicense;
        IdNumber = idNumber;
    }
}
