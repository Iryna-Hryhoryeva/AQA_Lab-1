namespace TASK;

public class Truck : Vehicle
{
    private bool _hasTrailer;

    public Truck(string model, int year, Engine engine, bool hasTrailer) : base(model, year, engine)
    {
        Model = model;
        Year = year;
        Engine = engine;
        _hasTrailer = hasTrailer;
    }
}
