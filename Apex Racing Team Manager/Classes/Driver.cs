using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apex_Racing_Team_Manager.Classes
{
    internal class Driver
    {
        private int _id;
        private int _age;
        private int _points;

        public int Id
        {
            get { return _id; }
            set
            {
                if ( value <= 0)
                {
                    throw new Exception("ID must be greater than 0.");
                }

                _id = value;
            }
        }
        public int RacingNumber { get; set; }
        public int Age
        {
            get { return _age; }
            set
            {
                if (value <= 18)
                {
                    throw new Exception("the age must be greater than 18");
                }
                _age = value;
            }
        }
        public int ChampionshipPoints
        {
            get { return _points; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("points cant be negative");
                }
                _points = value;
            }
        }
        public string? Name { get; set; }
        public string? Nationality { get; set; }
        public Car? AssignedCar { get; set; }


    }
}
