using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResultArchive.Models;
using ResultArchive.Models.AuditTrail;
using ResultArchive.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResultArchive.Controllers
{
    public class ExamLogController : Controller
    {
        private readonly DBContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private IHttpContextAccessor _accessor;

        public ExamLogController(DBContext db, UserManager<ApplicationUser> userManager, IHttpContextAccessor accessor)
        {
            _db = db;
            _userManager = userManager;
            _accessor = accessor;
        }

        // GET: ExamLog
        public ActionResult Index()
        {
            DisplayLogViewModel displayLogViewModel = new DisplayLogViewModel()
            {
                ExamLogs = _db.ExamLogs.ToList(),

            };

            return View(displayLogViewModel);
        }


        // GET: ExamLog/Edit/5
        public async Task<ActionResult> EditAsync(string Id)
        {
            if (Id == null || Id.Trim().Length == 0)
            {
                return NotFound();
            }
            else
            {
                var logsFromDB = await _db.ExamLogs.FindAsync(int.Parse(Id));

                if (logsFromDB == null)
                {
                    return NotFound();
                }

                return View(logsFromDB);
            }
        }

        // POST: ExamLog/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, IFormCollection collection, ExamLog examLog)
        {
            var logFromDb = _db.ExamLogs.Where(r => r.Id == examLog.Id).FirstOrDefault();

            if (logFromDb == null)
            {
                ViewBag.Warning = "Exam Log with the given ID cannot be found ";
                return View(examLog);
            }
            else
            {
                logFromDb.SN = Request.Form["SN"];
                logFromDb.Jamb_No = Request.Form["Jamb_No"];
                logFromDb.Subject = Request.Form["Subject"];
                logFromDb.RegNumber = Request.Form["RegNumber"];
                logFromDb.Refrence_Text = Request.Form["Refrence_Text"];
                logFromDb.Question = Request.Form["Question"];
                logFromDb.Option_A = Request.Form["Option_A"];
                logFromDb.Option_B = Request.Form["Option_B"];
                logFromDb.Option_C = Request.Form["Option_C"];
                logFromDb.Option_D = Request.Form["Option_D"];
                logFromDb.Option_E = Request.Form["Option_E"];

                logFromDb.Answer_Choice = Request.Form["Answer_Choice"];
                logFromDb.Answer_Point = Request.Form["Answer_Point"];

                logFromDb.Option_A_Choice = Request.Form["Option_A_Choice"];
                logFromDb.Option_B_Choice = Request.Form["Option_B_Choice"];
                logFromDb.Option_C_Choice = Request.Form["Option_C_Choice"];
                logFromDb.Option_D_Choice = Request.Form["Option_D_Choice"];
                logFromDb.Option_E_Choice = Request.Form["Option_E_Choice"];

                logFromDb.Is_Bonus = Request.Form["Is_Bonus"];
                logFromDb.Is_Option_Image = Request.Form["Is_Option_Image"];
                logFromDb.Ans_From_Student = Request.Form["Ans_From_Student"];
                logFromDb.Question_No = Request.Form["Question_No"];

                logFromDb.Question_Batch_No = Request.Form["Question_Batch_No"];
                logFromDb.Question_No = Request.Form["Question_No"];
                logFromDb.RegNumber = Request.Form["RegNumber"];
                logFromDb.CourseCode = Request.Form["Subject"];


                await _db.SaveChangesAsync();

                //move to audit
                AuditExamLog newAudit = new AuditExamLog(_db);
                var updatedLogFromDb = _db.ExamLogs.Where(r => r.Id == examLog.Id).FirstOrDefault();
                var user = await _userManager.GetUserAsync(HttpContext.User);
                newAudit.CreateAudit(updatedLogFromDb, "EDIT", user.Email.ToString(), _accessor.HttpContext.Connection.RemoteIpAddress.ToString());


                ViewBag.Warning = "ExamLog Successfully Updated";
                return View(examLog);
            }

           
        }

        // GET: ExamLog/Delete/5
        public async Task<ActionResult> DeleteAsync(string Id)
        {
            if (Id == null || Id.Trim().Length == 0)
            {
                return NotFound();
            }
            else
            {
                var logFromDB = await _db.ExamLogs.FindAsync(int.Parse(Id));

                if (logFromDB == null)
                {
                    return NotFound();
                }

                ViewBag.Warning = "This action is irreversible";
                return View(logFromDB);
            }
        }

        // POST: ExamLog/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(string Id, IFormCollection collection)
        {
            try
            {
                if (Id == null)
                {
                    return NotFound();
                }

                var examLog = await _db.ExamLogs.FindAsync(int.Parse(Id));
                _db.ExamLogs.Remove(examLog);
                await _db.SaveChangesAsync();

                //move to audit
                AuditExamLog newAudit = new AuditExamLog(_db);
                var user = await _userManager.GetUserAsync(HttpContext.User);
                newAudit.CreateAudit(examLog, "DELETE", user.Email.ToString(), _accessor.HttpContext.Connection.RemoteIpAddress.ToString());


                TempData["Success"] = "Exam Log Deleted";
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                TempData["Success"] = "An Error Occured";
                return RedirectToAction(nameof(Index));
            }
        }

        //GET: ExamLog/DeleteAll?RouteParams
        [HttpGet]
        public async Task<ActionResult> DeleteAllAsync(string Regnumber, string CourseCode, string School_Acronym, string Session, string Semester)
        {
            try
            {
                var examLog = await _db.ExamLogs.Where(p => p.RegNumber == Regnumber
                                  && p.CourseCode == CourseCode
                                  && p.School_Acronym == School_Acronym
                                  && p.Session == Session
                                  && p.Semester == Semester
                                   ).ToListAsync();

                foreach (var item in examLog)
                {
                    _db.ExamLogs.Remove(item);
                    await _db.SaveChangesAsync();

                    //move to audit
                    AuditExamLog newAudit = new AuditExamLog(_db);
                    var user = await _userManager.GetUserAsync(HttpContext.User);
                    newAudit.CreateAudit(item, "DELETE", user.Email.ToString(), _accessor.HttpContext.Connection.RemoteIpAddress.ToString());

                }

                TempData["Success"] = "Exam Logs Deleted";
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                TempData["Success"] = "An Error Occured";
                return RedirectToAction(nameof(Index));
            }
                
        }

        //GET: ExamLog/ViewAll?RouteParams
        [HttpGet]
        public async Task<ActionResult> ViewAllAsync(string Regnumber, string CourseCode, string School_Acronym, string Session, string Semester)
        {

            var examLog = await _db.ExamLogs.Where(p => p.RegNumber == Regnumber
                                   && p.CourseCode == CourseCode
                                   && p.School_Acronym == School_Acronym
                                   && p.Session == Session
                                   && p.Semester == Semester
                                    ).ToListAsync();
           

            return View("LogFullDetail", examLog);
    
        }


        // GET: ExamLog/LogSearch
        public ActionResult LogSearch()
        {
            DisplayLogViewModel displayLogViewModel = new DisplayLogViewModel()
            {
                Schools = _db.ExamLogs.Select(m => m.School_Acronym).Distinct().ToList(),
                Sessions = _db.ExamLogs.Select(m => m.Session).Distinct().ToList(),
               // Semesters = _db.ExamLogs.Select(m => m.Semester).Distinct().ToList(),
                
            };

            return View(displayLogViewModel);
        }

        // POST: ExamLog/LogSearch
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogSearch(int id, IFormCollection collection)
        {
            string school = collection["school"].ToString();
            string session = collection["session"].ToString();
            string reg_number = collection["reg_number"].ToString();

            DisplayLogViewModel displayLogViewModel = new DisplayLogViewModel()
            {
                ExamLogSearch = _db.ExamLogs.Where(p => p.RegNumber == reg_number
                                    && p.School_Acronym == school
                                    && p.Session == session
                                    ).Select(m => new { m.RegNumber, m.CourseCode, m.School_Acronym, m.Department, m.Semester, m.Session }.ToExpando()).Distinct().ToList()



           };

            if (displayLogViewModel == null)
            {
                ViewBag.Warning = "No Matching Logs Found Based on the Searched Parameters";
                return View();
            }

            return View("LogSearchResult", displayLogViewModel);
        }
    
    
    }
}