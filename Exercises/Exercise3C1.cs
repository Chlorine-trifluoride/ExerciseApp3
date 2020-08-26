using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace ExerciseApp3.Exercises
{
    [Description("A simple text file writer")]
    class Exercise3C1 : IExercise
    {
        public void Run()
        {
            Console.WriteLine("Write lines of text which you wish to write to a file.");
            Console.WriteLine("Enter an empty line to finish.");

            List<string> lines = new List<string>();
            bool done = false;

            while (!done)
            {
                string input = Console.ReadLine();

                if (input == "")
                {
                    done = true;
                    WriteLinesToFile(lines.ToArray());
                }

                else
                    lines.Add(input);
            }
        }

        private void WriteLinesToFile(string[] lines)
        {
            using (StreamWriter writer = new StreamWriter(GetFileNameFromUser(), false))
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    writer.WriteLine(lines[i]);
                }
            }
        }

        private string GetFileNameFromUser()
        {
            Console.WriteLine("What do you wish to call the file?");
            Console.WriteLine("Beware: It will be overwritten if it exists");

            string res = Console.ReadLine() + ".txt"; // lets add txt to avoid overwriting our important files
            // TODO: validate?

            return res;
        }
    }
}
