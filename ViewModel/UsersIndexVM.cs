using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TEST22.Models;

namespace TEST22.ViewModel
{
    public class UsersIndexVM
    {
        public List<UserCheck> UserChecks { get; set; }

        public UsersIndexVM()
        {
            UserChecks = new List<UserCheck>();
        }
    }
}