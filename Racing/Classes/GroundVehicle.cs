namespace Racing.Classes;

public class GroundVehicle : Vehicle
{
    public int TimeToChill { get; set;}
    public int ChillDuration { get; set; }
    
    public GroundVehicle(string name, double speed, int timeToChill, int chillDuration) : base(name, speed)
    {
        TimeToChill = timeToChill;
        ChillDuration = chillDuration;
    }
    
    public double GetTime(int distance)
    {
        double time = distance / Speed;

        int chillCount = (int) Math.Floor(time / TimeToChill);

        for (int i = 1; i <= chillCount; i++)
        {
            time += i * ChillDuration;
        }
        
        return time;

    }
}