using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS_Complete.BL;
using UAMS_Complete.UI;

namespace UAMS_Complete.DL
{
    class StudentDL
    {
        public static List<StudentBL> StudentsList = new List<StudentBL>();
        public static List<StudentBL> SortedList = new List<StudentBL>();

        public static void AddStudentIntoList(StudentBL s)
        {
            StudentsList.Add(s);
        }

        public static void SortedByMerit()
        {
            SortedList = StudentsList.OrderByDescending(o => o.stu_Aggregrate).ToList();
        }

        public static bool CheckRegisteredStudent(string DegName,StudentBL s)
        {
            if(s.regDegree.deg_Name==DegName)
            {
                return true;
            }
            return false;
        }

        public static StudentBL StudentPresent(string name)
        {
            foreach (StudentBL s in StudentsList)
            {
                if (s.stu_Name == name && s.stu_Regsubject != null)
                {
                    return s;
                }
            }
            return null;
        }

        public static int getCreditHours(StudentBL stu)
        {
            int total = 0;
            foreach (SubjectBL sub in stu.stu_Regsubject)
            {
                total = total + sub.sub_Credithours;
            }
            
            return total;
        }

        public static bool RegisterSubject(SubjectBL s,StudentBL stu)
        {
            int stch = getCreditHours(stu);
            if (stu.regDegree != null && stu.regDegree.isSubjectExist(s) && stch + s.sub_Credithours <= 9)
            {
                stu.stu_Regsubject.Add(s);
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
