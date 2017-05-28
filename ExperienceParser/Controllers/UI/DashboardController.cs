using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ExperienceParser.Controllers.UI
{
    public class DashboardController : Controller
    {
        [AllowAnonymous]
        public ActionResult Recruiter()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Applicant()
        {
            return View();
        }
    }
}
