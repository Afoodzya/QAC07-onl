namespace Students.Models.Menu
{
    public class StudentMenu
    {
        private readonly string studentName;
        private readonly string projectRoot;

        public StudentMenu(string studentName)
        {
            this.studentName = studentName;
            projectRoot = Directory.GetParent(Directory.GetCurrentDirectory())!
                .Parent!
                .Parent!
                .FullName;
        }

        public void StudentAbileties()
        {
            while (true)
            {
                Console.WriteLine("\n-Меню Студента-\nВыберите пункт меню:");
                Console.WriteLine("1. Вывести результаты экзаменов");
                Console.WriteLine("2. Вывести назначенные экзамены");
                Console.WriteLine("3. Средний балл за сессию");
                Console.WriteLine("4. Выход");

                string select = Console.ReadLine();

                switch (select)
                {
                    case "1":
                        ShowExamResults();
                        break;
                    case "2":
                        ShowAssignedExams();
                        break;
                    case "3":
                        ShowSessionAverage();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Неверный пункт меню.");
                        break;
                }
            }
        }

        private void ShowExamResults()
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
                Console.WriteLine("Экзамены не назначены.");
                return;
            }

            foreach (string examFile in examFiles)
            {
                string subject = Path.GetFileNameWithoutExtension(examFile);
                string[] marks = File.ReadAllLines(examFile);

                if (marks.Length == 0)
                {
                    Console.WriteLine($"По предмету {subject} нет оценок.");
                }
                else
                {
                    Console.WriteLine($"\n{subject}:");
                    foreach (string mark in marks)
                    {
                        Console.WriteLine(mark);
                    }
                }
            }
        }

        private void ShowAssignedExams()
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
                Console.WriteLine("Экзамены не назначены.");
                return;
            }

            Console.WriteLine("Назначенные экзамены:");
            foreach (string examFile in examFiles)
            {
                Console.WriteLine(Path.GetFileNameWithoutExtension(examFile));
            }
        }

        private void ShowSessionAverage()
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
                Console.WriteLine("Нет экзаменов для подсчёта.");
                return;
            }

            int totalPoints = 0;
            int passedExams = 0;

            foreach (string examFile in examFiles)
            {
                string[] marks = File.ReadAllLines(examFile);

                if (marks.Length == 0)
                {
                    Console.WriteLine($"По предмету {Path.GetFileNameWithoutExtension(examFile)} нет оценок.");
                    continue;
                }

                string lastValid = marks.Reverse()
                    .Select(m => m.Split('-').Last().Trim())
                    .FirstOrDefault(g => g != "F");

                if (lastValid == null)
                {
                    Console.WriteLine($"Предмет {Path.GetFileNameWithoutExtension(examFile)} завален (все F).");
                    continue;
                }

                int numeric = ConvertGradeToPoints(lastValid);
                if (numeric > 0)
                {
                    totalPoints += numeric;
                    passedExams++;
                }
            }

            if (passedExams == 0)
            {
                Console.WriteLine("Сессия завалена.");
            }
            else
            {
                double avg = (double)totalPoints / passedExams;
                Console.WriteLine($"Средний балл за сессию: {avg:F2}");
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
    }
}
