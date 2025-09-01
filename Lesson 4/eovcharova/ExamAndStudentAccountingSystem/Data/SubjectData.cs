namespace ExamAndStudentAccountingSystem;

public class SubjectData
{
    public List<Subject> SubjectsInfo { get; set; }

    public SubjectData()
    {
        SubjectsInfo = new List<Subject>
        {
            new Subject("Биология", "А.М. Пирогов"),
            new Subject("Физика", "С.Д. Михалков"),
            new Subject("Химия", "А.Т. Менделеев"),
        };
    }
}