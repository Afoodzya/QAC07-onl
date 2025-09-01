namespace ExamAndStudentAccountingSystem;

public class SubjectDataManager
{
    private readonly Subject _subject;
    private readonly SubjectData _subjectData;
   
    public SubjectDataManager()
    {
        _subject = new Subject();
        _subjectData = new SubjectData();
    }
    
    private List<Subject> GetSubjectInfo(string subjectname)
    {
        return _subjectData.SubjectsInfo.
            FindAll(s => s.Subjectname.Contains(subjectname, StringComparison.OrdinalIgnoreCase));
            
    }

    private void PrintSubjectInfo(List<Subject> subjects)
    {
        if (subjects.Count > 0)
        {
            Console.WriteLine("Информация о предмете: ");
            foreach (Subject subject in subjects)
            {
                Console.WriteLine(subject);
            }
        }
        else
        {
            Console.WriteLine("Такой предмет не найден.");
        }
    }

    public void DisplaySubjectInfo()
    {
        Console.WriteLine("Введите название предмета: ");
        string subjectinfo = Console.ReadLine();

        if (string.IsNullOrEmpty(subjectinfo))
        {
            Console.WriteLine("Название не может быть пустым!");
            return;
        }
        List<Subject> subjectsInfo = GetSubjectInfo(subjectinfo);
        PrintSubjectInfo(subjectsInfo);
    }
    // проверка что предмет можно назначить
    public void ChooseSubject()
    {
        Console.WriteLine("Введите название предмета для экзамена: ");
        string subject = Console.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(subject))
        {
            Console.WriteLine("Название не может быть пустым!");
            return;
        }
        
        var subjectToTake = _subject.Subjects
            .FirstOrDefault(s => string.Equals(s, subject, StringComparison.OrdinalIgnoreCase));
        //.FirstOrDefault(s =>s.Contains(subject, StringComparison.OrdinalIgnoreCase));
        if (subjectToTake != null)
        {
            // предмет попытка и оценка
            Console.WriteLine($"Предмет {subjectToTake} выбран для сдачи!");
        }
        else
        {
            Console.WriteLine("Предмет не найден.");
        }
    }
    
}