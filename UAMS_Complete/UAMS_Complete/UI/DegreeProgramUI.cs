using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS_Complete.DL;
using UAMS_Complete.BL;

namespace UAMS_Complete.UI
{
    class DegreeProgramUI
    {
        public static DegreeProgramBL takedegreeinput()
        {
            //int totalhour = 21;
            Console.Write("Enter degree name: ");
            string deg_Name = Console.ReadLine();
            Console.Write("Enter degree duration: ");
            int deg_Duration = int.Parse(Console.ReadLine());
            Console.Write("Enter seats for degree: ");
            int deg_Seats = int.Parse(Console.ReadLine());
            Console.Write("Enter how many subjects to enter: ");
            int total = int.Parse(Console.ReadLine());
            DegreeProgramBL deg = new DegreeProgramBL(deg_Name, deg_Duration, deg_Seats);
            SubjectUI s = new SubjectUI();
            for (int i = 0; i < total; i++)
            {
                if (DegreeProgramDL.AddSubject(deg,SubjectUI.getallsubjects()) == false)//YHA CHANGE KYA
                {
                    Console.WriteLine("Your selected subjects  has increased from 20 credit hours ");
                }
            }

            //while (totalhour > 20)
            //{
            //    Console.Clear();
            //    List<Subject> Subjects = getallsubjects(total);
            //    newdegree = new DegreeProgram(name, duration, seats, Subjects);
            //    totalhour = newdegree.CalculateCreditHours();
            //    if (totalhour > 20)
            //    {
            //        Console.WriteLine("Your entered subject exceed 20 credit hour..Try again");
            //    }
            //}
            return deg;
        }

    }
}
