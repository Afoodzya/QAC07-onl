using Students.Models.Menu;

namespace Students.Models.Authorize
{
    public class StudentAutorization
    {
        string projectRoot = Directory.GetParent(Directory.GetCurrentDirectory())!
             .Parent!
             .Parent!
             .FullName;
        private string name;
        private string password;

        public void Authorize()
        {
            while (true)
            {
                Console.Write("Введите имя пользователя: ");
                name = Console.ReadLine();
                Console.Write("Введите пароль: ");
                password = Console.ReadLine();

                string userArchivePath = Path.Combine(projectRoot, "Docs", "Students");
                string? foundDir = Directory
                    .GetDirectories(userArchivePath, "*", SearchOption.AllDirectories)
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
                        StudentMenu studentMenu = new StudentMenu(foundDir);
                        studentMenu.StudentAbileties();
                        return;
                    }
                }
            }
        }
    }
}
