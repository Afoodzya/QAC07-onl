namespace Students.Models
{
    public class SetExamsToStudent
    {
        public string projectRoot = Directory.GetParent(Directory.GetCurrentDirectory())!
            .Parent!
            .Parent!
            .FullName;
        private string[] studentsNames;
        private string[] subjects;
        public string selectedStudent;
        public string subject;
        public void GetStudentsList() 
        {
            string studentsPath = Path.Combine(projectRoot, "Docs", "Students");
            studentsNames = Directory.GetDirectories(studentsPath);
            Console.WriteLine("Выберите студента");
            foreach (string names in studentsNames)
            {
                Console.WriteLine(Path.GetFileName(names));
            }
        }
        public void GetStudent()
        {
            Console.WriteLine("Введите id студента (порядковый номер):");
            int index = int.Parse(Console.ReadLine());
            selectedStudent = studentsNames[index - 1];
            Console.WriteLine($"Вы выбрали: {Path.GetFileName(selectedStudent)}");
        }

        public void GetSubjectsList() 
        {
            Console.WriteLine("Список экзаменов:");
            string subjectsPath = Path.Combine(projectRoot, "Docs", "Teachers");
            subjects = Directory.GetDirectories(subjectsPath);
            for (int s = 0; s < subjects.Length; s++)
            {
                subject = subjects[s];
                Console.WriteLine($"{s + 1}. {Path.GetFileName(subjects[s])}");               
            }
        }
        public void SetExam()
        {
            Console.WriteLine("Введите порядковый номер:");
            int index = int.Parse(Console.ReadLine());
            string selectedExam = subjects[index - 1];
            Console.WriteLine($"Экзамен по {Path.GetFileName(selectedExam)} назначен");

            string filePathExsumResultDoc = Path.Combine(projectRoot, "Docs", "Students", $"{selectedStudent}", $"{Path.GetFileName(selectedExam)}.txt");
            File.Create(filePathExsumResultDoc).Close();
        }
        
        public void SetPrepod()
        {
            Console.WriteLine("Выберите преподавателя:");
            string prepodsPath = Path.Combine(projectRoot, "Docs", "Teachers", $"{subject}");
            string[] prepods = Directory.GetDirectories(prepodsPath);
            
            for (int p = 0; p < prepods.Length; p++)
            {
                Console.WriteLine($"{p + 1}. {Path.GetFileName(prepods[p])}");
            }
            Console.WriteLine("Введите порядковый номер:");
            int index = int.Parse(Console.ReadLine());
            string selectedPrepod = subjects[index - 1];
            Console.WriteLine($"На экзамен назначен преподаватель {selectedPrepod}");
            //Возможно
            //берём папку студента
            //смотрим наличие файла с названием Level
            // 
        }
    }
}
