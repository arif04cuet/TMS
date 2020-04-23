using System;
using System.Collections.Generic;
using System.Linq;

namespace Migrator
{
    public class EnvironmentPicker
    {
        private static Dictionary<string, string> environments = new Dictionary<string, string>
        {
            { "localhost", null },
            { "Staging", "staging" },
            { "Production", "production" },
            { "Development", "development" }
        };

        public static string Pick()
        {
            string environmentName = null;
            Console.WriteLine("Choose Migration Options:");
            int index = 1;
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var environment in environments)
            {
                Console.WriteLine($"{index}. {environment.Key}");
                index++;
            }
            Console.ForegroundColor = ConsoleColor.White;

            while (true)
            {
                Console.Write(">_ ");
                var input = Console.ReadLine().Replace(">_ ", "");
                try
                {
                    var option = Convert.ToInt32(input) - 1;
                    environmentName = environments.ElementAt(option).Value;
                    break;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                }
                Console.ForegroundColor = ConsoleColor.White;
            }

            return environmentName;
        }
    }
}
