using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS_Complete.BL;
using UAMS_Complete.DL;

namespace UAMS_Complete.UI
{
    class SubjectUI
    {
        public static SubjectBL getallsubjects()//tha static change kya
        {
            int i = 1;
            Console.WriteLine("Add {0} subject: ", i);
            Console.Write("Enter subject code: ");
            string code = Console.ReadLine();
            Console.Write("Enter subject type: ");
            string type = Console.ReadLine();
            Console.Write("Enter subject credit hours: ");
            int credit = int.Parse(Console.ReadLine());
            Console.Write("Enter subject fees: ");
            int fees = int.Parse(Console.ReadLine());
            SubjectBL subjects = new SubjectBL(code, type, credit, fees);
            i++;
            return subjects;
        }
    }
}
