using Students.Models.Menu;

namespace Students.Models.Authorize
{
    public class TeacherAuthorization
    {
        string projectRoot = Directory.GetParent(Directory.GetCurrentDirectory())!
           .Parent!
           .Parent!
           .FullName;

        private string name;
        private string password;

        public string TeacherSubjFolderName { get; private set; }
        public string SubjectName { get; private set; }

        public void Authorize()
        {
            while (true)
            {
                string teachersArchivePath = Path.Combine(projectRoot, "Docs", "Teachers");
                Console.WriteLine("Выберите предмет:\n1. Высшая Математика\n2. Сопротивление материалов\n3. Гидравлика");
                string curs = Console.ReadLine();

                switch (curs)
                {
                    case "1":
                        TeacherSubjFolderName = Path.Combine(teachersArchivePath, "Mathematics");
                        SubjectName = "Mathematics";
                        break;
                    case "2":
                        TeacherSubjFolderName = Path.Combine(teachersArchivePath, "Strength of materials");
                        SubjectName = "Strength of materials";
                        break;
                    case "3":
                        TeacherSubjFolderName = Path.Combine(teachersArchivePath, "Hydraulics");
                        SubjectName = "Hydraulics";
                        break;
                    default:
                        Console.WriteLine("Неверный выбор");
                        continue;
                }

                Console.Write("Введите имя пользователя: ");
                name = Console.ReadLine();
                Console.Write("Введите пароль: ");
                password = Console.ReadLine();

                string? foundDir = Directory
                    .GetDirectories(TeacherSubjFolderName, "*", SearchOption.AllDirectories)
                    .FirstOrDefault(dir => Path.GetFileName(dir)
                        .Contains(name, StringComparison.OrdinalIgnoreCase));

                if (foundDir == null)
                {
                    Console.WriteLine("Папка пользователя не найдена.");
                    continue;
                }
                else
                {
                    string filePath = Path.Combine(foundDir, "LoginData.txt");

                    string[] loginData = File.ReadAllLines(filePath);
                    if (name != loginData[0] || password != loginData[1])
                    {
                        Console.WriteLine("Неверное имя или PIN-код. Попробуйте снова.\n");
                    }
                    else
                    {
                        PrepodMenu prepodMenu = new PrepodMenu(SubjectName);
                        prepodMenu.PrepodAbileties();

                        var studentSetter = new Students.Models.SetPointToStudent(SubjectName);
                        studentSetter.GetStudentsList();

                        return;
                    }
                }
            }
        }
    }
}
