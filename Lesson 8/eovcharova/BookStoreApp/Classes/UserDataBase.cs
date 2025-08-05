namespace BookStoreApp.Classes;

public class UsersDataBase
{
    public List<User> UsersList { get; set; }
    public UsersDataBase()
    {
        UsersList = new List<User>
        {
            new User("Denny", 777),
            new User("Michael", 4578),
        };
    }
    public List<User> GetUserByName(string name)
    {
        return UsersList
            .FindAll(u => u.Username.Equals(name));
    }
    public User? AuthorizeUser()
    {
        Console.Write("Для входа в приложение, введите свое имя: ");
        string userInputName = Console.ReadLine()?.Trim() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(userInputName))
        {
            Console.WriteLine("Имя не может быть пустым!");
            return null;
        }

        var foundUsers = GetUserByName(userInputName);
        if (foundUsers.Count == 0)
        {
            Console.WriteLine("Данное имя не найдено!");
            return null;
        }

        const int maxPinAttempts = 3;
        int pinAttempt = 0;

        while (pinAttempt < maxPinAttempts)
        {
            Console.Write("Введите пинкод: ");
            string? pinInput = Console.ReadLine();
            if (!int.TryParse(pinInput, out int userInputPincode))
            {
                Console.WriteLine("Пинкод введен неверно!");
                pinAttempt++;
                if (pinAttempt < maxPinAttempts)
                    Console.WriteLine($"Попытка {pinAttempt} из {maxPinAttempts}. Попробуйте снова.");
                continue;
            }
            foreach (var user in foundUsers)
            {
                if (user.Pincode == userInputPincode)
                {
                    return user;
                }
            }

            pinAttempt++;
            if (pinAttempt < maxPinAttempts)
                Console.WriteLine($"Пинкод неверный. Попытка {pinAttempt} из {maxPinAttempts}. Попробуйте еще раз!");
        }
        Console.WriteLine("Количество попыток для ввода пинкода закончилось.");
        return null;
        }
}