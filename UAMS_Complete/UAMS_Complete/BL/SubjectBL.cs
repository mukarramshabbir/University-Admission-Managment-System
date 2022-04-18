using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS_Complete.UI;
using UAMS_Complete.DL;

namespace UAMS_Complete.BL
{
    class SubjectBL
    {
        public string sub_Code;
        public string sub_Type;
        public int sub_Credithours;
        public int sub_Fees;
        public SubjectBL(string sub_Code, string sub_Type, int sub_Credithours, int sub_Fees)
        {
            this.sub_Code = sub_Code;
            this.sub_Type = sub_Type;
            this.sub_Credithours = sub_Credithours;
            this.sub_Fees = sub_Fees;
        }
        public SubjectBL()
        {

        }

        
    }
}
