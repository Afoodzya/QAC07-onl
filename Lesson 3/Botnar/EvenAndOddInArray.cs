using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_3
{
    internal class EvenAndOddInArray
    {
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Чётные и нечётные в массиве\n");
                int[] rowOfNumbers = [25, 42, 10, 33, 9, 12, 11, 28, 18, 4];
                int evensSumm = 0;
                int oddsSumm = 0;
                Console.WriteLine("Исходные числа в массиве: ");
                Console.WriteLine(string.Join(" ", rowOfNumbers));

                foreach (int number in rowOfNumbers)

                {
                     if ((number % 2) == 0)
                    {
                        evensSumm += number;
                    }
                     else
                    {
                        oddsSumm += number;
                    }
                }
                Console.WriteLine($"\nСумма чётных чисел: {evensSumm}");
                Console.WriteLine($"\nСумма нечётных чисел: {oddsSumm}");
                Console.WriteLine("\n\nНажмите ESC для возврата в главное меню.");
                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.Escape:
                        Console.Clear();
                        return;
                }
            }
        }
    }
}
