using System.Collections;
using Racing.Interfaces;

namespace Racing.Classes;

public class Race : IRaceManager
{
    public List<Vehicle> Participants { get; set; }
    public int RaceType { get; set; } // 1 - наземная, 2 - воздушная, 3 - общая
    public int Distance { get; set; }
    public Race()
    {
        Participants = new List<Vehicle>();
    }

    public Race(int raceType) : this()
    {
        RaceType = raceType;
    }
    public Race(int raceType, int distance) : this(raceType)
    {
        Distance = distance;
    }

    public void StartRace()
    {
        var leaderTable = new SortedDictionary<double, Vehicle>();
        foreach (var vehicle in Participants)
        {
            if (vehicle is AirVehicle)
            {
                AirVehicle airVehicle;
                airVehicle = vehicle as AirVehicle;
                leaderTable.Add(airVehicle.GetTime(Distance), vehicle);

            } else if (vehicle is GroundVehicle)
            {
                GroundVehicle groundVehicle;
                groundVehicle = vehicle as GroundVehicle;
                leaderTable.Add(groundVehicle.GetTime(Distance), vehicle);
            }

        }

        Console.WriteLine("Таблица результатов:");

        int i = 1;
        foreach (var leader in leaderTable)
        {
            Console.WriteLine($"{i}) {leader.Value.Name} . Время: {leader.Key}");
            i++;
        }

        Console.WriteLine();
    }

    public void AddVehiclesToRace(List<Vehicle> vehicles)
    {
        while (true)
        {
            Console.WriteLine("Выберите гонщиков:");
            Console.WriteLine("0) Начать гонку");
            for (int i = 0; i < vehicles.Count; i++)
            {
                Console.WriteLine($"{i+1}) {vehicles[i].Name}");
            }

            
            int.TryParse(Console.ReadLine(), out int choice);
            choice--;
            
            if (choice >= vehicles.Count)
                continue;
            if (choice == -1)
            {
                StartRace();
                return;
            }

            
            bool isAdded = AddToRace(vehicles[choice]);
            if (isAdded)
                vehicles.Remove(vehicles[choice]);
            else
            {
                Console.WriteLine("Выбранный транспорт не подходит к типу гонки!");
            }
        }
    }

    public bool AddToRace(Vehicle vehicle)
    {
        switch (RaceType)
        {
            case 1:
                if (vehicle is GroundVehicle)
                {
                    Participants.Add(vehicle);
                    return true;
                } 
                return false;
            
            case 2:
                if (vehicle is AirVehicle)
                {
                    Participants.Add(vehicle);
                    return true;
                }
                return false;
            
            case 3:
                Participants.Add(vehicle);
                return true;
            
            default:
                return false;

        }
    }
    
}