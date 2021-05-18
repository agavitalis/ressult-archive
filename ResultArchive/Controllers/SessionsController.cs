using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ResultArchive.Models;
using ResultArchive.Models.AuditTrail;

namespace ResultArchive.Controllers
{
    public class SessionsController : Controller
    {
        private readonly DBContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private IHttpContextAccessor _accessor;

        public SessionsController(DBContext db, UserManager<ApplicationUser> userManager, IHttpContextAccessor accessor)
        {
            _db = db;
            _userManager = userManager;
            _accessor = accessor;
        }
        // GET: Sessions
        public ActionResult Index()
        {
            return View(_db.Sessions.ToList());
        }

        // GET: Sessions/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        // GET: Sessions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sessions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Session session)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Add(session);
                    await _db.SaveChangesAsync();
                   
                    //move to audit
                    AuditSession newAudit = new AuditSession(_db);
                    var user = await _userManager.GetUserAsync(HttpContext.User);
                    newAudit.CreateAudit(session, "CREATE", user.Email.ToString(), _accessor.HttpContext.Connection.RemoteIpAddress.ToString());

                }
                ViewBag.Success = "Session successsfully created";
                return View(session);
            }
            catch
            {
                ViewBag.Error = "Your input seems incorrect, Please check and try again";
                return View(session);
            }
        }
 

        // GET: Sessions/Edit/5
        public async Task<IActionResult> Edit(string Id)
        {
            if (Id == null || Id.Trim().Length == 0)
            {
                return NotFound();
            }
            else
            {
                var sessionFromDB = await _db.Sessions.FindAsync(int.Parse(Id));

                if (sessionFromDB == null)
                {
                    return NotFound();
                }

                return View(sessionFromDB);
            }

        }

        // POST: Sessions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Session session)
        {
            if (id != session.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Update(session);
                await _db.SaveChangesAsync();

                //move to audit
                AuditSession newAudit = new AuditSession(_db);
                var user = await _userManager.GetUserAsync(HttpContext.User);
                newAudit.CreateAudit(session, "EDIT", user.Email.ToString(), _accessor.HttpContext.Connection.RemoteIpAddress.ToString());

                return RedirectToAction("Index");
            }

            return View(session);
        }

        // GET: Sessions/Delete/5
        public async Task<IActionResult> Delete(string Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            Session session = await _db.Sessions.FindAsync(int.Parse(Id));

            if (session == null)
            {
                return NotFound();
            }

            ViewBag.Warning = "This action is irreversible";
            return View(session);
           
        }

        // POST: Sessions/Delete/5
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

                Session session = await _db.Sessions.FindAsync(int.Parse(Id));
                _db.Sessions.Remove(session);
                await _db.SaveChangesAsync();


                //move to audit
                AuditSession newAudit = new AuditSession(_db);
                var user = await _userManager.GetUserAsync(HttpContext.User);
                newAudit.CreateAudit(session, "DELETE", user.Email.ToString(), _accessor.HttpContext.Connection.RemoteIpAddress.ToString());

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}