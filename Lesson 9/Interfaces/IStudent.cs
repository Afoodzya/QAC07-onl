public interface IStudent
{
    Guid Id { get; }
    string Name { get; set; }
    List<ExamResult> ExamResults { get; }
    double GetSuccessRating();
}
