public interface IExamService
{
    void AddExamResult(Student student, Subject subject, int score);
    double GetAverageScoreBySubject(List<Student> students, string subjectName);
}
