using Students.Models.Authorize;

public class MainMenu
{

    public void VelcomeMenu()
    {
        while (true)
        {
            Console.WriteLine("\n-Главное Меню-\nВыберите кем вы являетесь:");
            Console.WriteLine("1. Администратор\n2. Преподаватель\n3. Студент\n4. Выход");
            string select = Console.ReadLine();

            switch (select)
            {
                case "1":
                    AdminAuthorization adminAuthorization = new AdminAuthorization();
                    adminAuthorization.Authorize();
                    break;
                case "2":


                    break;
                case "3":
                    
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Введён неверный пункт меню");
                    break;
            }
        }
    }
}
