namespace WordsElCount;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter your line, please!");
       
        string line = Console.ReadLine();
        
        char[] symbols = line.ToCharArray();
        
        string result = CountOfSymbolsResult(symbols);
        
        Console.WriteLine(result);
    }
    public static string CountOfSymbolsResult(char[] symbols)
    {
        int vowelsCount = 0;
        int consonantsCount = 0;
        int numbersCount = 0;
        int whiteSpacesCount = 0;
        
        char[] vowelsEn = { 'a', 'e', 'i', 'o', 'u', 'y' };
        char[] vowelsCyrillic = { 'а', 'э', 'ы', 'о', 'у', 'и', 'я', 'ю', 'ё', 'е' };
        
        foreach (char c in symbols)
        {
            if (char.IsDigit(c))
            {
                numbersCount++;
            }
            else if (char.IsLetter(c))
            {
                if (vowelsEn.Contains(char.ToLower(c)) || vowelsCyrillic.Contains(char.ToLower(c)))
                {
                    vowelsCount++;
                }
                else
                {
                    consonantsCount++;
                }
                
            }
            else if (char.IsWhiteSpace(c))
            {
                whiteSpacesCount++;
            }
        }
        return $"The total number of different symbols in your line is: vowels {vowelsCount}, consonants {consonantsCount}, numbers {numbersCount}, whitespaces {whiteSpacesCount}";
    } 
}