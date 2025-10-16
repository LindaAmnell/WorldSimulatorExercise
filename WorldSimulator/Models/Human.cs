namespace WorldSimulator.Models
{
    public enum GenderType
    {
        Male,
        Female
    }


    public class Human
    {
        public static long Population = 0;

        public Human Mother { get; set; }
        public Human Father { get; set; }

        //CORE IDENTITY
        public string Name { get; set; }
        public GenderType Gender { get; set; }
        public int Age { get; set; }
        public Guid DNA { get; set; }
        public bool IsAlive { get; set; }

        //Biogical & pysical
        public double Health { get; set; } = 100.0;
        public string BlodType { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public double EnergyLevel { get; set; }
        public double Strenght { get; set; }
        public double Endurance { get; set; }
        public double ImmuneSystemStrenght { get; set; }
        public double SleepQuality { get; set; }
        public double Hunger { get; set; } = 0.0;
        public double Thirst { get; set; } = 0.0;

        //Emotional and Congnitve
        public double Intelligence { get; set; }
        public double Empathy { get; set; }
        public double Creativity { get; set; }
        public double MemmoryRetention { get; set; }
        public double Focuse { get; set; }
        public double Curiosity { get; set; }
        public double StressLevel { get; set; }
        public double Wisdom { get; set; }
        public double Happiness { get; set; }

        // Social
        public List<Human> SocialConnections { get; set; } = new List<Human>();
        public List<string> Skills { get; set; } = new List<string>();
        public double Reputation { get; set; }
        public double Charisma { get; set; }
        public double Integrity { get; set; }

        // Economic & survival
        public decimal Wealth { get; set; }
        public string Occupation { get; set; }
        public string EducationLevel { get; set; }
        public string HomeLocation { get; set; }

        // Existensial
        public string Purpos { get; set; }
        public bool IsRelgion { get; set; }
        public double FathLevel { get; set; }
        public string MoralLevel { get; set; }
        public double LegacyLevle { get; set; }


        public Human(string name, GenderType gender, string birthLocation, bool isAlive)
        {
            Name = name;
            Gender = gender;
            Age = 0;
            Intelligence = 20;
            Empathy = 20;
            Strenght = 5;
            Creativity = 5;
            DNA = Guid.NewGuid();
            HomeLocation = birthLocation;
            IsAlive = isAlive;

            Population++;
        }


        public Human MakeChild(Human partner)
        {

            Random random = new Random();
            string[] maleNames = {
            "Noah", "Kane", "Abel", "Åke", "Frank", "Abraham",
            "Elias", "Oscar", "William", "Lucas", "Alexander",
            "Liam", "Hugo", "Filip", "Oliver", "Jonathan",
            "Benjamin", "Samuel", "Gabriel", "David", "Anton",
            "Jack", "Leo", "Erik", "Simon", "Isak"
            };
            string[] femaleNames = {
            "Lilith", "Sheniqua", "Sara", "Eva", "Alina", "Beyonce",
            "Emma", "Alice", "Olivia", "Ella", "Maja", "Sophia",
            "Lilly", "Freja", "Nora", "Astrid", "Agnes", "Clara",
            "Julia", "Hanna", "Elvira", "Stella", "Ebba", "Ida",
            "Selma", "Sofia"
                };


            GenderType childGender;
            string childName;

            if (random.Next(0, 2) == 0)
            {
                childGender = GenderType.Male;
                childName = maleNames[random.Next(maleNames.Length)];
            }
            else
            {
                childGender = GenderType.Female;
                childName = femaleNames[random.Next(femaleNames.Length)];
            }

            Human child = new Human(childName, childGender, partner.HomeLocation, true);

            if (partner.Gender == GenderType.Male)
            {
                child.Father = partner;
                child.Mother = this;
            }
            else
            {
                child.Mother = partner;
                child.Father = this;
            }
            return child;
        }

        public void GetOlder(int age)
        {
            Age += age;
        }
        public void Die()
        {
            IsAlive = false;
            Population--;
        }
        public void Eat()
        {
            if (Hunger > 0)
            {
                Random random = new Random();
                int food = random.Next(1, 10);
                if (Hunger < 0)
                {
                    Hunger = 0;
                }

                Hunger -= food;
                EnergyLevel += 5;
                Happiness += 3;
                Console.WriteLine($"{Name} ate some food and feels better!");
            }
            Console.WriteLine($"{Name} is not hungry right now.");
        }

        public void Sleep()
        {
            if (IsAlive)
            {
                Random random = new Random();
                int sleepQuality = random.Next(50, 100);
                int energyQuality = random.Next(80, 100);
                SleepQuality += sleepQuality;
                EnergyLevel += energyQuality;

                Console.WriteLine($"{Name} has sleept");
            }
        }

        public void Work()
        {

            Console.WriteLine($"{Name} has worked ");
            Wealth += 1000;
            EnergyLevel -= 50;
            StressLevel += 10;
        }
        public void Rest()
        {
            Console.WriteLine($"{Name} has rested");
            StressLevel -= 5;
            Happiness += 10;
            EnergyLevel += 10;
        }

        public void Speak(Human h)
        {
            Console.WriteLine($"{Name} says: Hello to {h.Name}");
        }
        public void PrintSummary()
        {
            Console.WriteLine($"{Name} is {Age} years old {Gender}");
            Console.WriteLine($"Has health {Health} and energy level {EnergyLevel} and happiness {Happiness}");
        }

        public void GoToSchool(string education)
        {
            if (!Skills.Contains(education))
            {
                Intelligence += 8;
                Skills.Add(education);
                return;
            }
        }

        public void LearnSkill(string skill)
        {

            Intelligence += 10;
            if (!Skills.Contains(skill))
            {
                Creativity += 5;
                Skills.Add(skill);
                Console.WriteLine($"{Name} learned {skill}");
                return;
            }
            else
            {
                Console.WriteLine($"{Name} already knows {skill}");
            }
        }

        public override string ToString()
        {
            string motherName = Mother?.Name ?? "Unknown";
            string fatherName = Father?.Name ?? "Unknown";

            return $"Name: {Name}, Age: {Age}, Gender: {Gender}, Mother: {motherName}, Father: {fatherName}";
        }


    }
}
