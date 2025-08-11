using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static List<Student> students = new List<Student>();
    static ExamService examService = new ExamService();
    static UserRole adminRole = new UserRole("admin");
    static UserRole studentRole = new UserRole("student");

    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("===== МЕНЮ =====");
            Console.WriteLine("1. Добавить студента");
            Console.WriteLine("2. Назначить экзамен");
            Console.WriteLine("3. Показать отчёт студента");
            Console.WriteLine("4. Средний балл по предмету");
            Console.WriteLine("5. Выход");
            Console.Write("Выбор: ");
            var choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        if (!adminRole.CanEditData()) { Console.WriteLine("Нет прав."); break; }
                        AddStudent();
                        break;
                    case "2":
                        if (!adminRole.CanEditData()) { Console.WriteLine("Нет прав."); break; }
                        AssignExam();
                        break;
                    case "3":
                        ShowStudentReport();
                        break;
                    case "4":
                        ShowSubjectStatistics();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.Log("Ошибка: " + ex.Message);
            }
        }
    }

    static void AddStudent()
    {
        Console.Write("Имя студента: ");
        string name = Console.ReadLine();
        students.Add(new Student(name));
        Logger.Log($"Добавлен студент: {name}");
    }

    static void AssignExam()
    {
        Console.Write("Имя студента: ");
        string name = Console.ReadLine();
        var student = students.FirstOrDefault(s => s.Name == name);
        if (student == null) { Console.WriteLine("Студент не найден."); return; }

        Console.Write("Предмет: ");
        string subjectName = Console.ReadLine();
        Console.Write("Преподаватель: ");
        string teacher = Console.ReadLine();
        Console.Write("Баллы: ");
        int score = int.Parse(Console.ReadLine());

        examService.AddExamResult(student, new Subject(subjectName, teacher), score);
    }

    static void ShowStudentReport()
    {
        Console.Write("Имя студента: ");
        string name = Console.ReadLine();
        var student = students.FirstOrDefault(s => s.Name == name);
        if (student == null) { Console.WriteLine("Студент не найден."); return; }

        Console.WriteLine($"Отчёт по студенту {student.Name} (ID: {student.Id})");
        foreach (var exam in student.ExamResults)
        {
            Console.WriteLine($"{exam.Subject.Name} (преп. {exam.Subject.TeacherName}), Балл: {exam.Score}, Оценка: {exam.Grade}, Попытка: {exam.Attempt}");
        }
        Console.WriteLine($"Средний балл: {student.ExamResults.Select(e => e.Score).DefaultIfEmpty(0).Average():F2}");
        Console.WriteLine($"Рейтинг (A/B): {student.GetSuccessRating():F2}%");
        Console.WriteLine($"Количество пересдач: {student.ExamResults.Count(e => e.Attempt > 1)}");
    }

    static void ShowSubjectStatistics()
    {
        Console.Write("Название предмета: ");
        string subjectName = Console.ReadLine();
        double avg = examService.GetAverageScoreBySubject(students, subjectName);
        Console.WriteLine($"Средний балл по '{subjectName}': {avg:F2}");
    }
}
