namespace Students.Models.Authorize
{
    public class AdminAuthorization
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

                string adminArchivePath = Path.Combine(projectRoot, "Docs", "Admin", "LoginData.txt");
                //Console.Write(adminArchivePath + "\n");

                string[] adminLoginData = File.ReadAllLines(adminArchivePath);
                //Console.WriteLine(adminLoginData[0] + "\n" + adminLoginData[1]);
                if (name != adminLoginData[0] || password != adminLoginData[1])
                {
                    Console.WriteLine("Неверное имя или PIN-код. Попробуйте снова.\n");
                }
                else
                {
                    AdminMenu adminMenu = new AdminMenu();
                    adminMenu.AdminAbileties();
                    return;
                }
               
            }
        }
    }
}
