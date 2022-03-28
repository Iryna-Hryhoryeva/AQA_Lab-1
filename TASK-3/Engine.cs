namespace TASK;

public class Engine
{
    private int _capacity;
    private int _power;
    private int _fuelBurn;
    private string _fuelType;
    private int _maxSpeed;

    public Engine(int capacity, int power, int fuelBurn, string fuelType, int maxSpeed)
    {
        Capacity = capacity;
        Power = power;
        FuelBurn = fuelBurn;
        FuelType = fuelType;
        MaxSpeed = maxSpeed;
    }
    
    public int Capacity { get { return _capacity; } set { _capacity = value; } } 
    public int Power { get { return _power; } set { _power = value; } }
    public int FuelBurn { get { return _fuelBurn; } set { _fuelBurn = value; } }
    public string FuelType { get { return _fuelType; } set { _fuelType = value; } }
    public int MaxSpeed { get { return _maxSpeed; } set { _maxSpeed = value; } }
}
