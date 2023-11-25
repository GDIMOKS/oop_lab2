using Racing.Interfaces;

namespace Racing.Classes;

public class AirVehicle : Vehicle, IVehicle
{
    public double Acceleration { get; set; }

    public AirVehicle() : base()
    {
        
    }

    public AirVehicle(string name, double speed, double acceleration) : base(name, speed)
    {
        Acceleration = acceleration;
    }

    public double GetTime(int distance)
    {
        double discriminant = Math.Pow(Speed, 2) - 4 * Acceleration/2 * -distance;

        return (-Speed + Math.Sqrt(discriminant)) / 2 ;
    }
}