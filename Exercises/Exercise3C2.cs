using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.IO.Enumeration;
using System.Text;
using System.Text.Json;

namespace ExerciseApp3.Exercises
{
    class Note
    {
        [Key]
        public int ID { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Text { get; set; }
    }

    [Description("Note to JSON serializer")]
    class Exercise3C2 : IExercise
    {
        const string FILE_NAME = "notes.json";
        private List<Note> allNotes = new List<Note>();

        public void Run()
        {
            PrintHelp();

            bool done = false;

            for (int id = 0; !done; id++)
            {
                string input = Console.ReadLine();

                if (input == "")
                {
                    done = true;
                    SaveAllNotes();
                }

                else
                    AddUserNote(id, input);
            }
        }

        private void PrintHelp()
        {
            Console.WriteLine("Write a line of text to save as a note");
            Console.WriteLine("Enter an empty line to quit and save all your notes to JSON");
        }

        private void AddUserNote(int id, string text)
        {
            Note note = new Note
            {
                ID = id,
                Text = text,
                TimeStamp = DateTime.Now
            };

            allNotes.Add(note);
        }

        private void SaveAllNotes()
        {
            // Serialize to json string
            string jsonString = JsonSerializer.Serialize<List<Note>>(allNotes);

            // write to a file
            using (StreamWriter writer = new StreamWriter(FILE_NAME))
            {
                writer.Write(jsonString);
            }

            Console.WriteLine($"Saved to {FILE_NAME}");
        }
    }
}
