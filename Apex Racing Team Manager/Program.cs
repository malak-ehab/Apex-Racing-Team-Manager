using Apex_Racing_Team_Manager.Classes;
using Apex_Racing_Team_Manager.Enums;

namespace Apex_Racing_Team_Manager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Team team = new Team();

            Console.WriteLine("==========================================");
            Console.WriteLine("       Apex Racing Team Manager");
            Console.WriteLine("==========================================");

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine("==========================================");
                Console.WriteLine("                 MENU");
                Console.WriteLine("==========================================");
                Console.WriteLine("1. Add Driver");
                Console.WriteLine("2. Remove Driver");
                Console.WriteLine("3. Display Drivers");
                Console.WriteLine("4. Add Car");
                Console.WriteLine("5. Remove Car");
                Console.WriteLine("6. Display Cars");
                Console.WriteLine("7. Assign Car to Driver");
                Console.WriteLine("8. Create Race");
                Console.WriteLine("9. Display Races");
                Console.WriteLine("10. Register Driver in Race");
                Console.WriteLine("11. Start Race");
                Console.WriteLine("12. Finish Race");
                Console.WriteLine("13. Cancel Race");
                Console.WriteLine("0. Exit");
                Console.WriteLine("==========================================");

                int choice = ReadInt("Enter your choice: ");

                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        AddDriver(team);
                        break;

                    case 2:
                        RemoveDriver(team);
                        break;

                    case 3:
                        DisplayDrivers(team);
                        break;

                    case 4:
                        AddCar(team);
                        break;

                    case 5:
                        RemoveCar(team);
                        break;

                    case 6:
                        DisplayCars(team);
                        break;

                    case 7:
                        AssignCarToDriver(team);
                        break;

                    case 8:
                        CreateRace(team);
                        break;

                    case 9:
                        DisplayRaces(team);
                        break;

                    case 10:
                        RegisterDriverInRace(team);
                        break;

                    case 11:
                        StartRace(team);
                        break;

                    case 12:
                        FinishRace(team);
                        break;

                    case 13:
                        CancelRace(team);
                        break;

                    case 0:
                        exit = true;
                        Console.WriteLine("Exiting program...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a number from 0 to 13.");
                        break;
                }
            }
        }

        static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);

                if (int.TryParse(Console.ReadLine(), out int value))
                {
                    return value;
                }

                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }

        static double ReadDouble(string message)
        {
            while (true)
            {
                Console.Write(message);

                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }

                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        static string ReadString(string message)
        {
            Console.Write(message);

            return Console.ReadLine() ?? "";
        }

        static EngineType ReadEngineType()
        {
            while (true)
            {
                Console.Write("Enter Engine Type (Turbo / Hybrid / Electric): ");

                string input = Console.ReadLine() ?? "";

                if (input.Equals("Turbo", StringComparison.OrdinalIgnoreCase))
                {
                    return EngineType.Turbo;
                }

                if (input.Equals("Hybrid", StringComparison.OrdinalIgnoreCase))
                {
                    return EngineType.Hybrid;
                }

                if (input.Equals("Electric", StringComparison.OrdinalIgnoreCase))
                {
                    return EngineType.Electric;
                }

                Console.WriteLine("Invalid engine type. Please enter Turbo, Hybrid, or Electric.");
            }
        }


        


        static void AddDriver(Team team)
        {
            Console.WriteLine("========== Add Driver ==========");

            Driver driver = new Driver();

            try
            {
                driver.Id = ReadInt("Enter Driver ID: ");

                driver.Name = ReadString("Enter Driver Name: ");

                driver.RacingNumber = ReadInt("Enter Racing Number: ");

                driver.Age = ReadInt("Enter Driver Age: ");

                driver.Nationality = ReadString("Enter Nationality: ");

                driver.ChampionshipPoints =
                    ReadInt("Enter Championship Points: ");

                team.AddDriver(driver);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Invalid driver data: {ex.Message}");
            }
        }

        static void RemoveDriver(Team team)
        {
            Console.WriteLine("========== Remove Driver ==========");

            int id = ReadInt("Enter Driver ID: ");

            Driver? driver = team.FindDriverById(id);

            if (driver == null)
            {
                Console.WriteLine("Driver is not found.");
                return;
            }

            team.RemoveDriver(driver);
        }

        static void DisplayDrivers(Team team)
        {
            Console.WriteLine("========== Drivers ==========");

            if (team.Drivers.Count == 0)
            {
                Console.WriteLine("No drivers found.");
                return;
            }

            team.DisplayDrivers();
        }


        static void AddCar(Team team)
        {
            Console.WriteLine("========== Add Car ==========");

            Car car = new Car();

            try
            {
                car.Id = ReadInt("Enter Car ID: ");

                car.Model = ReadString("Enter Car Model: ");

                car.Engine = ReadEngineType();

                car.TopSpeed = ReadDouble("Enter Top Speed: ");

                car.FuelCapacity =
                    ReadDouble("Enter Fuel Capacity: ");

                car.CurrentFuel =
                    ReadDouble("Enter Current Fuel: ");

                team.AddCar(car);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Invalid car data: {ex.Message}");
            }
        }

        static void RemoveCar(Team team)
        {
            Console.WriteLine("========== Remove Car ==========");

            int id = ReadInt("Enter Car ID: ");

            Car? car = team.FindCarById(id);

            if (car == null)
            {
                Console.WriteLine("Car is not found.");
                return;
            }

            team.RemoveCar(car);
        }

        static void DisplayCars(Team team)
        {
            Console.WriteLine("========== Cars ==========");

            if (team.Cars.Count == 0)
            {
                Console.WriteLine("No cars found.");
                return;
            }

            team.DisplayCars();
        }


        static void AssignCarToDriver(Team team)
        {
            Console.WriteLine("========== Assign Car to Driver ==========");

            int driverId = ReadInt("Enter Driver ID: ");

            Driver? driver = team.FindDriverById(driverId);

            if (driver == null)
            {
                Console.WriteLine("Driver doesn't exist.");
                return;
            }

            int carId = ReadInt("Enter Car ID: ");

            Car? car = team.FindCarById(carId);

            if (car == null)
            {
                Console.WriteLine("Car doesn't exist.");
                return;
            }

            team.AssignCarToDriver(driver, car);
        }


        static void CreateRace(Team team)
        {
            Console.WriteLine("========== Create Race ==========");

            int id = ReadInt("Enter Race ID: ");

            // Check Race ID uniqueness
            Race? existingRace = team.FindRaceById(id);

            if (existingRace != null)
            {
                Console.WriteLine("This Race ID already exists.");
                return;
            }

            string raceName = ReadString("Enter Race Name: ");

            string circuitName = ReadString("Enter Circuit Name: ");

            int numberLaps = ReadInt("Enter Number of Laps: ");

            try
            {
                Race race = new Race(
                    id,
                    numberLaps,
                    raceName,
                    circuitName
                );

                team.Races.Add(race);

                Console.WriteLine("Race created successfully.");
                Console.WriteLine($"Race Status: {race.StatusOfRace}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Invalid race data: {ex.Message}");
            }
        }

        static void DisplayRaces(Team team)
        {
            Console.WriteLine("========== Races ==========");

            if (team.Races.Count == 0)
            {
                Console.WriteLine("No races found.");
                return;
            }

            foreach (Race race in team.Races)
            {
                race.DisplayRace();

                Console.WriteLine(
                    $"Registered Drivers: {race.RegisteredDrivers.Count}"
                );

                Console.WriteLine();
            }
        }


        static void RegisterDriverInRace(Team team)
        {
            Console.WriteLine("========== Register Driver in Race ==========");

            int driverId = ReadInt("Enter Driver ID: ");

            Driver? driver = team.FindDriverById(driverId);

            if (driver == null)
            {
                Console.WriteLine("Driver doesn't exist.");
                return;
            }

            int raceId = ReadInt("Enter Race ID: ");

            Race? race = team.FindRaceById(raceId);

            if (race == null)
            {
                Console.WriteLine("Race doesn't exist.");
                return;
            }

            team.RegisterDriverInRace(driver, race);
        }


        static void StartRace(Team team)
        {
            Console.WriteLine("========== Start Race ==========");

            int raceId = ReadInt("Enter Race ID: ");

            Race? race = team.FindRaceById(raceId);

            if (race == null)
            {
                Console.WriteLine("Race doesn't exist.");
                return;
            }

            race.StartRace();
        }


        static void FinishRace(Team team)
        {
            Console.WriteLine("========== Finish Race ==========");

            int raceId = ReadInt("Enter Race ID: ");

            Race? race = team.FindRaceById(raceId);

            if (race == null)
            {
                Console.WriteLine("Race doesn't exist.");
                return;
            }

            race.FinishRace();
        }


        static void CancelRace(Team team)
        {
            Console.WriteLine("========== Cancel Race ==========");

            int raceId = ReadInt("Enter Race ID: ");

            Race? race = team.FindRaceById(raceId);

            if (race == null)
            {
                Console.WriteLine("Race doesn't exist.");
                return;
            }

            race.CancelRace();
        }
    }
}
