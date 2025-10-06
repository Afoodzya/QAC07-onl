using Students.Models.PasswordMenagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Models.NewUsers
{
    public class NewTeacher
    {
        public string projectRoot = Directory.GetParent(Directory.GetCurrentDirectory())!
            .Parent!
            .Parent!
            .FullName;
        public string newName;
        public string newSurname;
        public string id;
        public string newTeacherArchivePath;

        public void NewTeacherName()
        {
            Console.WriteLine("Введите Имя нового преподавателя:");
            newName = Console.ReadLine();

            Console.WriteLine("Введите Фамилию преподавателя:");
            newSurname = Console.ReadLine();

            string newTeacherFolderName = $"{newName} {newSurname}";

            string teachersArchivePath = Path.Combine(projectRoot, "Docs", "Teachers");

            Console.WriteLine("Выберите предмет:\n1. Высшая Математика\n2. Сопротивление материалов\n3. Гидравлика");
            string curs = Console.ReadLine();
            switch (curs)
            {
                case "1":
                    string newTeacherFolder1 = Path.Combine(teachersArchivePath, "Mathematics", newTeacherFolderName);
                    Directory.CreateDirectory(newTeacherFolder1);
                    Console.WriteLine("Новый преподаватель Математики добавлен\n");
                    break;
                case "2":
                    string newTeacherFolder2 = Path.Combine(teachersArchivePath, "Strength of materials", newTeacherFolderName);
                    Directory.CreateDirectory(newTeacherFolder2);
                    Console.WriteLine("Новый преподаватель Сопротивления материалов добавлен\n");
                    break;
                case "3":
                    string newTeacherFolder3 = Path.Combine(teachersArchivePath, "Hydraulics", newTeacherFolderName);
                    Directory.CreateDirectory(newTeacherFolder3);
                    Console.WriteLine("Новый преподаватель Гидравлики добавлен\n");
                    break;
                default:
                    break;

            }
            string password = PasswordGenerator.Generate();
            PasswordGenerator.SaveToFile(password, newTeacherArchivePath);
            PasswordGenerator.SaveToFile($"\n{newSurname}", newTeacherArchivePath);
            Console.WriteLine($"Уведомите студента:\nЛогин для входа в систему: {newSurname}\nПароль: {password}");
        }
    }
}
