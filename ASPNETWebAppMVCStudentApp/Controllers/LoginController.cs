using ASPNETWebAppMVCStudentApp.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNETWebAppMVCStudentApp.Controllers
{
    public class LoginController : Controller
    {
        private SchoolDB2Entities db = new SchoolDB2Entities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "UserID, Username, Password, Email")] tblUser user)
        {
            if (ModelState.IsValid)
            {
                tblUser existing = null;
                if(user.Username != string.Empty && user.Username != null)
                {
                    existing = db.tblUsers.FirstOrDefault(u => u.Username == user.Username);
                }
                else if(user.Email != null && user.Email != string.Empty)
                {
                    existing = db.tblUsers.FirstOrDefault(u => u.Email == user.Email);
                }


                if (existing != null)
                {
                    if (existing.Password == user.Password)
                    {
                        return RedirectToAction("Index","Home");
                        // return RedirectToRoute("Home/Index");
                    }
                    return View();
                }
            }

            return View();
        }
    }
}