public class Subject
{
    public string Name { get; set; }
    public string TeacherName { get; set; }

    public Subject(string name, string teacherName)
    {
        Name = name;
        TeacherName = teacherName;
    }
}
