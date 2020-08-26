using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ExerciseApp3.Exercises
{
    public class PlantEventAttribute : Attribute
    {

    }

    [Description("Rudimentary Event System")]
    class Exercise3B1 : IExercise
    {
        private bool done = false;
        delegate void PrintDelegate();
        PrintDelegate eventsToExec = null;

        [PlantEventAttribute]
        private void ReleaseWater()
        {
            Console.WriteLine("Releasing water");
        }

        [PlantEventAttribute]
        private void ReleaseFertilizer()
        {
            Console.WriteLine("Releasing fertilizer");
        }

        [PlantEventAttribute]
        private void IncreaseTemperature()
        {
            Console.WriteLine("Increasing temperature");
        }

        public void Run()
        {
            //eventsToExec += ReleaseWater;
            //eventsToExec();

            PrintEventMethodsHelp();

            // Once done is set to true we fall bakc here
            // Execute the events delegate
            eventsToExec();
        }

        private void PrintEventMethodsHelp()
        {
            Console.WriteLine("Toggle events on");

            // Get the methods we want using reflection and attributes
            Type t = this.GetType();
            MethodInfo[] methods = t.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            MethodInfo[] eventMethods = methods.Where(m => m.GetCustomAttributes(typeof(PlantEventAttribute), false).Length > 0).ToArray();

            for (int i = 0; i < eventMethods.Length; i++)
            {
                Console.WriteLine($"{i}) - {eventMethods[i].Name}");
            }

            Console.WriteLine("9) Done - Execute events");

            while (!done)
            {
                GetUserInput(eventMethods);
            }
        }

        private void GetUserInput(MethodInfo[] eventMethods)
        {
            char selectionChar = Console.ReadKey(true).KeyChar;
            
            if (int.TryParse(selectionChar.ToString(), out int selection))
            {
                if (selection == 9)
                {
                    done = true;
                    return;
                }

                else if (selection > eventMethods.Length - 1)
                    return; // out of range

                // Add selected event to our delegate
                PrintDelegate printDelegate = (PrintDelegate)Delegate.CreateDelegate(typeof(PrintDelegate), this, eventMethods[selection]);
                eventsToExec += printDelegate;
            }
        }
    }
}
