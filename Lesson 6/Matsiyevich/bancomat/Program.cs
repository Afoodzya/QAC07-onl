using System.Security.Principal;

namespace bancomat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount bankAccount = new BankAccount("1234");
            while (true)
            {
                Console.WriteLine("\nДобро пожаловать в Банкомат!");
                if (bankAccount.Authorize())
                {
                    bool shouldLoginAgain = bankAccount.ShowMenu();
                    if (!shouldLoginAgain)
                        break;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("Пока!");

        }
    }
}
