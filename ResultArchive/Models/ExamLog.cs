using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResultArchive.Models
{
    public class ExamLog
    {
        public int Id { get; set; }

        public string SN { get; set; }
       
        public string Jamb_No { get; set; }
       
        public string Subject { get; set; }
       
        public string Refrence_Text { get; set; }
       
        public string Refrence_Image { get; set; }
       
        public string Question { get; set; }
       
        public string Option_A { get; set; }
       
        public string Option_B { get; set; }
       
        public string Option_C { get; set; }
       
        public string Option_D { get; set; }
       
        public string Option_E { get; set; }
       
        public string Answer_Choice { get; set; }
       
        public string Answer_Point { get; set; }
       
        public string Option_A_Choice { get; set; }
       
        public string Option_B_Choice { get; set; }
       
        public string Option_C_Choice { get; set; }
       
        public string Option_D_Choice { get; set; }
       
        public string Option_E_Choice { get; set; }
       
        public string Is_Bonus { get; set; }
       
        public string Is_Option_Image { get; set; }
       
        public string Ans_From_Student { get; set; }
       
        public string Question_No { get; set; }
       
        public string Question_Batch_No { get; set; }

        public string CourseCode { get; set; }
        public string RegNumber { get; set; }
        public string School { get; set; }
        public string School_Acronym { get; set; }
        public string Department { get; set; }
        public string Session { get; set; }
        public string Semester { get; set; }

    }
}
