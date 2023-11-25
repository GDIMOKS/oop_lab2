using Racing.Classes;

namespace Racing.Interfaces;

public interface IRaceManager
{
    public void StartRace();
    public bool AddToRace(Vehicle vehicle);
    public void AddVehiclesToRace(List<Vehicle> vehicle);
    

}