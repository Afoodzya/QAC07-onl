namespace ExamAndStudentAccountingSystem;

public interface ITeacher
{
    int Id { get; set; }
    string Name { get; set; }
    string Middlename { get; set; }
    string Lastname { get; set; }
    void ScheduleExamForStudent(); // или в экзамены
    //void ViewSubjectStatistics();
    //void ConvertTheGrade();
}