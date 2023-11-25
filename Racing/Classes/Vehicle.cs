using Racing.Interfaces;

namespace Racing.Classes;

public class Vehicle 
{
    public string Name { get; set; }
    public double Speed { get; set; }

    public Vehicle()
    {
        
    }

    /*
    Vehicle(string name) :this()
    {
        Name = name;
    }*/
    public Vehicle(string name, double speed) /*: this(name)*/
    {
        Name = name;
        Speed = speed;
    }

    /*public double GetTime(int distance)
    {
        throw new NotImplementedException();
    }*/
}