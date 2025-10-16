using WorldSimulator.Models;

namespace WorldSimulator.Service
{
    public class HumanHelper
    {
        public static List<Human> Society = new List<Human>();
        public static Human God { get; private set; }
        public static Human Adam { get; private set; }
        public static Human Eve { get; private set; }

        public static void CreateGod()
        {
            God = new Human("God", GenderType.Male, "Heaven", true);
            Human.Population--;
        }
        public static void CreateAdamAndEve()
        {
            Adam = new Human("Adam", GenderType.Male, "Garden of Eden", true);
            Adam.Age = 33;

            Eve = new Human("Eve", GenderType.Female, "Garden of Eden", true);
            Eve.Age = 32;

            Adam.Mother = God;
            Adam.Father = God;
            Eve.Mother = God;
            Eve.Father = God;
        }
        public static void EvaAndAdamMakeChildren(int number)
        {
            Console.WriteLine($"\nAdam and Eve are having {number} children...");
            Random random = new Random();

            for (int i = 0; i < number; i++)
            {
                int age = random.Next(5, 15);
                Human child = Adam.MakeChild(Eve);
                child.GetOlder(age);
                Society.Add(child);
            }

            Console.WriteLine("All children have been born!");
        }

        public static void SeeAllHumans()
        {
            foreach (Human h in Society)
            {
                Console.WriteLine(h);
            }
            Console.WriteLine(Human.Population);
        }

        public static void AllFemales()
        {
            var femaleList = Society.Where(f => f.Gender == GenderType.Female).ToList();
            foreach (Human f in femaleList)
            {
                Console.WriteLine(f);
            }
        }

        public static void MenOver20()
        {
            var menOver20 = Society.Where(m => m.Gender == GenderType.Male && m.Age > 20).ToList();
            foreach (Human m in menOver20)
            {
                Console.WriteLine(m);
            }
        }

        public static void HowManyChildren()
        {
            var childrenList = Society.Where(c => c.Age < 20 && c.HomeLocation == "Garden of Eden").ToList();

            Console.WriteLine("How many children dose Eve and Adam have ");
            Console.WriteLine($"{childrenList.Count} children");
        }

        public static void OldestHuman()
        {
            Human oldest = Society.MaxBy(h => h.Age);

            Console.WriteLine($"The oldest human is {oldest.Name}, age {oldest.Age}.");
        }

        public static void MakeAllHumansOlder()
        {
            Random random = new Random();
            int age = random.Next(5, 10);
            foreach (Human h in Society)
            {
                h.GetOlder(age);
            }
        }

        public static void AverageAge()
        {
            var average = Society.Average(h => h.Age);
            Console.WriteLine($"The average age is {average:f2}");
        }
        public static void Die(Human h)
        {
            var children = Society.Where(c => c.Mother.Name == h.Name || c.Father.Name == h.Name);

            if (children.Count() > 0 && h.Wealth > 0)
            {
                Console.WriteLine($"{h.Name}'s kids");

                decimal money = h.Wealth / children.Count();
                foreach (Human f in children)
                {
                    f.Wealth += money;
                    Console.WriteLine($"{f.Name} got {money:f2} from his parent {h.Name}");
                }
            }

            h.Wealth = 0;
            //Console.WriteLine($"{h.Name} dies");
            h.Die();
            Society.Remove(h);
        }

        public static void SortByAge()
        {
            var sortedList = Society.OrderByDescending(h => h.Age).ToList();

            foreach (Human h in sortedList)
            {
                Console.WriteLine($"{h.Name} , {h.Age}");
            }
        }

        public static void CreatRandomHumans()
        {
            Random random = new Random();
            string[] maleNames = { "Sebastian", "Noah", "Liam", "Oscar", "Elias", "Lucas", "William", "Alexander", "Hugo", "Leo" };
            string[] femaleNames = { "Linda", "Emma", "Alice", "Olivia", "Ella", "Maja", "Sophia", "Lilly", "Freja", "Nora" };
            string[] homeLocations = { "Garden of Eden", "Mystic Valley", "Crystal Lake", "Emerald Forest", "Golden Plains" };

            GenderType gender = (GenderType)random.Next(0, 2);

            string name = (gender == GenderType.Male)
                ? maleNames[random.Next(maleNames.Length)]
                : femaleNames[random.Next(femaleNames.Length)];

            string home = homeLocations[random.Next(homeLocations.Length)];

            Human newHuman = new Human(name, gender, home, true);
            newHuman.Father = God;
            newHuman.Mother = God;

            newHuman.Age = random.Next(0, 10);
            Society.Add(newHuman);
            Console.WriteLine(newHuman.ToString());

        }

        public static void GroupByGender()
        {
            var groups = Society.GroupBy(h => h.Gender);

            foreach (var group in groups)
            {
                Console.WriteLine($"==={group.Key}====");
                foreach (Human h in group)
                {
                    Console.WriteLine(h);
                }
            }
        }

        public static void FamilyTree(Human human)
        {
            string motherName = human.Mother?.Name ?? "Unknown";
            string fatherName = human.Father?.Name ?? "Unknown";

            Console.WriteLine($"{human.Name} mom {motherName} father {fatherName}");

            var siblings = Society
                .Where(h => h.Mother == human.Mother && h != human).ToList();

            if (siblings.Count > 0)
            {
                Console.WriteLine($"{human.Name}'s siblings:");
                foreach (var s in siblings)
                    Console.WriteLine($" - {s.Name}");
            }
            else
            {
                Console.WriteLine($"{human.Name} has no siblings.");
            }
        }
        public static void RandomDeath()
        {
            if (Society.Count == 0)
            {
                Console.WriteLine("No one left to die");
                return;
            }

            Random random = new Random();
            int index = random.Next(Society.Count);
            Human unlucky = Society[index];

            Die(unlucky);
            Console.WriteLine($"{unlucky.Name} died of a disease.");


        }

        public static void RandomMakeChild()
        {
            Random random = new Random();

            var men = Society.Where(h => h.IsAlive && h.Gender == GenderType.Male && h.Age >= 18).ToList();
            var female = Society.Where(h => h.Gender == GenderType.Female && h.Age >= 18).ToList();

            if (men.Count == 0 || female.Count == 0)
            {
                Console.WriteLine("No adults available to reproduce this year.");
                return;
            }

            var mother = female[random.Next(female.Count)];
            var father = men[random.Next(men.Count)];

            Human child = father.MakeChild(mother);

            Society.Add(child);
            Console.WriteLine($"{father.Name} and {mother.Name} had a child named {child.Name}.");
        }

        public static void SimulateYear()
        {
            Random random = new Random();

            int newBirths = random.Next(0, 6);
            int deaths = random.Next(0, 3);
            int newHumans = random.Next(0, 6);
            int randomAge;

            foreach (Human h in Society.ToList())
            {
                randomAge = random.Next(5, 10);
                h.GetOlder(randomAge);
                h.Health += random.Next(-10, 6);
                h.Happiness += random.Next(-5, 6);

                if (h.Health < 0)
                {
                    h.Health = 0;
                }
                if (h.Happiness < 0)
                {
                    h.Happiness = 0;
                }
                if (h.Age >= 110)
                {
                    Die(h);
                    Console.WriteLine($"{h.Name} died of old age");
                }
            }



            for (int i = 0; i < newHumans; i++)
            {
                CreatRandomHumans();
            }

            for (int i = 0; i < newBirths; i++)
            {
                RandomMakeChild();
            }

            for (int i = 0; i < deaths; i++)
            {
                if (Society.Count == 0) break;
                RandomDeath();
            }

        }

        public static void SimulateGenerations(int population)
        {
            Console.WriteLine("\n===== Starting multi-generation simulation =====");


            int years = 0;
            while (Society.Count < population)
            {
                years++;
                Console.WriteLine($"\n--- Year {years} ---");


                SimulateYear();

                Console.WriteLine($"Population: {Society.Count}");

                if (Society.Count == 0)
                {
                    Console.WriteLine("Everyone has died. Simulation stopped.");
                    break;
                }
            }

            Console.WriteLine("\n===== Simulation complete =====");
            Console.WriteLine($"Years simulated: {years}");
            Console.WriteLine($"Final population: {Society.Count}");
            Console.WriteLine($"Average age: {Society.Average(h => h.Age):F1}");
        }


        public static void HappiestPerson()
        {
            Random random = new Random();
            foreach (Human h in Society)
            {
                double happy = random.Next(10, 80);
                h.Happiness += happy;
            }

            var happyiest = Society.MaxBy(h => h.Happiness);

            Console.WriteLine($"{happyiest.Name} is the happiest person {happyiest.Happiness}");
        }

        public static Human FindByName(string name)
        {
            var person = Society.FirstOrDefault(h => h.Name == name);

            if (person != null)
            {
                return person;
            }

            return null;
        }


    }
}
