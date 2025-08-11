public class ExamResult
{
    public Subject Subject { get; set; }
    public int Score { get; set; }
    public int Attempt { get; set; }

    public string Grade
    {
        get
        {
            if (Score >= 90) return "A";
            if (Score >= 75) return "B";
            if (Score >= 60) return "C";
            if (Score >= 50) return "D";
            return "F";
        }
    }

    public ExamResult(Subject subject, int score, int attempt)
    {
        Subject = subject;
        Score = score;
        Attempt = attempt;
    }
}
