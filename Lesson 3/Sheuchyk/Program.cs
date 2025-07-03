using System;

namespace Lesson3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Task 1: Deposit growth 

            Console.Write("Enter the deposit amount: ");
            decimal deposit = decimal.Parse(Console.ReadLine());

            decimal rate = 0.10m;

            deposit += deposit * rate;
            Console.WriteLine("Amount after year 1: " + deposit);

            deposit += deposit * rate;
            Console.WriteLine("Amount after year 2: " + deposit);

            deposit += deposit * rate;
            Console.WriteLine("Amount after year 3: " + deposit);

            Console.WriteLine(); 





            //Task 2: Even and odd in array 

            int[] numbers = { 3, 7, 4, 2, 8, 1, 5, 6, 9, 10 };

            int evenSum = 0;
            int oddCount = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    evenSum += numbers[i];
                }
                else
                {
                    oddCount++;
                }
            }

            Console.WriteLine("Sum of even numbers: " + evenSum);
            Console.WriteLine("Count of odd numbers: " + oddCount);

         
        }
    }
}