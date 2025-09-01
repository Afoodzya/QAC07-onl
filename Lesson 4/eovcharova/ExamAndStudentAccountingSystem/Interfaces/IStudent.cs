namespace ExamAndStudentAccountingSystem;

public interface IStudent
{
    int Id { get; set; }
    string Firstname { get; set; }
    string Lastname { get; set; }
    string Subject { get; set; }
    string Grade { get; set; }
    string YearOfStudy { get; set; }
    int? RetakeAttempt { get; set; }
    List<string> ExamResults { get; set; }
    
    //void ViewSubjectInfo(); // посмотреть кто препод + расписание 
    //void ExamInfo(); // оценка, количество пересдач и прочее
}