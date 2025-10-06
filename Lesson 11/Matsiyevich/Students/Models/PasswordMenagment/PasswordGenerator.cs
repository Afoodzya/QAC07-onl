namespace Students.Models.PasswordMenagment
{
    public class PasswordGenerator
    {
        private static Random _random = new Random();
        string password;



        public static string Generate()
        {
            string digits = "";
            for (int i = 0; i < 4; i++)
            {
                digits += _random.Next(0, 9).ToString();
            }
            return digits;
        }

        public static void SaveToFile(string password, string folderPath, string fileName = "LoginData.txt")
        {
            string fullPath = Path.Combine(folderPath, fileName);
            File.AppendAllText(fullPath, password);
        }
    }
}
