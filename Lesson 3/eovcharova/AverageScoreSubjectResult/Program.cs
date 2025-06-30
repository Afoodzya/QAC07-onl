namespace AverageScoreSubjectResult;

class Program
{
    static void Main(string[] args)
    {
        // Задача № 3

        // задаем начальное значение для суммы оценок
        int gradesSum = 0;
        string[] subjects = new[] { "1st", "2nd", "3rd", "4th", "5th" };

        // цикл для сбора оценок по предметам и суммирования
        for (int i = 0; i < subjects.Length; i++)
        {
            Console.WriteLine("Enter the grade for the {0} subject (from 0 to 100)", subjects[i]);

            int grade = Convert.ToInt32(Console.ReadLine());
            // сумма оценок по предметам
            gradesSum += grade;
        }

        // вычисляем средний балл по предметам
        int averageScoreResult = gradesSum / subjects.Length;
        
        // вывод среднего балла и описание результата
        Console.WriteLine(GetAvrScoreGradesResultDescription(averageScoreResult));
    }

    // переносим логику определения результата в зависимости от оценки в метод для улучшения читаемости кода,
    // логика определения описания оценки сосредоточена в одном месте — проще изменять и поддерживать
    
    // static - относится к классу
    // string - тип возвращаемого методом значения
    // (int averageScoreResult) — параметр метода
        static string GetAvrScoreGradesResultDescription(int averageScoreResult)
        {
            if (averageScoreResult >= 90)
            {
                return "Your grade is excellent: " + averageScoreResult;
            }

            if (averageScoreResult >= 75)
            {
                return "Your grade is good: " + averageScoreResult;
            }
            if (averageScoreResult >= 60)
            {
                return "Your grade is satisfactory: " + averageScoreResult;
            }
            return "Your grade is unsatisfactory: " + averageScoreResult;
        }
        
        /*
         первый вариант без метода
        if (averageScoreResult >= 90)
        {
            Console.WriteLine("Your grade is excellent: " + averageScoreResult);
        } 
        else if (averageScoreResult < 90 && averageScoreResult >= 75)
        {
            Console.WriteLine("Your grade is good: " + averageScoreResult);
        }
        else if (averageScoreResult < 75 && averageScoreResult >= 60)
        {
            Console.WriteLine("Your grade is satisfactory: " + averageScoreResult);
        }
        else //(averageScoreResult < 60)
        {
            Console.WriteLine("Your grade is unsatisfactory: " + averageScoreResult);
        } */
    }
