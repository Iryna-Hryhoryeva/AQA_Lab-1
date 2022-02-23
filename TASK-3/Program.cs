using TASK;

var persons = new List<Person>();
persons.Add(new Person("Max", "Smith", new DateOnly(2000, 06, 05), true));
persons.Add(new Person("Liz", "Mueller", DateOnly.Parse("1970, 07, 21"), true));
persons.Add(new Person("Meghan", "Markle", DateOnly.Parse("1999, 02, 18"), true));

var drivingLicenses = new List<DrivingLicense>();
drivingLicenses.Add(new DrivingLicense(DateOnly.Parse("2020, 01, 01"), Guid.NewGuid()));
drivingLicenses.Add(new DrivingLicense(DateOnly.Parse("1990, 03, 12"), Guid.NewGuid()));
drivingLicenses.Add(new DrivingLicense(DateOnly.Parse("2017, 08, 11"), Guid.NewGuid()));

var engines = new List<Engine>();
engines.Add(new Engine(15, 30, 6, "Oil", 300));
engines.Add(new Engine(4, 70, 10, "Diesel", 120));
engines.Add(new Engine(3, 10, 5, "Gasoline", 80));

var vehicles = new List<Vehicle>();
vehicles.Add(new Vehicle("BMW", 2005, engines[0]));
vehicles.Add(new Vehicle("VW", 1981, engines[1]));
vehicles.Add(new Vehicle("Pegeout", 1970, engines[2]));

var drivers = new List<Driver>();
for (var i = 0; i < persons.Count; i++)
{
    drivers.Add(new Driver(persons[i], drivingLicenses[i], vehicles[i]));
}

Console.WriteLine(" №  | {0,30} | {1,15} | {2,30} | {3}", "Driver Name:", "Date of Birth", "Date of Driving License:",
    "Id Number");

for (var i = 0; i < drivers.Count; i++)
{
    Console.WriteLine(" {4}. | {0,30} | {1,15} | {2,30} | {3} ",
        drivers[i].Person.LastName + " " + drivers[i].Person.FirstName, drivers[i].Person.DateOfBirth,
        drivers[i].DrivingLicense.DateDrivingLicense,
        drivers[i].DrivingLicense.IdNumber, i + 1);
}


var driverChoice = 0;
do
{
    Console.Write("Choose the driver (1-" + drivers.Count + "): ");
    driverChoice = Convert.ToInt32(Console.ReadLine());
} while (driverChoice < 0 || driverChoice > drivers.Count);

Console.Write(
    "Car characteristics: \n\n1. Technical characteristics \n2. Exploitation characteristics \n\nYour choice: ");
var characteristicsChoice = 0;
characteristicsChoice = Convert.ToInt32(Console.ReadLine());

var vehicle = drivers[driverChoice - 1].Vehicle;

switch (characteristicsChoice)
{
    case 1:
        Console.WriteLine("Model:\t{0} \nYear:\t{1}\nCapacity:\t{2}\nFuel Burn:\t{3}\nMax Speed:\t{4}", vehicle.Model,
            vehicle.Year, vehicle.Engine.Capacity,
            vehicle.Engine.FuelBurn, vehicle.Engine.MaxSpeed);
        break;
    case 2:
        Console.Write("Enter number of km: ");
        var km = Convert.ToInt32(Console.ReadLine());
        var drivingExperience =
            (DateTime.Today.Date - drivers[driverChoice - 1].DrivingLicense.DateDrivingLicense
                .ToDateTime(new TimeOnly(0, 0))).TotalDays / 365;
        Console.WriteLine("Driving Experience:\t{0}\nFuel per km:\t{1}\nTime:\t{2}", (int) drivingExperience,
            vehicle.Engine.FuelBurn * km, km / vehicle.Engine.MaxSpeed);
        break;
    default:
        Console.WriteLine("Invalid number");
        break;
}
