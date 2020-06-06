using System;
using System.Runtime.Serialization;

namespace Time
{
    class Program
    {
        static void Main(string[] args)
        {
            int flag12Hour = 0;
            string value;

            Console.WriteLine("Please enter 0 or 1 (0 for 12 hour and 1 for 24 hour) : ");
            flag12Hour = Convert.ToInt32(Console.ReadLine());

            var valFor = flag12Hour == 0 ? "24 hour" : "12 hour";
            Console.WriteLine($"Enter the time ({valFor}): ");
            value = Console.ReadLine();

            if(flag12Hour == 0)
            {
                if(!(value.Contains("AM") || value.Contains("PM")))
                {
                    var hour = Convert.ToInt32(value.Split(':')[0]);
                    string format = "AM";

                    if(hour == 0)
                    {
                        hour = 12;
                    }
                    else if(hour > 12)
                    {
                        hour -= 12;
                        format = "PM";
                    }

                    value = hour + value.Substring(value.IndexOf(':')) + " " + format;
                }
            }
            else
            {
                if (value.Contains("AM"))
                {
                    var hour = Convert.ToInt32(value.Split(':')[0]);

                    if (hour == 12)
                    {
                        hour = 0;
                    }

                    value = hour + value.Substring(value.IndexOf(':'));
                }
                else if (value.Contains("PM"))
                {
                    var hour = Convert.ToInt32(value.Split(':')[0]);

                    hour += 12;

                    value = hour + value.Substring(value.IndexOf(':'));
                }
            }

            var resFor = flag12Hour == 0 ? "12 hour" : "24 hour";
            Console.WriteLine($"New time format ({resFor}): {value}");
        }
    }
}
