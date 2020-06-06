using System;

namespace Diamond
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 0;

            Console.WriteLine("Enter the size: ");
            number = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= (number/2 + 1); i++)
            {
                for (int j = 0; j < number-i; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < i*2-1; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            for (int i = (number/2); i > 0; i--)
            {
                for (int j = 0; j < number-i; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < i*2-1; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }


        }
    }
}
