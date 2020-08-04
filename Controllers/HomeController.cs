using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using TEST22.Models;
using TEST22.ViewModel;

namespace TEST22.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserCheck()
        {
            return View();
        }

        public ActionResult UserResult(int? id)
        {
            try
            {
                var user = DbContext.UserChecks.FirstOrDefault(x => x.Id == id && x.IsDeleted != true);

                if (user == null)
                {
                    return View("UserCreate");
                }

                user.Counter = user.Counter + 1;
                DbContext.SaveChanges();
                var model = new UserIndex
                {
                    currentid = user.Id,
                    Name = user.Name
                };
                return View("UserResult", model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult UserCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserCreate(UserVM userVM)
        {
            var success = false;
            var message = (string)null;
            try
            {
                var usercheck = new UserCheck
                {
                    Name = userVM.Name,
                };

                DbContext.UserChecks.Add(usercheck);
                DbContext.SaveChanges();
                success = true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            if (success)
            {
                return RedirectToAction("UserReg", "Home");
            }
            return UserCheck();
        }

        public ActionResult UserReg()
        {
            return View();
        }

        public ActionResult UserList()
        {
            var users = DbContext.UserChecks.Where(x => x.IsDeleted != true).ToList();

            var model = new UsersIndexVM
            {
                UserChecks = users,

            };
            return View(model);
        }

        public bool MarkIsDeleted(int? id)
        {
            bool success;
            try
            {
                var users = DbContext.UserChecks.FirstOrDefault(x => x.Id == id);

                users.IsDeleted = true;

                DbContext.SaveChanges();

                success = true;
            }
            catch (Exception ex)
            {
                success = false;
                throw ex;
            }
            return success;
        }
    }
}