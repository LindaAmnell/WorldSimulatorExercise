namespace WorldSimulator.Service
{
    using global::WorldSimulator.Models;
    using System;

    namespace WorldSimulator.Service
    {
        public static class RunTheWorld
        {
            public static void CreationOfTheWorld()
            {
                Console.WriteLine("Creating the world...");

                HumanHelper.CreateGod();
                HumanHelper.CreateAdamAndEve();

                HumanHelper.Society.Add(HumanHelper.Adam);
                HumanHelper.Society.Add(HumanHelper.Eve);

                Console.WriteLine("The beginning of humanity...");

                HumanHelper.EvaAndAdamMakeChildren(13);

                Console.WriteLine("\n=========================================\n");
                Console.WriteLine("Write a name to search;");
                string name = Console.ReadLine();
                Human found = HumanHelper.FindByName(name);

                if (found != null)
                {
                    Console.WriteLine($"Found {found}");
                }
                else
                {
                    Console.WriteLine("Could not find that person.");
                }

                Console.WriteLine("\n================Year======================");
                HumanHelper.SimulateYear();

                Console.WriteLine("\n================Population=====================¨\n");
                HumanHelper.SimulateGenerations(50);
                HumanHelper.HappiestPerson();
                Console.WriteLine("\n=========================================\n");
                HumanHelper.SeeAllHumans();
                Console.WriteLine("\n=========================================\n");

                Console.WriteLine("End of creation sequence.");

            }
        }
    }

}