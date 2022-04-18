using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS_Complete.UI;
using UAMS_Complete.BL;

namespace UAMS_Complete.DL
{
    class DegreeProgramDL
    {
        public static List<DegreeProgramBL> TotalDegreesList = new List<DegreeProgramBL>();

        public static int CalculateCreditHours(DegreeProgramBL d)//yha change kya
        {
            int total = 0;
            for (int i = 0; i < d.Subjects.Count; i++)
            {
                total = total + d.Subjects[i].sub_Credithours;
            }
            return total;
        }

        public static bool AddSubject(DegreeProgramBL d,SubjectBL s)//yha change kya
        {
            
            
            int credithours = CalculateCreditHours(d);
            if (credithours + s.sub_Credithours <= 20)
            {
                d.Subjects.Add(s);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void AddDegreeIntoList(DegreeProgramBL d)
        {
            TotalDegreesList.Add(d);
        }

        public static bool IsPreferenceExist(string pref,List<DegreeProgramBL> d)
        {
            //for(int i=0;i<TotalDegreesList.Count;i++)
            //{
            //    if (pref == TotalDegreesList[i].deg_Name && !(d.Contains(pref)))
            //}

            foreach(DegreeProgramBL deg in TotalDegreesList)
            {
                if(pref==deg.deg_Name && !(d.Contains(deg)))
                {
                    d.Add(deg);
                    return true;
                }
                
            }
            return false;
        }

    }
}
