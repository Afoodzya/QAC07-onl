namespace Students.Models
{
    public class SetPointToStudent
    {
        public string projectRoot = Directory.GetParent(Directory.GetCurrentDirectory())!
            .Parent!
            .Parent!
            .FullName;

        private string[] studentsNames;
        private string[] subjects;

        public string selectedStudent;
        public string subject;

        // Конструктор принимает предмет (из TeacherAuthorization)
        public SetPointToStudent(string subjectName)
        {
            subject = subjectName;
        }

        public void GetStudentsList()
        {
            string studentsPath = Path.Combine(projectRoot, "Docs", "Students");
            studentsNames = Directory.GetDirectories(studentsPath);
            Console.WriteLine("Выберите студента:");
            for (int i = 0; i < studentsNames.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Path.GetFileName(studentsNames[i])}");
            }
        }

        public void GetStudent()
        {
            Console.WriteLine("Введите id студента (порядковый номер):");
            int index = int.Parse(Console.ReadLine());
            selectedStudent = studentsNames[index - 1];
            Console.WriteLine($"Вы выбрали: {Path.GetFileName(selectedStudent)}");
        }

        public void SetExam()
        {
            string filePathExsumResultDoc = Path.Combine(
                projectRoot,
                "Docs",
                "Students",
                $"{selectedStudent}",
                $"{subject}.txt"
            );

            if (!File.Exists(filePathExsumResultDoc))
            {
                File.Create(filePathExsumResultDoc).Close();
                Console.WriteLine($"Экзамен по {subject} назначен. Файл создан.");
            }
            else
            {
                Console.WriteLine($"Файл экзамена по {subject} уже существует.");
            }
        }

        public void SetMark()
        {
            string studentFolder = Path.Combine(projectRoot, "Docs", "Students", $"{selectedStudent}");
            Attempt attempt = new Attempt(studentFolder, subject);

            Console.WriteLine("Введите оценку за экзамен (A, B, C, D, F):");
            string mark = Console.ReadLine();
            attempt.AddMark(mark);
        }

    }
}
