using Apex_Racing_Team_Manager.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apex_Racing_Team_Manager.Classes
{
    internal class Car
    {
        private int _id;
        private double _topSpeed;
        private double _fuelCapacity;
        private double _currentFuel;
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
        public string? Model { get; set; }
        public double TopSpeed
        {
            get { return _topSpeed; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Top Speed must be greater than 0.");
                }

                _topSpeed = value;
            }
        }
        public double FuelCapacity
        {
            get { return _fuelCapacity; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Fuel Capacity must be greater than 0.");
                }

                _fuelCapacity = value;
            }
        }
        public double CurrentFuel
        {
            get { return _currentFuel; }
            set
            {
                if(value <0 || value > FuelCapacity)
                {
                    throw new Exception("Current Fuel cannot be greater than Fuel Capacity or less than zero");
                }
                _currentFuel = value;

            }
        }
        public EngineType Engine { get; set; }
    }
}
