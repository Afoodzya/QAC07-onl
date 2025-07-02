    int[] numbers = new int[10] { 3, 65, 77, 983, 54, 44, 768, 644, 6, 90 };
    int sum_even = 0;
    int sum_odd = 0;
    for (int i = 0; i < 10; i++)
    {
        if (numbers[i] % 2 == 0)
        {
            sum_even += numbers[i];
        }
        else
        {
            sum_odd += numbers[i];
        }
    }
    Console.WriteLine("The sum of even numbers equals " + sum_even);
    Console.WriteLine("The sum of odd numbers equals " + sum_odd);




