using System;
using System.Collections.Generic;
using System.Linq;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 0;
            var data = new List<string>();

            Console.WriteLine("How many data do you want to add: ");
            number = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                data.Add(Console.ReadLine());
            }

            Console.WriteLine("After sorting: ");

            data = data.OrderBy(x => x.Split(',')[1])
                    .ThenBy(x => x.Split(',')[0]).ThenBy(x => x.Split(',')[2]).ToList();

            for (int i = 0; i < number; i++)
            {
                Console.WriteLine(data[i]);
            }
        }
    }
}
