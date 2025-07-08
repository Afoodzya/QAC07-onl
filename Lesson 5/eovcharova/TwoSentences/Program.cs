using System.Text;

namespace TwoSentences;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        
        Console.WriteLine("Enter the first sentence, please!");
        
        string userInput1 = Console.ReadLine();
        
        Console.WriteLine("Enter the second sentence, please!");
        
        string userInput2 = Console.ReadLine();
        
        string result1 = LengthOfSentencesToCompare(userInput1, userInput2);
        Console.WriteLine(result1);
        
        string result2 = ContentComparison(userInput1, userInput2);
        Console.WriteLine(result2);
        
        string[] userInputWords1 = userInput1.Split(' ');
        string[] userInputWords2 = userInput2.Split(' ');
        
        int wordsCount1 = GetNumberOfWords(userInputWords1);
        int wordsCount2 = GetNumberOfWords(userInputWords2);
        
        Console.WriteLine($"The number of words in the first sentence is {wordsCount1}");
        Console.WriteLine($"The number of words in the second sentence is {wordsCount2}");

        string[] clearedWordslist1 = WordsCollectionToCompare(userInputWords1);
        string[] clearedWordslist2 = WordsCollectionToCompare(userInputWords2);
        
        int equalWordsCount = EqualWordsNumbers(clearedWordslist1, clearedWordslist2);
        Console.WriteLine($"The number of the same words in two sentences is {equalWordsCount}");
    }
    public static string LengthOfSentencesToCompare(string sentence1, string sentence2)
    {
        int longestSentenceResult = sentence1.Length.CompareTo(sentence2.Length);

        if (longestSentenceResult > 0)
        {
           return "The first sentence is longer than the second sentence.";
        }
        else if (longestSentenceResult < 0)
        {
            return "The second sentence is longer than the first sentence.";
        }
        else
        {
            return "The length of the sentences is equal.";
        }
    }
    public static string ContentComparison(string sentence1, string sentence2)
    {
        bool contentComparisonResult = sentence1.Equals(sentence2, StringComparison.OrdinalIgnoreCase);

        if (contentComparisonResult == true)
        {
            return "Semantically the sentences are equal.";
        }
        else
        {
            return "Semantically the sentences are not equal.";
        }
    }
    public static int GetNumberOfWords(string[] sentence)
    {
        int words = 0;
        
        string punctuation = ".,!?;:-()\"'";

        foreach (string word in sentence)
        {
            string cleanWord = word.Trim(punctuation.ToCharArray());
            
            if (!string.IsNullOrEmpty(cleanWord))
            {
                words++;
            }
        }
        return words;
    }
    public static string[] WordsCollectionToCompare(string[] sentence)
    {
        string punctuation = ".,!?;:-()\"'";
        
        List<string> wordsToCompare = new List<string>();
        
        for (int i = 0; i < sentence.Length; i++)
        {
            string wordToCompare = sentence[i].Trim(punctuation.ToCharArray());
            if (!string.IsNullOrEmpty(wordToCompare))
            {
                wordsToCompare.Add(wordToCompare.ToLower());
            }
        }
        return wordsToCompare.ToArray();
    }
    public static int EqualWordsNumbers(string[] sentence1, string[] sentence2)
    {
        int words = 0;

        for (int i = 0; i < sentence1.Length; i++)
        {
            for (int j = 0; j < sentence2.Length; j++)
            {
                if (String.Equals(sentence1[i], sentence2[j]))
                {
                    words++;
                }
            }
        }
        return words;
    }
}