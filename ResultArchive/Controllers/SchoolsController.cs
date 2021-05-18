using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ResultArchive.Models;
using ResultArchive.Models.AuditTrail;

namespace ResultArchive.Controllers
{
    public class SchoolsController : Controller
    {  
        private readonly DBContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private IHttpContextAccessor _accessor;
        public SchoolsController(DBContext db, UserManager<ApplicationUser> userManager, IHttpContextAccessor accessor)
        {
            _db = db;
            _userManager = userManager;
            _accessor = accessor;
        }
                                                                                                                                          
        // GET: Schools
        public ActionResult Index()
        {
            return View(_db.Schools.ToList());
        }

        // GET: Schools/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Schools/Create  
        public ActionResult Create()
        {
            return View();
        }

        // POST: Schools/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(School school)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Add(school);
                    await _db.SaveChangesAsync();

                    //move to audit
                    AuditSchool newAudit = new AuditSchool(_db);
                    var user = await _userManager.GetUserAsync(HttpContext.User);
                    newAudit.CreateAudit(school,"CREATE",user.Email.ToString(), _accessor.HttpContext.Connection.RemoteIpAddress.ToString());

                }
                ViewBag.Success = "School successsfully created";
                return View(school);

            }
            catch
            {
                ViewBag.Error = "Your input seems incorrect, Please check and try again";
                return View(school);
            }
        }

        // GET: Schools/Edit/5
        public async Task<IActionResult> Edit(string Id)
        {
            if (Id == null || Id.Trim().Length == 0)
            {
                return NotFound();
            }
            else
            {
                var schoolsFromDB = await _db.Schools.FindAsync(int.Parse(Id));

                if (schoolsFromDB == null)
                {
                    return NotFound();
                }

                return View(schoolsFromDB);
            }

        }

        // POST: School/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, School school)
        {
            if (id != school.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Update(school);
                await _db.SaveChangesAsync();

                //move to audit
                AuditSchool newAudit = new AuditSchool(_db);
                var user = await _userManager.GetUserAsync(HttpContext.User);
                newAudit.CreateAudit(school, "EDIT", user.Email.ToString(), _accessor.HttpContext.Connection.RemoteIpAddress.ToString());

                return RedirectToAction("Index");
            }

            return View(school);
        }

        // GET: School/Delete/5
        public async Task<IActionResult> Delete(string Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            School school = await _db.Schools.FindAsync(int.Parse(Id));

            if (school == null)
            {
                return NotFound();
            }

            ViewBag.Warning = "This action is irreversible";
            return View(school);

        }

        // POST: Schools/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(string Id)
        {
            try
            {
                if (Id == null)
                {
                    return NotFound();
                }

                School school = await _db.Schools.FindAsync(int.Parse(Id));
                _db.Schools.Remove(school);
                await _db.SaveChangesAsync();

                //move to audit
                AuditSchool newAudit = new AuditSchool(_db);
                var user = await _userManager.GetUserAsync(HttpContext.User);
                newAudit.CreateAudit(school, "DELETE", user.Email.ToString(), _accessor.HttpContext.Connection.RemoteIpAddress.ToString());


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}