using System.ComponentModel.DataAnnotations;

namespace Task1_Kayumov
//Задание #1. Калькулятор роста вклада
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, you are opening a deposit at 10% per annum.");
            Console.WriteLine("Please indicate the amount you wish to deposit:");

            decimal money = decimal.Parse(Console.ReadLine());

            double[] percentYears = new double[3];

            for (int i = 1; i <= percentYears.Length; i++)
            {
                percentYears[i - 1] = Math.Pow(1.1, i);
            }

            Console.WriteLine($"The total amount after 3 years, taking into account the annual increase, will be = {money * (decimal)percentYears[2]}");

            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"The amount on the deposit, taking into account capitalization after {i} year, is = {money * (decimal)percentYears[i-1]}");
            }                       
        }
    }
}
