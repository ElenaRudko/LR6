using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR6
{
    enum Country
    {
        Argentina,
        Belarus,
        China,
        Russia,
        Ukraine
    }

    interface IInformation
    {
        void DisplaySport();
        void DisplaySpecificInfo();
    }

    struct Person
    {
        string firstName;
        string lastName;
        int age;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (!String.IsNullOrEmpty(value) && value.Length > 1)
                {
                    firstName = value;
                }
                else
                    Console.WriteLine("incorrect value.");
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (!String.IsNullOrEmpty(value) && value.Length > 1)
                {
                    lastName = value;
                }
                else
                    Console.WriteLine("incorrect value.");
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value >= 21 & value < 35)
                    age = value;
                else
                    Console.WriteLine("incorrect value.");
            }
        }
    }

    class Sportsman
    {
        protected string Country { get; set; }
        protected Person participant;

        public Sportsman(string lastName, string firstName, int age, int country)
        {
            participant.LastName = lastName;
            participant.FirstName = firstName;
            participant.Age = age;
            Country = Enum.GetName(typeof(Country), country);
        }

        public void DisplayGeneralInfo()
        {
            Console.WriteLine("Surname: " + participant.LastName);
            Console.WriteLine("Name: " + participant.FirstName);
            Console.WriteLine("Age: " + participant.Age);
            Console.WriteLine("Represented country: " + Country);
        }
    }

    class Motorsport : Sportsman, IInformation
    {
        string TypeOfCompetition { get; set; }

        public Motorsport(string lastName, string firstName, int age, int country, string typeOfCompetition) : base(lastName, firstName, age, country)
        {
            TypeOfCompetition = typeOfCompetition;
        }

        public void DisplaySport()
        {
            Console.WriteLine("Sport: motorsport");
        }

        public void DisplaySpecificInfo()
        {
            Console.WriteLine("Type of competition: " + TypeOfCompetition);
        }
    }

    class Athletics : Sportsman, IInformation, IComparable<Athletics>
    {
        int Distance { get; set; }

        public Athletics(string lastName, string firstName, int age, int country, int distance) : base(lastName, firstName, age, country)
        {
            Distance = distance;
        }

        public void DisplaySport()
        {
            Console.WriteLine("\nSport: athletics");
        }

        public void DisplaySpecificInfo()
        {
            Console.WriteLine("Distance: " + Distance);
        }

        public int CompareTo(Athletics obj)
        {
            if (this.Distance > obj.Distance)
                return 1;
            else if (this.Distance < obj.Distance)
                return -1;
            else
                return 0;
        }
    }

    class Biathlon : Sportsman, IInformation, IEquatable<Biathlon>
    {
        string RaceOfType { get; set; }

        public Biathlon(string lastName, string firstName, int age, int country, string raceOfType) : base(lastName, firstName, age, country)
        {
            RaceOfType = raceOfType;
        }

        public void DisplaySport()
        {
            Console.WriteLine("\nSport: biathlon");
        }

        public void DisplaySpecificInfo()
        {
            Console.WriteLine("Race of type: " + RaceOfType);
        }

        public bool Equals(Biathlon obj)
        {
            if (this.RaceOfType == obj.RaceOfType)
                return true;

            return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Motorsport motorsport = new Motorsport("Avdeev", "Kirill", 25, 2, "drift");
            Athletics athletics = new Athletics("Tsarenkov", "Victor", 23, 1, 100);
            Biathlon biatlon = new Biathlon("Vlasenko", "Vyacheslav", 30, 3, "mass start");

            motorsport.DisplaySport();
            motorsport.DisplayGeneralInfo();
            motorsport.DisplaySpecificInfo();

            athletics.DisplaySport();
            athletics.DisplayGeneralInfo();
            athletics.DisplaySpecificInfo();

            biatlon.DisplaySport();
            biatlon.DisplayGeneralInfo();
            biatlon.DisplaySpecificInfo();

            Console.WriteLine("\nSorting by distance\n");

            Athletics[] mas = new Athletics[3];

            mas[0] = new Athletics("Ivanov", "Ivan", 25, 2, 120);
            mas[1] = new Athletics("Anisimov", "Anton", 21, 3, 100);
            mas[2] = new Athletics("Bordyug", "Andrew", 24, 3, 110);

            Array.Sort(mas);

            foreach (Athletics x in mas)
            {
                x.DisplayGeneralInfo();
                Console.WriteLine();
            }

            Biathlon secondBiatlon = new Biathlon("Vlasenko", "Anton", 25, 3, "mass start");
            Console.WriteLine("Comparing class instances: " + biatlon.Equals(secondBiatlon));

            Console.ReadLine();
        }
    }
}
