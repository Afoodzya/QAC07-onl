using System;
using System.IO;

namespace leson4_strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "D:\\Kurs\\QAC07-onl\\QAC07-onl\\Lesson 4\\leson4_strings\\TextFile1.txt";
            
            StreamReader reader1 = new StreamReader(path);
            string line1 = reader1.ReadToEnd();
            
            reader1.Close();

            while (true)
            {
                
                while (true)
                {
                    StreamReader reader2 = new StreamReader(path);
                    string line2 = reader2.ReadToEnd();
                   
                    reader2.Close();
                    if (line2.Length > line1.Length)
                    {
                        Console.WriteLine(line2[-1]);
                        break;
                    }
                    
                }

            }
        }
    }
}