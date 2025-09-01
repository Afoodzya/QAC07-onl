namespace ExamAndStudentAccountingSystem;

public class Student : IStudent
{
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Subject { get; set; }
    public string Grade { get; set; }
    public int? RetakeAttempt { get; set; }
    public string YearOfStudy { get; set; }
    public List<string> ExamResults { get; set; }

    public Student(string firstname, string lastname, string subject, string grade, int? retakeAttempt = null)
    {
        Firstname = firstname;
        Lastname = lastname;
        Subject = subject;
        Grade = grade;
        RetakeAttempt = retakeAttempt;
    }

    public Student(int id, string firstname, string lastname, string year)
    {
        Id = id;
        Firstname = firstname;
        Lastname = lastname;
        YearOfStudy = year;
    }

    public Student(string firstname, string lastname)
    {
        Firstname = firstname;
        Lastname = lastname;
        ExamResults = new List<string>();
    }

    public override string ToString()
    {
        return $"id: {Id}, Имя: {Firstname}, Фамилия: {Lastname}, курс: {YearOfStudy}";
    }
}