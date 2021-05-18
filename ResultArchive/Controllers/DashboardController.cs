using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResultArchive.Models;
using ResultArchive.ViewModels;

namespace ResultArchive.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly DBContext _db;
       
        public DashboardController(DBContext db)
        {
            _db = db;
        }
        public IActionResult Dashboard()
        {
            DashboardViewModel displayDetails = new DashboardViewModel()
            {
                SchoolCount = _db.Schools.Count().ToString(),
                SessionCount = _db.Sessions.Count().ToString(),
                ResultCount = _db.Results.Count().ToString(),
                UserCount = _db.ApplicationUsers.Count().ToString()

            };
            return View(displayDetails);
        }                                                                                                                                                                                                                
                                                                                               
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
                                                                                                                                                                                                                                                          