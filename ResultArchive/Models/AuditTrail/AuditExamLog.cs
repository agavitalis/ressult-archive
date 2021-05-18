using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResultArchive.Models.AuditTrail
{
    public class AuditExamLog
    {

        private readonly DBContext _db;
        public AuditExamLog(DBContext db)
        {
            _db = db;
            Timestamp = DateTime.Now;
        }

        public int Id { get; set; }
        public int ExamLogId { get; set; }
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


        public string Action { get; set; }
        public string PerformedBy { get; set; }
        public string IpAddress { get; set; }
        public DateTime Timestamp { get; set; }

        public void CreateAudit(ExamLog examLog, string action, string userEmail, string userIpAddress)
        {
            var newAuditExamLog = new AuditExamLog(_db)
            {
                ExamLogId = examLog.Id,
                SN = examLog.SN,
                Jamb_No = examLog.Jamb_No,
                Subject = examLog.Subject,
                Refrence_Text = examLog.Refrence_Text,
                Refrence_Image = examLog.Refrence_Image,

                Question = examLog.Question,
                Option_A = examLog.Option_A,
                Option_B = examLog.Option_B,
                Option_C = examLog.Option_C,
                Option_D = examLog.Option_D,
                Option_E = examLog.Option_E,
                Answer_Choice = examLog.Answer_Choice,

                Answer_Point = examLog.Answer_Point,
                Option_A_Choice = examLog.Option_A_Choice,
                Option_B_Choice = examLog.Option_B_Choice,
                Option_C_Choice = examLog.Option_C_Choice,
                Option_D_Choice = examLog.Option_D_Choice,
                Option_E_Choice = examLog.Option_E_Choice,

                Is_Bonus = examLog.Is_Bonus,
                Is_Option_Image = examLog.Is_Option_Image,
                Ans_From_Student = examLog.Ans_From_Student,
                Question_No = examLog.Question_No,
                Question_Batch_No = examLog.Question_Batch_No,

                CourseCode = examLog.Subject,
                RegNumber = examLog.RegNumber,
                School = examLog.School,
                School_Acronym = examLog.School_Acronym,
                Department = examLog.Department,
                Session = examLog.Session,
                Semester = examLog.Semester,

                Action = action,
                PerformedBy = userEmail,
                IpAddress = userIpAddress

            };

            _db.AuditExamLogs.Add(newAuditExamLog);

            //save the school Audit Records
            _db.SaveChanges();
        }
    }
}
