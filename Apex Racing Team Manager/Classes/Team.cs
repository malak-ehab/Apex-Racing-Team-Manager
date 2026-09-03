using Apex_Racing_Team_Manager.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apex_Racing_Team_Manager.Classes
{
    internal class Team
    {
        private int _id;
        public string? TeamName { get; set; }
        public int Id
        {
            get { return _id; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("ID must be greater than 0.");
                }

                _id = value;
            }
        }
        public List<Driver> Drivers { get; set; } = new List<Driver>();
        public List<Car> Cars { get; set; } = new List<Car>();
        public List<Race> Races { get; set; } = new List<Race>();

        public void AddDriver (Driver driver)
        {
            bool idExists = false;
            bool racingNumberExists = false;

            foreach (Driver d in Drivers)
            {
                if (driver.Id == d.Id)
                {
                    idExists = true;
                    break;
                }
                if (driver.RacingNumber == d.RacingNumber)
                {
                    racingNumberExists = true;
                }
            }

            if (idExists)
            {
                Console.WriteLine("This Driver already exists.");
            }
            else if (racingNumberExists)
            {
                Console.WriteLine("This Racing Number already exists.");
            }
            else
            {
                Drivers.Add(driver);
                Console.WriteLine("Driver added successfully.");
            }
        }
        public void RemoveDriver(Driver driver)
        {

            bool idExists = false;

            foreach (Driver d in Drivers)
            {
                if (driver.Id == d.Id)
                {
                    idExists = true;
                    break;
                }
            }

            if (idExists)
            {
                Drivers.Remove(driver);
                Console.WriteLine("This Driver is removed successfully.");
            }
            else
            {
                Console.WriteLine("Driver is not found.");
            }
        }

        public void AddCar(Car newCar)
        {
            bool idExists = false;

            foreach (Car c in Cars)
            {
                if (newCar.Id == c.Id)
                {
                    idExists = true;
                    break;
                }
            }

            if (idExists)
            {
                Console.WriteLine("This Car already exists.");
            }
            else
            {
                Cars.Add(newCar);
                Console.WriteLine("Car added successfully.");
            }
        }
        public void RemoveCar(Car oldCar)
        {

            bool idExists = false;

            foreach (Car c in Cars)
            {
                if (oldCar.Id == c.Id)
                {
                    idExists = true;
                    break;
                }
            }

            if (idExists)
            {
                Cars.Remove(oldCar);
                Console.WriteLine("This Car is removed successfully.");
            }
            else
            {
                Console.WriteLine("Car is not found.");
            }
        }

        public void DisplayDrivers()
        {
            foreach (Driver d in Drivers)
            {
                Console.WriteLine($"Driver ID: {d.Id}");
                Console.WriteLine($"Name: {d.Name}");
                Console.WriteLine($"Racing Number: {d.RacingNumber}");
                Console.WriteLine($"Age: {d.Age}");
                Console.WriteLine($"Nationality: {d.Nationality}");
                Console.WriteLine($"Championship Points: {d.ChampionshipPoints}");
                Console.WriteLine($"Assigned Car: {d.AssignedCar?.Id.ToString() ?? "Not Assigned"}");

                Console.WriteLine("-------------------------");
            }
        }
        public void DisplayCars()
        {
            foreach(Car c in Cars)
    {
                Console.WriteLine($"Car ID: {c.Id}");
                Console.WriteLine($"Model: {c.Model}");
                Console.WriteLine($"Engine Type: {c.Engine}");
                Console.WriteLine($"Top Speed: {c.TopSpeed}");
                Console.WriteLine($"Fuel Capacity: {c.FuelCapacity}");
                Console.WriteLine($"Current Fuel: {c.CurrentFuel}");

                Console.WriteLine("-------------------------");
            }
        }
        public void AssignCarToDriver(Driver driver, Car car)
        {
            bool driverExists = false;
            bool carExists = false;

            foreach (Driver d in Drivers)
            {
                if (d.Id == driver.Id)
                {
                    driverExists = true;
                    break;
                }
            }

            if (!driverExists)
            {
                Console.WriteLine("Driver doesn't exist.");
                return;
            }

            foreach (Car c in Cars)
            {
                if (c.Id == car.Id)
                {
                    carExists = true;
                    break;
                }
            }

            if (!carExists)
            {
                Console.WriteLine("Car doesn't exist.");
                return;
            }

            foreach (Driver d in Drivers)
            {
                if (d.AssignedCar != null && d.AssignedCar.Id == car.Id)
                {
                    Console.WriteLine("Car is already assigned to another driver.");
                    return;
                }
            }

            driver.AssignedCar = car;
            Console.WriteLine("Car is successfully assigned to the driver.");
        }
        public void RegisterDriverInRace(Driver driver, Race race)
        {
            
            if (race.StatusOfRace != RaceStatus.Scheduled)
            {
                Console.WriteLine($"Cannot register driver. The race is {race.StatusOfRace}.");
                return;
            }

            
            if (driver.AssignedCar == null)
            {
                Console.WriteLine("Cannot register driver. The driver has no assigned car.");
                return;
            }

           
            foreach (Driver d in race.RegisteredDrivers)
            {
                if (d.Id == driver.Id)
                {
                    Console.WriteLine("Driver is already registered in this race.");
                    return;
                }
            }

            
            race.RegisteredDrivers.Add(driver);

            Console.WriteLine("Driver registered successfully.");
        }
        public Driver? FindDriverById( int id)
        {
            foreach (Driver driver in Drivers)
            {
                if (driver.Id == id)
                {
                    return driver;
                }
            }

            return null;
        }

        public Car? FindCarById( int id)
        {
            foreach (Car car in Cars)
            {
                if (car.Id == id)
                {
                    return car;
                }
            }

            return null;
        }

        public Race? FindRaceById( int id)
        {
            foreach (Race race in Races)
            {
                if (race.Id == id)
                {
                    return race;
                }
            }

            return null;
        }
    }
}
