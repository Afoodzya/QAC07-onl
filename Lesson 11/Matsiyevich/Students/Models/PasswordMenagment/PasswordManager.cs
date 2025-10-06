namespace Students.Models.PasswordMenagment
{
    public class PasswordManager
    {
        private string _currentPassword;

        public PasswordManager()
        {
            Console.WriteLine("Пароль должен содержать минимум 4 символа и состоять только из цифр");
        }

        public string CurrentPassword => _currentPassword;

        public bool ChangePassword(string oldPassword, string newPassword)
        {
            if (_currentPassword != oldPassword)
            {
                Console.WriteLine("Ошибка: старый пароль неверный!");
                return false;
            }

            if (!IsValid(newPassword))
            {
                Console.WriteLine("Ошибка: новый пароль некорректный!");
                return false;
            }

            _currentPassword = newPassword;
            Console.WriteLine("Пароль успешно изменён!");
            return true;
        }

        private bool IsValid(string password)
        {
            return !string.IsNullOrEmpty(password)
                   && password.Length >= 4
                   && password.All(char.IsDigit);
        }
    }
}
