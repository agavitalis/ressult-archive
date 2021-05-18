using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResultArchive.Models;
using System.Data;
using ResultArchive.ViewModels;
using OfficeOpenXml;
using System.IO;
using Microsoft.AspNetCore.Identity;
using ResultArchive.Models.AuditTrail;

namespace ResultArchive.Controllers
{
    public class ResultsController : Controller
    {

        private readonly DBContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private IHttpContextAccessor _accessor;

        public ResultsController(DBContext db, UserManager<ApplicationUser> userManager, IHttpContextAccessor accessor)
        {
            _db = db;
            _userManager = userManager;
            _accessor = accessor;
        }


        // GET: Results
        public ActionResult Index()
        {
            DisplayResultViewModel displayResultViewModel = new DisplayResultViewModel()
            {
                Schools = _db.Schools.ToList(),
                Sessions = _db.Sessions.ToList(),
                Results =_db.Results.ToList()

            };

            return View(displayResultViewModel);
        }

        // GET: Results/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Results/Create
        public ActionResult Create()
        {
            IEnumerable<School> school = _db.Schools.OrderByDescending(s => s.Id);
            IEnumerable<Session> session = _db.Sessions.OrderByDescending(s => s.Id);
        
            AddResultViewModel resultViewModel = new AddResultViewModel() { Schools = school, Sessions = session };      
          
            return View(resultViewModel);
        }

        // POST: Results/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile resultExcel)
        {
          
            // use Collection["name"] or mehtod below          
            string schoolID = Request.Form["school"];
            string sessionID = Request.Form["session"];
            string semester = Request.Form["semester"];

            //Read the scripts and move them to db 
            ExcelPackage excel;
            using(var memoryStream = new MemoryStream())
            {
                await resultExcel.CopyToAsync(memoryStream);
                excel = new ExcelPackage(memoryStream);
            }

            //check if this excel is the right one
            if (ValidateExeclSheet(excel))
            {
                //get the first sheet in the excel
                var resultSheet = excel.Workbook.Worksheets[0];
                var start = resultSheet.Dimension.Start;
                var end = resultSheet.Dimension.End;

                for (int row = 2; row <= end.Row; row++)
                {
                    //create a result
                    Result newResult = new Result
                    {
                        RegNumber = resultSheet.Cells[row, 1].Text,
                        FirstName = resultSheet.Cells[row, 2].Text,
                        LastName = resultSheet.Cells[row, 3].Text,
                        OtherName = resultSheet.Cells[row, 4].Text,
                        
                        CVScore = resultSheet.Cells[row, 5].Text,
                        ExamScore = resultSheet.Cells[row, 6].Text,
                        TotalScore = resultSheet.Cells[row, 7].Text,
                        CourseCode = resultSheet.Cells[row, 8].Text,
                        Department = resultSheet.Cells[row, 9].Text,
  
                        Semester = semester,
                        SessionId = Int32.Parse(sessionID),
                        SchoolId = Int32.Parse(schoolID),
                    };

                    _db.Results.Add(newResult);

                    //move to audit
                    AuditResult newAudit = new AuditResult(_db);
                    var user = await _userManager.GetUserAsync(HttpContext.User);
                    newAudit.CreateAudit(newResult, "CREATE", user.Email.ToString(), _accessor.HttpContext.Connection.RemoteIpAddress.ToString());


                }


                //save the results
                _db.SaveChanges();

                TempData["Success"] = "Result Uploaded Successfully";
                return RedirectToAction(nameof(Create));
            }
            else
            {

                TempData["Error"] = "Invalid Result Template, Please download and use the sample result sheet";
                return RedirectToAction(nameof(Create));
            }

        }

        // GET: Results/Edit/5
        public async Task<ActionResult> EditAsync(string Id)
        {
            if (Id == null || Id.Trim().Length == 0)
            {
                return NotFound();
            }
            else
            {
                var resultsFromDB = await _db.Results.FindAsync(int.Parse(Id));

                if (resultsFromDB == null)
                {
                    return NotFound();
                }

                return View(resultsFromDB);
            }
        }

        // POST: Results/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Result result)
        {
            var resultFromDb = _db.Results.Where(r => r.Id == result.Id).FirstOrDefault();

            if (resultFromDb == null)
            {
                return NotFound();
            }
            else
            {
                resultFromDb.FirstName = Request.Form["FirstName"];
                resultFromDb.LastName = Request.Form["LastName"];
                resultFromDb.OtherName = Request.Form["OtherName"];
                resultFromDb.RegNumber = Request.Form["RegNumber"];
                resultFromDb.CVScore = Request.Form["CVScore"];
                resultFromDb.ExamScore = Request.Form["ExamScore"];
                resultFromDb.TotalScore = Request.Form["TotalScore"];
                resultFromDb.CourseCode = Request.Form["CourseCode"];
                resultFromDb.Department = Request.Form["Department"]; 

                 await _db.SaveChangesAsync();

                //move to audit
                AuditResult newAudit = new AuditResult(_db);
                var updatedresultFromDb = _db.Results.Where(r => r.Id == result.Id).FirstOrDefault();
                var user = await _userManager.GetUserAsync(HttpContext.User);
                newAudit.CreateAudit(updatedresultFromDb, "EDIT", user.Email.ToString(), _accessor.HttpContext.Connection.RemoteIpAddress.ToString());


                return RedirectToAction(nameof(Index));
            }

          
        }

        // GET: Results/Delete/5
        public async Task<ActionResult> DeleteAsync(string Id)
        {
            if (Id == null || Id.Trim().Length == 0)
            {
                return NotFound();
            }
            else
            {
                var resultsFromDB = await _db.Results.FindAsync(int.Parse(Id));

                if (resultsFromDB == null)
                {
                    return NotFound();
                }

                ViewBag.Warning = "This action is irreversible";
                return View(resultsFromDB);
            }
        }

        // POST: Results/Delete/5
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

                Result result = await _db.Results.FindAsync(int.Parse(Id));
                _db.Results.Remove(result);
                await _db.SaveChangesAsync();

                //move to audit
                AuditResult newAudit = new AuditResult(_db);
                var user = await _userManager.GetUserAsync(HttpContext.User);
                newAudit.CreateAudit(result, "DELETE", user.Email.ToString(), _accessor.HttpContext.Connection.RemoteIpAddress.ToString());


                TempData["Success"] = "Result Deleted";
                return RedirectToAction(nameof(Index));

            
            }
            catch
            {
                TempData["Success"] = "An Error Occured";
                return RedirectToAction(nameof(Index));
            }
        }

        private bool ValidateExeclSheet(ExcelPackage result)
        {
            //get the first sheet in the excel
            var workSheet = result.Workbook.Worksheets[0];

            //grab the first excel rows
            var RegNumber = workSheet.Cells[1, 1].Text;
            var FirstName = workSheet.Cells[1, 2].Text;
            var LastName = workSheet.Cells[1, 3].Text;
            var OtherName = workSheet.Cells[1, 4].Text;

            var CVScore = workSheet.Cells[1, 5].Text;
            var ExamScore = workSheet.Cells[1, 6].Text;
            var TotalScore = workSheet.Cells[1, 7].Text;

            var CourseCode = workSheet.Cells[1, 8].Text;
            var Department = workSheet.Cells[1, 9].Text;

            //check if this colums are in the same other
            if (RegNumber != "RegNumber" || FirstName != "FirstName" || LastName != "LastName" || OtherName != "OtherName" || CVScore != "CVScore" || ExamScore != "ExamScore" || TotalScore != "TotalScore" || CourseCode != "CourseCode" || Department != "Department")
            {
                return false;
            }

            return true;
        }

        public FileResult DownloadSampleExcel()
        {
            var fileName = $"SampleResultSheet.xlsx";
            var filepath = $"Uploads/{fileName}";
            byte[] fileBytes = System.IO.File.ReadAllBytes(filepath);
            return File(fileBytes, "application/x-msdownload", fileName);
        }

    }
}