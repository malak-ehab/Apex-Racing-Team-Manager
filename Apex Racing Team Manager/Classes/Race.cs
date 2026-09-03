using Apex_Racing_Team_Manager.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apex_Racing_Team_Manager.Classes
{
    internal class Race
    {
        private int _id;
        private int _numberLaps;

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
        public int NumberLaps
        {
            get { return _numberLaps; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Number of laps must be greater than 0.");
                }

                _numberLaps = value;
            }
        }
        public string? RaceName { get; set; }
        public string? CircuitName { get; set; }
        public RaceStatus StatusOfRace { get; set;}
        public List<Driver> RegisteredDrivers { get; set; } = new List<Driver>();
        public Race(int id, int numberLaps, string raceName, string circuitName)
        {
            Id = id; 
            NumberLaps = numberLaps; 
            RaceName = raceName; 
            CircuitName = circuitName; 
            StatusOfRace = RaceStatus.Scheduled;
        }
        
        public void DisplayRace()
        {
            Console.WriteLine($"Race ID: {Id}");
            Console.WriteLine($"Race Name: {RaceName}");
            Console.WriteLine($"Number of Laps: {NumberLaps}");
            Console.WriteLine($"Circuit Name: {CircuitName}");
            Console.WriteLine($"Status of Race: {StatusOfRace}");

            Console.WriteLine("-------------------------");
        }

        public void StartRace()
        {
            if (StatusOfRace == RaceStatus.Scheduled)
            {
                StatusOfRace = RaceStatus.Running;
                Console.WriteLine("Race has started");
            }else
                Console.WriteLine($"The Race is already {StatusOfRace}");
        }

        public void FinishRace()
        {
            if (StatusOfRace == RaceStatus.Running)
            {
                StatusOfRace = RaceStatus.Finished;
                Console.WriteLine("Race has finished");
            }
            else if (StatusOfRace == RaceStatus.Scheduled)
                Console.WriteLine("The Race hasnt started yet");
            else
                Console.WriteLine($"The Race is already {StatusOfRace}");
        }

        public void CancelRace()
        {
            if (StatusOfRace == RaceStatus.Scheduled)
            {
                StatusOfRace = RaceStatus.Cancelled;
                Console.WriteLine("Race has been cancelled");
            }
            else
                Console.WriteLine($"The Race is already {StatusOfRace}");
        }



    }
}
