namespace EvenAndOddArrayNumbers;

class Program
{
    static void Main(string[] args)
    {
        // Задача № 2
        
        // создаем массив из 10 чисел
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        
        // сумма четных чисел
        int sumOfEvenNumbers = 0;
        // счетчик для подсчета количесва нечетных чисел
        int quantityOfOddNumbers = 0;
        
        
        foreach(int number in numbers)
        {
            if (number % 2 == 0)
            {
                // если нашли четное число то прибавляем его
                sumOfEvenNumbers += number;
            } 
            else
            {
                quantityOfOddNumbers ++;
            }
            
            /*
             // запись с использованием тернарного оператора
             // 1) вычисляем условие слева от ?
             // 2) если условие истинно (число чётное), то выражение возвращает значение перед двоеточием
             // 3) если ложно, то после двоеточия
             
            sumOfEvenNumbers += (number % 2 == 0) ? number : 0;
            quantityOfOddNumbers += (number % 2 != 0) ? 1 : 0;
             */
        }
        Console.WriteLine("The sum of even numbers is " + sumOfEvenNumbers);
        Console.WriteLine("The quantity of odd numbers is " + quantityOfOddNumbers);
    }
}