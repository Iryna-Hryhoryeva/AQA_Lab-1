namespace TASK;

public class Vehicle
{
    private string _model;
    private int _year;
    private Engine _engine;
    private Driver _owner;

    public Vehicle(string model, int year, Engine engine)
    {
        Model = model;
        Year = year;
        Engine = engine;
    }

    public string Model
    {
        get => _model;
        set => _model = value;
    }

    public int Year
    {
        get => _year;
        set => _year = value;
    }

    public Engine Engine
    {
        get => _engine;
        set => _engine = value;
    }

    public Driver Owner
    {
        get => _owner;
        set => _owner = value;
    }
}
