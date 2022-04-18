using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS_Complete.UI;
using UAMS_Complete.DL;

namespace UAMS_Complete.BL
{
    class StudentBL
    {
        //public static List<newstudent> duplicatestudent = new List<newstudent>();
        public string stu_Name;
        public int stu_Age;
        public int stu_FscMarks;
        public int stu_EcatMarks;
        public double stu_Aggregrate;
        public List<DegreeProgramBL> stu_Preferences;
        public List<SubjectBL> stu_Regsubject;
        public DegreeProgramBL regDegree;
        public StudentBL()
        {

        }
        public StudentBL(string stu_Name, int stu_Age, int stu_FscMarks, int stu_EcatMarks, List<DegreeProgramBL> stu_Preferences)
        {
            this.stu_Name = stu_Name;
            this.stu_Age = stu_Age;
            this.stu_FscMarks = stu_FscMarks;
            this.stu_EcatMarks = stu_EcatMarks;
            this.stu_Aggregrate = CalculateAggregrate();
            this.stu_Preferences = stu_Preferences;
            stu_Regsubject = new List<SubjectBL>();
            this.regDegree = null;
        }

        public double CalculateAggregrate()
        {
            double merit = (((stu_FscMarks / 1100) * 70) + ((stu_EcatMarks / 400) * 30));
            return merit;
        }

        public float calculatefee(StudentBL s)
        {
            float fee = 0;
            if (s.regDegree != null)
            {
                foreach (SubjectBL sub in stu_Regsubject)
                {
                    fee = fee + sub.sub_Fees;
                }
            }
            return fee;
        }
    }
}
