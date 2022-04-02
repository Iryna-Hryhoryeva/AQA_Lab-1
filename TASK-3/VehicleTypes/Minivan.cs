namespace TASK;

public class Minivan : Vehicle
{
    private int _seatsCount;

    public Minivan(string model, int year, Engine engine, int seatsCount) : base(model, year, engine)
    {
        Model = model;
        Year = year;
        Engine = engine;
        _seatsCount = seatsCount;
    }
}
