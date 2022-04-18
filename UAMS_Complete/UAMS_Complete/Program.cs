using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS_Complete.UI;
using UAMS_Complete.DL;
using UAMS_Complete.BL;

namespace UAMS_Complete
{
    class Program
    {
        static void Main(string[] args)
        {
            int Option = 0;
            while(Option!=8)
            {
                Option = StudentUI.menu();
                StudentUI.clearscreen();
                if(Option==1)//Add student
                {
                    StudentUI.header();
                    StudentBL AddStudent = StudentUI.addstudent();
                    StudentDL.AddStudentIntoList(AddStudent);
                    Console.WriteLine(StudentDL.StudentsList.Count);
                    Console.WriteLine(StudentDL.StudentsList[0].stu_Preferences.Count);
                }
                else if(Option==2)//Take degree input
                {
                    StudentUI.header();
                    DegreeProgramBL AddDegree = DegreeProgramUI.takedegreeinput();
                    DegreeProgramDL.AddDegreeIntoList(AddDegree);
                    Console.WriteLine(DegreeProgramDL.TotalDegreesList.Count);
                }
                else if(Option==3)//Generate Merit
                {
                    StudentUI.header();
                    StudentDL.SortedByMerit();
                    StudentUI.giveadmission();
                    StudentUI.PrintStudent();
                }
                else if(Option==4)//View Registered Student
                {
                    StudentUI.header();
                    StudentUI.ViewRegisteredStudent();
                }
                else if(Option==5)//Students of specific program
                {
                    StudentUI.header();
                    StudentUI.StudentOfSpecificProgram();
                }
                else if(Option==6)//Register subjects for a specific student
                {
                    StudentUI.header();
                    StudentUI.RegisterSubjects();
                }
                else if(Option==7)// Calculate fee for all subjeects
                {
                    StudentUI.header();
                    StudentUI.calculatefeeforall();
                }
                StudentUI.clearscreen();
            }
        }
    }
}
