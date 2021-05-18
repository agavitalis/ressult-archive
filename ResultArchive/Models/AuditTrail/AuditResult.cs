using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResultArchive.Models.AuditTrail
{
    public class AuditResult
    {
        private readonly DBContext _db;
        public AuditResult(DBContext db)
        {
            _db = db;
            Timestamp = DateTime.Now;
        }

        public int Id { get; set; }
        public int ResultId { get; set; }
        public string RegNumber { get; set; }    
        public string FirstName { get; set; }      
        public string LastName { get; set; }
        public string OtherName { get; set; }
        public string CourseCode { get; set; }
        public string CVScore { get; set; }
        public string ExamScore { get; set; }
        public string TotalScore { get; set; }
        public string Department { get; set; }
        public int SchoolId { get; set; }
        public int SessionId { get; set; }
        public string Semester { get; set; }
        public string Action { get; set; }
        public string PerformedBy { get; set; }
        public string IpAddress { get; set; }
        public DateTime Timestamp { get; set; }

        public void CreateAudit(Result result, string action, string userEmail, string userIpAddress)
        {
            var newAuditResult = new AuditResult(_db)
            {
                ResultId = result.Id,
                RegNumber = result.RegNumber,
                FirstName = result.FirstName,
                LastName = result.LastName,
                OtherName = result.OtherName,

                CVScore = result.CVScore,
                ExamScore = result.ExamScore,
                TotalScore = result.TotalScore,
                CourseCode = result.CourseCode,
                Department = result.Department,

                Semester = result.Semester,
                SessionId = result.SessionId,
                SchoolId = result.SchoolId,

                Action = action,
                PerformedBy = userEmail,
                IpAddress = userIpAddress

            };

            _db.AuditResults.Add(newAuditResult);

            //save the school Audit Records
            _db.SaveChanges();
        }
    }
}
