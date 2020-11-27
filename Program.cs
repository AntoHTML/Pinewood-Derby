using System;
using System.Threading;
using System.Collections.Generic;

namespace Race
{
    class Program
    {
        static long startTime = 0;
        private static List<Participant> 
        participants = new List<Participant>();
        static void Main(string[] args)
        {
            Console.Clear();
            ConsoleKeyInfo x;
            Console.WriteLine("How many total participants?");
            var numparticipants1 = Console.ReadLine();
            var numparticipants = Int32.Parse(numparticipants1);
            var participantscount = 0;
            do
            {
                Console.WriteLine("Enter participant's name.");
                var partname = Console.ReadLine();
                Console.WriteLine("Enter participant's car number.");
                var partcar1 = Console.ReadLine();
                var partcar = Int32.Parse(partcar1);
                Console.WriteLine("Enter participant's lane number");
                var partlane1 = Console.ReadLine();
                var partlane = char.Parse(partlane1);
                Console.WriteLine("Enter the participant's rank");
                var partrank = Console.ReadLine();
                var newparticipant = new Participant { Name = partname, Car = partcar, Lane = partlane, Rank = partrank};
                participants.Add(newparticipant);
                Console.Clear();
                participantscount++;
            } while (participantscount < numparticipants);
            int counter = 0;
            RaceStart();
            do
            {
                x = Console.ReadKey();
                Console.CursorLeft = 0;
                Print(x);
                counter++;
            } while (counter < numparticipants);

            Console.WriteLine("Congratulations Racers!");            
        }

        private static void Print(ConsoleKeyInfo o)
        {
            double diff = DateTime.Now.Ticks - startTime;
            var seconds = Math.Round((diff / 10000000), 4);
            var finisher = participants.Find(x => x.Lane == o.KeyChar);
            if (finisher != null)
            {
            Console.WriteLine($"{finisher.Name} in lane {finisher.Lane} finished in {seconds} seconds.");
            }
        }

        private static void RaceStart()
        {
            Console.WriteLine($"Gentlemen!, Start your engines!!");
            Thread.Sleep(2000);
            Console.Write("Ready in : ");
            int count = 5;
            do
            {
                Console.Write(count);
                --count;
                Thread.Sleep(1000);
                if (Console.CursorLeft > 0)
                {
                Console.CursorLeft = Console.CursorLeft - 1;
                }

            } while (count > 0);
            Console.Clear();
            startTime = DateTime.Now.Ticks;
            Console.WriteLine($"GO!!!");
        }
    }
    public class Participant
    {
        public string Name { get; set; }
        public int Car { get; set; }
        public char Lane { get; set; }
        public string Rank { get; set; }
    }
}
