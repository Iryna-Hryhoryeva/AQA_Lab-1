namespace Task4;

public class Engine
{
    public Engine(int capacity, int power, int fuelBurn, string fuelType, int maxSpeed)
    {
        Capacity = capacity;
        Power = power;
        FuelBurn = fuelBurn;
        FuelType = fuelType;
        MaxSpeed = maxSpeed;
    }

    public int Capacity { get; set; } 
    public int Power { get; set; }
    public int FuelBurn { get; set; }
    public string FuelType { get; set; }
    public int MaxSpeed { get; set; }
}
