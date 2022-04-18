using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS_Complete.DL;
using UAMS_Complete.UI;

namespace UAMS_Complete.BL
{
    class DegreeProgramBL
    {
        public string deg_Name;
        public int deg_Duration;
        public int deg_Seats;
        public  List<SubjectBL> Subjects = new List<SubjectBL>();

        public DegreeProgramBL(string deg_name)
        {
            this.deg_Name = deg_name;
        }
        public DegreeProgramBL(string deg_Name, int deg_Duration, int deg_Seats)
        {
            this.deg_Name = deg_Name;
            this.deg_Duration = deg_Duration;
            this.deg_Seats = deg_Seats;
        }
        public DegreeProgramBL()
        {

        }

        public bool isSubjectExist(SubjectBL s)
        {
            foreach (SubjectBL sub in Subjects)
            {
                if (s.sub_Code == sub.sub_Code)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
