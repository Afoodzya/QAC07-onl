namespace ExamAndStudentAccountingSystem;

public class Teacher : ITeacher
{
    // чтобы использовать метод из другого класса
    // нужно иметь доступ к экземпляру класса (через поле, параметр конструктора или иным способом)
    
    private readonly SubjectDataManager _subjectDataManager;
    private readonly StudentInfoManager _manager;

    private readonly List<string> _studentsExamList = new List<string>();
    
    // Конструктор с передачей зависимости
    public Teacher()
    {
        _subjectDataManager = new SubjectDataManager();
        _manager = new StudentInfoManager();
    }
    
    public int Id { get; set; }
    public string Name { get; set; }
    public string Middlename { get; set; }
    public string Lastname { get; set; }
    

    public Teacher(int id, string name, string secondname, string lastname)
    {
        Id = id;
        Name = name;
        Middlename = secondname;
        Lastname = lastname;
        
    }
    public override string ToString()
    {
        return $"id: {Id}, Имя: {Name}, Отчество: {Middlename} Фамилия: {Lastname}";
    }
    public void ScheduleExamForStudent()
    {
        // из ввода брать данные для вывода в конце что и кому назначено
        _subjectDataManager.ChooseSubject();
        _manager.DisplayFoundStudentsPersanalData();
        Console.WriteLine($"Вы назначили студенту экзамен.");
    }

    public void ScheduleExamForStudent2()
    {
        Console.WriteLine("Введите название предмета для экзамена: ");
        string subjectName = Console.ReadLine();
        _studentsExamList.Add(subjectName);
        Console.WriteLine("Введите имя и фамилию студента: ");
        string student = Console.ReadLine();
        _studentsExamList.Add(student);

        foreach (var item in _studentsExamList)
        {
            Console.Write(item + " ");
        }
    }
}