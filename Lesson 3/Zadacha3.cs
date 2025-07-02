    using System.Diagnostics.CodeAnalysis;
    using System.Net.Quic;

    int sum = 0;
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine("Enter mark" + (i + 1));
        sum += Convert.ToInt32(Console.ReadLine());
    }
    int average = sum / 5;

    if (average > 100)
    {
        Console.WriteLine("Error");
    }
    else
    {
        Console.WriteLine(average);

        switch (average)
        {
            case >= 90:
                Console.WriteLine("Отлично");
                break;

            case >= 75:
                Console.WriteLine("Хорошо");
                break;

            case >= 60:
                Console.WriteLine("Удовлетворительно");
                break;

            default:
                Console.WriteLine("Неудовлетворительно");
                break;
        }
    }




