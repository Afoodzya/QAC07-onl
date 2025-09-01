namespace ExamAndStudentAccountingSystem;

public class StudentInfoManager
{
    
    private readonly StudentData _studentData;
    //private List<Student> _students;

    public StudentInfoManager()
    {
        _studentData = new StudentData();
    }
    
    public void DisplayAllStudents()
    {
        foreach (var student in _studentData.Students)
        {
            Console.WriteLine(student);
        }
    }
    private List<int> IdsList()
    {
        var Ids = _studentData.Students.Select(s => s.Id).ToList();
        return Ids;
    }
    public void AddStudent()
    {
        Console.WriteLine("Введите имя, фамилию и курс нового студента через пробел: ");
        
        string userInput = Console.ReadLine() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(userInput))
        {
            Console.WriteLine("Вы не ввели данные нового студента!");
        }
        else
        {
            string[] newstudentInfo = userInput.Split(' ');
            if (newstudentInfo.Length == 4)
            {
                var idsNumber = IdsList().Count;
                int id = idsNumber + 1;
                
                Student newstudent = new Student(id, newstudentInfo[0], newstudentInfo[1], string.Join(" ", newstudentInfo[2], newstudentInfo[3]));
                // Student newstudent = new Student(id, newstudentInfo[0], newstudentInfo[1], $"{newstudentInfo[2]} {newstudentInfo[3]}");
                _studentData.Students.Add(newstudent);
                Console.WriteLine("Список студентов после добавления: ");
                DisplayAllStudents();
            }
            else
            {
                Console.WriteLine("Вы ввели данные неверно, попробуйте еще раз!");
            }
        }
    }
    // вывод на экран по фильтру
    public void DisplayStudentsByYearOfStudy()
    {
        Console.WriteLine("Ввведите курс обучения по образцу - первый/втрой... курс: ");
        string studetsInfo = Console.ReadLine() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(studetsInfo))
        {
            Console.WriteLine("Вы ввели информацию неккоректно, попробуйте еще раз!");
            return;
        }
        List<Student> studentsFound = GetStudentsByYearOfStudy(studetsInfo);
        PrintFoundStudentsInfo(studentsFound);
    }
    public void DisplayFoundStudentsPersanalData()
    {
        Console.WriteLine("Введите ИФ студента: ");
        string userInput = Console.ReadLine() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(userInput))
        {
            Console.WriteLine("Вы ввели информацию неккоректно, попробуйте еще раз!");
            return;
        }
        string[] studentInfo = userInput.Split(' ');
        if (studentInfo.Length != 2)
        {
            Console.WriteLine("Вы ввели данные неверно, попробуйте еще раз!");
            return;
        }

        string studentName = studentInfo[0];
        string studentLastname = studentInfo[1];

        List<Student> studentsFound = GetStudentsByNameAndLastname(studentName, studentLastname);
        PrintFoundStudentsInfo(studentsFound);
    }
    
    // фильтры
    private List<Student> GetStudentsByYearOfStudy(string yearofstudy)
    {
        
        return _studentData.Students
            .FindAll(s => s.YearOfStudy.Contains(yearofstudy, StringComparison.OrdinalIgnoreCase));
    }

    private List<Student> GetStudentsByNameAndLastname(string name, string lastname)
    {
        return _studentData.Students.FindAll(s => s.Firstname == name && s.Lastname == lastname);
    }

    // вывод списка для display методов
    private void PrintFoundStudentsInfo(List<Student> students)
    {
        if (students.Count > 0)
        {
            Console.WriteLine("Найдены студенты: ");
            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }
        }
        else Console.WriteLine("Студенты по запросу не найдены.");
    }
}