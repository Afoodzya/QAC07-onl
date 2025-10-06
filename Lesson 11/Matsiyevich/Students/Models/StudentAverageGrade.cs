namespace Students.Models
{
    public class StudentAverageGrade
    {
        private readonly string projectRoot;

        public StudentAverageGrade()
        {
            projectRoot = Directory.GetParent(Directory.GetCurrentDirectory())!
                .Parent!
                .Parent!
                .FullName;
        }

        public double CalculateAverage(string studentName)
        {
            string studentFolder = Path.Combine(projectRoot, "Docs", "Students", studentName);

            if (!Directory.Exists(studentFolder))
            {
                Console.WriteLine($"Студент {studentName} не найден.");
                return 0;
            }

            string[] examFiles = Directory.GetFiles(studentFolder, "*.txt")
                .Where(f => !Path.GetFileName(f).StartsWith("level", StringComparison.OrdinalIgnoreCase) &&
                            !Path.GetFileName(f).Equals("LoginData.txt", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            if (examFiles.Length == 0)
                return 0;

            int totalPoints = 0;
            int totalExams = 0;

            foreach (string examFile in examFiles)
            {
                string[] marks = File.ReadAllLines(examFile);

                if (marks.Length == 0)
                    continue;

                string lastMark = marks.Last().Split('-').Last().Trim();
                int numeric = ConvertGradeToPoints(lastMark);

                if (numeric > 0)
                {
                    totalPoints += numeric;
                    totalExams++;
                }
            }

            return totalExams > 0 ? (double)totalPoints / totalExams : 0;
        }

        public Dictionary<string, double> CalculateAllStudents()
        {
            string studentsPath = Path.Combine(projectRoot, "Docs", "Students");

            if (!Directory.Exists(studentsPath))
            {
                Console.WriteLine("Папка студентов не найдена.");
                return new Dictionary<string, double>();
            }

            string[] studentDirs = Directory.GetDirectories(studentsPath);
            Dictionary<string, double> results = new();

            foreach (string dir in studentDirs)
            {
                string studentName = Path.GetFileName(dir);
                double avg = CalculateAverage(studentName);
                results[studentName] = avg;
            }

            return results;
        }

        public void ShowTopStudents(int topCount = 5)
        {
            var all = CalculateAllStudents();

            var sorted = all
                .OrderByDescending(s => s.Value)
                .Take(topCount);

            Console.WriteLine($"\nТОП-{topCount} студентов по среднему баллу:");
            foreach (var s in sorted)
            {
                Console.WriteLine($"{s.Key} — {s.Value:F2}");
            }
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
        
        public void ShowAllStudentsSorted()
        {
            var all = CalculateAllStudents();

            if (all.Count == 0)
            {
                Console.WriteLine("Нет данных о студентах.");
                return;
            }

            var sorted = all
                .OrderByDescending(s => s.Value)
                .ToList();

            Console.WriteLine("\nРейтинг студентов по среднему баллу:");
            int rank = 1;
            foreach (var s in sorted)
            {
                Console.WriteLine($"{rank}. {s.Key} — {s.Value:F2}");
                rank++;
            }
        }

    }
}
