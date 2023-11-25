using Racing.Classes;

while (true)
{
    Console.WriteLine("Выберите тип гонки:");
    Console.WriteLine("1) Наземная гонка");
    Console.WriteLine("2) Воздушная гонка");
    Console.WriteLine("3) Общая гонка");
    Console.WriteLine("4) Выйти из программы");
    
    if (!int.TryParse(Console.ReadLine(), out int raceType))
        continue;
    
    
    
    switch (raceType)
    {
        case 1 or 2 or 3: 
            Console.WriteLine("Введите дистанцию в виде положительного числа:");
            if (!int.TryParse(Console.ReadLine(), out int distance) || distance <= 0)
                continue;
        
            List<Vehicle> vehicles = new List<Vehicle>();

            vehicles.Add(new GroundVehicle("Сапоги-скороходы", 30, 20, 5));
            vehicles.Add(new GroundVehicle("Карета-тыква", 30+Math.Sqrt(distance), 100, 20));
            vehicles.Add(new GroundVehicle("Избушка на курьих ножках", Math.E * 50, 50, 15));
            vehicles.Add(new GroundVehicle("Кентавр", 70, 100, 25));

            vehicles.Add(new AirVehicle("Ступа Бабы Яги", 276, Math.Sqrt(distance)));
            vehicles.Add(new AirVehicle("Летучий корабль", 400, Math.Log2(distance)));
            vehicles.Add(new AirVehicle("Ковер-самолет", 200, Math.Pow(distance, Math.Log(2, distance))));
            vehicles.Add(new AirVehicle("Метла", 300, 2));
        
            Race race = new Race(raceType, distance);
            race.AddVehiclesToRace(vehicles);
            
            break;
        
        case 4:
            Console.WriteLine("Не очень-то и хотелось...");
            return;
        
        default:
            Console.WriteLine("Куда я жмал...");
            break;
    }
    
}
