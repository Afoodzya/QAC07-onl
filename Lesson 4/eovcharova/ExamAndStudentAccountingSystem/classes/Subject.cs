namespace ExamAndStudentAccountingSystem;

public class Subject : ISubject
{
    public string Subjectname { get; set; }
    public string Teacher { get; set; }
    public List<string> Subjects { get; set; }
    
    //public string Schedule { get; set; }

    public Subject()
    {
        Subjects = new List<string>
        {
            "Биология", "Физика", "Химия"
        };
    }
    public Subject(string subjectname, string teacher)
    {
        Subjectname = subjectname;
        Teacher = teacher;
    }

    public override string ToString()
    {
        return $"Предмет: {Subjectname}, Преподаватель: {Teacher}";
    }
}