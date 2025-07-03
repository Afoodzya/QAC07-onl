using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_3
{
    internal class DepositCalculator
    {
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Калькулятор вклада \n");
                Console.WriteLine("Введите сумму депозита: ");
                Decimal interestRate = 1.1m;
                decimal deposit = decimal.Parse(Console.ReadLine());
                Console.WriteLine("\nПри процентной ставке 10% годовых и сроке депозита 3 года сумма на счету составит: \n");

                for (int i = 0; i < 3; i++)

                {
                    deposit = deposit * interestRate;
                    Console.WriteLine($"Год {i + 1}: {deposit:N2}");
                }

                Console.WriteLine("\nЖелаете выполнить рассчёт для другой суммы? [Д/Н]");
                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.L:
                        break;

                    case ConsoleKey.Y or ConsoleKey.Escape:
                        Console.Clear();
                        return;
                }
            }
        }
    }
}
