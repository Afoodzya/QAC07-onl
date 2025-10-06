namespace Students.Models
{
    public class Attempt
    {
        private readonly string filePath;

        public Attempt(string studentFolderPath, string subject)
        {
            filePath = Path.Combine(studentFolderPath, $"{subject}.txt");
            if (!File.Exists(filePath))
                File.Create(filePath).Close();
        }
        public string[] GetAllMarks()
        {
            return File.ReadAllLines(filePath);
        }
        public int GetConsecutiveF()
        {
            string[] marks = GetAllMarks();
            int count = 0;
            for (int i = marks.Length - 1; i >= 0; i--)
            {
                if (marks[i].EndsWith("F"))
                    count++;
                else
                    break;
            }
            return count;
        }
        public bool CanAttempt()
        {
            return GetConsecutiveF() < 3;
        }
        public void AddMark(string mark)
        {
            if (!new string[] { "A", "B", "C", "D", "F" }.Contains(mark.ToUpper()))
                throw new ArgumentException("Некорректная оценка. Используйте A, B, C, D или F.");

            if (!CanAttempt())
            {
                Console.WriteLine("Превышено количество попыток пересдачи (3 подряд F). Новая оценка не может быть поставлена.");
                return;
            }

            string record = $"{DateTime.Now:dd.MM.yyyy HH:mm} - {mark.ToUpper()}";
            File.AppendAllText(filePath, record + Environment.NewLine);

            if (mark.ToUpper() == "F")
                Console.WriteLine($"Студент получил F. Можно назначить пересдачу. Попытка {GetConsecutiveF()}/3.");
            else
                Console.WriteLine($"Студент получил {mark}. Экзамен засчитан.");
        }
    }
}
