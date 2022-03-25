namespace TASK;

public class Program
{
    public static void Main(string[] args)
    {
        const int numberOfPersons = 30;
        const int numberOfDrivers = 3;

        var listOfDrivers = new List<Driver>();

        var repository = new BogusRepository();

        var persons = repository.GetPersons(numberOfPersons)
            .Where(person => person.CanBeDriver).Take(numberOfDrivers);

        var drivingLicenses = repository.GetDrivingLicenses(numberOfPersons);
        var vehicles = repository.GetVehicles(numberOfPersons);

        Console.WriteLine(" №  | {0,30} | {1,15} | {2,30} | {3}", "Driver's Name:", "Date of Birth",
            "Date of Driving License:", "Id Number");

        int index;
        foreach (var person in persons)
        {
            index = new Random().Next(0, numberOfPersons);

            var driver = new Driver(drivingLicenses.ElementAt(index), vehicles.ElementAt(index), person);
            listOfDrivers.Add(driver);
        }

        index = 0;

        foreach (var driver in listOfDrivers)
        {
            Console.WriteLine(" {4}. | {0,30} | {1,15} | {2,30} | {3} ",
                driver.LastName + " " + driver.FirstName, driver.DateOfBirth,
                driver.DrivingLicense.DateDrivingLicense,
                driver.DrivingLicense.IdNumber, ++index);
        }

        int selectedNumberOfDriver;

        do
        {
            Console.Write("Choose the driver (1-" + numberOfDrivers + "): ");
            selectedNumberOfDriver = Convert.ToInt32(Console.ReadLine());
        } while (selectedNumberOfDriver < 0 || selectedNumberOfDriver > numberOfDrivers);

        Console.Write(
            "Car characteristics: \n\n1. Technical characteristics \n2. Exploitation characteristics \n\nYour choice: ");

        var selectedCharacteristics = Convert.ToInt32(Console.ReadLine());
        var selectedDriver = listOfDrivers[selectedNumberOfDriver - 1];

        var selectedVehicle = selectedDriver.Vehicle;
        selectedVehicle.Owner = selectedDriver;

        switch (selectedCharacteristics)
        {
            case 1:
                Console.WriteLine("Model:\t{0} \nYear:\t{1}\nCapacity:\t{2}\nFuel Burn:\t{3}\nMax Speed:\t{4}",
                    selectedVehicle.Model,
                    selectedVehicle.Year, selectedVehicle.Engine.Capacity,
                    selectedVehicle.Engine.FuelBurn, selectedVehicle.Engine.MaxSpeed);
                break;

            case 2:
                Console.Write("Enter number of km: ");
                var km = Convert.ToInt32(Console.ReadLine());

                var drivingExperience =
                    (DateTime.Today.Date - listOfDrivers[selectedNumberOfDriver - 1].DrivingLicense.DateDrivingLicense
                        .ToDateTime(new TimeOnly(0, 0))).TotalDays / 365;

                Console.WriteLine("Driving Experience:\t{0} y\nFuel per {3} km:\t{1} L\nTime:\t{2} h",
                    Math.Round(drivingExperience, 2),
                    selectedVehicle.Engine.FuelBurn * km / 100,
                    Math.Round((double) km / (double) selectedVehicle.Engine.MaxSpeed, 2), km);
                break;

            default:
                Console.WriteLine("Invalid number");
                break;
        }
    }
}
