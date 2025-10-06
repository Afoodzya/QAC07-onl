using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Models
{     
    public class Confirm
    {
        public string variantForNewStudent;
        public Confirm(string _variantForNewStudent)    
        {
            Console.WriteLine("Вы уверены в правильности ввода?\n 1 - Да\n 2 - Нет");
            int select = Int32.Parse(Console.ReadLine());

            switch (select)
            {
                case 1:
                    Console.WriteLine("Saved!");
                    break;

                case 2:
                    Console.WriteLine("Do not save!");
                    break;
            }
        }

        
    }
}
