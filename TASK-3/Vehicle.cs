namespace TASK;

public class Vehicle
{
    public string Model { get; set; } 

    public int Year { get; set; }

    public Engine Engine { get; set; }

    public Vehicle(string model, int year, Engine engine)
    {
        Model = model;
        Year = year;
        Engine = engine;
    }
}
