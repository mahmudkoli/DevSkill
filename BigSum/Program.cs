using System;

namespace BigSum
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstValue = "";
            string secondValue = "";
            string result = "";

            Console.WriteLine("Enter 1st value: ");
            firstValue = Console.ReadLine();

            Console.WriteLine("Enter 2nd value: ");
            secondValue = Console.ReadLine();

            result = StringSum(firstValue, secondValue);

            for (int i = 0; i < result.Length; i++)
            {
                if (result.ToCharArray()[0] != '0')
                    break;

                result = result.Substring(1);
            }

            Console.WriteLine($"Result is : {result}");
        }

        static string StringSum(string first, string second)
        {
            string newValue = "";
            string smallValue = "";
            string bigValue = "";
            char[] smallValueChar;
            char[] bigValueChar;
            bool hasCarry = false;
            int diffLen = 0;

            if (first.Length > second.Length)
            {
                smallValue = second;
                bigValue = first;
            }
            else
            {
                smallValue = first;
                bigValue = second;
            }

            diffLen = bigValue.Length - smallValue.Length;
            for (int i = 0; i < diffLen; i++)
            {
                smallValue = "0" + smallValue;
            }

            smallValueChar = smallValue.ToCharArray();
            bigValueChar = bigValue.ToCharArray();

            for (int i = (bigValue.Length - 1); i >= 0; i--)
            {
                string bChar = bigValueChar[i].ToString();
                string sChar = smallValueChar[i].ToString();
                int temp = Convert.ToInt32(bChar) + Convert.ToInt32(sChar);

                if (hasCarry)
                    temp += 1;

                if (temp > 9)
                {
                    newValue = (temp % 10).ToString() + newValue;
                    hasCarry = true;
                }
                else
                {
                    newValue = (temp).ToString() + newValue;
                    hasCarry = false;
                }

            }

            if (hasCarry)
                newValue = (1).ToString() + newValue;

            return newValue;
        }
    }
}

