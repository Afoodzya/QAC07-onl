namespace Students.Models
{
    public class StudentReport
    {
        private readonly string projectRoot;

        public StudentReport()
        {
            projectRoot = Directory.GetParent(Directory.GetCurrentDirectory())!
                .Parent!
                .Parent!
                .FullName;
        }

        public void ShowReport(string studentName)
        {
            string studentFolder = Path.Combine(projectRoot, "Docs", "Students", studentName);

            if (!Directory.Exists(studentFolder))
            {
                Console.WriteLine("Студент не найден.");
                return;
            }

            string[] examFiles = Directory.GetFiles(studentFolder, "*.txt")
                .Where(f => !Path.GetFileName(f).StartsWith("level", StringComparison.OrdinalIgnoreCase) &&
                            !Path.GetFileName(f).Equals("LoginData.txt", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            if (examFiles.Length == 0)
            {
                Console.WriteLine("У студента пока нет экзаменов.");
                return;
            }

            int totalPoints = 0;
            int totalExams = 0;
            int totalAttempts = 0;
            int totalFails = 0;

            Console.WriteLine($"\n--- Отчёт о студенте: {studentName} ---");

            foreach (string examFile in examFiles)
            {
                string subjectName = Path.GetFileNameWithoutExtension(examFile);
                string[] marks = File.ReadAllLines(examFile);

                if (marks.Length == 0)
                {
                    Console.WriteLine($"{subjectName}: нет оценок");
                    continue;
                }

                Console.WriteLine($"\nПредмет: {subjectName}");
                foreach (string m in marks)
                {
                    Console.WriteLine(m);
                }

                
                string lastMark = marks.Last().Split('-').Last().Trim();
                int numeric = ConvertGradeToPoints(lastMark);

                if (numeric > 0)
                {
                    totalPoints += numeric;
                    totalExams++;
                }

                
                totalFails += marks.Count(m => m.EndsWith("F"));
                totalAttempts += marks.Length;
            }

            if (totalExams > 0)
            {
                double avg = (double)totalPoints / totalExams;
                Console.WriteLine($"\nСредний балл: {avg:F2}");
            }

            Console.WriteLine($"Количество пересдач (F): {totalFails}");
            Console.WriteLine($"Всего попыток: {totalAttempts}");
        }

        private int ConvertGradeToPoints(string grade)
        {
            return grade switch
            {
                "A" => 5,
                "B" => 4,
                "C" => 3,
                "D" => 2,
                "F" => 1,
                _ => 0
            };
        }
    }
}
