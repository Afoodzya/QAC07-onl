namespace Task3_Kayumov
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] grades = new int[5];
            int sumGrades = 0;

            Console.WriteLine("Enter grades for 5 subjects (0 to 100)");

            for (int i = 0; i < grades.Length; i++)
            {
                grades[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < grades.Length; i++)
            {
                sumGrades = sumGrades + grades[i];
            }

            double averageRating = sumGrades / grades.Length;

            if (averageRating >= 90)
            {
                Console.WriteLine("Отлично");
            }

            else if (averageRating <= 89  && averageRating >= 75)
            {
                Console.WriteLine("Хорошо");
            }

            else if (averageRating <= 74 && averageRating >= 60)
            {
                Console.WriteLine("Удовлетворительно");
            }

            else if (60 > averageRating)
            {
                Console.WriteLine("Неудовлетворительно");
            }
        }
    }
}
