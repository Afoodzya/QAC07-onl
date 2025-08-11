public class ExamService : IExamService
{
    private const int MaxAttempts = 2;

    public void AddExamResult(Student student, Subject subject, int score)
    {
        var existingAttempts = student.ExamResults
            .Count(e => e.Subject.Name == subject.Name);

        if (existingAttempts >= MaxAttempts)
            throw new InvalidOperationException($"Превышено число попыток по предмету {subject.Name}");

        student.ExamResults.Add(new ExamResult(subject, score, existingAttempts + 1));
        Logger.Log($"Добавлен экзамен {subject.Name} студенту {student.Name}, попытка {existingAttempts + 1}");
    }

    public double GetAverageScoreBySubject(List<Student> students, string subjectName)
    {
        var allScores = students.SelectMany(s => s.ExamResults)
                                .Where(e => e.Subject.Name == subjectName)
                                .Select(e => e.Score)
                                .ToList();
        return allScores.Any() ? allScores.Average() : 0;
    }
}
