using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS_Complete.BL;
using UAMS_Complete.DL;

namespace UAMS_Complete.UI
{
    class StudentUI
    {
        public static int menu()
        {
            Console.WriteLine("1. Add Student:");
            Console.WriteLine("2. Add Degree Program:");
            Console.WriteLine("3. Generate Merit:");
            Console.WriteLine("4. View Registered Student:");
            Console.WriteLine("5. View students of a specific program:");
            Console.WriteLine("6. Register Subjects for a specific student:");
            Console.WriteLine("7. Calculate fees for all Regsitered students:");
            Console.WriteLine("8. Exit");
            Console.Write("Enter your option: ");
            int op = int.Parse(Console.ReadLine());
            while (op < 0 || op > 8)
            {
                Console.WriteLine("You entered invalid option.Please try Again.");
                Console.Write("Enter your option: ");
                op = int.Parse(Console.ReadLine());
            }
            return op;
        }
        public static void header()
        {
            Console.WriteLine("****************************************");
            Console.WriteLine("                  UAMS");
            Console.WriteLine("****************************************");
        }
        public static void clearscreen()
        {
            Console.WriteLine("Enter any number to continue ");
            Console.ReadKey();
            Console.Clear();
        }

        public static StudentBL addstudent()
        {
            //List<DegreeProgram> preferences = new List<DegreeProgram>();

            Console.Write("Enter the student name: ");
            string name = Console.ReadLine();
            Console.Write("Enter the studenta age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter the fsc marks: ");
            int fscmark = int.Parse(Console.ReadLine());
            Console.Write("Enter ecat marks: ");
            int ecatmark = int.Parse(Console.ReadLine());
            //Student s = new Student();
            Console.WriteLine("Available Degree programs: ");
            ViewDegreePrograms();
            Console.Write("Enter how many preferences you want to add: ");
            int total = int.Parse(Console.ReadLine());
            List<DegreeProgramBL> pref = prefer(total);
            StudentBL s1 = new StudentBL(name, age, fscmark, ecatmark, pref);
            return s1;
        }

        public static void ViewDegreePrograms()
        {
            int i = 0;
            foreach (DegreeProgramBL d in DegreeProgramDL.TotalDegreesList)
            {
                Console.WriteLine("{0}. {1}", i + 1, d.deg_Name);
                i++;
            }
        }
        public static List<DegreeProgramBL> prefer(int total)
        {
            string pref = " ";
            //List<newstudent> lis = new List<newstudent>();
            List<DegreeProgramBL> p = new List<DegreeProgramBL>();

            for (int i = 0; i < total; i++)
            {
                bool flag = false;
                Console.WriteLine("{0}. Enter preference: ", i + 1);
                pref = Console.ReadLine();
                //foreach (DegreeProgram d in DegreeProgram.TotalDegrees)
                //{
                //    if (pref == d.deg_Name && !(p.Contains(d)))
                //    {
                //        flag = true;
                //        p.Add(d);
                //    }
                //}
                //if (flag == false)
                //{
                //    Console.WriteLine("Your selected preference is incorrect or not available.Please try again");
                //    i--;
                //}
                if(DegreeProgramDL.IsPreferenceExist(pref,p)==false)
                {
                    Console.WriteLine("You entered wrong preference or the following preference is not available");
                }
                //for (int j = 0; j < DegreeProgram.TotalDegrees.Count; j++)
                //{
                //    if (DegreeProgram.TotalDegrees[j].deg_Name == pref)
                //    {
                //        flag = true;
                //        DegreeProgram extra = new DegreeProgram(pref);
                //        p.Add(extra);
                //    }
                //}
                //if (flag == false)
                //{
                //    Console.WriteLine("You entered wrong preference or the following preference is not available");
                //}
            }
            return p;
        }

        public static void giveadmission()
        {
            foreach (StudentBL s in StudentDL.SortedList)
            {
                foreach (DegreeProgramBL d in s.stu_Preferences)
                {
                    if (d.deg_Seats > 0 && s.regDegree == null)
                    {
                        s.regDegree = d;
                        d.deg_Seats--;
                        break;
                    }
                }
            }
        }

        public static void PrintStudent()
        {
            foreach (StudentBL s in StudentDL.SortedList)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine("{0} Got admission in {1}", s.stu_Name, s.regDegree.deg_Name);
                }
                else
                {
                    Console.WriteLine("{0} didnot got admission.", s.stu_Name);
                }
            }
        }

        public static void ViewRegisteredStudent()
        {
            Console.WriteLine("Name \t Fsc Marks \t Ecat Marks \t Age");
            for (int i = 0; i < StudentDL.SortedList.Count; i++)
            {
                if (StudentDL.SortedList[i].regDegree != null)
                {
                    Console.WriteLine("{0} \t {1} \t {2} \t {3}", StudentDL.SortedList[i].stu_Name, StudentDL.SortedList[i].stu_FscMarks, StudentDL.SortedList[i].stu_EcatMarks, StudentDL.SortedList[i].stu_Age);
                }
            }
        }

        public static void StudentOfSpecificProgram()
        {
            Console.WriteLine("Enter the Degree Name: ");
            
                string DegName = Console.ReadLine();
            
            Console.WriteLine("Name \t Fsc Marks \t Ecat Marks \t Age");
            //foreach (StudentBL s in StudentDL.SortedList)
            //{
            //    if (s.regDegree != null)
            //    {
            //        if (DegName == s.regDegree.deg_Name)
            //        {
            //            Console.WriteLine("{0} \t {1} \t {2} \t {3}", s.stu_Name, s.stu_FscMarks, s.stu_EcatMarks, s.stu_Age);
            //        }
            //    }
            //}
            for(int i=0;i<StudentDL.SortedList.Count;i++)
            {
                if(StudentDL.CheckRegisteredStudent(DegName,StudentDL.SortedList[i]))
                {
                    Console.WriteLine("{0} \t {1} \t {2} \t {3}", StudentDL.SortedList[i].stu_Name, StudentDL.SortedList[i].stu_FscMarks, StudentDL.SortedList[i].stu_EcatMarks, StudentDL.SortedList[i].stu_Age);
                }
            }
        }

        public static void RegisterSubjects()
        {
            Console.WriteLine("Enter the student name: ");
            string name = Console.ReadLine();
            StudentBL s = StudentDL.StudentPresent(name);
            if (s != null)
            {
                ViewSubject(s);
                RegisterStudentSubject(s);
            }
        }

        public static void ViewSubject(StudentBL s)
        {
            DegreeProgramBL d = new DegreeProgramBL();
            if (s != null)
            {
                Console.WriteLine("Sub Code \t Sub Type");
                foreach (SubjectBL sub in s.regDegree.Subjects)//yha change kya
                {
                    Console.WriteLine("{0} \t {1}", sub.sub_Code, sub.sub_Type);
                }
                //for(int i=0;i<s.regDegree.Subjects.Count;i++)
                //{

                //}
            }
        }

        public static void RegisterStudentSubject(StudentBL s)
        {
            Console.WriteLine("Enter how many subjects you want to register: ");
            int total = int.Parse(Console.ReadLine());
            for (int i = 0; i < total; i++)
            {
                Console.WriteLine("Enter the subject code: ");
                string code = Console.ReadLine();
                bool flag = false;
                foreach (SubjectBL sub in s.regDegree.Subjects)
                {
                    if (code == sub.sub_Code && !(s.stu_Regsubject.Contains(sub)))
                    {
                        if (StudentDL.RegisterSubject(sub, s))
                        {
                            flag = true;
                            Console.WriteLine("Your subject has been reistered");
                            break;
                        }
                    }
                }
                //for(int i=0;i<s.regDegree.)
                if (flag == false)
                {
                    Console.WriteLine("Enter Valid course.");
                    i--;
                }
            }
        }

        public static void calculatefeeforall()
        {
            foreach (StudentBL s in StudentDL.StudentsList)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine("{0} has total fee {1}", s.stu_Name, s.calculatefee(s));
                }
            }
        }
    }
}
