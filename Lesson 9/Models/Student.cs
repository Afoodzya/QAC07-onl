using System;
using System.Collections.Generic;
using System.Linq;

public class Student : IStudent
{
    public Guid Id { get; private set; }
    public string Name { get; set; }
    public List<ExamResult> ExamResults { get; private set; } = new List<ExamResult>();

    public Student(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }

    public double GetSuccessRating()
    {
        if (!ExamResults.Any()) return 0;
        var successCount = ExamResults.Count(e => e.Grade == "A" || e.Grade == "B");
        return (double)successCount / ExamResults.Count * 100;
    }
}
