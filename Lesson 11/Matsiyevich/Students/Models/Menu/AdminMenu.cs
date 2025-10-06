using Students.Models;
using Students.Models.NewUsers;
public class AdminMenu
{
	
    public void AdminAbileties()
    {
        while (true)
        {
            Console.WriteLine("\n-Меню Администратора-\nВыберите пункт меню:");
            Console.WriteLine("1. Добавить студента\n2. Добавить Преподавателя\n3. Назначить экзамен студенту\n4. Выход");
            string select = Console.ReadLine();

            switch (select)
            {
                case "1":
                    NewStudent newStudent = new NewStudent();
                    newStudent.NewStudentName();
                    break;
                case "2":
                    NewTeacher newTeacher = new NewTeacher();
                    newTeacher.NewTeacherName();
                    break;
                case "3":
                    SetExamsToStudent setExamsToStudent = new SetExamsToStudent();
                    setExamsToStudent.GetStudentsList();
                    setExamsToStudent.GetStudent();
                    setExamsToStudent.GetSubjectsList();
                    setExamsToStudent.SetExam();
                    setExamsToStudent.SetPrepod();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Введён неверный пункт меню");
                    break;
            }
        }
    }
}
