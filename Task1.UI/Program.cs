using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.UI
{
    class Program
    {
        static string menu = "\n\n1. Set timer and wait.\n2. Subscribe TooLate.\n3. Unsubscribe TooLate.\n" +
                             "4. Subscribe Stepan.\n5. Unsubscribe Stepan.\n6. Exit.\n\n";
        static void Main(string[] args)
        {
            TickTock time = new TickTock();
            TooLate die = null;
            Stepan stepan = null;
            
            
            bool wannaBreak = false;
            while (true)
            {
                Console.WriteLine(menu);
                string response = Console.ReadLine();
                int result;
                if (int.TryParse(response, out result) && result >= 1 && result <= 6)
                {
                    switch (result)
                    {
                        case 1:
                            Console.WriteLine("Enter time in milliseconds");
                            string responsedTime = Console.ReadLine();
                            int resultTime;
                            if (int.TryParse(responsedTime, out resultTime))
                                time.SetTheFinalCountDown(resultTime);
                            else
                            {
                                Console.WriteLine("Bad decision!");
                            }
                            break;

                        case 2:
                            die = new TooLate(time);
                            break;

                        case 3:
                            die?.Unregister(time);
                            break;

                        case 4:
                            stepan = new Stepan(time);
                            break;

                        case 5:
                            stepan?.Unregister(time);
                            break;

                        case 6:
                            wannaBreak = true;
                            break;
                    }
                    if(wannaBreak)
                        break;
                }
                else
                {
                    Console.WriteLine("Bad decision!");
                }
            }
        }
    }

    public class TooLate
    {
        public TooLate(TickTock time)
        {
            time.RockAroundTheClock += Boom;
        }

        private void Boom(object sender, TickTockEventsArgs eventArgs)
        {
            Console.WriteLine($"Live fast, die young. You was realy young, just {eventArgs.LastWaitingTime} milliseconds old.");
        }

        public void Unregister(TickTock time)
        {
            time.RockAroundTheClock -= Boom;
        }
    }

    public class Stepan
    {
        public Stepan(TickTock time)
        {
            time.RockAroundTheClock += Birthday;
        }

        private void Birthday(object sender, TickTockEventsArgs eventArgs)
        {
            Console.WriteLine($"Hello, Stepan. You are {eventArgs.LastWaitingTime} today.");
        }

        public void Unregister(TickTock time)
        {
            time.RockAroundTheClock -= Birthday;
        }
    }
}
