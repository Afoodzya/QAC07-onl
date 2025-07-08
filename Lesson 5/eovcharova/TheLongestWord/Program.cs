using System.Text;

namespace TheLongestWord;

class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        
        Console.WriteLine("Enter the words, please!");
        
        string userInput = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(userInput))
        {
            Console.WriteLine("No words entered.");
            return;
        }
        string[] words = userInput.Split(' ');
        
        string longestWord = FindTheLongestWord(words);
        Console.WriteLine($"Your longest word is \"{longestWord}\"!");
    }
    public static string FindTheLongestWord(string[] words)
    {
        Array.Sort(words, (a, b) => b.Length.CompareTo(a.Length));
        return words[0];
    }
}