namespace ExamAndStudentAccountingSystem;

public class TeacherData
{
    public List<Teacher> TeacherPersonalData { get; set; }

    public TeacherData()
    {
        TeacherPersonalData = new List<Teacher>
        {
            new Teacher(1, "Иван", "Иванович", "Иванов"),
            new Teacher(2, "Петр", "Петрович", "Петров"),
            new Teacher(3, "Семен", "Семенович", "Семенов"),
        };
    }
}