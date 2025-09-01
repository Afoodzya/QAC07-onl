namespace ExamAndStudentAccountingSystem;

public interface ISubject
{
    string Subjectname { get; set; }
    string Teacher { get; set; }
    List<string> Subjects { get; set; }
    
   //string Schedule { get; set; }
   //void ViewSubjectStatistics();
}