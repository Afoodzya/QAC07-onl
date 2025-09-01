namespace ExamAndStudentAccountingSystem;

class Program
{
    static void Main(string[] args)
    {
        // создаем экземпляр и через него вызываем метод
        
        // Дмитрий Смирнов химия
        
        Teacher teacher = new Teacher();
        //teacher.ScheduleExamForStudent2();
        teacher.ScheduleExamForStudent();
        ExamManager examManager = new ExamManager();
        examManager.GiveTheGradeToTheStudent();
        examManager.ViewStudentReportByPersonalData();
        
        StudentInfoManager studentManager = new StudentInfoManager();
        studentManager.DisplayAllStudents();
        studentManager.AddStudent();
        studentManager.DisplayFoundStudentsPersanalData();
        studentManager.DisplayStudentsByYearOfStudy();
        
        
        SubjectDataManager subjectManager = new SubjectDataManager();
        subjectManager.DisplaySubjectInfo();
        subjectManager.ChooseSubject();
        
        
        
        StudentData studentData = new StudentData();
        Subject subject = new Subject();
        SubjectData subjectData = new SubjectData();
        
    }
}