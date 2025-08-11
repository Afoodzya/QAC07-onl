namespace DepositGrowthCalculator;

class Program
{
    static void Main(string[] args)
    {
        // Задача № 1
        Console.WriteLine("Enter the deposit amount, please: ");
        // сохраняем сумма вклада в переменную
        decimal depositAmount = Convert.ToDecimal(Console.ReadLine());

        // процентная ставка
        decimal interestRate = 0.10M;

        // создаем динамический массив, он же список
        // для добавления общей суммы за каждый год
        List<decimal> incomePerYearCollection = new List<decimal>();
        // массив для вывода года
        string[] year = new[] { "1st", "2nd", "3rd" };

        for (int i = 0; i < year.Length; i++)
        {
            decimal incomePerYear = depositAmount + (depositAmount * interestRate);
            // добавляем новый элемент в конец списка с помощью Add()
            incomePerYearCollection.Add(incomePerYear);

            // обновляем сумму вклада для следующего года
            depositAmount = incomePerYear; 

            Console.WriteLine("The total deposit amount per {0} year is {1}", year[i], depositAmount);
        }  
    }
}