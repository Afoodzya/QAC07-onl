using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_3
{
    internal class ResultByAverageScore
    {
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Оценка результата по среднему баллу \n");
                Console.WriteLine("Введите через запятую оценки по пяти предметам: ");

                string input = Console.ReadLine();

                int[] scores = input.Split(',').Select(s => int.Parse(s.Trim())).ToArray();
                int averageScore = (scores.Sum() / 5);

                if (averageScore >= 90)
                {
                    Console.WriteLine("\nОтлично");
                }
                else if (averageScore >= 75 && averageScore <= 89)
                {
                    Console.WriteLine("\nХорошо");
                }
                else if (averageScore >= 60 && averageScore <= 74)
                {
                    Console.WriteLine("\nУдовлетворительно");
                }
                else
                {
                    Console.WriteLine("\nНеудовлетворительно");
                }

                Console.WriteLine("\nЖелаете рассчитать результат для других предметов? [Д/Н]");
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
