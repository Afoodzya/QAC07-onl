using Students.Models.PasswordMenagment;

namespace Students.Models.NewUsers
{
    public class NewStudent
    {
        

        public string projectRoot = Directory.GetParent(Directory.GetCurrentDirectory())!
            .Parent!
            .Parent!
            .FullName;
        public string newName;
        public string newSurname;
        public string id;
        public string newStudentArchivePath;
        public string newStudentFolder;

        public void NewStudentName()
        {         

            Console.WriteLine("Введите Имя нового студента:");
            newName = Console.ReadLine();

            Console.WriteLine("Введите Фамилию студента:");
            newSurname = Console.ReadLine();

            string newStudetFolderName = $"{newName} {newSurname}";

            string studentsArchivePath = Path.Combine(projectRoot, "Docs", "Students");

            string[] studentsInArchiv = Directory.GetDirectories(studentsArchivePath);
            int numberOfStudents = studentsInArchiv.Length;

            List<string> studentNames = new List<string>();

            foreach (string dir in Directory.GetDirectories(studentsArchivePath))
            {
                string folderName = Path.GetFileName(dir);
                studentNames.Add(folderName);
            }

            var duplicates = studentNames
                .Where(name => name.Contains(newStudetFolderName))
                .ToList();

            bool exists = duplicates.Count > 0;

            if (exists)
            {
                Console.WriteLine("Студент с таким именем и файмилией уже есть в системе!");
                int confirm = YasNo();
                if (confirm == 1)
                {
                    int studentNumber = numberOfStudents + 1;
                    id = studentNumber.ToString();

                    newStudentFolder = $"{id}. {newStudetFolderName}";
                    newStudentArchivePath = Path.Combine(studentsArchivePath, newStudentFolder);
                    Directory.CreateDirectory(newStudentArchivePath);
                    Console.WriteLine("Новый студент добавлен\n");
                }
                else
                {
                    return;
                }
            }
            else
            {
                int studentNumber = numberOfStudents + 1;
                id = studentNumber.ToString();

                newStudentFolder = $"{id}. {newStudetFolderName}";
                newStudentArchivePath = Path.Combine(studentsArchivePath, newStudentFolder);
                Directory.CreateDirectory(newStudentArchivePath);
                Console.WriteLine("Новый студент добавлен\n");
            }

            string password = PasswordGenerator.Generate();
            PasswordGenerator.SaveToFile(password, newStudentArchivePath);
            PasswordGenerator.SaveToFile($"\n{id}_{newName}", newStudentArchivePath);
            



            string newStudetName = $"{newName} {newSurname}";

            string LevelsPath = Path.Combine(projectRoot, "Docs", "Levels");

            Console.WriteLine("Введите курс студента (1-5)");
            string curs = Console.ReadLine();
            switch (curs)
            {
                case "1":
                    string filePath1 = Path.Combine(LevelsPath, "level_1.txt");
                    string filePath12 = Path.Combine(newStudentArchivePath, "level_1.txt");
                    File.Create(filePath12).Close();
                    File.WriteAllText(filePath1, $"{newName} {newSurname}\n");
                    Console.WriteLine("Новый студент зачислен на Первый курс\n");
                    break;
                case "2":                    
                    string filePath2 = Path.Combine(LevelsPath, "level_2.txt");
                    string filePath22 = Path.Combine(newStudentArchivePath, "level_2.txt");
                    File.Create(filePath22).Close();
                    File.WriteAllText(filePath2, $"{newName} {newSurname}\n");
                    Console.WriteLine("Новый студент зачислен на Второй курс\n");
                    break;
                case "3":                    
                    string filePath3 = Path.Combine(LevelsPath, "level_3.txt");
                    string filePath32 = Path.Combine(newStudentArchivePath, "level_3.txt");
                    File.Create(filePath32).Close();
                    File.WriteAllText(filePath3, $"{newName} {newSurname}\n");
                    Console.WriteLine("Новый студент зачислен на Третий курс\n");
                    break;
                case "4":
                    string filePath4 = Path.Combine(LevelsPath, "level_4.txt");
                    string filePath42 = Path.Combine(newStudentArchivePath, "level_4.txt");
                    File.Create(filePath42).Close();
                    File.WriteAllText(filePath4, $"{newName} {newSurname}\n");
                    Console.WriteLine("Новый студент зачислен на Четвёртый курс\n");
                    break;
                case "5":
                    string filePath5 = Path.Combine(LevelsPath, "level_5.txt");
                    string filePath52 = Path.Combine(newStudentArchivePath, "level_5.txt");
                    File.Create(filePath52).Close();
                    File.WriteAllText(filePath5, $"{newName} {newSurname}\n");
                    Console.WriteLine("Новый студент зачислен на Пятый курс\n");
                    break;
                default:
                    break;

            }
            Console.WriteLine($"Уведомите студента:\nЛогин для входа в систему: {id}_{newName}\nПароль: {password}");
        }

        
        
        int YasNo()
        {
            Console.WriteLine("Вы уверены в правильности ввода?\n 1 - Да\n 2 - Нет");
            int select = int.Parse(Console.ReadLine());
            return select;
        }


    }
}
