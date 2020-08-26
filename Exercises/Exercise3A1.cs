using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace ExerciseApp3.Exercises
{
    class Message
    {
        public static int totalMessages { get; private set; } = 0;
        public static string lastMessage { get; private set; } = string.Empty;

        private static List<Message> allMessages = new List<Message>();

        private string messageText = string.Empty;

        public Message(string message)
        {
            totalMessages++;
            lastMessage = message;

            allMessages.Add(this);
        }
    }

    [Description("Messages exercise")]
    class Exercise3A1 : IExercise
    {
        const int NUM_MESSAGES = 3;

        public void Run()
        {
            Console.WriteLine($"Write {NUM_MESSAGES} messages");

            for (int i = 0; i < NUM_MESSAGES; i++)
            {
                string message = Console.ReadLine();
                new Message(message);
            }

            Console.WriteLine($"Total messages: {Message.totalMessages}");
            Console.WriteLine($"Last messages: {Message.lastMessage}");
        }
    }
}
