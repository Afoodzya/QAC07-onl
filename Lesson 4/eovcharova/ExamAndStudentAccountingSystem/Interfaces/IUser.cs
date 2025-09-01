namespace ExamAndStudentAccountingSystem;

public interface IUser
{
    string Role { get; set; }
    
    // void LogIn();
    bool CanEditData();
    bool CanViewStatistics();
}