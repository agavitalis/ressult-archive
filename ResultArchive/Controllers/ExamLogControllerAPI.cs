using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResultArchive.Models;
using ResultArchive.Models.AuditTrail;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ResultArchive.Controllers
{
    [Produces("application/json")]
    [Route("api/exam_log")]
    [EnableCors("AllowAll")]
    public class ExamLogControllerAPI : Controller
    {
        private readonly DBContext _db;
        private IHttpContextAccessor _accessor;

        public ExamLogControllerAPI(DBContext db, IHttpContextAccessor accessor)
        {
            _db = db;
            _accessor = accessor;
        }
        // GET: api/exam_log
        [HttpGet]
        public object Get()
        {
            IEnumerable<ExamLog> examLogs = _db.ExamLogs.OrderByDescending(s => s.Id);
            return new
            {
                examLogs = examLogs,
                response =200

            };
        }

        // GET api/exam_log/5
        [HttpGet("{id}")]
        public async  Task<object> GetAsync(string Id)
        {
            var logsFromDB = await _db.ExamLogs.FindAsync(int.Parse(Id));

            if (logsFromDB == null)
            {
                return new
                {
                    message = "Exam Log with the supplied Id was not found",
                    response = 400
                };
            }

            return new
            {
                examLog = logsFromDB,
                response = 200

            };
        }
           
        // POST api/<exam_log>
        [HttpPost]
        public object Post([FromBody]ExamLog examLog)
        {
            //ensure that something was sent
            //create a result
            if(examLog != null)
            {
                //Todo:checked for duplicate entries
                ExamLog newExamLog = new ExamLog
                {
    
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
                    Semester = examLog.Semester

                };

                _db.ExamLogs.Add(newExamLog);

                //save the results
                _db.SaveChanges();

                AuditExamLog newAudit = new AuditExamLog(_db);
                newAudit.CreateAudit(newExamLog, "CREATE", "CBT APP", _accessor.HttpContext.Connection.RemoteIpAddress.ToString());


                return new
                {
                    response = 200,
                    message = "Exam Log Recorded Successfully"
                };
            }

            return new
            {
                response = 500,
                message = "Please double check your data and try again"
            };


        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public object Put(int id, [FromBody]string value)
        {
            return new
            {
                response = 419,
                message = "Silence is Golder"
            };

        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            return new
            {
                response = 419,
                message = "Silence is Golder"
            };
        }
    }
}
