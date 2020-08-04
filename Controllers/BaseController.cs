using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using TEST22.Models;

namespace TEST22.Controllers
{
    public abstract class BaseController : Controller
    {
        protected ApplicationDbContext DbContext { get; }

        public BaseController()
        {
            DbContext = new ApplicationDbContext();
        }

        public IdentityUser IdentityUser
        {
            get
            {
                var result = (ApplicationUser)null;
                if (User is ClaimsPrincipal user)
                {
                    var claim = user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                    result = DbContext.Users.FirstOrDefault(x => x.Id == claim);
                }
                return result;
            }
        }
    }
}