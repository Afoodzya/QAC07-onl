namespace bancomat
{
    internal class BankAccount
    {
        private float balance;
        private List<string> transactionHistory;
        private string _pin;

        public BankAccount(string pin)
        {
            _pin = pin;
            transactionHistory = new List<string>();
        }

        public bool Authorize()
        {
            for (int i = 3; i > 0; i--)
            {
                Console.WriteLine($"Введите PIN код\nКоличество попыток {i}: ");
                string enteredPin = Console.ReadLine();
                if (enteredPin == _pin)
                {
                    Console.WriteLine("Добро пожаловать в банкомат!");
                    return true;
                }
                else
                {
                    Console.WriteLine("Неверный PIN");
                }
            }
            return false;
            
        }

        public void ChangePin()
        {
            Console.Write("Введите текущий PIN: ");
            string currentPin = Console.ReadLine();

            if (currentPin != _pin)
            {
                Console.WriteLine("Неверный PIN");
                return;
            }

            Console.WriteLine("Введите новый PIN: ");
            string newPin = Console.ReadLine();

            _pin = newPin;
            Console.WriteLine("PIN изменён!\nВыполните вход");
        }

        public void Deposit(float deposit)
        {
            balance += deposit;
            transactionHistory.Add($"{DateTime.Now}: Внесено {deposit}");
            Console.WriteLine("Деньги зачислены на счёт");
        }

        public void Withdraw(float money)
        {
            if (money <= 0)
            {
                Console.WriteLine("Введите положительное число");
                return;
            }

            if (money > balance)
            {
                Console.WriteLine("Недостаточно средств");
                return;
            }

            balance -= money;
            transactionHistory.Add($"{DateTime.Now}: Снято {money}");
            Console.WriteLine("Деньги сняты");
        }
        public void ShowBalance()
        {
            Console.WriteLine($"Ваш баланс: {balance}");
        }

        public void PrintHistory()
        {
            Console.WriteLine("История операций:");
            if (transactionHistory.Count == 0)
            {
                Console.WriteLine("Операции отсутствуют.");
            }
            else
            {
                foreach (string operations in transactionHistory)
                {
                    Console.WriteLine(operations);
                }
            }
        }

        private bool AskToContinue()
        {
            while (true)
            {
                Console.Write("Хотите выполнить ещё операцию? (Да/Нет): ");
                string input = Console.ReadLine().Trim().ToLower();

                if (input == "да")
                    return true;
                else if (input == "нет")
                {
                    Console.Write("Вы уверены, что хотите выйти? (Да/Нет): ");
                    string confirm = Console.ReadLine().Trim().ToLower();
                    if (confirm == "да")
                        return false;
                    else if (confirm == "нет")
                        return true;
                }
                else
                {
                    Console.WriteLine("Введите 'Да' или 'Нет'.");
                }
            }
        }
        public bool ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Посмотреть баланс");
                Console.WriteLine("2. Положить деньги");
                Console.WriteLine("3. Снять деньги");
                Console.WriteLine("4. История операций");
                Console.WriteLine("5. Сменить PIN");
                Console.WriteLine("6. Выйти");

                Console.Write("Ваш выбор: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowBalance();
                        break;
                    case "2":
                        Console.Write("Введите сумму для внесения: ");
                        if (float.TryParse(Console.ReadLine(), out float depositAmount))
                        {
                            Deposit(depositAmount);
                        }
                        else
                        {
                            Console.WriteLine("Неверный формат суммы.");
                        }
                        break;
                    case "3":
                        Console.Write("Введите сумму для снятия: ");
                        if (float.TryParse(Console.ReadLine(), out float withdrawAmount))
                        {
                            Withdraw(withdrawAmount);
                        }
                        else
                        {
                            Console.WriteLine("Неверный формат суммы.");
                        }
                        break;
                    case "4":
                        PrintHistory();
                        break;
                    case "5":
                        ChangePin();
                        return true; // переход к авторизации
                    case "6":
                        Console.WriteLine("Выход из системы.");
                        return false;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }

                if (!AskToContinue())
                {
                    return false; // завершить программу
                }
            }

        }
    }
}
