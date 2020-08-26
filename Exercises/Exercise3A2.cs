using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ExerciseApp3.Exercises
{
    // IInfo is a bad name
    interface IDetails
    {
        public string InfoText { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine($"InfoText: {InfoText}");
        }
    }

    class Product : IDetails
    {
        public string InfoText { get; set; }

        public Product(string text)
        {
            this.InfoText = text;
        }
    }

    class Category : IDetails
    {
        public string InfoText { get; set; }

        public Category(string text)
        {
            this.InfoText = text;
        }
    }

    [Description("Interface Details Exercise")]
    class Exercise3A2 : IExercise
    {
        List<IDetails> allDetails = new List<IDetails>();

        public void Run()
        {
            allDetails.Add(new Product("ProductInfo"));
            allDetails.Add(new Category("CategoryInfo"));
            allDetails.Add(new Product("ProductInfo2"));
            allDetails.Add(new Category("CategoryInfo2"));

            Console.WriteLine("Press Enter to print details");
            Console.WriteLine("Press Q to quit");

            for (; ; )
            {
                ConsoleKey key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.Enter:
                        PrintAllDetails();
                        break;

                    case ConsoleKey.Q:
                        return;
                }
            }
        }

        private void PrintAllDetails()
        {
            foreach (IDetails details in allDetails)
            {
                details.PrintInfo();
            }
        }
    }
}
