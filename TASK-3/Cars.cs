﻿namespace TASK;

public class SportsCar : Vehicle
{
    private const int RequiredYearsExperience = 5;

    public SportsCar(string model, int year, Engine engine) : base(model, year, engine)
    {
        Model = model;
        Year = year;
        Engine = engine;
    }

    public string CheckDriversExperience(DateOnly dateDrivingLicense)
    {
        var hasEnoughExperience =
            (DateTime.Today.Date - dateDrivingLicense.ToDateTime(new TimeOnly(0, 0))).TotalDays / 365 >=
            RequiredYearsExperience;
        return hasEnoughExperience
            ? "The driver's experience meets the requirements."
            : "The driver's experience is not enough for driving a sports car.";
    }
}

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