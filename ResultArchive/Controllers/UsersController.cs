  using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ResultArchive.Models;
using ResultArchive.Utility;

namespace ResultArchive.Controllers  
{
    public class UsersController : Controller
    {
        private readonly DBContext _db;
        private IHostingEnvironment _env;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;


        public UsersController(DBContext db, IHostingEnvironment env,UserManager<ApplicationUser> userManager ,RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _env = env;
            _roleManager = roleManager;
            _userManager = userManager;

        }

        // GET: Users  
        public IActionResult Index()
        {
            //get all the users of this application
            return View(_db.ApplicationUsers.ToList()); 

        }
          
        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Users/Create
        //[Authorize(Roles = SD.SuperAdminEndUser)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        //[Authorize(Roles = SD.SuperAdminEndUser)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ApplicationUser user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newApplicationUser = new ApplicationUser()
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        UserName = user.Email
                    };

                    var result = await _userManager.CreateAsync(newApplicationUser, Request.Form["Password"]);
                    if (result.Succeeded)
                    {
                        //check if the roles exists or create them if not
                        if (!await _roleManager.RoleExistsAsync(SD.AdminEndUser))
                        {
                            await _roleManager.CreateAsync(new IdentityRole(SD.AdminEndUser));
                        }

                        if (!await _roleManager.RoleExistsAsync(SD.SuperAdminEndUser))
                        {
                            await _roleManager.CreateAsync(new IdentityRole(SD.SuperAdminEndUser));
                        }

                        if (user.IsSuperAdmin)
                        {
                            await _userManager.AddToRoleAsync(newApplicationUser, SD.SuperAdminEndUser);
                        }
                        else
                        {
                            await _userManager.AddToRoleAsync(newApplicationUser, SD.AdminEndUser);
                        }

                        ViewBag.Success = "ApplicationUser successsfully registered";
                        return View(user);
                    }

                    foreach (var error in result.Errors)
                    {
                        ViewBag.Error = error.Description;
                    }

                   
                    return View(user); ;
                }

                ViewBag.Error = "Invalid Model Data Supplied";
                return View(user); ;


            }        
            catch (Exception e)
            {
                
                ViewBag.Error = e.Message;
                return View(user);
            }
        }

        // GET: Users/Edit/5
        [Authorize(Roles = SD.SuperAdminEndUser)]
        public async Task<IActionResult> Edit(string Id)
        {
            if (Id == null || Id.Trim().Length == 0)
            {
                return NotFound();
            }
            else
            {
                var userFromDB = await _db.ApplicationUsers.FindAsync(Id);

                if (userFromDB == null)
                {
                    return NotFound();
                }

                return View(userFromDB);
            }
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string Id, ApplicationUser user, IFormFile passport)
        {

            if (Id != user.Id)
            {
                return NotFound();
            }

            if(passport != null)
            {
                //do the image upload here///////
                var dir = _env.ContentRootPath;
                string mimeType = passport.ContentType;
                long fileLength = passport.Length;
                string fileName = passport.FileName;
                string filePath = Path.Combine(dir, fileName);
                var fileBinary = " ";

                if (mimeType.Contains("image"))
                {
                    //Uploading to a folder
                    using (var filestream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        //copy to the file stream
                        passport.CopyTo(filestream);
                    }

                    //Uploading as a binary
                    using (var memoryStream = new MemoryStream())
                    {
                        //copy to the file stream
                        await passport.CopyToAsync(memoryStream);
                        fileBinary = memoryStream.ToArray().ToString();
                    }

                }
  
            }
            
            //save the filepath to db


            var applicationUser = _db.ApplicationUsers.Where(m => m.Id == Id).FirstOrDefault();

            applicationUser.FirstName = user.FirstName;
            applicationUser.LastName = user.LastName;
            applicationUser.OtherNames = user.OtherNames;
            applicationUser.Email = user.Email;

            await _db.SaveChangesAsync();
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(string Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            ApplicationUser user = await _db.ApplicationUsers.FindAsync(Id);

            if (user == null)
            {
                return NotFound();
            }

            ViewBag.Warning = "This action is irreversible";
            return View(user);
        }
      
        // POST: Users/Delete/5
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

                ApplicationUser user = await _db.ApplicationUsers.FindAsync(Id);
                _db.ApplicationUsers.Remove(user);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}