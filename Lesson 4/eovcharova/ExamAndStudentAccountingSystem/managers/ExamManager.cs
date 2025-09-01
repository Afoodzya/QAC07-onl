namespace ExamAndStudentAccountingSystem;

public class ExamManager
{
    private readonly ExamResults _examResults;
    private readonly List<Student> _studentReport = new List<Student>();
    
    public ExamManager()
    {
        _examResults = new ExamResults();
    }
    
    public void GiveTheGradeToTheStudent()
    {
        Console.WriteLine("Введите ИФ студента и название предмета для оценивания: ");
        
        string userInput = Console.ReadLine() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(userInput))
        {
            Console.WriteLine("Вы ввели информацию неккоректно, попробуйте еще раз!");
            return; // или return null;
        }
        string[] studentInfo = userInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (studentInfo.Length != 3)
        {
            Console.WriteLine("Вы ввели данные неверно, попробуйте еще раз!");
            return; // или return null;
        }

        string studentName = studentInfo[0];
        string studentLastname = studentInfo[1];
        string subjectName = studentInfo[2];

        var studentExam = new ExamResults();
        string grade = studentExam.StartExam();
        
        // создаем студента и добавляем его в список
        var student = new Student(studentName, studentLastname, subjectName, grade);
        _studentReport.Add(student);
        // добавляем студента в отчет экзаменов
        _examResults.StudentExamResultsReport.Add(student);
    }
    public Student? ViewStudentReportByPersonalData()
    {
        Console.WriteLine("Введите ИФ студента и название предмета для просмотра результата: ");
        
        string userInput = Console.ReadLine() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(userInput))
        {
            Console.WriteLine("Вы ввели информацию неккоректно, попробуйте еще раз!");
            return null;
        }
        string[] studentInfo = userInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (studentInfo.Length != 3)
        {
            Console.WriteLine("Вы ввели данные неверно, попробуйте еще раз!");
            return null;
        }
        
        string studentName = studentInfo[0];
        string studentLastname = studentInfo[1];
        string subjectName = studentInfo[2];

        var result = _studentReport
            .FirstOrDefault(r => r.Firstname == studentName && r.Lastname == studentLastname && r.Subject == subjectName);

        _examResults.PrintExamReport();
        
        if (result == null)
        {
            Console.WriteLine("Результат не найден.");
        }
        return result;
    }
}