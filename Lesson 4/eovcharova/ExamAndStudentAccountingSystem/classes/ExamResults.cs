namespace ExamAndStudentAccountingSystem;

public class ExamResults : IExamResults
{
    private const int MaxAttempts = 2; // Максимальное количество попыток
    private int _retakeAttempts;
    public List<Student> StudentExamResultsReport {get; set;} = new List<Student>();

    public ExamResults()
    {
    }
    public void PrintExamReport()
    {
        foreach (var studentExam in StudentExamResultsReport)
        {
            Console.WriteLine($"Имя: {studentExam.Firstname}");
            Console.WriteLine($"Фамилия: {studentExam.Lastname}");
            Console.WriteLine($"Предмет: {studentExam.Subject}");
            Console.WriteLine($"Оценка: {studentExam.Grade}");
        }
    }
    // методы для запуска экзамена и подсчета кол-ва попыток
    
    // метод объединяющий выставление оценки и если нужно пересдачу
    public string StartExam()
    {
        string grade = ConvertTheGrade();
        HandleRetakeIfNeeded(ref grade); // Передаем оценку по ссылке, чтобы изменить ее при пересдаче
        return grade;
    }
    private string ConvertTheGrade()
    {
        Console.Write("Введите балл за экзамен от 0 до 100: ");

        int subjectScore;
        if (!int.TryParse(Console.ReadLine(), out subjectScore) || subjectScore < 0 || subjectScore > 100)
        {
            Console.WriteLine("Некорректный ввод балла.");
            return string.Empty; // или можно выбросить исключение, или вернуть специальное значение
        }

        string grade = string.Empty;

        if (subjectScore >= 90 && subjectScore <= 100)
        {
            grade = "A";
            Console.WriteLine($"Оценка по экзамену - {grade} \"Отлично!\" Экзамен сдан!");
        }
        else if (subjectScore >= 80 && subjectScore <= 89)
        {
            grade = "B";
            Console.WriteLine($"Оценка по экзамену - {grade} \"Хорошо!\" Экзамен сдан!");
        }
        else if (subjectScore >= 70 && subjectScore <= 79)
        {
            grade = "C";
            Console.WriteLine($"Оценка по экзамену - {grade} \"Удовлетворительно!\" Экзамен сдан!");
        }
        else if (subjectScore < 60)
        {
            grade = "F"; // Определяем оценку F
            Console.WriteLine($"Оценка по экзамену - {grade} \"Неудовлетворительно!\"");
        }

        return grade;
    }
    private void HandleRetakeIfNeeded(ref string grade)
    {
        if (grade == "F")
        {
            Console.WriteLine("Экзамен не сдан. Начинаем процесс пересдачи.");
            int remainingAttempts = DefineRetakeToStudent(ref grade); // Передаем оценку по ссылке
            Console.WriteLine($"Осталось попыток пересдачи: {remainingAttempts}");
        }
    }
    private int DefineRetakeToStudent(ref string grade)
    {
        while (_retakeAttempts < MaxAttempts)
        {
            Console.WriteLine($"Попытка {_retakeAttempts + 1} из {MaxAttempts} для пересдачи.");

            // даем возможность еще раз сдать
            string newGrade = ConvertTheGrade(); // Вызов метода для получения новой оценки

            // Проверяем, была ли оценка успешной
            if (newGrade == "F") 
            {
                Console.WriteLine("Пересдача не удалась.");
                _retakeAttempts++; // Увеличиваем количество попыток только после неудачи
            }
            else
            {
                grade = newGrade; // Обновляем оценку
                Console.WriteLine("Экзамен успешно пересдан!");
                return MaxAttempts - (_retakeAttempts + 1); // Возвращаем количество оставшихся попыток
            }
        }

        Console.WriteLine("Попытки пересдачи исчерпаны.");
        return 0; // Все попытки исчерпаны, возвращаем 0
    }
}