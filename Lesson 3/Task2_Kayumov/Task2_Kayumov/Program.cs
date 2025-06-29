namespace Task2_Kayumov
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[10] { 3, 7, -4, 2, 8, 1, 5, 6, 9, -10 };

            int sumEven = 0, quantityUneven = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    sumEven = sumEven + numbers[i];
                }
                else
                {
                    quantityUneven = quantityUneven + 1;
                }
            }

            Console.WriteLine($"The sum of even numbers is {sumEven}");
            Console.WriteLine($"The number of odd numbers is {quantityUneven}");
        }
    }
}
