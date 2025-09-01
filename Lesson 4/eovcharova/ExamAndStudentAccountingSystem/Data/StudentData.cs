using System.Collections.Immutable;

namespace ExamAndStudentAccountingSystem;

public class StudentData
{
    public List<Student> Students { get; set; }

    public StudentData()
    {
        Students = new List<Student>
        {
            new Student(1,"Дмитрий", "Смирнов", "первый курс"),
            new Student(2,"Мария", "Александрова", "последний курс"),
            new Student(3,"Михаил", "Задунайский", "первый курс"),
            new Student(4,"Светлана", "Морозова", "первый курс")
        };
    }
}