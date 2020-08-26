using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace ExerciseApp3
{
    class Program
    {
        private static bool exit = false;

        static void Main(string[] args)
        {
            LoadUsingAppDomain();
        }

        static void LoadUsingAppDomain()
        {
            var type = typeof(IExercise);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                        .SelectMany(s => s.GetTypes())
                        .Where(p => type.IsAssignableFrom(p) && p.IsClass);

            while (!exit)
                PrintLoadedMainMenu(types);
        }

        static string GetDescriptionAttributeText(Type t)
        {
            string result = "";
            DescriptionAttribute descriptionAttribute = (DescriptionAttribute)t.GetCustomAttribute(typeof(DescriptionAttribute));
            result = descriptionAttribute?.Description;

            return result;
        }

        static void PrintLoadedMainMenu(IEnumerable<Type> exercises)
        {
            Console.Clear();
            Console.WriteLine("Select Exercise to run:");
            Console.WriteLine("-----------------------");

            Type[] exerArray = exercises.ToArray();

            for (int i = 0; i < exercises.Count(); i++)
            {
                Type t = exerArray[i];

                Console.WriteLine($"{i}) {t.Name} - {GetDescriptionAttributeText(t)}");
            }

            char key = Console.ReadKey(true).KeyChar;
            int selection;

            if (int.TryParse(key.ToString(), out selection))
            {
                if (selection >= exerArray.Length)
                    return; // selection out of range

                Console.Clear();
                IExercise selectedExer = Activator.CreateInstance(exerArray[selection]) as IExercise;
                selectedExer.Run();

                // Stop returning 
                Console.ReadKey();
            }
        }
    }
}
