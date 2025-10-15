namespace WorldSimulator.Service
{
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

                HumanHelper.EvaAndAdamMakeChildren(8);

                Console.WriteLine("\n================Year======================");
                HumanHelper.SimulateYear();
                Console.WriteLine("\n=========================================");

                HumanHelper.SeeAllHumans();
                Console.WriteLine("\n=========================================");

                Console.WriteLine("End of creation sequence.");
            }
        }
    }
}

