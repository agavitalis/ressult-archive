using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ResultArchive.Controllers
{
    public class WelcomeController : Controller
    {
        // GET: Welcome
        public ActionResult Index()
        {
            return View();
        }

     
        public RedirectResult Login()
        {
            var redirectUrl = Url.Page("/Account/Login");
            return Redirect(redirectUrl);
        }


    }
}