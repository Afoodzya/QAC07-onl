namespace Students.Models.Menu
{
    public class PrepodMenu
    {
        private readonly string subjectName;
        public PrepodMenu(string subjectName)
        {
            this.subjectName = subjectName;
        }
        public void PrepodAbileties() 
        {
            while (true)
            {
                Console.WriteLine("\n-Меню Преподавателя-\nВыберите пункт меню:");
                Console.WriteLine("1. Поставить оценку студенту\n2. Отчёт о студенте\n3. Средний бал студента\n4. ТОП студентов\n5. Выход");
                string select = Console.ReadLine();

                switch (select)
                {
                    case "1":                        
                        SetPointToStudent setPointToStudent = new SetPointToStudent(subjectName);
                        setPointToStudent.GetStudentsList();
                        setPointToStudent.GetStudent();      
                        setPointToStudent.SetExam();      
                        setPointToStudent.SetMark();          
                        break;                        
                    case "2":
                        Console.WriteLine("Введите имя студента:");
                        string studentName = Console.ReadLine();
                        StudentReport report = new StudentReport();
                        report.ShowReport(studentName);
                        break;
                    case "3":
                        var avgCalc = new StudentAverageGrade();
                        string studentsPath = Path.Combine(
                            Directory.GetParent(Directory.GetCurrentDirectory())!
                                .Parent!
                                .Parent!
                                .FullName,
                            "Docs", "Students"
                        );

                        string[] studentDirs = Directory.GetDirectories(studentsPath);

                        
                        Console.WriteLine("Выберите студента:");
                        for (int i = 0; i < studentDirs.Length; i++)
                        {
                            Console.WriteLine($"{i + 1}. {Path.GetFileName(studentDirs[i])}");
                        }

                        Console.Write("Введите номер: ");
                        int index = int.Parse(Console.ReadLine());

                        if (index > 0 && index <= studentDirs.Length)
                        {
                            string selectedStudent = Path.GetFileName(studentDirs[index - 1]);
                            double avg = avgCalc.CalculateAverage(selectedStudent);

                            Console.WriteLine($"Средний балл студента {selectedStudent}: {avg:F2}");
                        }
                        break;
                    case "4":
                        var topStud = new StudentAverageGrade();
                        topStud.ShowAllStudentsSorted();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Введён неверный пункт меню");
                        break;
                }
            }
        }
    }
}
